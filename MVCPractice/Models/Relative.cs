using System.ComponentModel.DataAnnotations.Schema;

namespace MVCPractice.Models
{
    public class Relative
    {
        public int Id { get; set; }
        public string name  { get; set; }

        public string relation { get; set; }
        [ForeignKey("emp")]
        public int EmployeeId { get; set; }

        public Employee emp { get; set; }

    }
}
