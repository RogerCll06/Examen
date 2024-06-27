using Microsoft.AspNetCore.Mvc;

namespace Examen.Controllers
{
    public class Controller1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
