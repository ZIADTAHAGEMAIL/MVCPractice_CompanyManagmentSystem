
using MVCPractice.ViewModels;

namespace MVCPractice.Services
{
    public interface IProjectService
    {
        Task<ProjectVM> GetAddVMAsync();

        Task<List<ProjectVM>> GetAllAsync();

        Task<ProjectVM> GetByIdAsync(int id);

        Task AddAsync(ProjectVM vm);

        Task UpdateAsync(int id, ProjectVM vm);

        Task DeleteAsync(int id);
        Task<bool> UniqeProjectTitle(string name);

    }
}
