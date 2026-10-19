
using MVCPractice.Models;
using MVCPractice.ViewModels;
using MVCPractice.Models;
namespace MVCPractice.Services
{
    public interface IRelativeService
    {
        Task<List<RelativeVM>> GetAllAsync();
        Task<RelativeVM> GetByIdAsync(int id);
        Task AddAsync(RelativeVM vm);
        Task UpdateAsync(int id, RelativeVM vm);
        Task DeleteAsync(int id);
        Task<List<Employee>> GetEmployeesAsync();
    }
}
