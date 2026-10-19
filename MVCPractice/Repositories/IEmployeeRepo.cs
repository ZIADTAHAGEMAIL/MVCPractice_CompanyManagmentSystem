using MVCPractice.Models;
using MVCPractice.ViewModels;

namespace MVCPractice.Repositories
{
    public interface IEmployeeRepo
    {



        Task<bool> IsEmployeeExistsAsync(int id);
        public Task<List<Employee>> GetAllAsync();
        public Task<Employee?> GetByIAsync(int id);
        public Task DeleteAsync(Employee e);
        //public Task UpdateAsync(int Id, AddEmployeeVM em);
        public Task AddAsync(Employee e);
        Task SaveChangesAsync();

        Task<bool> IsEmployeeNameExistInDepartmentAsync
          (string name, int departmentId, int? excludeEmployeeId = null);
    

    }
}
