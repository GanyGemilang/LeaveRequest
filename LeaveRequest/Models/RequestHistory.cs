/*using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveRequest.Models
{
    [Table("TB_M_RequestHistory")]
    public class RequestHistory
    {
        [Key, Required(ErrorMessage = "Tidak boleh kosong")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Tidak boleh kosong"), DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime SubmitDate { get; set; }
        [Required(ErrorMessage = "Tidak boleh kosong")]
        public string UserNIK { get; set; }
        [ForeignKey("UserNIK")]
        public virtual User User { get; set; }
        public int RequestId { get; set; }
        [ForeignKey("RequestId")]
        public virtual Request Request { get; set; }
    }
    public enum Status
    {
        Waiting,
        ApproveByHrd,
        RejectByHrd,
        ApproveByManager,
        RejectByManager
    }
}
*/