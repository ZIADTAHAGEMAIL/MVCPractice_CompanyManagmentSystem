using Microsoft.EntityFrameworkCore;
using MVCPractice.Models;
using MVCPractice.Repositories;
using MVCPractice.ViewModels;

namespace MVCPractice.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepo employeeRepo;
        private readonly IDepartmentRepo departmentRepo;

        public EmployeeService(IEmployeeRepo employeeRepo, IDepartmentRepo departmentRepo)
        {
            this.employeeRepo = employeeRepo;
            this.departmentRepo = departmentRepo;
        }

        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            return await employeeRepo.GetAllAsync();
        }

        public async Task<List<Department>> GetAllDepartmentsAsync()
        {
            return await departmentRepo.GetAllAsync();
        }

        public async Task AddEmployeeAsync(AddEmployeeVM e)
        {
            if (!await departmentRepo.IsDepartmentExistsAsync(e.DepartmentId))
            {
                throw new KeyNotFoundException(
                    $"Department with ID {e.DepartmentId} does not exist.");
            }

            Employee em = new Employee
            {
                Name = e.Name,
                Age = e.Age,
                Salary = e.Salary,
                DepartmentId = e.DepartmentId,
                ImageUrl = e.ImageUrl,
                Address = e.Address ?? string.Empty,
                Email = e.Email ?? string.Empty,
                HireDate = e.HireDate == default ? DateTime.Today : e.HireDate,
                Phone = e.Phone ?? string.Empty
            };

            await employeeRepo.AddAsync(em);
        }

        public async Task<Employee?> GetEmployeeAsync(int id)
        {
            return await employeeRepo.GetByIAsync(id);
        }

        public async Task UpdateEmployeeAsync(int id, AddEmployeeVM em)
        {
            var employee = await employeeRepo.GetByIAsync(id);

            if (employee == null)
                throw new KeyNotFoundException("Employee not found");

            if (!await departmentRepo.IsDepartmentExistsAsync(em.DepartmentId))
            {
                throw new KeyNotFoundException(
                    $"Department with ID {em.DepartmentId} does not exist.");
            }

            employee.Name = em.Name;
            employee.Age = em.Age;
            employee.Salary = em.Salary;
            employee.ImageUrl = em.ImageUrl;
            employee.DepartmentId = em.DepartmentId;
            employee.HireDate = em.HireDate == default ? employee.HireDate : em.HireDate;
            employee.Phone = em.Phone ?? string.Empty;
            employee.Address = em.Address ?? string.Empty;
            employee.Email = em.Email ?? string.Empty;

            await employeeRepo.SaveChangesAsync();
        }

        public async Task DeleteEmployeeAsync(Employee res)
        {
            await employeeRepo.DeleteAsync(res);
        }

        public async Task<bool> IsDepartmentExistsAsync(int departmentId)
        {
            return await departmentRepo.IsDepartmentExistsAsync(departmentId);
        }

        public async Task<bool> IsEmployeeNameExistInDepartmentAsync(string name, int departmentId, int? excludeId = null)
        {
            return await employeeRepo.IsEmployeeNameExistInDepartmentAsync(name, departmentId, excludeId);
        }
    }
}