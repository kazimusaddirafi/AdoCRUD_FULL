using AdoPractice1.DAL;
using AdoPractice1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AdoPractice1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DepartmentDAL departmentDAL;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            departmentDAL = new DepartmentDAL();
        }

        public IActionResult Index()
        {
            List<DepartmentSummary> summaries=departmentDAL.EmployeeCountByDepartment();
            return View(summaries);
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
