using LeaveRequest.Context;
using LeaveRequest.Handler;
using LeaveRequest.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
            string resetCode = Guid.NewGuid().ToString();
            var time24 = DateTime.Now.ToString("HH:mm:ss");

            var getuser = myContext.Users.Where(a => a.Email == email).FirstOrDefault();
            if (getuser == null)
            {
                return 0;
            }
            else
            {
                var password = Hashing.HashPassword(resetCode);
                getuser.Password = password;
                var result = myContext.SaveChanges();

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new NetworkCredential("1997HelloWorld1997@gmail.com", "wwwsawwwsdwwwszwwwsx");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                NetworkCredential nc = new NetworkCredential("1997HelloWorld1997@gmail.com", "wwwsawwwsdwwwszwwwsx");
                smtp.Credentials = nc;
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("1997HelloWorld1997@gmail.com", "Leave Request Reset Password");
                mailMessage.To.Add(new MailAddress(getuser.Email));
                mailMessage.Subject = "Reset Password " + time24;
                mailMessage.IsBodyHtml = false;
                mailMessage.Body = "Hi " + getuser.FirstName + "\nThis is new password for your account. " + resetCode + "\nThank You";
                smtp.Send(mailMessage);
                return result;
            }
        }
    }
}
