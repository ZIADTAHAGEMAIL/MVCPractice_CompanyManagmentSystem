
using MVCPractice.Models;

namespace MVCPractice.Repositories
{
    public interface IRelativeRepo
    {
        Task<List<Relative>> GetAllAsync();
        Task<Relative?> GetByIdAsync(int id);
        Task AddAsync(Relative relative);
        Task DeleteAsync(Relative relative);
        Task SaveChangesAsync();
    }
}
