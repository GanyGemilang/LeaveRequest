using LeaveRequest.Context;
using LeaveRequest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveRequest.Repositories.Data
{
    public class RequestHistoryRepository : GeneralRepository<RequestHistory, MyContext>
    {
        public RequestHistoryRepository(MyContext myContext) : base(myContext)
        {

        }
    }
}
