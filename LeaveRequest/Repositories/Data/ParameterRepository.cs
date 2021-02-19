using LeaveRequest.Context;
using LeaveRequest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveRequest.Repositories.Data
{
    public class ParameterRepository : GeneralRepository<Parameter, MyContext,string>
    {
        public ParameterRepository(MyContext myContext) : base(myContext)
        {

        }
    }
}
