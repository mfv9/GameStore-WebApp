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

        public IActionResult Create(Cliente c)
        {
            try
            {
                s.AltaCliente(c);
                ViewBag.msg = "Registro correcto";
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

        public IActionResult Details(int id)
        {
            return View(s.FindClientById(id));
        }

        public IActionResult VerMiPerfil(LoginViewModel lvm)
        {
            return View(lvm);
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

