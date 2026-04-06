using Microsoft.AspNetCore.Mvc;

namespace DoMate_Project_by_Priya.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Setup()
        {
            return View();
        }

        public IActionResult Dashboard()
        {
            var hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour < 12 ? "Good Morning ☀️" :
                               hour < 17 ? "Good Afternoon 🌤️" :
                                           "Good Evening 🌙";

            return View();
        }
    }
}