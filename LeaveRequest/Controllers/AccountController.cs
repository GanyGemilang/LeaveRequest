using LeaveRequest.Base.Controller;
using LeaveRequest.Handler;
using LeaveRequest.Models;
using LeaveRequest.ModelViews;
using LeaveRequest.Repositories.Data;
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
    public class AccountController : BaseController<Account, AccountRepository>
    {
        private readonly AccountRepository accountRepository;
        private IConfiguration configuration;
        private readonly IJWTAuthenticationManager jwtAuthenticationManager;

        public AccountController(AccountRepository accountRepository, IConfiguration configuration) : base(accountRepository)
        {
            this.accountRepository = accountRepository;
            this.configuration = configuration;
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
    }
}
