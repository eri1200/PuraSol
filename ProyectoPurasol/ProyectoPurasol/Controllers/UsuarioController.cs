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
                if (captchaValid) //revisar manualmente el captcha
                {

                    var randomNumber = new Random().Next(100, 1000);
                    DateTime hora = new DateTime();
                    string Contrasena = usuario.NombreUsuario + randomNumber + hora.Second.ToString();
                    string ContraseñaEncriptada = Security.Encriptar(Contrasena);
                    clsUsuario clsUsuario = new clsUsuario();
                    clsCorreo clsCorreo = new clsCorreo();
                    clsCorreo.SendEmailAsync(usuario.Correo, usuario.NombreUsuario, Contrasena);
                    bool respuesta = false;
                    var Resultado = clsUsuario.ConsultarUsuario(usuario.NombreUsuario).Count();

                    if (Resultado == 0)
                    {
                        respuesta = clsUsuario.AgregarUsuario(usuario.NombreUsuario, ContraseñaEncriptada, true, usuario.ListaRol,usuario.Descripcion,usuario.Correo);
                        if (respuesta)
                        {
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            return View();
                        }
                    }
                    else
                    {
                        return RedirectToAction("Index");
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
                    return RedirectToAction("Create");
                }
            }
            catch
            {
                return View();
            }
        }





        // GET: Usuario/Edit/5
        public ActionResult Edit(string usuario)
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

         
        [HttpPost]
		public ActionResult Edit(String NombreUsuario, String activo, String Clave, String ListaRol, String Descripcion, String Correo)
		{
			try
			{
                String UsuarioSession= Session["NOMBREUSUARIO"].ToString();
                String ClaveEncriptada= Tools.Security.Encriptar(Clave);
                clsUsuario User = new clsUsuario();
                bool respuesta= User.ActualizarUsuario(NombreUsuario, ClaveEncriptada, UsuarioSession, ListaRol,Correo,Descripcion);
                if (respuesta)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Edit");
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
            catch
            {
                return View();
            }
        }
    }
}
