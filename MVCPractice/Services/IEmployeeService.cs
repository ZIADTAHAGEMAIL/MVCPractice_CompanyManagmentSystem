using MVCPractice.Models;
using MVCPractice.Repositories;
using MVCPractice.ViewModels;

namespace MVCPractice.Services
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetAllEmployeesAsync();
        Task<List<Department>> GetAllDepartmentsAsync();
        Task AddEmployeeAsync(AddEmployeeVM e);
        Task<Employee?> GetEmployeeAsync(int id);
        Task UpdateEmployeeAsync(int id,  AddEmployeeVM model);
        Task DeleteEmployeeAsync(Employee res);
        Task<bool> IsDepartmentExistsAsync(int departmentId);
        Task<bool> IsEmployeeNameExistInDepartmentAsync
          (string name, int departmentId, int? excludeId = null);
        
    }
}