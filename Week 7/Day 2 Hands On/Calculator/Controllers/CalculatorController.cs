using Microsoft.AspNetCore.Mvc;

namespace WebApplication4.Controllers
{
        [Route("calculator")]
        public class CalculatorController : Controller
        {
            // GET:add
            [HttpGet("add")]
            public IActionResult Add()
            {
                return View();
            }

            // POST:add
            [HttpPost("add")]
            public IActionResult Add(int num1, int num2)
            {
                int res = num1 + num2;

                ViewData["Number1"] = num1;
                ViewData["Number2"] = num2;
                ViewData["Result"] = res;

                return View();
            }
        }
    }

