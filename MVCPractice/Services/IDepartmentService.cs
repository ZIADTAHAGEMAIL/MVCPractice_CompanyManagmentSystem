using MVCPractice.Models;
using MVCPractice.ViewModels;

namespace MVCPractice.Services
{
    public interface IDepartmentService
    {
        Task<List<Department>> GetAllDepartmentsAsync();
        Task SaveDepartmentAsync(DepartmentVM department);
        Task<Department?> FindDepartmentAsync(int id);
        Task UpdateDepartmentAsync(int id, DepartmentVM d);

        Task DeleteDepartmentAsync(Department res);
        Task<bool> HasEmployeesAsync(int departmentId);
    }
}