﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveRequest.ViewModels
{
    public class ChangePasswordVM
    {
        [Required(ErrorMessage = "Tidak boleh kosong")]
        public string OldPassword { get; set; }
        [Required(ErrorMessage = "Tidak boleh kosong")]
        public string NewPassword { get; set; }

        [Compare("NewPassword"), Required]
        public string ConfirmPassword { get; set; }
    }
}
