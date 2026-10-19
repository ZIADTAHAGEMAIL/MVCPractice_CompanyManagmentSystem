
using Microsoft.EntityFrameworkCore;
using MVCPractice.Models;
using MVCPractice.ViewModels;

namespace MVCPractice.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly AppDbContext context;

        public DashboardService(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<DashboardVM> GetDashboardAsync()
        {
            var vm = new DashboardVM
            {
                EmployeesCount = await context.Employee.CountAsync(),
                DepartmentsCount = await context.Department.CountAsync(),
                ProjectsCount = await context.Project.CountAsync(),
                RelativesCount = await context.Relative.CountAsync(),
                EmployeeProjectsCount = await context.EmployeeProject.CountAsync(),

                AverageProjectBudget =
                    await context.Project
                        .Select(p => (double?)p.Budget)
                        .AverageAsync() ?? 0,

                RecentEmployees = await context.Employee
                    .AsNoTracking()
                    .OrderByDescending(e => e.HireDate)
                    .Take(5)
                    .Select(e => new DashboardEmployeeItemVM
                    {
                        Id = e.Id,
                        Name = e.Name,
                        DepartmentName = e.Department != null
                            ? e.Department.Name
                            : "غير محدد",
                        HireDate = e.HireDate
                    })
                    .ToListAsync(),

                RecentProjects = await context.Project
                    .AsNoTracking()
                    .OrderByDescending(p => p.StartDate)
                    .Take(5)
                    .Select(p => new DashboardProjectItemVM
                    {
                        Id = p.Id,
                        Title = p.Title,
                        Budget = p.Budget,
                        StartDate = p.StartDate,
                        EndDate = p.EndDate
                    })
                    .ToListAsync()
            };

            return vm;
        }
    }
}
