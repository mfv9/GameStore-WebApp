using DEMO2;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{

    public class CarritoController : Controller
    {
        Sistema s = Sistema.getInstance();
        public IActionResult Index()
        {
            int lid = HttpContext.Session.GetInt32("LogueadoId").Value;
            Cliente actual = s.FindClientById(lid);
            return View(actual.CarritoActual.Juegos);
        }

        [HttpPost]
        public IActionResult AgregarCarrito(int id, bool dlc)
        {
            int lid = HttpContext.Session.GetInt32("LogueadoId").Value;
            Cliente actual = s.FindClientById(lid);
            try
            {
                s.AgregarAlCarrito(id, dlc, actual);
                TempData["Mensaje"] = "Agregado al carrito";

                HttpContext.Session.SetInt32("CantidadCarrito", actual.CarritoActual.Juegos.Count);

            }
            catch (Exception e)
            {

                ViewBag.msg = "Error: " + e.Message;

            }
            return RedirectToAction("Index", "VideoJuego");
        }

        [HttpPost]
        public IActionResult Comprar()
        {
            int lid = HttpContext.Session.GetInt32("LogueadoId").Value;

            try
            {
                
                Cliente actual = s.FindClientById(lid);
                s.AgregarJuegoDelCarritoActualAListaCompras(lid);
                TempData["MsjCompra"] = "Compra realizada.";

                HttpContext.Session.SetInt32("CantidadCarrito", actual.CarritoActual.Juegos.Count);

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
            int lid = HttpContext.Session.GetInt32("LogueadoId").Value;
            Cliente actual = s.FindClientById(lid);

            try
            {
                s.QuitarJuegoDelCarrito(id, actual);
                HttpContext.Session.SetInt32("CantidadCarrito", actual.CarritoActual.Juegos.Count);
            }
            catch (Exception e)
            {
                ViewBag.msg = "Error: " + e.Message;
            }
            return RedirectToAction("Index", "Carrito");
        }


    }
}
