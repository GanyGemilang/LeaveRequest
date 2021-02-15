using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveRequest.Models
{
    [Table("TB_M_Parameter")]
    public class Parameter
    {
        [Key, Required(ErrorMessage = "Tidak boleh kosong")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Tidak boleh kosong"), MaxLength(20, ErrorMessage = "Maksimal 20 karakter"), RegularExpression(@"^\D+$", ErrorMessage = "Tidak boleh berupa angka")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Tidak boleh kosong")]
        public int Value { get; set; }
    }
}
