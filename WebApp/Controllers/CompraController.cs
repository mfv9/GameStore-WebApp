using DEMO2;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class CompraController : Controller
    {
        Sistema s = Sistema.getInstance();
        public IActionResult Index()
        {
            return View(s.GetCompras());
        }

        public IActionResult VerComprasClienteLogueado()
        {
            int lid = HttpContext.Session.GetInt32("LogueadoId").Value;
            return View(s.VerComprasPorCliente(lid));
        }
    }
}
