using Dapper;
using LeaveRequest.Context;
using LeaveRequest.Handler;
using LeaveRequest.Models;
using LeaveRequest.ViewModels;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace LeaveRequest.Repositories.Data
{
    public class AccountRepository : GeneralRepository<Account, MyContext, string>
    {
        private DbSet<Account> accounts;
        private readonly MyContext myContext;
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

        public int ChangePassword(string NIK, string password)
        {
            Account acc = myContext.Accounts.Where(a => a.NIK == NIK).FirstOrDefault();
            acc.Password = password;
            myContext.Entry(acc).State = EntityState.Modified;
            var result = myContext.SaveChanges();
            return result;
        }

        public LoginVM Login(string email, string password)
        {
            LoginVM result = null;

            string connectStr = Configuration.GetConnectionString("MyConnection");

            using (IDbConnection db = new SqlConnection(connectStr))
            {
                string readSp = "sp_retrieve_login";
                var parameter = new { Email = email, Password = password };
                result = db.Query<LoginVM>(readSp, parameter, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
            return result;
        }

        public int Register(RegisterVM registerVM)
        {

            var user = new User()
            {
                NIK = registerVM.NIK,
                FirstName = registerVM.FirstName,
                LastName = registerVM.LastName,
                Password = Hashing.HashPassword("B0o7c@mp"),
                BirthDate = registerVM.BirthDate,
                Gender = registerVM.Gender,
                MarriedStatus = registerVM.MarriedStatus,
                Position = registerVM.Position,
                Address = registerVM.Address,
                PhoneNumber = registerVM.PhoneNumber,
                RemainingQuota = registerVM.RemainingQuota,
                Email = registerVM.Email
            };

            var account = new Account()
            {
                NIK = registerVM.NIK,
                Password = Hashing.HashPassword("B0o7c@mp")
            };

            var resUser = userRepository.Create(user);

            myContext.Add(account);

            var resAccount = myContext.SaveChanges();

            if (resAccount > 0 && resUser > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
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
                //var password = resetCode;
                var accounts = new Account()
                {
                    NIK = account.NIK,
                    Password = password
                };
                myContext.Entry(accounts).State = EntityState.Modified;
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
