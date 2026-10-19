
using Microsoft.AspNetCore.Mvc;
using MVCPractice.Services;
using MVCPractice.ViewModels;

namespace MVCPractice.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectService projectService;

        public ProjectController(IProjectService projectService)
        {
            this.projectService = projectService;
        }

        public async Task<IActionResult> Index()
        {
            var projects = await projectService.GetAllAsync();
            return View(projects);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var vm = await projectService.GetAddVMAsync();
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> SaveAdd(ProjectVM vm)
        {
            if (vm.EndDate < vm.StartDate)
            {
                ModelState.AddModelError(
                    nameof(vm.EndDate),
                    "تاريخ النهاية يجب ألا يسبق تاريخ البداية");
            }
            if (await projectService.UniqeProjectTitle(vm.Title))
                ModelState.AddModelError(nameof(vm.Title),"This project Title Is found");

            if (!ModelState.IsValid)
            {
                var addVM = await projectService.GetAddVMAsync();
                vm.Employees = addVM.Employees;
                return View("Add", vm);
            }

            await projectService.AddAsync(vm);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var vm = await projectService.GetByIdAsync(id);
                return View(vm);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> SaveEdit(int id, ProjectVM vm)
        {
            if (id != vm.Id)
                return BadRequest();

            if (vm.EndDate < vm.StartDate)
            {
                ModelState.AddModelError(
                    nameof(vm.EndDate),
                    "تاريخ النهاية يجب ألا يسبق تاريخ البداية");
            }
            if (await projectService.UniqeProjectTitle(vm.Title))
                ModelState.AddModelError(nameof(vm.Title), "This project Title Is found");

            if (!ModelState.IsValid)
            {
                var addVM = await projectService.GetAddVMAsync();
                vm.Employees = addVM.Employees;
                return View("Edit", vm);
            }

            try
            {
                await projectService.UpdateAsync(id, vm);
                return RedirectToAction(nameof(Index));
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await projectService.DeleteAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
