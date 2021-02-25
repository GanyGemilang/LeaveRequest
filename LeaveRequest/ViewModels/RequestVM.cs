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
        //[Required(ErrorMessage = "Tidak boleh kosong")]
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
        //[Required(ErrorMessage = "Tidak boleh kosong")]
        public string NIK { get; set; }
        [Required(ErrorMessage = "Tidak boleh kosong")]
        public string Notes { get; set; }
        public string UploadProof { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public int RoleId { get; set; }
        public int IdRequest { get; set; }
        public int RemainingQuota { get; set; }
    }
   /* public enum ReasionRequest
    {
        Normal_leave,
        Maternity_leave,
        Sick_leave,
        Married,
        Marry_or_Circumcise_or_Baptize_Children,
        Wife_gave_birth_or_had_a_miscarriage,
        Husband_or_Wife_Parents_or_In_laws_Children_or_Son_In_law_have_passed_away,
        Family_member_in_one_house_died
    }*/
}
