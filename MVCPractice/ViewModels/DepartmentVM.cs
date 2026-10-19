using System.ComponentModel.DataAnnotations;

namespace MVCPractice.ViewModels
{
    public class DepartmentVM
    {
        public int Id { get; set; }
        [RegularExpression(@"^[a-zA-Z\u0600-\u06FF\s]+$", ErrorMessage = "الاسم يجب أن يحتوي على حروف فقط بدون أرقام أو رموز خاصة")]

        public string Name { get; set; }

        public string Description { get; set; }

    }
}
