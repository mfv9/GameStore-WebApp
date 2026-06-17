using DEMO2;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class VideojuegoController : Controller
    {
        Sistema s = Sistema.getInstance();

        public IActionResult Index()
        {
            return View(s.GetJuegos());
        }
        public IActionResult Buscar()
        {
            int? lid = HttpContext.Session.GetInt32("LogueadoId");
            if (lid == null)
            {
                return RedirectToAction("NoPermitido", "Auth");

            }
            return View();
        }
    
        public IActionResult BuscarJuegos(string criterio)
        {
            List<VideoJuego> juegos = s.BuscarJuego(criterio);
            return PartialView("BuscarJuegos", juegos);
        }
    }
}
