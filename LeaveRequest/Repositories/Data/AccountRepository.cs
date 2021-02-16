using LeaveRequest.Context;
using LeaveRequest.Handler;
using LeaveRequest.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveRequest.Repositories.Data
{
    public class AccountRepository : GeneralRepository<Account, MyContext, string>
    {
        private readonly MyContext myContext;
        private DbSet<Account> accounts;
        private readonly SendEmail sendEmail = new SendEmail();
        private readonly UserRepository userRepository;
        public IConfiguration Configuration { get; }
        public AccountRepository(MyContext myContext, UserRepository userRepository, IConfiguration configuration) : base(myContext)
        {
            myContext.Set<Account>();
            this.myContext = myContext;
            this.userRepository = userRepository;
            this.Configuration = configuration;
        }
        public int ResetPassword(Account account, string email)
        {
            var data = myContext.Users.Where(x => x.Email == email).FirstOrDefault();
            if (data == null)
            {
                return 0;
            }
            else
            {
                myContext.Entry(account).State = EntityState.Modified;
                var result = myContext.SaveChanges();
                sendEmail.Send(email);
                return result;
            }
        }
    }
}
