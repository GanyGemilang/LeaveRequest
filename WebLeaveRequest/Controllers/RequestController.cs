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
    public class RequestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult requestAction()
        {
            return View();
        }

        public IActionResult requestHistory()
        {
            return View();
        }

        [HttpGet]
        public String Get(int id)
        {
            var httpClient = new HttpClient();
            var response = httpClient.GetAsync("https://localhost:44330/api/request/" + id)
                .Result;
            var apiResponse = response.Content.ReadAsStringAsync();
            return apiResponse.Result;
        }

        [HttpPost]
        public HttpStatusCode SubmitRequest(RequestVM requestVM)
        {
            var httpClient = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(requestVM), Encoding.UTF8, "application/json");
            var result = httpClient.PostAsync("https://localhost:44330/api/request/SubmitRequest/", content).Result;
            return result.StatusCode;
        }
    }
}
