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
using Microsoft.AspNetCore.Http;

namespace LeaveRequest.Controllers
{  
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AccountRepository accountRepository;
        private readonly IJWTAuthenticationManager jWTAuthenticationManager;
        private IConfiguration iconfiguration;
        public AuthController(IJWTAuthenticationManager jWTAuthenticationManager, AccountRepository accountRepository, IConfiguration iconfiguration)
        {
            this.accountRepository = accountRepository;

            this.jWTAuthenticationManager = jWTAuthenticationManager;
        }
/*
        [HttpPost("Login")]
        public LoginVM Login([FromBody] LoginVM loginVM)
        {
            var user = accountRepository.Login(loginVM.Email, loginVM.Password);
            return user;
            this.iconfiguration = iconfiguration;
        }*/

        /*[AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate(LoginVM loginVM)
        {
            var token = jWTAuthenticationManager.Generate(Login(loginVM));
            if (token == null)
                return Unauthorized();
            return Ok(token);
        }       
        }*/

        [HttpPost("Login")]
        public LoginResponseVM Login([FromBody] LoginVM login)
        {
            var response = accountRepository.Login(login.Email, login.Password);
            var token = jWTAuthenticationManager.Generate(response);
            LoginResponseVM result = new LoginResponseVM();
            result.Token = token;
            result.Role = response.Role;
            result.Email = response.NIK;

            HttpContext.Session.SetString("nik", response.NIK);
            string valuenik = HttpContext.Session.GetString("nik");
            //HttpContext.Session.SetString("name", response.Name);
            //HttpContext.Session.SetString("email", response.Email);
            //HttpContext.Session.SetString("rolename", response.RoleName);

            return result;
        }
    }
}
