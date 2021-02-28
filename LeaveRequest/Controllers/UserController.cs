using LeaveRequest.Base.Controller;
using LeaveRequest.Handler;
using LeaveRequest.Models;
using LeaveRequest.Repositories.Data;
using LeaveRequest.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveRequest.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController<User, UserRepository,string>
    {
        private readonly UserRepository userRepository;
        public UserController(UserRepository userRepository) : base(userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpPut("SubmitAdminRole")]
        public ActionResult SubmitAdminRole(RegisterVM registerVM)
        {
            var data = userRepository.AdminRole(registerVM);
            if (data == 1)
            {
                return Ok(new { status = "Approved success" });
            }
            else
            {
                return StatusCode(500, new { status = "Internal Server Error" });
            }

        }
    }
}
