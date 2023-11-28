using System.ComponentModel.DataAnnotations;

namespace MyCodeFirstApproachDemo.Models
{
    public class Employee
    {
        [Display(Name = "Mã người dùng")]
        [Required(ErrorMessage = "id  không được đề trống")]
        public int? Id { get; set; }
        [Required(ErrorMessage = "Họ tên không được đề trống")]
        public string FullName { get; set; }
        [Range(18, 69, ErrorMessage = "Tuổi phải từ 18 đến 69")]
        public int Age { get; set; }
        [Phone(ErrorMessage = "số điện thoại không hợp lệ")]
        public string PhoneNumber { get; set; }
        [Url(ErrorMessage = "Địa chỉ URL không hợp lệ")]
        public string Website { get; set; }
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public string Email { get; set; }
        
    }
}
