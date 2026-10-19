using Microsoft.EntityFrameworkCore;
using MVCPractice.Models;

namespace MVCPractice.Repositories
{
    public class RelativeRepo : IRelativeRepo
    {
        private readonly AppDbContext context;

        public RelativeRepo(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Relative>> GetAllAsync()
        {
            return await context.Relative
                .Include(r => r.emp)
                .ToListAsync();
        }

        public async Task<Relative?> GetByIdAsync(int id)
        {
            return await context.Relative
                .Include(r => r.emp)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task AddAsync(Relative relative)
        {
            await context.Relative.AddAsync(relative);
        }

        public Task DeleteAsync(Relative relative)
        {
            context.Relative.Remove(relative);
            return Task.CompletedTask;
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}