using Dapper;
using LeaveRequest.Context;
using LeaveRequest.Handler;
using LeaveRequest.Models;
using LeaveRequest.ModelViews;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
                Gender = Gender.Male,
                MarriedStatus = Married.Single,
                Position = Position.ApplicationDeveloper,
                Address = registerVM.Address,
                Phone = registerVM.Phone,
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
