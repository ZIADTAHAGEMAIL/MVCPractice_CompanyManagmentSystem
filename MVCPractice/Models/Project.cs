using System.ComponentModel.DataAnnotations;

namespace MVCPractice.Models
{
    public class Project
    {
        public int Id { get; set; }

        public String Title { get; set; }
        [Range(20000, 80000, ErrorMessage = "العمر يجب أن يكون بين 20 و 80 الف")]

        public double Budget { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public List<EmployeeProject> EmpPrj { get; set; }
    }
}
