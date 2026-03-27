using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {

            List<Employee> employees = new List<Employee>()
            {
                new Employee { Empno = 101, Ename = "Raju", Job = "Developer", Salary = 50000, Deptno = 10 },
                new Employee { Empno = 102, Ename = "Anil", Job = "Tester", Salary = 40000, Deptno = 20 },
                new Employee { Empno = 103, Ename = "Kiran", Job = "Manager", Salary = 70000, Deptno = 10 },
                new Employee { Empno = 104, Ename = "Sneha", Job = "HR", Salary = 35000, Deptno = 30 },
                new Employee { Empno = 105, Ename = "Priya", Job = "Developer", Salary = 55000, Deptno = 20 }
            };

            return View(employees);
        }
    }
}


