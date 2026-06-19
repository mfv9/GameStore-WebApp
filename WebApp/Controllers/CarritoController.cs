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

        [HttpPost]
        public IActionResult Comprar(int id, bool dlc)
        {
            s.AgregarAlCarrito(id, dlc);

            return RedirectToAction("Index", "Carrito");
        }
     
    }
}
