using LeaveRequest.ViewModels;
using Microsoft.AspNetCore.Http;
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
    public class ApproveManagerController : Controller
    {
        public IActionResult Index()
        {
            return View();
            /*if (HttpContext.Session.GetString("email") != null)
            {
                return View();
            }
            return RedirectToAction("index", "Home");*/

        }

        [HttpPut]
        public HttpStatusCode ApproveManager(ApproveRequestVM approveRequestVM)
        {
            var httpClient = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(approveRequestVM), Encoding.UTF8, "application/json");
            var result = httpClient.PutAsync("https://localhost:44330/api/request/SubmitApprovedManager", content).Result;
            return result.StatusCode;
        }

        [HttpPut]
        public HttpStatusCode RejectManager(ApproveRequestVM approveRequestVM)
        {
            var httpClient = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(approveRequestVM), Encoding.UTF8, "application/json");
            var result = httpClient.PutAsync("https://localhost:44330/api/request/SubmitRejectManager", content).Result;
            return result.StatusCode;
        }
    }
}
