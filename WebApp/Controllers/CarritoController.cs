using DEMO2;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
 
    public class CarritoController : Controller
    {
        Sistema s = Sistema.getInstance();
        public IActionResult Index()
        {
            return View(s.CarritoActual.Juegos);
        }

        public IActionResult Comprar(int id)
        {
            s.AgregarAlCarrito(id, false);
            return RedirectToAction("Index", "VideoJuego");
        }
     
    }
}
