using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveRequest.Models
{
    [Table("TB_M_User")]
    public class User
    {
        [Key, Required(ErrorMessage = "Tidak boleh kosong"), MaxLength(10, ErrorMessage = "Maksimal 10 karakter"), MinLength(5, ErrorMessage = "Minimal 5 karakter"), RegularExpression(@"^\d+$", ErrorMessage = "Harus berupa angka")]
        public string NIK { get; set; }
        [Required(ErrorMessage = "Tidak boleh kosong"), MaxLength(30, ErrorMessage = "Maksimal 30 karakter"), RegularExpression(@"^\D+$", ErrorMessage = "Tidak boleh berupa angka")]
        public string FirstName { get; set; }
        [MaxLength(255, ErrorMessage = "Maksimal 255 karakter"), RegularExpression(@"^\D+$", ErrorMessage = "Tidak boleh berupa angka")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Tidak boleh kosong"), DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Tidak boleh kosong"), DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime BirthDate { get; set; }
        [Required(ErrorMessage = "Tidak boleh kosong")]
        public Gender Gender { get; set; }
        [Required(ErrorMessage = "Tidak boleh kosong")]
        public Married MarriedStatus { get; set; }
        public int ManagerId { get; set; }
        public Position Position { get; set; }
        [MaxLength(255, ErrorMessage = "Maksimal 255 karakter")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Tidak boleh kosong")]
        public int RemainingQuota { get; set; }
        [Required(ErrorMessage = "Tidak boleh kosong"), RegularExpression(@"^08[0-9]{10,11}$", ErrorMessage = "Harus berupa angka diawali 08"), MinLength(11, ErrorMessage = "Minimal 11 karakter"), MaxLength(12, ErrorMessage = "Maksimal 12 karakter")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Tidak boleh kosong"), EmailAddress(ErrorMessage = "Masukan format email yang valid"), MaxLength(255, ErrorMessage = "Maksimal 255 karakter")]
        public string Email { get; set; }
        
        public virtual Account Account { get; set; }
        public int RoleId { get; set; }
        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }
        public virtual List<RequestHistory> RequestHistory { get; set; } = new List<RequestHistory>();
    }
    public enum Gender
    {
        Male = 0,
        Female = 1
    }
    public enum Married
    {
        Single = 0,
        Married = 1,
        Widower = 2,
        Widow = 3
    }
    public enum Position
    {
        ApplicationDeveloper = 0,
        BackendDeveloper = 1,
        FrontendDeveloper = 2
    }
}