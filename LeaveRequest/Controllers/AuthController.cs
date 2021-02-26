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
using Microsoft.Extensions.Configuration;

namespace LeaveRequest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IJWTAuthenticationManager jWTAuthenticationManager;
        private readonly AccountRepository accountRepository;
        private IConfiguration iconfiguration;

        public AuthController(IJWTAuthenticationManager jWTAuthenticationManager, AccountRepository accountRepository, IConfiguration iconfiguration)
        {
            this.jWTAuthenticationManager = jWTAuthenticationManager;
            this.accountRepository = accountRepository;
            this.iconfiguration = iconfiguration;
        }

        /*[AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] LoginVM loginVM)
        {
            var token = jWTAuthenticationManager.Generate(Login(loginVM));
            if (token == null)
                return Unauthorized();
            return Ok(token);
        }*/

        [HttpPost("Login")]
        public LoginResponseVM Login([FromBody] LoginVM login)
        {
            var response = accountRepository.Login(login.Email, login.Password);
            var token = jWTAuthenticationManager.Generate(response);
            LoginResponseVM result = new LoginResponseVM();
            result.Token = token;
            result.Role = response.Role;
            result.Email = response.Email;
            return result;
        }
    }
}
