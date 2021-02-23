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

            RequestVM result = null;

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

            if(TotalDay <= result.RemainingQuota)
            {
                var resRequest = myContext.SaveChanges();
                if (resRequest > 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
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
