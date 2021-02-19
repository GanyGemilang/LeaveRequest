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
        [Required(ErrorMessage = "Tidak boleh kosong"), MaxLength(20, ErrorMessage = "Maksimal 20 karakter"), RegularExpression(@"^\D+$", ErrorMessage = "Tidak boleh berupa angka")]
        public string ManagerName { get; set; }
        [Required(ErrorMessage = "Tidak boleh kosong")]
        public string ReasionRequest { get; set; }
        [Required(ErrorMessage = "Tidak boleh kosong")]
        public string ApprovedManager { get; set; }
        [Required(ErrorMessage = "Tidak boleh kosong")]
        public string ApprovedHRD { get; set; }
        [Required(ErrorMessage = "Tidak boleh kosong"), DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public string StartDate { get; set; }
        [Required(ErrorMessage = "Tidak boleh kosong"), DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public string EndDate { get; set; }
        [Required(ErrorMessage = "Tidak boleh kosong")]
        public string Notes { get; set; }
        public string UploadProof { get; set; }
        public virtual List<RequestHistory> RequestHistory { get; set; } = new List<RequestHistory>();
    }
  /*  public enum ReasionRequest
    {
        Married,
        ChildMarriage,
        CircumciseTheChild,
        Religious
    }
    public enum Approve
    {
        Waiting,
        Approve,
        Reject
    }*/
}
