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
    public class RoleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public String Get(int id)
        {
            var httpClient = new HttpClient();
            var response = httpClient.GetAsync("https://localhost:44361/api/Role/" + id).Result;
            var apiResponse = response.Content.ReadAsStringAsync();
            return apiResponse.Result;
        }

        [HttpPost]
        public HttpStatusCode Create(RoleVM roleVM)
        {
            var httpClient = new HttpClient();

            StringContent content = new StringContent(JsonConvert.SerializeObject(roleVM), Encoding.UTF8, "application/json");
            var result = httpClient.PostAsync("https://localhost:44361/api/Role/", content).Result;
            return result.StatusCode;
        }

        [HttpDelete]
        public HttpStatusCode Delete(int Id)
        {
            var httpClient = new HttpClient();
            var response = httpClient.DeleteAsync("https://localhost:44361/api/Role/" + Id).Result;
            return response.StatusCode;
        }

        [HttpPut]
        public HttpStatusCode Update(RoleVM roleVM)
        {
            var httpClient = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(roleVM), Encoding.UTF8, "application/json");
            var result = httpClient.PutAsync("https://localhost:44361/api/Role/", content).Result;
            return result.StatusCode;
        }
    }
}
