using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveRequest.ViewModels
{
    public class RequestVM
    {
        public int Id { get; set; }
        /*[Required(ErrorMessage = "Tidak boleh kosong"), MaxLength(20, ErrorMessage = "Maksimal 20 karakter"), RegularExpression(@"^\D+$", ErrorMessage = "Tidak boleh berupa angka")]
        public string ManagerName { get; set; }*/
        [Required(ErrorMessage = "Tidak boleh kosong")]
        public string ReasonRequest { get; set; }
        //[Required(ErrorMessage = "Tidak boleh kosong")]
        /*public string ApprovedManager { get; set; }
        //[Required(ErrorMessage = "Tidak boleh kosong")]
        public string ApprovedHRD { get; set; }*/
        [Required(ErrorMessage = "Tidak boleh kosong"), DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "Tidak boleh kosong"), DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime EndDate { get; set; }
        [Required(ErrorMessage = "Tidak boleh kosong")]
        public string NIK { get; set; }
        [Required(ErrorMessage = "Tidak boleh kosong")]
        public string Notes { get; set; }
        public string UploadProof { get; set; }
        public string Email { get; set; }
        public int RemainingQuota { get; set; }
    }
}
