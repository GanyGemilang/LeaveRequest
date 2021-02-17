using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveRequest.ViewModels
{
    public class RegisterVM
    {
        [Key, Required(ErrorMessage = "Tidak boleh kosong"), MaxLength(10, ErrorMessage = "Maksimal 10 karakter"), MinLength(5, ErrorMessage = "Minimal 5 karakter"), RegularExpression(@"^\d+$", ErrorMessage = "Harus berupa angka")]
        public string NIK { get; set; }
        [Required(ErrorMessage = "Tidak boleh kosong"), MaxLength(30, ErrorMessage = "Maksimal 30 karakter"), RegularExpression(@"^\D+$", ErrorMessage = "Tidak boleh berupa angka")]
        public string FirstName { get; set; }
        [MaxLength(255, ErrorMessage = "Maksimal 255 karakter"), RegularExpression(@"^\D+$", ErrorMessage = "Tidak boleh berupa angka")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Tidak boleh kosong"), EmailAddress(ErrorMessage = "Masukan format email yang valid"), MaxLength(255, ErrorMessage = "Maksimal 255 karakter")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Tidak boleh kosong"), MaxLength(255, ErrorMessage = "Tidak boleh berupa angka")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Tidak boleh kosong"), RegularExpression(@"^08[0-9]{10,11}$", ErrorMessage = "Harus berupa angka diawali 08"), MinLength(11, ErrorMessage = "Minimal 11 karakter"), MaxLength(12, ErrorMessage = "Maksimal 12 karakter")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Tidak boleh kosong")]
        public int RemainingQuota { get; set; }
        [Required(ErrorMessage = "Tidak boleh kosong")]
        public string Position { get; set; }
        [Required(ErrorMessage = "Tidak boleh kosong")]
        public string MarriedStatus { get; set; }
        [Required(ErrorMessage = "Tidak boleh kosong"), DataType(DataType.Text)]
        public string Address { get; set; }
        [Required(ErrorMessage = "Tidak boleh kosong"), DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime BirthDate { get; set; }
        public int RoleId{ get; set; }
    }

    public enum Gender
    {
        Male,
        Female
    }
    public enum Married
    {
        Single,
        Married,
        Widower,
        Widow
    }
    public enum Position
    {
        JuniorApplicationDeveloper,
        BackendDeveloper,
        FrontendDeveloper
    }
}
