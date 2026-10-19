using Microsoft.EntityFrameworkCore;
using MVCPractice.Models;
using MVCPractice.Repositories;
using MVCPractice.ViewModels;

namespace MVCPractice.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepo repo;

        public DepartmentService(IDepartmentRepo repo)
        {
            this.repo = repo;
        }

        public async Task<List<Department>> GetAllDepartmentsAsync()
        {
            return await repo.GetAllAsync();
        }

        public async Task<Department?> FindDepartmentAsync(int id)
        {
            return await repo.GetByIAsync(id);
        }

        public async Task SaveDepartmentAsync(DepartmentVM department)
        {
            Department d = new Department
            {
                Name = department.Name,
                Description= department.Description
            };

            await repo.AddAsync(d);
            await repo.SaveChangesAsync();
        }

        public async Task UpdateDepartmentAsync(int id, DepartmentVM newdep)
        {
           var old=await repo.GetByIAsync(id);
            if (old == null)
                throw new KeyNotFoundException("department not found");

            old.Name = newdep.Name;
            old.Description = newdep.Description;
           

            await repo.SaveChangesAsync();
        }

        public Task DeleteDepartmentAsync(Department res)
        {
            return  repo.DeleteAsync(res);
        }
        public async Task<bool> HasEmployeesAsync(int departmentId)
        {
            return await repo.HasEmployeesAsync(departmentId);
        }
    }
}