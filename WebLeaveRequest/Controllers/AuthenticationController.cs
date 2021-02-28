using LeaveRequest.Context;
using LeaveRequest.Models;
using LeaveRequest.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public String Login(LoginVM loginVM)
        {
            var httpclient = new HttpClient();
            StringContent stringContent = new StringContent(JsonConvert.SerializeObject(loginVM), Encoding.UTF8, "application/json");
            var result = httpclient.PostAsync("https://localhost:44330/api/auth/authenticate/", stringContent).Result;
            return result.StatusCode;

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
            var result = httpClient.PutAsync("https://localhost:44330/api/Account/Reset/", content).Result;
            return result.StatusCode;
        }

        [HttpPut]
        public HttpStatusCode ChangePassword(ChangePasswordVM changePasswordViewModels)
        {
            var httpClient = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(changePasswordViewModels), Encoding.UTF8, "application/json");
            var result = httpClient.PutAsync("https://localhost:44330/api/Account/ChangePassword/", content).Result;
            return result.StatusCode;
        }
    }
}
