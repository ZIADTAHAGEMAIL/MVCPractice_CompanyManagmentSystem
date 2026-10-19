
using MVCPractice.Models;
using System.ComponentModel.DataAnnotations;

namespace MVCPractice.ViewModels
{
    public class ProjectVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "اسم المشروع مطلوب")]
        [StringLength(100, MinimumLength = 3)]
        [RegularExpression(@"^[a-zA-Z\u0600-\u06FF\s]+$", ErrorMessage = "الاسم يجب أن يحتوي على حروف فقط بدون أرقام أو رموز خاصة")]

        public string Title { get; set; } = string.Empty;

        [Range(20000, 80000)]
        public double Budget { get; set; }

        public DateTime StartDate { get; set; } = DateTime.Today;

        public DateTime EndDate { get; set; } = DateTime.Today;

        // الموظفون المتاحون للاختيار
        public List<Employee> Employees { get; set; } = new();

        // الموظفون المختارون للمشروع
        public List<int> SelectedEmployeeIds { get; set; } = new();
    }
}
