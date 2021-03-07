using LeaveRequest.Context;
using LeaveRequest.Models;
using LeaveRequest.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WebLeaveRequest.Controllers
{
    public class DashboardController : Controller
    {
   /*     public IConfiguration Configuration { get; }
        public DashboardController(IConfiguration configuration)
        {
            Configuration = configuration;
        }*/
        /*private MyContext myContext = new MyContext();*/
        public IActionResult Index()
        {
         /*   string query = "SELECT usr.Email, req.Id FROM TB_M_Request";
            string constr = Configuration["ConnectionStrings:DefaultConnection"];
            List<Request> chartData = new List<Request>();

            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            chartData.Add(new Request
                            {
                                ReasonRequest = Convert.ToString(sdr["Reason_Request"]),
                                Id = Convert.ToInt32(sdr["Id_Request"])
                            });
                        }
                    }
                    con.Close();
                }
            }*/
            /* DashboardViewModel dashboard = new DashboardViewModel();

             dashboard.waiting_count = dashboard.waiting_count.Count();
             dashboard.approve_count = dashboard.approve_count.Count();
             dashboard.reject_count = dashboard.reject_count.Count();
             return View(dashboard);*/
            ViewData["NIKValue"] = HttpContext.Session.GetString("nik");
            string viewdata = HttpContext.Session.GetString("nik");
            ViewData["GenderValue"] = HttpContext.Session.GetString("gender");
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
