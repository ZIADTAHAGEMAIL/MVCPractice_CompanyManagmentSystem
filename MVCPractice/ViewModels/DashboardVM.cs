
namespace MVCPractice.ViewModels
{
    public class DashboardVM
    {
        public int EmployeesCount { get; set; }
        public int DepartmentsCount { get; set; }
        public int ProjectsCount { get; set; }
        public int RelativesCount { get; set; }
        public int EmployeeProjectsCount { get; set; }

        public double AverageProjectBudget { get; set; }

        public List<DashboardEmployeeItemVM> RecentEmployees { get; set; } = new();
        public List<DashboardProjectItemVM> RecentProjects { get; set; } = new();
    }

    public class DashboardEmployeeItemVM
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string DepartmentName { get; set; } = string.Empty;
        public DateTime HireDate { get; set; }
    }

    public class DashboardProjectItemVM
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public double Budget { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
