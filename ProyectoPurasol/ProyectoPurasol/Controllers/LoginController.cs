using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoPurasol.Models;
using ProyectoPurasol.Tools;
using BLL;
using System.Web.Security;

namespace ProyectoPurasol.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [AllowAnonymous]
        public ActionResult Login()
        {
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return View();
            }
            return RedirectToAction("Blank", "Home");
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
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
                    foreach (var item in Usuario)
                    {
                        if (item.Nombre=="Administrador")
                        {
                            Session["ROLES"] = item.Nombre;
                        }
                        
                    }
                    
                    Session["US"] = model.Usuario;
                    Session["PW"] = model.Password;

                    clsLogin login = new clsLogin();
                    var stringJWT = login.ValidarInicio(model.Usuario, Encriptado2);
                    if (stringJWT != null)
                    {
                        JWT jwt = new JWT { Token = stringJWT };

                        FormsAuthentication.SetAuthCookie(model.Usuario, true);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return View("Login");
                    }
                    

                }
                else
                {
                    return View("Login");
                }

            }
            catch (Exception ex)
            {
                TempData["SuccessMessage"] = "Hubo un error";
                System.Diagnostics.Debug.WriteLine(ex);
                return RedirectToAction("Login");
            }
        }
        public ActionResult Salir()
        {
            Session["token"] = null;
            Session.RemoveAll();
            Response.Cache.SetCacheability(HttpCacheability.Private);
            Session.Clear();
            FormsAuthentication.SignOut();
            Session.Abandon();
            Response.Cache.SetNoServerCaching();
            Request.Cookies.Clear();
            return RedirectToAction("Login", "Login");
        }
    }
}
