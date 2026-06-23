using DEMO2;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class ClienteController : Controller
    {

        Sistema s = Sistema.getInstance();
        public IActionResult Index()
        {
            return View(s.GetClientes());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Create(Cliente c, string mailUser, string mailRep)
        {
            try
            {
                if(mailUser != mailRep)
                {
                    throw new Exception("Mail no coincide");
                }
                s.AltaCliente(c);
                ViewBag.msg = "Registro correcto";
                return RedirectToAction("Login", "Auth");
            }
            catch (Exception e)
            {
                ViewBag.msg = "Error " + e.Message;
            }

            return View();
        }

        public IActionResult Edit(int id)
        {
            return View(s.FindClientById(id));
        }

        [HttpPost]
        public IActionResult Edit(Cliente c)
        {
            try
            {
                s.ActualizarUsuario(c);
                ViewBag.msg = "Exito";
            }
            catch (Exception e)
            {
                ViewBag.msg = "Error " + e.Message;

            }
            return View();
        }

        public IActionResult EditPass(int id)
        {
            return View(s.FindClientById(id));
        }

        [HttpPost]
        public IActionResult EditPass(int id, string passActual, string repetirPass, string nuevaPass)
        {
            try
            {
                Cliente buscado = s.FindClientById(id);
                if (buscado.Password != passActual)
                {
                    throw new Exception("Su contraseña no coincide");
                }
                if (nuevaPass != repetirPass)
                {
                    throw new Exception("Su contraseña nueva no coincide");

                }
                s.ActualizarContrasenia(id, nuevaPass);
                ViewBag.msg = "Contraseña guardada";
            }
            catch (Exception e)
            {
                ViewBag.msg = "Error " + e.Message;
            }
            return View();
        }

        public IActionResult Details(int id)
        {
            return View(s.FindClientById(id));
        }

        public IActionResult VerMiPerfil()
        {
            int? id = HttpContext.Session.GetInt32("LogueadoId");

            if (id == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            Cliente buscado = s.FindClientById(id.Value);
            return View(buscado);
        }

        public IActionResult Delete(int id)
        {
            return View(s.FindClientById(id));
        }

        [HttpPost]
        public IActionResult Delete(Cliente c)
        {
            try
            {
                s.DesactivarUsuario(c);
                ViewBag.msg = "Exito";


            }
            catch (Exception e)
            {
                ViewBag.msg = "Error " + e.Message;

            }
            return View();
        }

        [HttpPost]

        public IActionResult BorrarUsuarios(List<int> ids)
        {
            try
            {
                s.BorrarUsuarios(ids);

            }
            catch (Exception e)
            {

                ViewBag.msg = "Error " + e.Message;

            }
            return RedirectToAction("Index", "Cliente");
        }



        public IActionResult Activate(int id)
        {
            return View(s.FindClientById(id));
        }

        [HttpPost]

        public IActionResult Activate(Cliente c)
        {
            try
            {
                s.ActivarUsuario(c);
                ViewBag.msg = "Exito";


            }
            catch (Exception e)
            {
                ViewBag.msg = "Error " + e.Message;

            }
            return View();
        }

    }



}

