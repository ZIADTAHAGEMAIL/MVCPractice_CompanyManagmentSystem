
using MVCPractice.Models;
using MVCPractice.Repositories;
using MVCPractice.ViewModels;

namespace MVCPractice.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepo projectRepo;

        public ProjectService(IProjectRepo projectRepo)
        {
            this.projectRepo = projectRepo;
        }

        public async Task<ProjectVM> GetAddVMAsync()
        {
            return new ProjectVM
            {
                Employees = await projectRepo.GetAllEmployeesAsync(),
                StartDate = DateTime.Today,
                EndDate = DateTime.Today
            };
        }

        public async Task<List<ProjectVM>> GetAllAsync()
        {
            var projects = await projectRepo.GetAllAsync();

            return projects.Select(p => new ProjectVM
            {
                Id = p.Id,
                Title = p.Title,
                Budget = p.Budget,
                StartDate = p.StartDate,
                EndDate = p.EndDate,

                // الموظفون المرتبطون بالمشروع فقط
                Employees = p.EmpPrj?
                    .Where(ep => ep.Employee != null)
                    .Select(ep => ep.Employee)
                    .ToList() ?? new List<Employee>()
            }).ToList();
        }

        public async Task<ProjectVM> GetByIdAsync(int id)
        {
            var p = await projectRepo.GetByIdAsync(id);

            if (p == null)
                throw new KeyNotFoundException("Project not found");

            return new ProjectVM
            {
                Id = p.Id,
                Title = p.Title,
                Budget = p.Budget,
                StartDate = p.StartDate,
                EndDate = p.EndDate,

                // كل الموظفين لعرضهم في الـ Checkboxes
                Employees = await projectRepo.GetAllEmployeesAsync(),

                // الموظفون المختارون بالفعل لهذا المشروع
                SelectedEmployeeIds = p.EmpPrj?
                    .Select(ep => ep.EmployeeId)
                    .ToList() ?? new List<int>()
            };
        }

        public async Task AddAsync(ProjectVM vm)
        {
            ValidateDates(vm);

            var allEmployees = await projectRepo.GetAllEmployeesAsync();
            var validEmployeeIds = allEmployees.Select(e => e.Id).ToHashSet();

            var selectedIds = vm.SelectedEmployeeIds
                .Distinct()
                .ToList();

            if (selectedIds.Any(id => !validEmployeeIds.Contains(id)))
                throw new ArgumentException("An invalid employee was selected.");

            var project = new Project
            {
                Title = vm.Title,
                Budget = vm.Budget,
                StartDate = vm.StartDate,
                EndDate = vm.EndDate,

                EmpPrj = selectedIds.Select(employeeId =>
                    new EmployeeProject
                    {
                        EmployeeId = employeeId
                    }).ToList()
            };

            await projectRepo.AddAsync(project);
            await projectRepo.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, ProjectVM vm)
        {
            ValidateDates(vm);

            var project = await projectRepo.GetByIdAsync(id);

            if (project == null)
                throw new KeyNotFoundException("Project not found");

            var allEmployees = await projectRepo.GetAllEmployeesAsync();
            var validEmployeeIds = allEmployees.Select(e => e.Id).ToHashSet();

            var selectedIds = vm.SelectedEmployeeIds
                .Distinct()
                .ToList();

            if (selectedIds.Any(employeeId =>
                    !validEmployeeIds.Contains(employeeId)))
            {
                throw new ArgumentException("An invalid employee was selected.");
            }

            project.Title = vm.Title;
            project.Budget = vm.Budget;
            project.StartDate = vm.StartDate;
            project.EndDate = vm.EndDate;

            project.EmpPrj ??= new List<EmployeeProject>();

            // حذف العلاقات القديمة من مجموعة المشروع
            project.EmpPrj.Clear();

            // إضافة العلاقات الجديدة
            foreach (var employeeId in selectedIds)
            {
                project.EmpPrj.Add(new EmployeeProject
                {
                    EmployeeId = employeeId,
                    ProjectId = project.Id
                });
            }

            await projectRepo.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var project = await projectRepo.GetByIdAsync(id);

            if (project == null)
                throw new KeyNotFoundException("Project not found");

            await projectRepo.DeleteAsync(project);
            await projectRepo.SaveChangesAsync();
        }
        public async Task<bool> UniqeProjectTitle(string name)
        {
            //var project = await projectRepo.GetByIdAsync(id);

            //if (project == null)
            //    throw new KeyNotFoundException("Project not found");

            var isFound = await projectRepo.UniqeProjectTitle(name);

            return isFound;
            
        }

        private static void ValidateDates(ProjectVM vm)
        {
            if (vm.EndDate < vm.StartDate)
            {
                throw new ArgumentException(
                    "Project end date cannot be earlier than start date.");
            }
        }

    }
}
