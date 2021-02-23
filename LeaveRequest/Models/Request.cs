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
        public string NIK{ get; set; }

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
}
