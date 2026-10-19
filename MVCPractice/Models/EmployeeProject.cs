using System.ComponentModel.DataAnnotations.Schema;

namespace MVCPractice.Models
{
    public class EmployeeProject
    {
        public int Id { get; set; }


        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        [ForeignKey("Project")]
        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
