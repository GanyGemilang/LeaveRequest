using LeaveRequest.Context;
using LeaveRequest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveRequest.Repositories.Data
{
    public class RequestRepository : GeneralRepository<Request, MyContext,string>
    {
        public RequestRepository(MyContext myContext) : base(myContext)
        {

        }
    }
}
