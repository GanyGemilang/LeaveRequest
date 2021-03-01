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
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            /* if (HttpContext.Session.GetString("email") != null)
             {
                 return View();
             }
             return RedirectToAction("index", "Home");*/
            return View();
        }

        [HttpGet]
        public String Get(int id)
        {
            var httpClient = new HttpClient();
            var response = httpClient.GetAsync("https://localhost:44330/api/User/" + id).Result;
            var apiResponse = response.Content.ReadAsStringAsync();
            return apiResponse.Result;
        }

        [HttpPut]
        public HttpStatusCode Update(RegisterVM registerVM)
        {
            var httpClient = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(registerVM), Encoding.UTF8, "application/json");
            var result = httpClient.PutAsync("https://localhost:44330/api/User/SubmitAdminRole/", content).Result;
            return result.StatusCode;
        }
    }
}
