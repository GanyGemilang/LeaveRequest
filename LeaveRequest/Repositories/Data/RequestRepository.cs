using Dapper;
using LeaveRequest.Context;
using LeaveRequest.Handler;
using LeaveRequest.Models;
using LeaveRequest.ViewModels;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveRequest.Repositories.Data
{
    public class RequestRepository : GeneralRepository<Request, MyContext, int>
    {
        private readonly SendEmail sendEmail = new SendEmail();
        private MyContext myContext;
        private readonly UserRepository userRepository;

        public IConfiguration Configuration { get; }
        public RequestRepository(MyContext myContext, IConfiguration configuration, UserRepository userRepository) : base(myContext)
        {
            this.Configuration = configuration;
            this.myContext = myContext;
            this.userRepository = userRepository;
        }

        public int Request(RequestVM requestVM)
        {
            var TotalDay = (requestVM.EndDate - requestVM.StartDate).TotalDays;
            var request = new Request()
            {
                NIK = requestVM.NIK,
                StartDate = requestVM.StartDate,
                ReasonRequest = requestVM.ReasonRequest,
                EndDate = requestVM.EndDate,
                Notes = requestVM.Notes,
                UploadProof = requestVM.UploadProof,
                Status = Status.Waiting
            };

            myContext.Add(request);
            var resRequest = myContext.SaveChanges();

            //DateTime Date = DateTime.Now;
            /* var requestHis = new RequestHistory()
             {
                 SubmitDate = Date,
                 Status = Status.Waiting,
                 UserNIK = requestVM.UserNIK,
                 RequestId = request.Id
             };
             myContext.Add(requestHis);*/
            /*var resRequestHis = myContext.SaveChanges();*/

            RequestVM result = null;
            string connectStr = Configuration.GetConnectionString("MyConnection");
            var userCondition = myContext.Users.Where(b => b.NIK == requestVM.NIK).FirstOrDefault();

            if (userCondition != null)
            {
                using (IDbConnection db = new SqlConnection(connectStr))
                {
                    string readSp = "sp_email_employee";
                    var parameter = new { NIK = requestVM.NIK };
                    result = db.Query<RequestVM>(readSp, parameter, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }

            RequestVM result1 = null;
            string connectStr1 = Configuration.GetConnectionString("MyConnection");
            var userCondition1 = myContext.Users.Where(b => b.NIK == requestVM.NIK).FirstOrDefault();

            if (userCondition1 != null)
            {
                using (IDbConnection db = new SqlConnection(connectStr1))
                {
                    string readSp = "sp_email_HRD";
                    var parameter1 = new { RoleId = 2 };
                    result1 = db.Query<RequestVM>(readSp, parameter1, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }

            //Condition For ReasionRequest
            if (requestVM.ReasonRequest == "Normal leave")
            {
                if (TotalDay > result.RemainingQuota && TotalDay > 5)
                {
                    return 2;
                }
            }
            else if (requestVM.ReasonRequest == "Maternity leave")
            {
                if (TotalDay != 90)
                {
                    return 3;
                }
            }
            else if (requestVM.ReasonRequest == "Married")
            {
                if (TotalDay != 3)
                {
                    return 4;
                }
            }
            else if (requestVM.ReasonRequest == "Marry or Circumcise or Baptize Children" ||
                requestVM.ReasonRequest == "Wife gave birth or had a miscarriage" ||
                requestVM.ReasonRequest == "Husband or Wife Parents or In laws Children or Son In law have passed away")
            {
                if (TotalDay != 2)
                {
                    return 5;
                }

            }
            else if (requestVM.ReasonRequest == "Family member in one house died")
            {
                if (TotalDay != 1)
                {
                    return 6;
                }
            }
            //End Condition For ReasionRequest


            if (resRequest > 0)
            {
                sendEmail.SendRequestEmployee(result.Email);
                sendEmail.SendRequestHRD(result1.Email);
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int Approved(ApproveRequestVM input)
        {
            var data = myContext.Requests.Where(e => e.Id == input.IdRequest).FirstOrDefault();
            if (data == null)
            {
                return 0;
            }
            if (data.Status == Status.ApprovedByManager)
            {
                return 0;
            }
            if (data.Status == Status.RejectByHRD || data.Status == Status.RejectByManager)
            {
                return 0;
            }

            User dataUser = userRepository.GetDataByEmail(input.Email);
            if (dataUser == null)
            {
                return 0;
            }
            if (data.NIK == dataUser.NIK || (data.ApprovedHRD != null && data.ApprovedHRD == dataUser.NIK)) //biar tidak bisa mengapproved data diri sendiri 
            {
                return 0;
            }
            if (data.Status == Status.Waiting && dataUser.Role.Name == "HRD")
            {
                data.Status = Status.ApprovedByHRD;
                data.ApprovedHRD = dataUser.NIK;
                myContext.Update(data);

                RequestVM result2 = null;
                string connectStr2 = Configuration.GetConnectionString("MyConnection");
                using (IDbConnection db = new SqlConnection(connectStr2))
                {
                    string readSp = "sp_email_HRD";
                    var parameter2 = new { RoleId = 3 };
                    result2 = db.Query<RequestVM>(readSp, parameter2, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
                sendEmail.SendAproveHRD(result2.Email,input.IdRequest);
            }
            else if (data.Status == Status.ApprovedByHRD && dataUser.Role.Name == "Manager")
            {
                var TotalDay = (data.EndDate - data.StartDate).TotalDays;
                userRepository.UpdateRemainingLeave(data.NIK, TotalDay);
                data.Status = Status.ApprovedByManager;
                data.ApprovedManager = dataUser.NIK;


                /*ApproveRequestVM result3 = null;
                string connectStr3 = Configuration.GetConnectionString("MyConnection");
                var userCondition3 = myContext.Requests.Where(b => b.Id == input.IdRequest).FirstOrDefault();
                if (userCondition3 != null)
                {
                    using (IDbConnection db = new SqlConnection(connectStr3))
                    {
                        string readSp = "sp_email_approveManager";
                        var parameter3 = new { IdRequest = input.IdRequest };
                        result3 = db.Query<ApproveRequestVM>(readSp, parameter3, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    }
                }
                sendEmail.SendAproveManager(result3.Email, input.IdRequest);*/
                myContext.Update(data);
            }
            else
            {
                return 0;
            }
            myContext.SaveChanges();
            return 1;
        }

        public int Reject(ApproveRequestVM input)
        {
            var data = myContext.Requests.Where(e => e.Id == input.IdRequest).FirstOrDefault();
            if (data == null)
            {
                return 0;
            }
            if (data.Status == Status.ApprovedByManager)
            {
                return 0;
            }
            if (data.Status == Status.RejectByHRD || data.Status == Status.RejectByManager)
            {
                return 0;
            }

            User dataUser = userRepository.GetDataByEmail(input.Email);
            if (dataUser == null)
            {
                return 0;
            }
            if (data.NIK == dataUser.NIK || (data.ApprovedHRD != null && data.ApprovedHRD == dataUser.NIK)) //biar tidak bisa mengapproved data diri sendiri 
            {
                return 0;
            }
            if (data.Status == Status.Waiting && dataUser.Role.Name == "HRD")
            {
                data.Status = Status.RejectByManager;
                data.ApprovedHRD = dataUser.NIK;
                data.ApprovedManager = dataUser.NIK;
                myContext.Update(data);

                /*RequestVM result2 = null;
                string connectStr2 = Configuration.GetConnectionString("MyConnection");
                using (IDbConnection db = new SqlConnection(connectStr2))
                {
                    string readSp = "sp_email_HRD";
                    var parameter2 = new { RoleId = 3 };
                    result2 = db.Query<RequestVM>(readSp, parameter2, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
                sendEmail.SendAproveHRD(result2.Email, input.IdRequest);*/
            }
            else if (data.Status == Status.ApprovedByHRD && dataUser.Role.Name == "Manager")
            {
                data.Status = Status.RejectByManager;
                data.ApprovedManager = dataUser.NIK;
                myContext.Update(data);

                /*RequestVM result3 = null;
                string connectStr3 = Configuration.GetConnectionString("MyConnection");
                var userCondition3 = myContext.Requests.Where(b => b.Id == input.IdRequest).FirstOrDefault();
                if (userCondition3 != null)
                {
                    using (IDbConnection db = new SqlConnection(connectStr3))
                    {
                        string readSp = "sp_email_approveManager";
                        var parameter3 = new { IdRequest = input.IdRequest };
                        result3 = db.Query<RequestVM>(readSp, parameter3, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    }
                }
                sendEmail.SendAproveManager(result3.Email, input.IdRequest);*/

            }
            else
            {
                return 0;
            }
            myContext.SaveChanges();
            return 1;
        }


    }
}
