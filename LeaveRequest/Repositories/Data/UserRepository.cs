using LeaveRequest.Context;
using LeaveRequest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveRequest.Repositories.Data
{
    public class UserRepository : GeneralRepository<User, MyContext,string>
    {
        public UserRepository(MyContext myContext) : base(myContext)
        {

        }
    }
}
