using MVCPractice.Models;
using MVCPractice.ViewModels;

namespace MVCPractice.Repositories
{
    public interface IDepartmentRepo
    {
        public Task<List<Department>> GetAllAsync();
        public Task<Department?> GetByIAsync(int id);
        public Task<bool> IsDepartmentExistsAsync(int id);
        public Task DeleteAsync(Department e);
        //public Task UpdateAsync(int Id, DepartmentVM n);
        public Task AddAsync(Department e);
        Task SaveChangesAsync();
        Task<bool> HasEmployeesAsync(int departmentId);
    }
}
