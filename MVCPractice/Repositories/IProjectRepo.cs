
using MVCPractice.Models;

namespace MVCPractice.Repositories
{
    public interface IProjectRepo
    {
        Task<List<Project>> GetAllAsync();

        Task<Project?> GetByIdAsync(int id);

        Task AddAsync(Project project);

        Task DeleteAsync(Project project);

        Task SaveChangesAsync();

        Task<List<Employee>> GetAllEmployeesAsync();

        Task<List<int>> GetEmployeeIdsAsync(int projectId);
        Task<bool> UniqeProjectTitle(string title);
       
    }
}
