using LeaveRequest.Context;
using LeaveRequest.Models;
using LeaveRequest.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebLeaveRequest.Controllers
{
    public class DashboardController : Controller
    {
        /*private MyContext myContext = new MyContext();*/
        public IActionResult Index()
        {
            /* DashboardViewModel dashboard = new DashboardViewModel();

             dashboard.waiting_count = dashboard.waiting_count.Count();
             dashboard.approve_count = dashboard.approve_count.Count();
             dashboard.reject_count = dashboard.reject_count.Count();
             return View(dashboard);*/
            ViewData["NIKValue"] = HttpContext.Session.GetString("nik");
            string viewdata = HttpContext.Session.GetString("nik");
            return View();
        }

        [HttpGet("/Logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("index", "Home");
        }
    }
}
