using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MVCPractice.Models;
using MVCPractice.Services;
using MVCPractice.ViewModels;

namespace MVCPractice.Controllers.Employee
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task<IActionResult> Index(
            string searchString, int? deptId, int pageNumber = 1,
            string? sortBy = "Name", string? sortOrder = "Asc")
        {
            pageNumber = pageNumber < 1 ? 1 : pageNumber;
            int pageSize = 20;

            var employees = await _employeeService.GetAllEmployeesAsync();

            if (!string.IsNullOrEmpty(searchString))
            {
                employees = employees.Where(e => e.Name.Contains(searchString.Trim())).ToList();
            }

            if (deptId.HasValue && deptId.Value > 0)
            {
                employees = employees.Where(e => e.DepartmentId == deptId.Value).ToList();
            }

            employees = (sortBy, sortOrder?.ToLower()) switch
            {
                ("Name", "desc") => employees.OrderByDescending(e => e.Name).ToList(),
                ("Name", _) => employees.OrderBy(e => e.Name).ToList(),
                ("Salary", "desc") => employees.OrderByDescending(e => e.Salary).ToList(),
                ("Salary", _) => employees.OrderBy(e => e.Salary).ToList(),
                ("Age", "desc") => employees.OrderByDescending(e => e.Age).ToList(),
                ("Age", _) => employees.OrderBy(e => e.Age).ToList(),
                _ => employees.OrderBy(e => e.Id).ToList()
            };

            int totalItems = employees.Count;
            int totalPages = (int)Math.Ceiling((double)totalItems / pageSize);
            var result = employees.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            ViewBag.SearchString = searchString;
            ViewBag.DeptId = deptId;
            ViewBag.Departments = await _employeeService.GetAllDepartmentsAsync();
            ViewBag.SortBy = sortBy;
            ViewBag.SortOrder = sortOrder;
            ViewBag.PageNumber = pageNumber;
            ViewBag.TotalPages = totalPages > 0 ? totalPages : 1;

            return View("Index", result);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            AddEmployeeVM addEmployeeVM = new AddEmployeeVM
            {
                HireDate = DateTime.Today,
                Departments = await _employeeService.GetAllDepartmentsAsync()
            };
            return View("AddEmployee", addEmployeeVM);
        }

        [HttpGet]
        public Task<IActionResult> AddEmployee()
        {
            return Add();
        }

        [HttpPost]
        public async Task<IActionResult> SaveAdd(AddEmployeeVM e)
        {
            bool departmentExists =
                await _employeeService.IsDepartmentExistsAsync(e.DepartmentId);

            if (!departmentExists)
            {
                ModelState.AddModelError(
                    nameof(e.DepartmentId),
                    "القسم المحدد غير موجود"
                );
            }
            if (!string.IsNullOrWhiteSpace(e.Name) && e.DepartmentId > 0)
            {
                bool nameExists = await _employeeService.IsEmployeeNameExistInDepartmentAsync(e.Name, e.DepartmentId);
                if (nameExists)
                {
                    ModelState.AddModelError(nameof(e.Name), "يوجد موظف بنفس هذا الاسم مسجل بالفعل في هذا القسم");
                }
            }
            if (!ModelState.IsValid)
            {
                e.Departments = await _employeeService.GetAllDepartmentsAsync();
                return View("AddEmployee", e);
            }

            await _employeeService.AddEmployeeAsync(e);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public Task<IActionResult> Add(AddEmployeeVM e)
        {
            return SaveAdd(e);
        }

        [HttpPost]
        public Task<IActionResult> AddEmployee(AddEmployeeVM e)
        {
            return SaveAdd(e);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var emp = await _employeeService.GetEmployeeAsync(id);
            if (emp == null) return NotFound();

            AddEmployeeVM vm = new AddEmployeeVM
            {
                Name = emp.Name,
                Age = emp.Age,
                Salary = emp.Salary,
                ImageUrl = emp.ImageUrl,
                DepartmentId = emp.DepartmentId,
                Phone = emp.Phone,
                Email = emp.Email,
                Address = emp.Address,
                HireDate = emp.HireDate,
                Departments = await _employeeService.GetAllDepartmentsAsync()
            };

            return View("EditEmployee", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, AddEmployeeVM em)
        {
            bool departmentExists = await _employeeService.IsDepartmentExistsAsync(em.DepartmentId);
            if (!departmentExists)
            {
                ModelState.AddModelError(nameof(em.DepartmentId), "القسم المحدد غير موجود");
            }
            if (!string.IsNullOrWhiteSpace(em.Name) && em.DepartmentId > 0)
            {
                bool nameExists = await _employeeService
                    .IsEmployeeNameExistInDepartmentAsync(em.Name, em.DepartmentId);
                if (nameExists)
                {
                    ModelState.AddModelError(nameof(em.Name),
                        "يوجد موظف بنفس هذا الاسم مسجل بالفعل في هذا القسم");
                }
            }

            if (!ModelState.IsValid)
            {
                em.Departments = await _employeeService.GetAllDepartmentsAsync();
                return View("EditEmployee", em);
            }

            await _employeeService.UpdateEmployeeAsync(id, em);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public Task<IActionResult> SaveEdit(int id, AddEmployeeVM em)
        {
            return Edit(id, em);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var res = await _employeeService.GetEmployeeAsync(id);
            if (res == null) return NotFound();

            return View("DeleteEmployee", res);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var res = await _employeeService.GetEmployeeAsync(id);
            if (res == null) return NotFound();

            await _employeeService.DeleteEmployeeAsync(res);
            return RedirectToAction("Index");
        }
    }
}