
using Microsoft.EntityFrameworkCore;
using MVCPractice.Models;

namespace MVCPractice.Repositories
{
    public class ProjectRepo : IProjectRepo
    {
        private readonly AppDbContext context;

        public ProjectRepo(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Project>> GetAllAsync()
        {
            return await context.Project
                .Include(p => p.EmpPrj)
                    .ThenInclude(ep => ep.Employee)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Project?> GetByIdAsync(int id)
        {
            return await context.Project
                .Include(p => p.EmpPrj)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddAsync(Project project)
        {
            await context.Project.AddAsync(project);
        }

        public Task DeleteAsync(Project project)
        {
            context.Project.Remove(project);
            return Task.CompletedTask;
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }

        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            return await context.Employee
                .AsNoTracking()
                .OrderBy(e => e.Name)
                .ToListAsync();
        }
        public async Task<bool> UniqeProjectTitle(string title) {
        
       return  await context.Project.AnyAsync(p => p.Title == title);
        }
        public async Task<List<int>> GetEmployeeIdsAsync(int projectId)
        {
            return await context.EmployeeProject
                .Where(ep => ep.ProjectId == projectId)
                .Select(ep => ep.EmployeeId)
                .ToListAsync();
        }
    }
}
