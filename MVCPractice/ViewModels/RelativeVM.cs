
using MVCPractice.Models;
using System.ComponentModel.DataAnnotations;

namespace MVCPractice.ViewModels
{
    public class RelativeVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "اسم القريب مطلوب")]
        [StringLength(50, MinimumLength = 2,
            ErrorMessage = "الاسم يجب أن يكون بين حرفين و50 حرفًا")]
        [RegularExpression(@"^[a-zA-Z\u0600-\u06FF\s]+$", ErrorMessage = "الاسم يجب أن يحتوي على حروف فقط بدون أرقام أو رموز خاصة")]

        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "صلة القرابة مطلوبة")]
        [RegularExpression(@"^[a-zA-Z\u0600-\u06FF\s]+$", ErrorMessage = " يجب أن يحتوي على حروف فقط بدون أرقام أو رموز خاصة")]

        public string Relation { get; set; } = string.Empty;

        [Required(ErrorMessage = "يجب اختيار الموظف")]
        [Range(1, int.MaxValue,
            ErrorMessage = "يجب اختيار موظف صحيح")]
        public int EmployeeId { get; set; }

        public List<Employee> Employees { get; set; } = new();
    }
}
