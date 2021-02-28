using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveRequest.Models
{
    public class Dashboard
    {
        public string approval { get; set; }
        public int statusWaiting { get; set; }
        public int statusApprove { get; set; }
        public int statusReject { get; set; }
    }
}
