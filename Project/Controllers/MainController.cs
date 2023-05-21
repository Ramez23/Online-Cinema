using Microsoft.AspNetCore.Mvc;

namespace Project.Controllers
{
    public class MainController : Controller
    {
        public IActionResult Index()
                {
            ViewBag.acsses = HttpContext.Session.GetString("acsses");
            var Email = HttpContext.Session.GetString("Email");
            if (string.IsNullOrEmpty(Email))
            {
                return View();
            }
            return View();
        }
        public IActionResult ContactUs()
            {
                ViewBag.acsses = HttpContext.Session.GetString("acsses");
                var Email = HttpContext.Session.GetString("Email");
                if (string.IsNullOrEmpty(Email))
                {
                    return View();
                }
                return View();
        }
        public IActionResult ContactForm()
        { 
                    ViewBag.acsses = HttpContext.Session.GetString("acsses");
                    var Email = HttpContext.Session.GetString("Email");
                    if (string.IsNullOrEmpty(Email))
                    {
                        return View();
                    }
                    return View();
		}
        public IActionResult SignIn()
		{
            return View();
		}
    }
}
