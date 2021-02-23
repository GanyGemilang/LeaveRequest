using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveRequest.ViewModels
{
    public class ApproveRequestVM
    {
        public int IdRequest { get; set; }
        public string Email { get; set; }
        public Boolean IsApproved { get; set; } 
    }
}
