using System.ComponentModel.DataAnnotations;
using MVCPractice.Models;

namespace MVCPractice.ViewModels
{
    public class AddEmployeeVM
    {
        [Required(ErrorMessage = "اسم الموظف مطلوب")]
        [RegularExpression(@"^[a-zA-Z\u0600-\u06FF\s]+$", ErrorMessage = "الاسم يجب أن يحتوي على حروف فقط بدون أرقام أو رموز خاصة")]
        public string Name { get; set; } = string.Empty;
        [Range(18, 60, ErrorMessage = "العمر يجب أن يكون بين 18 و 60")]
        public int Age { get; set; }

        [Range(0, 1000000, ErrorMessage = "المرتب غير صالح")]
        public int Salary { get; set; }

        [Phone(ErrorMessage = "رقم الهاتف غير صحيح")]
        public string? Phone { get; set; }

        [EmailAddress(ErrorMessage = "البريد الإلكتروني غير صحيح")]
        public string? Email { get; set; }

        public string? Address { get; set; }

        public string? ImageUrl { get; set; }

        [Required(ErrorMessage = "يجب اختيار القسم")]
        [Range(1, int.MaxValue, ErrorMessage = "يجب اختيار القسم")]
        public int DepartmentId { get; set; }

        public DateTime HireDate { get; set; } = DateTime.Today;

        public List<Department>? Departments { get; set; }
    }
}