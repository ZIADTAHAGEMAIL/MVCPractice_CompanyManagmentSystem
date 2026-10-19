using Microsoft.EntityFrameworkCore;
using MVCPractice.Models;
using MVCPractice.ViewModels;

namespace MVCPractice.Repositories
{
    public class DepartmentRepo : IDepartmentRepo
    {
        private readonly AppDbContext context;
        public DepartmentRepo(AppDbContext context)
        { this.context = context; }
        public async Task AddAsync(Department e)
        {
            await context.Department.AddAsync(e); await SaveChangesAsync();

        }
        public async Task<bool> HasEmployeesAsync(int departmentId)
        {
            return await context.Employee.AnyAsync(e => e.DepartmentId == departmentId);
        }
        public async Task DeleteAsync(Department d)
        {
               context.Department.Remove(d); await SaveChangesAsync();

        }

        public Task<List<Department>> GetAllAsync()
        {
            return  context.Department.ToListAsync();
        }

        public async Task<Department?> GetByIAsync(int id)
        {
           return await context.Department.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<bool> IsDepartmentExistsAsync(int id)
        {
            return  context.Department.AnyAsync(d => d.Id == id);
        }

        public async Task SaveChangesAsync()
        {
           await context.SaveChangesAsync();
        }
  
        //public async Task UpdateAsync(int Id, DepartmentVM em)
        //{
        //    var depFromDb = await context.Department.FirstOrDefaultAsync(x => x.Id == Id);
        //    if (depFromDb == null)
        //        return;
        //    depFromDb.Name = em.Name;




        //    await SaveChangesAsync();
        //}
    }
}
