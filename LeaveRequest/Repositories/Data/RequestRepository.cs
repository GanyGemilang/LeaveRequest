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
        private readonly RequestRepository requestRepository;
        private readonly RequestHistoryRepository requestHistoryRepository;
        private readonly SendEmail sendEmail = new SendEmail();
        private readonly MyContext myContext;

        public IConfiguration Configuration { get; }
        public RequestRepository(MyContext myContext, IConfiguration configuration) : base(myContext)
        {
            this.requestRepository = requestRepository;
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

            RequestVM result = null;

            string connectStr = Configuration.GetConnectionString("MyConnection");
            var userCondition = myContext.Users.Where(b => b.NIK == requestVM.UserNIK).FirstOrDefault();

            if (userCondition != null)
            {

                using (IDbConnection db = new SqlConnection(connectStr))
                {
                    string readSp = "sp_email_employee";
                    var parameter = new { NIK = requestVM.UserNIK  };
                    result = db.Query<RequestVM>(readSp, parameter, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }

            if(TotalDay <= result.RemainingQuota)
            {
                if (resRequest > 0 && resRequestHis > 0)
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
    }
}
