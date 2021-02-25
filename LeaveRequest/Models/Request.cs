using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveRequest.Models
{
    [Table("TB_M_Request")]
    public class Request
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tidak boleh kosong")]
        public string ReasonRequest { get; set; }

        [Required(ErrorMessage = "Tidak boleh kosong")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Tidak boleh kosong"), DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Tidak boleh kosong")]
        public Status Status { get; set; }

        [Required(ErrorMessage = "Tidak boleh kosong")]
        public string Notes { get; set; }
        public string UploadProof { get; set; }
        public string ApprovedHRD { get; set; }
        public string ApprovedManager { get; set; }
        public string NIK { get; set; }
        [ForeignKey("NIK")]
        public virtual User User { get; set; }

        /*  public virtual List<RequestHistory> RequestHistory { get; set; } = new List<RequestHistory>();*/
    }
    public enum Status
    {
        Waiting,
        ApprovedByHRD,
        RejectByHRD,
        ApprovedByManager,
        RejectByManager
    }
    /*public enum ReasionRequest
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
