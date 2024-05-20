using AdoPractice1.DAL;
using AdoPractice1.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdoPractice1.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly DepartmentDAL departmentDAL;

        public DepartmentController()
        {
            departmentDAL=new DepartmentDAL();
        }
        public IActionResult Index()
        {
            List<Department> deptList = departmentDAL.GetAllDepartment();
            return View(deptList);
        }

        public IActionResult Create()
        {
           
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Department dept)
        {
            try
            {
                departmentDAL.CreateNewDepartment(dept);
                return RedirectToAction("Index");
            }
            catch (Exception ex) { return View(); }  
        }



    }
}
