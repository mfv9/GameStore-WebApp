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
        public IActionResult AgregarCarrito(int id, bool dlc)
        {
            try
            {
                s.AgregarAlCarrito(id, dlc);
                TempData["Mensaje"] = "Agregado al carrito";

                HttpContext.Session.SetInt32("CantidadCarrito", s.CarritoActual.Juegos.Count);

            }
            catch (Exception e)
            {

                ViewBag.msg = "Error: " + e.Message;

            }
            return RedirectToAction("Index", "VideoJuego");
        }

        [HttpPost]

        public IActionResult Delete(int id)
        {
            try
            {
                s.QuitarJuegoDelCarrito(id);
                HttpContext.Session.SetInt32("CantidadCarrito", s.CarritoActual.Juegos.Count);
            }
            catch (Exception e)
            {
                ViewBag.msg = "Error: " + e.Message;
            }
            return RedirectToAction("Index", "Carrito");
        }


    }
}
