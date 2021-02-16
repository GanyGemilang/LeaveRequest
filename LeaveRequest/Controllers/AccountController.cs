using LeaveRequest.Base.Controller;
using LeaveRequest.Models;
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
    public class AccountController : BaseController<Account, AccountRepository,string>
    {
        private readonly AccountRepository accountRepository;

        private IConfiguration Configuration;
        public AccountController(AccountRepository accountRepository, IConfiguration configuration) : base(accountRepository)
        {
            this.accountRepository = accountRepository;
            this.Configuration = Configuration;
        }
        [HttpPut("reset/{email}/{id}")]
        public ActionResult ResetPassword(Account account, string email)
        {
            var data = accountRepository.ResetPassword(account, email);
            return (data > 0) ? (ActionResult)Ok(new { message = "Email has been Sent, password changed", status = "Ok" }) : NotFound(new { message = "Data not exist in our database, please register first", status = 404 });
        }
    }
}
