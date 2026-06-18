using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class CompraController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
