
using MVCPractice.Models;
using MVCPractice.Repositories;
using MVCPractice.ViewModels;

namespace MVCPractice.Services
{
    public class RelativeService : IRelativeService
    {
        private readonly IRelativeRepo relativeRepo;
        private readonly IEmployeeRepo employeeRepo;

        public RelativeService(
            IRelativeRepo relativeRepo,
            IEmployeeRepo employeeRepo)
        {
            this.relativeRepo = relativeRepo;
            this.employeeRepo = employeeRepo;
        }

        public async Task<List<RelativeVM>> GetAllAsync()
        {
            var relatives = await relativeRepo.GetAllAsync();

            return relatives.Select(r => new RelativeVM
            {
                Id = r.Id,
                Name = r.name,
                Relation = r.relation,
                EmployeeId = r.EmployeeId
            }).ToList();
        }

        public async Task<RelativeVM> GetByIdAsync(int id)
        {
            var r = await relativeRepo.GetByIdAsync(id);

            if (r == null)
                throw new KeyNotFoundException("Relative not found");

            return new RelativeVM
            {
                Id = r.Id,
                Name = r.name,
                Relation = r.relation,
                EmployeeId = r.EmployeeId
            };
        }
        public async Task<List<Employee>> GetEmployeesAsync()
        {
            return await employeeRepo.GetAllAsync();
        }
        public async Task AddAsync(RelativeVM vm)
        {
            if (!await employeeRepo.IsEmployeeExistsAsync(vm.EmployeeId))
                throw new KeyNotFoundException(
                    $"Employee with ID {vm.EmployeeId} does not exist.");

            var relative = new Relative
            {
                name = vm.Name,
                relation = vm.Relation,
                EmployeeId = vm.EmployeeId
            };

            await relativeRepo.AddAsync(relative);
            await relativeRepo.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, RelativeVM vm)
        {
            var relative = await relativeRepo.GetByIdAsync(id);

            if (relative == null)
                throw new KeyNotFoundException("Relative not found");

            if (!await employeeRepo.IsEmployeeExistsAsync(vm.EmployeeId))
                throw new KeyNotFoundException(
                    $"Employee with ID {vm.EmployeeId} does not exist.");

            relative.name = vm.Name;
            relative.relation = vm.Relation;
            relative.EmployeeId = vm.EmployeeId;

            await relativeRepo.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var relative = await relativeRepo.GetByIdAsync(id);

            if (relative == null)
                throw new KeyNotFoundException("Relative not found");

            await relativeRepo.DeleteAsync(relative);
            await relativeRepo.SaveChangesAsync();
        }
    }
}
