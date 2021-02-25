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
    public class ApproveController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPut]
        public HttpStatusCode Approve(ApproveRequestVM approveRequestVM)
        {
            var httpClient = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(approveRequestVM), Encoding.UTF8, "application/json");
            var result = httpClient.PutAsync("https://localhost:44330/api/request/SubmitApproved/", content).Result;
            return result.StatusCode;
        }

        [HttpPut]
        public HttpStatusCode Reject(ApproveRequestVM approveRequestVM)
        {
            var httpClient = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(approveRequestVM), Encoding.UTF8, "application/json");
            var result = httpClient.PutAsync("https://localhost:44330/api/request/SubmitReject/", content).Result;
            return result.StatusCode;
        }
    }
}
