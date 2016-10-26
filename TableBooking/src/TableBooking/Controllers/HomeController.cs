using Microsoft.AspNetCore.Mvc;

namespace TableBooking.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/
        public IActionResult Index()
        {
            return View();
        }
    }
}
