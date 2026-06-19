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
            try
            {
                s.AgregarAlCarrito(id, dlc);
                
            }
            catch (Exception e)
            {

                ViewBag.msg = "Error: " + e.Message;

            }
            return RedirectToAction("Index", "Carrito");
        }

        [HttpPost]

        public IActionResult Delete(int id)
        {
            try
            {
                s.QuitarJuegoDelCarrito(id);
            }
            catch (Exception e)
            {
                ViewBag.msg = "Error: " + e.Message;
            }
            return RedirectToAction("Index", "Carrito");
        }

    }
}
