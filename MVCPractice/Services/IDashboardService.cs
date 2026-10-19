
using MVCPractice.ViewModels;

namespace MVCPractice.Services
{
    public interface IDashboardService
    {
        Task<DashboardVM> GetDashboardAsync();
    }
}
