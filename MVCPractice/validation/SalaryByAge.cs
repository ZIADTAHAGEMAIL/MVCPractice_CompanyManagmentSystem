using MVCPractice.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace MVCPractice.validation
{
    public interface ISalaryAge
    {
        public int Age { get; set; }
        public int Salary { get; set; }


    }

        public class SalaryByAgeValidation: ValidationAttribute
    {
        public override string FormatErrorMessage(string name)
        {
            return base.FormatErrorMessage(name);
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {


            var model = (ISalaryAge)validationContext.ObjectInstance;

            if (model.Age < 25 && model.Salary < 5000)
            {
                 return new ValidationResult(
                     
                    "الموظف الأقل من 25 سنة يجب أن يكون مرتبه 5000 على الأقل"
                );
            }
            else if (model.Age >= 25 && model.Salary < 8000) {

                 return new ValidationResult(
                       "الموظف الاكبر من او يساوي 25 سنة يجب أن يكون مرتبه 8000 على الأقل"
                   );

            }
             return ValidationResult.Success;
        }
    }
}
