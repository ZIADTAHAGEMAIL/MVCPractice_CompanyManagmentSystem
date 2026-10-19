using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCPractice.Models;
using MVCPractice.Services;
using MVCPractice.ViewModels;

namespace MVCPractice.Controllers.Department
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        public async Task<IActionResult> Index()
        {
            var res = await _departmentService.GetAllDepartmentsAsync();
            return View("Index", res);
        }

        public IActionResult Add()
        {
            DepartmentVM department = new DepartmentVM();
            return View("Add", department);
        }

        [HttpPost]
        public async Task<IActionResult> SaveAdd(DepartmentVM department)
        {
            if (ModelState.IsValid)
            {
                await _departmentService.SaveDepartmentAsync(department);
                return RedirectToAction("Index");
            }
            return View("Add", department);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var dep = await _departmentService.FindDepartmentAsync(id);

            if (dep == null)
                return NotFound();

            var vm = new DepartmentVM
            {
                Id = dep.Id,
                Name = dep.Name,
                Description = dep.Description
            };

            return View("Edit", vm);
        }

        [HttpPost]
        public async Task<IActionResult> SaveEdit(DepartmentVM d)
        {
            if (!ModelState.IsValid)
                return View("Edit", d);

            var department = await _departmentService.FindDepartmentAsync(d.Id);

            if (department == null)
                return NotFound();

            await _departmentService.UpdateDepartmentAsync(d.Id, d);

            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var department = await _departmentService.FindDepartmentAsync(id);
            if (department == null)
                return NotFound();

            if (await _departmentService.HasEmployeesAsync(id))
            {
                TempData["ErrorMessage"] = $"لا يمكن حذف قسم \"{department.Name}\" لوجود موظفين مسجلين به. يرجى نقل أو حذف الموظفين التابعين له أولاً.";
                return RedirectToAction(nameof(Index));
            }

            // ملاحظة: إذا كان هناك موظف مرتبط بهذا القسم قد تظهر مشكلة FK Constraint، 
            // يفضل التأكد من حذف أو نقل الموظفين أو استخدام Delete المناسبة في الـ Service/Repo.
            try
            {
                await _departmentService.DeleteDepartmentAsync(department);
                TempData["SuccessMessage"] = "تم حذف القسم بنجاح.";
            }
            catch (DbUpdateException)
            {
                TempData["ErrorMessage"] = "تعذر حذف القسم لوجود بيانات مرتبطة به في النظام.";
            }
            return RedirectToAction("Index");
        }
    }
}