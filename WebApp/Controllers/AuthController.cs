using DEMO2;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class AuthController : Controller
    {
        Sistema s = Sistema.getInstance();
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel lvm)
        {
            Cliente buscado = s.VerificarExistencia(lvm.Email, lvm.Password);
            if (buscado == null)
            {
                ViewBag.msg = "No existe usuario";
                return View();
            }
            else
            {
                HttpContext.Session.SetInt32("LogueadoId", buscado.Id);
                HttpContext.Session.SetString("LogueadoNombre", buscado.Nombre);
                HttpContext.Session.SetString("LogueadoRol", buscado.Rol);

                if (buscado.Rol == "Administrador")
                {
                    return RedirectToAction("Index", "VideoJuego");
                }
                else
                {
                    return RedirectToAction("Index", "Home");

                }


            }

        }

        public IActionResult Logout()
        {

            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Auth");

        }

        public IActionResult NoPermitido()
        {
            return View();
        }

    }
}
