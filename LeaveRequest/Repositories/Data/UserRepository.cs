using LeaveRequest.Context;
using LeaveRequest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveRequest.Repositories.Data
{
    public class UserRepository : GeneralRepository<User, MyContext>
    {
        private readonly MyContext myContext;
        private DbSet<User> users;
        public UserRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
            myContext.Set<User>();
            users = myContext.Set<User>();
        }

        public User getByNIK(string NIK)
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
        }
    }
}
