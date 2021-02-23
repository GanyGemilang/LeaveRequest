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
        private readonly RequestHistoryRepository requestHistoryRepository;
        private readonly SendEmail sendEmail = new SendEmail();
        private readonly MyContext myContext;

        public IConfiguration Configuration { get; }
        public RequestRepository(MyContext myContext, IConfiguration configuration) : base(myContext)
        {
            this.requestHistoryRepository = requestHistoryRepository;
            this.Configuration = configuration;
            this.myContext = myContext;
        }

        public int Request(RequestVM requestVM)
        {
            var TotalDay = (requestVM.EndDate - requestVM.StartDate).TotalDays;
            var request = new Request()
            {
                ReasionRequest = requestVM.ReasionRequest,
                StartDate = requestVM.StartDate,
                EndDate = requestVM.EndDate,
                Notes = requestVM.Notes,
                UploadProof = requestVM.UploadProof
            };

            myContext.Add(request);
            var resRequest = myContext.SaveChanges();

            DateTime Date = DateTime.Now;
            var requestHis = new RequestHistory()
            {
                SubmitDate = Date,
                Status = Status.Waiting,
                UserNIK = requestVM.UserNIK,
                RequestId = request.Id
            };
            myContext.Add(requestHis);
            var resRequestHis = myContext.SaveChanges();

            RequestVM resultEmployee = null;
            string connectStr = Configuration.GetConnectionString("MyConnection");
            var userCondition = myContext.Users.Where(b => b.NIK == requestVM.UserNIK).FirstOrDefault();

            if (userCondition != null)
            {

                using (IDbConnection db = new SqlConnection(connectStr))
                {
                    string readSp = "sp_email_employee";
                    var parameterEmployee = new { NIK = requestVM.UserNIK  };
                    resultEmployee = db.Query<RequestVM>(readSp, parameterEmployee, commandType: CommandType.StoredProcedure).FirstOrDefault();
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
    }
}
