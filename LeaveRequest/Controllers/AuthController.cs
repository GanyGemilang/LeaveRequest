using LeaveRequest.Handler;
using LeaveRequest.ViewModels;
using LeaveRequest.Repositories.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeaveRequest.Context;

namespace LeaveRequest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AccountRepository accountRepository;
        private readonly IJWTAuthenticationManager jWTAuthenticationManager;
       

        public AuthController(IJWTAuthenticationManager jWTAuthenticationManager, AccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
            this.jWTAuthenticationManager = jWTAuthenticationManager;
        }

        [HttpPost("Login")]
        public LoginVM Login([FromBody] LoginVM loginVM)
        {
            var user = accountRepository.Login(loginVM.Email, loginVM.Password);
            return user;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate(LoginVM loginVM)
        {
            var token = jWTAuthenticationManager.Generate(Login(loginVM));
            if (token == null)
                return Unauthorized();
            return Ok(token);
        }       
    }
}
