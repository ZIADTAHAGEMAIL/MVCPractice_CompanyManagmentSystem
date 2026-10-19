using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCPractice.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "الاسم مطلوب")]
        [MaxLength(50, ErrorMessage = "الاسم يجب ألا يتجاوز 50 حرفاً")]
        [MinLength(3, ErrorMessage = "الاسم يجب ألا يقل عن 3 أحرف")]
        public string Name { get; set; }

        [Required(ErrorMessage = "العمر مطلوب")]
        [Range(20, 60, ErrorMessage = "العمر يجب أن يكون بين 20 و 60 سنة")]
        public int Age { get; set; }

        [Required(ErrorMessage = "المرتب مطلوب")]
        [Range(3000, 50000, ErrorMessage = "المرتب يجب أن يكون بين 3000 و 50000")]
        public int Salary { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime HireDate { get; set; }

        public string? ImageUrl { get; set; }

        [ForeignKey("Department")]
        [Required(ErrorMessage = "يجب اختيار القسم")]
        public int DepartmentId { get; set; }

        public Department? Department { get; set; }

        public List<EmployeeProject>? EmpPrjs { get; set; }

        public List<Relative>? Relatives { get; set; }
    }
}