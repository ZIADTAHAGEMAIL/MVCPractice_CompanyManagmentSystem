
using Microsoft.AspNetCore.Mvc;
using MVCPractice.Services;

namespace MVCPractice.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IDashboardService dashboardService;

        public DashboardController(IDashboardService dashboardService)
        {
            this.dashboardService = dashboardService;
        }

        public async Task<IActionResult> Index()
        {
            var dashboard = await dashboardService.GetDashboardAsync();

            return View(dashboard);
        }
    }
}
