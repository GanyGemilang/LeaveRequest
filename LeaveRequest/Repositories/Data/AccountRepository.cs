using Dapper;
using LeaveRequest.Context;
using LeaveRequest.Handler;
using LeaveRequest.Models;
using LeaveRequest.ViewModels;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;

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
            acc.Password = Hashing.HashPassword(password);
            myContext.Entry(acc).State = EntityState.Modified;
            var result = myContext.SaveChanges();
            return result;
        }

        public LoginVM Login(string email, string password)
        {
            LoginVM result = null;

            string connectStr = Configuration.GetConnectionString("MyConnection");
            var userCondition = myContext.Users.Where(a => a.Email == email).FirstOrDefault();

            if (userCondition != null)
            {
                if (Hashing.ValidatePassword(password, userCondition.Account.Password))
                {
                    using (IDbConnection db = new SqlConnection(connectStr))
                    {
                        string readSp = "sp_retrieve_login";
                        var parameter = new { Email = email, Password = password };
                        result = db.Query<LoginVM>(readSp, parameter, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    }
                }
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
                Email = registerVM.Email,
                RoleId = registerVM.RoleId
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

            var getuser = myContext.Users.Include(u => u.Account).Where(a => a.Email == email).FirstOrDefault();
            var userAccount = myContext.Accounts.Where(a=>a.NIK == getuser.NIK).FirstOrDefault();
            if (getuser == null)
            {
                return 0;
            }
            else
            {
                var password = Hashing.HashPassword(resetCode);
                //account.Password = password;
                userAccount.Password= password;
                var result = myContext.SaveChanges();
                sendEmail.SendForgotPassword(resetCode, email);
                return result;
            }
        }
    }
}
