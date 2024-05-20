using AdoPractice1.DAL;
using AdoPractice1.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdoPractice1.Controllers
{
    public class EmployeeController:Controller
    {
        private readonly EmployeeDAL employeeDAL;
        private readonly DepartmentDAL departmentDAL;
        public EmployeeController() { 
            employeeDAL = new EmployeeDAL();
            departmentDAL = new DepartmentDAL();
        
        }

        public IActionResult Index()
        {
            List<Employee> employees = employeeDAL.GetAllEmployees();
            return View(employees);
        }

        public IActionResult Details(int id)
        {
            Employee employee = employeeDAL.GetEmployeeDetails(id);
            return View(employee);
        }

        public IActionResult Edit(int id)
        {
            Employee employee = employeeDAL.GetEmployeeDetails(id);
            List<Department> departments = departmentDAL.GetAllDepartment();

            // Set DeptId property of the employee model
            employee.DeptId = employee.Department.Id; // Assuming employee.Department is not null

            // Pass both employee details and departments to the view
            ViewBag.Departments = departments;

            Console.WriteLine($"Number of departments: {departments.Count} , deptId {employee.DeptId}");
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Employee emp)
        {
            try
            {
                employeeDAL.UpdateEmployee(emp);
                return RedirectToAction("Index");
            }
            catch (Exception ex) { return View(); }
        }

        public IActionResult Create()
        {
            ViewBag.Departments = departmentDAL.GetAllDepartment();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee emp)
        {
            try
            {
                employeeDAL.CreateNewEmployee(emp);
                return RedirectToAction("Index");
            }
            catch (Exception ex) { return View(); }
        }


        public IActionResult Delete(int id)
        {
            Employee employee = employeeDAL.GetEmployeeDetails(id);
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Employee emp)
        {
            try
            {
                employeeDAL.DeleteEmployee(emp.Id);
                return RedirectToAction("Index");
            }
            catch (Exception ex) { return View(); }
        }
    }
}
