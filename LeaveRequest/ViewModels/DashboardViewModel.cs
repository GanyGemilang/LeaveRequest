using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveRequest.ViewModels
{
    public class DashboardViewModel
    {
        public int waiting_count { get; set; }
        public int approve_count { get; set; }
        public int reject_count { get; set; }
    }
}
