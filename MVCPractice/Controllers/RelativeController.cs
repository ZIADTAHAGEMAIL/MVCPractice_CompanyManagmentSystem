
using Microsoft.AspNetCore.Mvc;
using MVCPractice.Services;
using MVCPractice.ViewModels;

namespace MVCPractice.Controllers
{
    public class RelativeController : Controller
    {
        private readonly IRelativeService relativeService;

        public RelativeController(IRelativeService relativeService)
        {
            this.relativeService = relativeService;
        }

        public async Task<IActionResult> Index()
        {
            var relatives = await relativeService.GetAllAsync();
            return View(relatives);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var vm = new RelativeVM
            {
                Employees = await relativeService.GetEmployeesAsync()
            };

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> SaveAdd(RelativeVM vm)
        {
            if (!ModelState.IsValid)
            {
                vm.Employees = await relativeService.GetEmployeesAsync();
                return View("Add", vm);
            }

            try
            {
                await relativeService.AddAsync(vm);
                return RedirectToAction(nameof(Index));
            }
            catch (KeyNotFoundException)
            {
                ModelState.AddModelError(
                    nameof(vm.EmployeeId),
                    "الموظف المحدد غير موجود");

                vm.Employees = await relativeService.GetEmployeesAsync();
                return View("Add", vm);
            }
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var vm = await relativeService.GetByIdAsync(id);

            if (vm == null)
                return NotFound();

            vm.Employees = await relativeService.GetEmployeesAsync();

            return View("Edit", vm);
        }


        [HttpPost]
        public async Task<IActionResult> SaveEdit(int id, RelativeVM vm)
        {
            if (id != vm.Id)
                return BadRequest();

            if (!ModelState.IsValid)
            {
                vm.Employees = await relativeService.GetEmployeesAsync();
                return View("Edit", vm);
            }

            try
            {
                await relativeService.UpdateAsync(id, vm);
                return RedirectToAction(nameof(Index));
            }
            catch (KeyNotFoundException ex)
            {
                ModelState.AddModelError(
                    nameof(vm.EmployeeId),
                    ex.Message);

                vm.Employees = await relativeService.GetEmployeesAsync();
                return View("Edit", vm);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await relativeService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
