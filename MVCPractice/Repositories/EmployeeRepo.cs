using Microsoft.EntityFrameworkCore;
using MVCPractice.Models;
using MVCPractice.ViewModels;

namespace MVCPractice.Repositories
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly AppDbContext context;

        public EmployeeRepo(AppDbContext context) {
        this.context = context;
        }

        public async Task AddAsync(Employee e)
        {
            await context.Employee.AddAsync(e);
            await SaveChangesAsync();
        }

        public async Task DeleteAsync(Employee e)
        {
             context.Employee.Remove(e);
            await SaveChangesAsync();
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            return await context.Employee
                .Include(e => e.Department)
                .Include(e => e.EmpPrjs)
                    .ThenInclude(ep => ep.Project)
                .AsNoTracking()
                .ToListAsync();
        }


        public async Task<bool> IsEmployeeNameExistInDepartmentAsync(string name, int departmentId, int? excludeEmployeeId = null)
        {
            return await context.Employee.AnyAsync(e =>
                e.DepartmentId == departmentId &&
                e.Name.Trim().ToLower() == name.Trim().ToLower() &&
                (!excludeEmployeeId.HasValue || e.Id != excludeEmployeeId.Value));
        }



        public  Task<Employee?> GetByIAsync(int id)
        {
            return context.Employee.FirstOrDefaultAsync(x=>x.Id==id);
        }
        public async Task<bool> IsEmployeeExistsAsync(int id)
        {
            return await context.Employee.AnyAsync(e => e.Id == id);
        }
        //public async Task UpdateAsync(int Id,AddEmployeeVM em)
        //{
        //  var empFromDb = await  context.Employee.FirstOrDefaultAsync(x=>x.Id==Id);
        //    if (empFromDb == null)
        //        return;
        //    empFromDb.Name = em.Name;
        //    empFromDb.Age = em.Age;
        //    empFromDb.Salary = em.Salary;
        //    empFromDb.ImageUrl = em.ImageUrl;
        //    empFromDb.DepartmentId = em.DepartmentId;



        //    await SaveChangesAsync();
        //}
        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }

    }
}
