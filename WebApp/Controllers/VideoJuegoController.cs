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
    
    
        public IActionResult BuscarJuegos(string criterio)
        {
            List<VideoJuego> juegos = s.BuscarJuego(criterio);
            return PartialView("_ListaJuegos", juegos);
        }

        public IActionResult ListaCompleta()
        {
            return PartialView("_ListaJuegos", s.GetJuegos());
        }
    }
}
