using Microsoft.AspNetCore.Mvc;

namespace R54_M9_Class_05_Work_01.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
