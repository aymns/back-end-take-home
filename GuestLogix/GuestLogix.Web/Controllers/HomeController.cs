using Microsoft.AspNetCore.Mvc;

namespace GuestLogix.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}