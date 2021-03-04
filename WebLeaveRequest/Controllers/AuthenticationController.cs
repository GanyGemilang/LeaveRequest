using Dapper;
using LeaveRequest.Context;
using LeaveRequest.Models;
using LeaveRequest.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WebLeaveRequest.Controllers
{
    //[Authorize(Roles = "Administrator")]
    public class AuthenticationController : Controller
    {
        private MyContext myContext = new MyContext();
        private IConfiguration Configuration;
        public IActionResult Index()
        {
            return View();
        }

        public AuthenticationController(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        [HttpPost]
        public String Login(LoginVM loginVM)
        {
            LoginVM result1 = null;

            string connectStr = Configuration.GetConnectionString("MyConnection");
            using (IDbConnection db = new SqlConnection(connectStr))
            {
                string readSp = "sp_retrieve_login";
                var parameter = new { Email = loginVM.Email, Password = loginVM.Password };
                result1 = db.Query<LoginVM>(readSp, parameter, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
            HttpContext.Session.SetString("remainingquota", result1.RemainingQuota);
            HttpContext.Session.SetString("gender", result1.Gender);
            string valuegender = HttpContext.Session.GetString("gender");

            var httpclient = new HttpClient();
            StringContent stringContent = new StringContent(JsonConvert.SerializeObject(loginVM), Encoding.UTF8, "application/json");
           /* var result = httpclient.PostAsync("https://localhost:44330/api/auth/authenticate/", stringContent).Result;
            return result.StatusCode;*/

            var result = httpclient.PostAsync("https://localhost:44330/api/Auth/Login/", stringContent).Result;
            return result.Content.ReadAsStringAsync().Result;
        }

        [HttpPost]
        public HttpStatusCode Register(RegisterVM registerVM)
        {
            var httpClient = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(registerVM), Encoding.UTF8, "application/json");
            var result = httpClient.PostAsync("https://localhost:44330/api/account/register/", content).Result;
            return result.StatusCode;
        }

        [HttpPut]
        public HttpStatusCode ForgotPassword(RegisterVM registerVM)
        {
            var httpClient = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(registerVM), Encoding.UTF8, "application/json");
            var result = httpClient.PutAsync("https://localhost:44330/api/Account/reset/", content).Result;
            return result.StatusCode;
        }

        [HttpPut]
        public HttpStatusCode ChangePassword(ChangePasswordVM changePasswordViewModels)
        {
            var httpClient = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(changePasswordViewModels), Encoding.UTF8, "application/json");
            var result = httpClient.PutAsync("https://localhost:44330/api/Account/ChangePassword/" + changePasswordViewModels.NIK, content).Result;
            return result.StatusCode;
        }
    }
}
