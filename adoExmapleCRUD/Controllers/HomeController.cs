using adoExmapleCRUD.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace adoExmapleCRUD.Controllers
{
    public class HomeController : Controller
    {
        private readonly EmployeeDAL dal;

        public HomeController()
        {
            dal = new EmployeeDAL();
        }
        public IActionResult Index()
        {
            List<Employee> emps = dal.getAllEmployees();
            return View(emps);
        }
       
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee emp)
        {
            try
            {
                dal.AddEmployee(emp);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
            return View();
        }

        public IActionResult Details(int? id)
        {
            Employee emp = dal.GetEmpByID(id);
            return View(emp);
        }

        public IActionResult Edit(int? id)
        {
            Employee emp = dal.GetEmpByID(id);
            return View(emp);
        }
        [HttpPost] 
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? id,Employee emp)
        {
            try
            {
                dal.EditEmployee(id, emp);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View(ex);
            }
        }

        public IActionResult Delete(int? id)
        {
            Employee emp = dal.GetEmpByID(id);
            return View(emp);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirm(int? id)
        {
            try
            {
                dal.DeleteEmployee(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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
