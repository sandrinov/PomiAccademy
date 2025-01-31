using Microsoft.AspNetCore.Mvc;
using TestWebAppMVC.TestWebAppMVC.DAL;

namespace TestWebAppMVC.Controllers
{
    public class EmployeesController : Controller
    {
        private IDataSource _db;
        public EmployeesController(IDataSource db)
        {
            _db = db;
        }
        public IActionResult GetAll()
        {
            List<Employee> employees = _db.GetAllEmployees();
            return View(employees);
        }
    }
}
