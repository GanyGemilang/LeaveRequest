using LeaveRequest.ViewModels;
using Microsoft.AspNetCore.Mvc;
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
    public class ChangePasswordController : Controller
    {
        public IActionResult Index()
        {
            return View();
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
