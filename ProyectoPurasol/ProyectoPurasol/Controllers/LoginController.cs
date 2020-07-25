using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoPurasol.Models;
using ProyectoPurasol.Tools;
using BLL;

namespace ProyectoPurasol.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [AllowAnonymous]
        public ActionResult Login()
        {
            //if (!HttpContext.User.Identity.IsAuthenticated)
            //{
                return View();
            //}
            //return RedirectToAction("Blank", "Home");
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginViewModel model)
        {
            try
            {

                clsUsuario Objcliente = new clsUsuario();

                
                var Encriptado2 = Security.Encriptar(model.Password);

                var Resultado = Objcliente.ConsultarUsuario(model.Usuario, Encriptado2).Count();
                
                if (Resultado > 0)
                {
                    var Usuario = Objcliente.ObtenerRol(model.Usuario);
                    Session["ROLES"] = Usuario[0].Nombre;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View("Login");
                }

            }
            catch
            {
                return View();
            }
        }

    }
}
