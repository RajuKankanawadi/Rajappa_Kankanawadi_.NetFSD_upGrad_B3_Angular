using Microsoft.AspNetCore.Mvc;

namespace WebApplication4.Controllers
{
        [Route("feedback")]
        public class FeedbackController : Controller
        {
            // GET:index
            [HttpGet("index")]
            public IActionResult Index()
            {
                return View();
            }

            // POST:submit
            [HttpPost("submit")]
            public IActionResult Submit(string name, string comments, int rating)
            {
                ViewData["Name"] = name;
                ViewData["Comments"] = comments;
                ViewData["Rating"] = rating;

                if (rating >= 4)
                {
                    ViewData["Message"] = "Thank You for your positive feedback!";
                }
                else
                {
                    ViewData["Message"] = "We will improve based on your feedback.";
                }

                return View("Index");
            }
        }
    }

