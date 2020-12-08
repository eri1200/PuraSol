using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoPurasol.Models;
using ProyectoPurasol.Tools;
using BLL;
using reCAPTCHA.MVC;
using Microsoft.Web.Helpers;

namespace ProyectoPurasol.Controllers
{


    public class UsuarioController : Controller
    {
        // GET: Usuario

        public ActionResult Index()
        {
            List<Usuario> listaUsuario = new List<Usuario>();

            clsUsuario usuario = new clsUsuario();
            var data = usuario.ConsultaListaUsuario().ToList();


            foreach (var item in data)
            {
                Usuario modelo = new Usuario();

                modelo.NombreUsuario = item.usuario;

                //if (item.activo)
                //{
                //    modelo.Activo = "Activo";
                //}
                //else
                //{
                //    modelo.Activo = "Desactivado";
                //}
                modelo.Activo=item.activo;
                listaUsuario.Add(modelo);

            }



            return View(listaUsuario);
        }



        // GET: Usuario/Create
        public ActionResult Create()
        {
            clsRol rol = new clsRol();
            ViewBag.ListaRol = rol.ConsultarRoles().Select(x => x.Nombre);
            return View();
        }

        // POST: Usuario/Create
        [CaptchaValidator( //validor del captcha
         PrivateKey = "6LeUhLEZAAAAAF585wGYcNTG_ft1woyFdv4gBojR",
         ErrorMessage = "Invalid input captcha.",
         RequiredMessage = "The captcha field is required.")]
        [HttpPost]
        public ActionResult Create(UsuarioCrear usuario, bool captchaValid)
        {
            try
            {
                if (captchaValid && string.IsNullOrEmpty(usuario.NombreUsuario)==false  && string.IsNullOrEmpty(usuario.Correo) == false && string.IsNullOrEmpty(usuario.Descripcion) == false && string.IsNullOrEmpty(usuario.ListaRol) == false) //revisar manualmente el captcha
                {

                    var randomNumber = new Random().Next(100, 1000);
                    DateTime hora = new DateTime();
                    string Contrasena = usuario.NombreUsuario + randomNumber + hora.Second.ToString();
                    string ContraseñaEncriptada = Security.Encriptar(Contrasena);
                    clsUsuario clsUsuario = new clsUsuario();
                    clsCorreo clsCorreo = new clsCorreo();
                    
                    bool respuesta = false;
                    var Resultado = clsUsuario.ConsultarUsuario(usuario.NombreUsuario).Count();

                    if (Resultado == 0 || clsUsuario.ConsultaListaUsuario().Where(x =>x.Correo==usuario.Correo).Count() ==0)
                    {
                        respuesta = clsUsuario.AgregarUsuario(usuario.NombreUsuario, ContraseñaEncriptada, true, usuario.ListaRol,usuario.Descripcion,usuario.Correo);
                        if (respuesta)
                        {
                            clsCorreo.SendEmailAsync(usuario.Correo, usuario.NombreUsuario, Contrasena);
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            TempData["SuccessMessage"] = "Hubo un error";
                            return RedirectToAction("Create");
                        }
                    }
                    else
                    {
                        TempData["SuccessMessage"] = "El usuario o el correo ya existe";
                        return RedirectToAction("Create");
                        //respuesta = clsUsuario.ActualizarUsuario(usuario.NombreUsuario, ContraseñaEncriptada);
                        //if (respuesta)
                        //{
                        //    return RedirectToAction("Index");
                        //}
                        //else
                        //{
                        //    return View();
                        //}
                    }




                }
                else
                {
                    TempData["SuccessMessage"] = "Complete la informacion";
                    return RedirectToAction("Create");
                }
            }
            catch (Exception ex)
            {
                TempData["SuccessMessage"] = "Hubo un error";
                System.Diagnostics.Debug.WriteLine(ex);
                return RedirectToAction("Create");
            }
        }





        // GET: Usuario/Edit/5
        public ActionResult Edit(string usuario)
        {

            try
            {
                clsRol rol = new clsRol();
                ViewBag.ListaRol = rol.ConsultarRoles().Select(x => x.Nombre);
                List<Usuario> listaCliente = new List<Usuario>();
                clsUsuario User = new clsUsuario();
                var data = User.ConsultarUsuario(usuario).ToList();
                Usuario modelo = new Usuario();
                foreach (var item in data)
                {
                    Session["NOMBREUSUARIO"] = item.usuario;

                    modelo.NombreUsuario = item.usuario;
                    modelo.Activo = item.activo;
                    modelo.Descripcion = item.Descripcion;
                    modelo.Correo = item.Correo;
                    var contrasena = Security.Desencriptar(item.Clave);
                    modelo.Clave = contrasena;



                }

                return View(modelo);
            }
            catch (Exception ex)
            {
                TempData["SuccessMessage"] = "Hubo un error";
                System.Diagnostics.Debug.WriteLine(ex);
                return RedirectToAction("Index");
            }

        }

         
        [HttpPost]
		public ActionResult Edit(String NombreUsuario, String activo, String Clave, String ListaRol, String Descripcion, String Correo)
		{
			try
			{
                try
                {
                    if ( string.IsNullOrEmpty(NombreUsuario) == false && string.IsNullOrEmpty(Correo) == false && string.IsNullOrEmpty(Descripcion) == false && string.IsNullOrEmpty(ListaRol) == false && string.IsNullOrEmpty(Clave) == false) //revisar manualmente el captcha
                    {
                        String UsuarioSession = Session["NOMBREUSUARIO"].ToString();
                        String ClaveEncriptada = Tools.Security.Encriptar(Clave);
                        clsUsuario User = new clsUsuario();
                        bool respuesta = User.ActualizarUsuario(NombreUsuario, ClaveEncriptada, UsuarioSession, ListaRol, Correo, Descripcion);
                        if (respuesta)
                        {
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            TempData["SuccessMessage"] = "Hubo un error";
                            return RedirectToAction("Edit");
                        }
                    }
                    else
                    {
                        TempData["SuccessMessage"] = "Complete la informacion";
                        return RedirectToAction("Create");
                    }
                }
                catch (Exception ex)
                {
                    TempData["SuccessMessage"] = "Hubo un error";
                    return RedirectToAction("Create");
                }
                
                
                
			}
			catch
			{
				return View();
			}
		}

		//// GET: Usuario/Delete/5
		//public ActionResult Delete(int id)
		//{
		//    return View();
		//}

		
		[HttpPost]
        public ActionResult Delete(String id)
        {
            try
            {

                clsUsuario User = new clsUsuario();
                bool respuesta = User.EliminarUsuario(id);
                if (respuesta)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["SuccessMessage"] = "Hubo un error";
                System.Diagnostics.Debug.WriteLine(ex);
                return RedirectToAction("Index");
            }
        }
        
        public ActionResult EditarRoles(String id)
        {
            try
            {
                List<Rol> listaRol = new List<Rol>();

                clsUsuario usuario = new clsUsuario();
                var data = usuario.ObtenerRol(id);
                Session["USUARIOROLTEMP"] = id;
                if (data.Count==1)
                {
                    return Content("<script language='javascript' type='text/javascript'>alert('EL USUARIO SOLO TIENE UN ROL, NO SE PUEDE ELIMINAR');" +
                        "window.history.back();" +
                        "" +
                        "</script>");
                }
                foreach (var item in data)
                {
                    Rol modelo = new Rol();

                    modelo.NombreRol = item.Nombre;

                    
                    listaRol.Add(modelo);

                }



                return View(listaRol);

            }
            catch
            {
                return View();
            }
        }
        public ActionResult EliminarRoles(String roles)
        {
            try
            {
                clsRol rol = new clsRol();
                bool respuesta = rol.EliminarRol(roles, Session["USUARIOROLTEMP"].ToString());
                if (respuesta)
                {
                    return RedirectToAction("EditarRoles", new {id =Session["USUARIOROLTEMP"].ToString() });
                }
                else
                {
                    return RedirectToAction("EditarRoles", new { id = Session["USUARIOROLTEMP"].ToString() });
                }
                
            }
            catch
            {
                return View();
            }
        }
    }
}
