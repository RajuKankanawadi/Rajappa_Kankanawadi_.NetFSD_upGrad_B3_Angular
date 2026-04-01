using Microsoft.AspNetCore.Mvc;

namespace WebApplication4.Controllers
{
        [Route("student")]
        public class StudentController : Controller
        {
            // GET:register
            [HttpGet("register")]
            public IActionResult Register()
            {
                return View();
            }

            // POST:register
            [HttpPost("register")]
            public IActionResult Register(string studentName, int age, string course)
            {
                ViewBag.StudentName = studentName;
                ViewBag.Age = age;
                ViewBag.Course = course;

                return View("Display");
            }

            // GET:display
            [HttpGet("display")]
            public IActionResult Display()
            {
                return View();
            }
        }
    }
