using LeaveRequest.Base.Controller;
using LeaveRequest.Handler;
using LeaveRequest.Models;
using LeaveRequest.Repositories.Data;
using LeaveRequest.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveRequest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseController<Account, AccountRepository, string>
    {
        private readonly AccountRepository accountRepository;

        private IConfiguration Configuration;
        private readonly IJWTAuthenticationManager jwtAuthenticationManager;
        private readonly UserRepository userRepository;

        public AccountController(AccountRepository accountRepository, UserRepository userRepository, IConfiguration configuration) : base(accountRepository)

        {
            this.accountRepository = accountRepository;
            this.userRepository = userRepository;
            this.Configuration = Configuration;
        }


        [HttpPost("Register")]
        public ActionResult Register(RegisterVM registerVM)
        {
            if (ModelState.IsValid)
            {
                var data = accountRepository.Register(registerVM);
                if (data > 0)
                {
                    return Ok(new { status = "Registration Successed..." });
                }
                else
                {
                    return StatusCode(500, new { status = "Internal server error..." });
                }
            }
            else
            {
                return BadRequest(new { status = "Bad request...", errorMessage = "Data input is not valid..." });
            }
        }

        [HttpPut("ChangePassword/{NIK}")]
        public ActionResult ChangePassword(string NIK, ChangePasswordVM changePasswordVM)
        {
            var acc = accountRepository.Get(NIK);
            if (acc != null)
            {
                if (acc.Password == changePasswordVM.OldPassword)
                {
                    var data = accountRepository.ChangePassword(NIK, changePasswordVM.NewPassword);
                    return Ok(new { message = "Password Changed", status = "Ok" });
                }
                else
                {
                    return StatusCode(404, new { status = "404", message = "Wrong password" });
                }
            }
            return NotFound();
        }

        [HttpPut("reset/{email}/{id}")]
        public ActionResult ResetPassword(Account account, string email)
        {
            var data = accountRepository.ResetPassword(account, email);
            return (data > 0) ? (ActionResult)Ok(new { message = "Email has been Sent, password changed", status = "Ok" }) : NotFound(new { message = "Data not exist in our database, please register first", status = 404 });

        }
    }
}
