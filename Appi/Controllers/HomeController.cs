using Microsoft.AspNetCore.Mvc;

namespace Appi.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
