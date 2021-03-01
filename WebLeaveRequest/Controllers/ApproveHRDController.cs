using LeaveRequest.ViewModels;
using Microsoft.AspNetCore.Authorization;
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
    public class ApproveHRDController : Controller
    {
        //[Authorize(Roles = "HRD,Manager")]
        public IActionResult Index()
        {
            return View();
            /*if (HttpContext.Session.GetString("email") != null)
            {
                return View();
            }
            return RedirectToAction("index", "Home");*/

        }

        [HttpGet]
        public String Get(int id)
        {
            var httpClient = new HttpClient();
            var response = httpClient.GetAsync("https://localhost:44330/api/request/" + id).Result;
            var apiResponse = response.Content.ReadAsStringAsync();
            return apiResponse.Result;
        }
        [HttpPut]
        public HttpStatusCode ApproveHRD(ApproveRequestVM approveRequestVM)
        {
            var httpClient = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(approveRequestVM), Encoding.UTF8, "application/json");
            var result = httpClient.PutAsync("https://localhost:44330/api/request/SubmitApprovedHRD", content).Result;
            return result.StatusCode;
        }

        [HttpPut]
        public HttpStatusCode RejectHRD(ApproveRequestVM approveRequestVM)
        {
            var httpClient = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(approveRequestVM), Encoding.UTF8, "application/json");
            var result = httpClient.PutAsync("https://localhost:44330/api/request/SubmitRejectHRD", content).Result;
            return result.StatusCode;
        }
    }
}
