using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {

            int? lid = HttpContext.Session.GetInt32("LogueadoId");

            if (lid != null)
            {

                string nom = HttpContext.Session.GetString("LogueadoNombre");
                string ape = HttpContext.Session.GetString("LogueadoApellido");

                ViewBag.msgBienvenida = $"Hola {nom} {ape} ";
            }
            else
            {
                ViewBag.msgBienvenida = $"Hola debe iniciar sesión";

            }

            return View();
        }

        public IActionResult Menu()
        {

            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
