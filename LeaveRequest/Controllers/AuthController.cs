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
using Microsoft.Data.SqlClient;
using System.Data;
using Dapper;

namespace LeaveRequest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AccountRepository accountRepository;
        private readonly IJWTAuthenticationManager jWTAuthenticationManager;
        private IConfiguration Configuration;
        public AuthController(IJWTAuthenticationManager jWTAuthenticationManager, AccountRepository accountRepository, IConfiguration configuration)
        {
            this.accountRepository = accountRepository;

            this.jWTAuthenticationManager = jWTAuthenticationManager;
            this.Configuration = configuration;
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

            /*LoginVM result1 = null;

            string connectStr = Configuration.GetConnectionString("MyConnection");
            using (IDbConnection db = new SqlConnection(connectStr))
            {
                string readSp = "sp_retrieve_login";
                var parameter = new { Email = login.Email, Password = login.Password };
                result1 = db.Query<LoginVM>(readSp, parameter, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
            HttpContext.Session.SetString("gender", result1.Gender);
            string valuegender = HttpContext.Session.GetString("gender");
*/

            //HttpContext.Session.SetString("remainingquota", response.RemainingQuota);
            //HttpContext.Session.SetString("email", response.Email);
            //HttpContext.Session.SetString("rolename", response.RoleName);

            return result;
        }
    }
}
