using LeaveRequest.Context;
using LeaveRequest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveRequest.Repositories.Data
{
    public class UserRepository : GeneralRepository<User, MyContext,string>
    {
        private MyContext myContext;
        /*private readonly MyContext myContext;
        private DbSet<User> users;*/
        public UserRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
            /* this.myContext = myContext;
             myContext.Set<User>();
             users = myContext.Set<User>();*/
        }

        public User GetDataByEmail(string email)
        {
            var data = myContext.Users.Where(e => e.Email == email).FirstOrDefault();
            return data;
        }

        public int UpdateRemainingLeave(string nik, double leaveRequest)
        {
            var data = myContext.Users.Where(e => e.NIK == nik).FirstOrDefault();
   
            data.RemainingQuota = data.RemainingQuota - Convert.ToInt32(leaveRequest);
            myContext.Update(data);
            myContext.SaveChanges();
            return 1;
        }

        /*    public User getByNIK(string NIK)
            {
                var result = myContext.Users.Where(value => value.NIK == NIK).FirstOrDefault();
                return result;
            }

            public User GetPersonById(string id)
            {
                return users.Find(id);
            }

            public User GetDataByEmail(string email)
            {
                var data = myContext.Users.Where(e => e.Email == email).FirstOrDefault();
                return data;
            }*/
    }
}
