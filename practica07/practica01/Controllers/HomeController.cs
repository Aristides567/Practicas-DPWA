using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using practica01.Models;
using System.Diagnostics;

using practica01.Repositories;
using practica01.ViewsModels;

namespace practica01.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly DashboardRepository _dashboardRepository;

        public HomeController(DashboardRepository dashboardRepository)
        {
            _dashboardRepository = dashboardRepository;
        }

        public IActionResult Index()
        {
            ViewBag.username = User.Identity?.Name;

            var metrics = _dashboardRepository.getDashboardMetrics();
            return View(metrics);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
