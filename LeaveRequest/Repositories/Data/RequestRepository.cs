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

            DateTime Date = DateTime.Now;
           /* var requestHis = new RequestHistory()
            {
                SubmitDate = Date,
                Status = Status.Waiting,
                UserNIK = requestVM.UserNIK,
                RequestId = request.Id
            };
            myContext.Add(requestHis);*/
            /*var resRequestHis = myContext.SaveChanges();*/

            RequestVM resultEmployee = null;
            string connectStr = Configuration.GetConnectionString("MyConnection");
            var userCondition = myContext.Users.Where(b => b.NIK == requestVM.NIK).FirstOrDefault();

            if (userCondition != null)
            {
                using (IDbConnection db = new SqlConnection(connectStr))
                {
                    string readSp = "sp_email_employee";
                    var parameter = new { NIK = requestVM.NIK  };
                    result = db.Query<RequestVM>(readSp, parameter, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }

            RequestVM resultHrd = null;
            using (IDbConnection db = new SqlConnection(connectStr))
            {
                string readSp = "sp_email_HRD";
                var parameterHrd = new { RoleId = 2 };
                resultHrd = db.Query<RequestVM>(readSp, parameterHrd, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }

            //Condition For ReasionRequest
            if (request.ReasionRequest == "Normal leave")
            {
                if (TotalDay > resultEmployee.RemainingQuota && TotalDay > 5)
                {
                    return 2;
                }
            } 
            else if(request.ReasionRequest == "Maternity leave")
            {
                if (TotalDay != 90)
                {
                    return 3;
                }
            }
            else if (request.ReasionRequest == "Married")
            {
                if (TotalDay != 3)
                {
                    return 4;
                }
            }
            else if (request.ReasionRequest == "Marry or Circumcise or Baptize Children" || 
                request.ReasionRequest == "Wife gave birth or had a miscarriage" || 
                request.ReasionRequest == "Husband or Wife Parents or In laws Children or Son In law have passed away")
            {
                if (TotalDay != 2)
                {
                    return 5;
                }

            }
            else if (request.ReasionRequest == "Family member in one house died")
            {
                if (TotalDay != 1)
                {
                    return 6;
                }
            }
            //End Condition For ReasionRequest

            var resRequest = myContext.SaveChanges();
            if (resRequest > 0 && resRequestHis > 0)
            {
                sendEmail.SendRequestEmployee(resultEmployee.Email);
                sendEmail.SendRequestHRD(resultHrd.Email);
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
            if (data.Status == Status.RejectByHRD || data.Status ==Status.RejectByManager)
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
            }
            else if (data.Status == Status.ApprovedByHRD && dataUser.Role.Name == "Manager")
            {
                var TotalDay = (data.EndDate - data.StartDate).TotalDays;
                userRepository.UpdateRemainingLeave(data.NIK, TotalDay);
                data.Status = Status.ApprovedByManager;
                data.ApprovedManager = dataUser.NIK;
                myContext.Update(data);
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
