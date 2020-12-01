using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BLL;
using DAL;
using System.Configuration;
using Newtonsoft.Json;
using ProyectoPurasol.Models;

namespace ProyectoPurasol.Controllers
{
    //[Authorize]
    public class ClienteController : Controller
    {
        clsInformacion Informacion = new clsInformacion();
        // GET: Cliente
        [CustomAuthorize]
        public ActionResult Index()
        {
            try
            {
                //if (User.Identity.IsAuthenticated)
                //{
                    List<Cliente> listaCliente = new List<Cliente>();
                    clsCliente cliente = new clsCliente();
                    var data = cliente.ConsultarClientes().ToList();

                    foreach (var item in data)
                    {
                        Cliente modelo = new Cliente();
                        modelo.IdCliente = item.IdCliente;
                        modelo.Identificacion = item.Cedula;
                        modelo.Nombre = item.Nombre;
                        modelo.Apellido = item.Apellido;
                        
                        modelo.Correo = item.Correo;
                        modelo.Telefono = item.Telefono.ToString();
                        modelo.Provincia = item.Provincia.ToString();
                        modelo.Canton = item.Canton.ToString();
                        modelo.Distrito = item.Distrito.ToString();
                        

                        listaCliente.Add(modelo);

                    }

                    return View(listaCliente);
            //}
            //    else
            //    {
            //        return RedirectToAction("Login", "Login");
            //    }
            }
            catch
            {
                string descMsg = "Error consultando la informacion del CLiente.";
                //Bitacora
                return RedirectToAction("Error", "Error");
            }
        }

        // GET: Cliente/Create
        public ActionResult Crear()
        {
            try
            {
                
                ViewBag.ListaSexo = new SelectList(new[] {
                                   new SelectListItem { Value = "H", Text = "Hombre" },
                                   new SelectListItem { Value = "M", Text = "Mujer" }
                                                               }, "Value", "Text");
                ViewBag.ListaEstados = new SelectList(new[] {
                                   new SelectListItem { Value = "1", Text = "Activo" },
                                   new SelectListItem { Value = "0", Text = "Inactivo" }
                                                               }, "Value", "Text");
                ViewBag.ListaProvincias = CargaProvincias();
                
                return View();
            }
            catch (Exception)
            {

                throw;
            }

        }

        // POST: Cliente/Crear
        [HttpPost]
        public ActionResult Crear(Cliente cliente)
        {
            try
            {
                
                    
                    clsCliente Objcliente = new clsCliente();
                if (Objcliente.ConsultaCliente(cliente.Identificacion).Count() >=1||Objcliente.ConsultarClientes().Where(x =>x.Correo==cliente.Correo).Count() >= 1)
                {
                    TempData["SuccessMessage"] = "LOS DATOS ADMINISTRADOS YA EXISTEN EN OTRO CLIENTE";
                    return RedirectToAction("Crear");
                }
                else
                {
                    TempData["SuccessMessage"] = null;
                    bool Resultado = Objcliente.AgregarCliente(cliente.Identificacion.ToString(),
                        cliente.Nombre, cliente.Apellido, cliente.Correo, Convert.ToInt32(cliente.Telefono),
                       Convert.ToInt32(cliente.Distrito), Convert.ToInt32(cliente.Canton), Convert.ToInt32(cliente.Provincia));

                    if (Resultado)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["SuccessMessage"] = "HUBO UN ERROR INSERTANDO LA INFORMACION";
                        ViewBag.ListaProvincias = CargaProvincias();
                        return RedirectToAction("Crear");
                    }
                }

                return RedirectToAction("Crear");



            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: Cliente/Editar/5
        public ActionResult Editar(int id)
        {
            try
            {
                
                clsCliente cliente = new clsCliente();
                ViewBag.ListaSexo = new SelectList(new[] {
                                   new SelectListItem { Value = "H", Text = "Hombre" },
                                   new SelectListItem { Value = "M", Text = "Mujer" }
                                                               }, "Value", "Text");
                ViewBag.ListaEstados = new SelectList(new[] {
                                   new SelectListItem { Value = "1", Text = "Activo" },
                                   new SelectListItem { Value = "0", Text = "Inactivo" }
                                                               }, "Value", "Text");
                var dato = cliente.ConsultaCliente(id);

                Cliente modelo = new Cliente();
                modelo.IdCliente = dato[0].IdCliente;
                
                modelo.Identificacion = dato[0].Cedula;
                modelo.Nombre = dato[0].Nombre;
                modelo.Apellido = dato[0].Apellido;
                modelo.Correo = dato[0].Correo;
                modelo.Telefono = dato[0].Telefono.ToString();
                modelo.Provincia = dato[0].Provincia.ToString();
                modelo.Canton = dato[0].Canton.ToString();
                modelo.Distrito = dato[0].Distrito.ToString();


                ViewBag.ListaProvincias = CargaProvincias();
                ViewBag.ListaCantones = CargaCanton(dato[0].Provincia);
                ViewBag.ListaDistritos = CargaDistrito(dato[0].Provincia, dato[0].Canton);
                return View(modelo);
            }
            catch (Exception)
            {

                throw;
            }
          
        }

        
            // POST: Cliente/Editar/5
            [HttpPost]
        public ActionResult Editar(string id, Cliente cliente)
        {
            try
            {

                
                clsCliente ObjCliente = new clsCliente();
                bool Resultado = ObjCliente.ActualizarCliente(id,
                        cliente.Nombre, cliente.Apellido, cliente.Correo, Convert.ToInt32(cliente.Telefono),
                       Convert.ToInt32(cliente.Distrito), Convert.ToInt32(cliente.Canton), Convert.ToInt32(cliente.Provincia));

                if (Resultado)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    
                    
                    ViewBag.ListaProvincias = CargaProvincias();
                    
                    return RedirectToAction("Editar");
                }
            }
            catch
            {
                return View();
            }
        }
        
        

        //[HttpPost]
        // POST: Cliente/Eliminar/5
        public ActionResult Eliminar(string id)
        {
            try
            {
                clsCliente objcliente = new clsCliente();
                bool Resultado = objcliente.EliminarCliente(Convert.ToInt32(id));

                if (Resultado)
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
                return RedirectToAction("Index");
            }
        }
        /// <summary>
        /// Obtiene Provincias
        /// </summary>
        /// <returns></returns>
        public List<ProvinciasResult> CargaProvincias()
        {
            List<ProvinciasResult> provincias = Informacion.ObtenerProvincias();
            return provincias;
        }
        /// <summary>
        /// Obtiene Cantones
        /// </summary>
        /// <param name="provincia"></param>
        /// <returns></returns>
        public List<CantonesResult> CargaCanton(int provincia)
        {
            List<CantonesResult> cantones = Informacion.ObtenerCantones(provincia);
            return cantones;
        }
        /// <summary>
        /// Obtiene Distritos
        /// </summary>
        /// <param name="provincia"></param>
        /// <param name="canton"></param>
        /// <returns></returns>
        public List<DistritosResult> CargaDistrito(int provincia, int canton)
        {
            List<DistritosResult> distritos = Informacion.ObtenerDistritos(provincia, canton);
            return distritos;
        }
        /// <summary>
        /// Cargar Cantones hacia la pantalla
        /// </summary>
        /// <param name="provincia"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult CargaCantones(int provincia)
        {
            List<CantonesResult> cantones = Informacion.ObtenerCantones(provincia);
            return Json(cantones, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// Cargar Disttritos hacia la pantalla
        /// </summary>
        /// <param name="provincia"></param>
        /// <param name="canton"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult CargaDistritos(int provincia, int canton)
        {
            List<DistritosResult> distritos = Informacion.ObtenerDistritos(provincia, canton);
            return Json(distritos, JsonRequestBehavior.AllowGet);
        }
        
        public JsonResult ConsultarCliente(string id)
        {

            try
            {
                clsCliente cliente = new clsCliente();
                int identificacion = Convert.ToInt32(id);
                List<SeleccionarClienteResult> resultado = cliente.ConsultaCliente(identificacion);
                if(resultado.Count > 0)
                {
                    return Json(new { success = true,  resul=resultado }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false, responseText = "Hubo un error" });
                }
    }
            catch (Exception ex)
            {

                return Json(new { success = false, responseText = ex.Message });
            }
        }
       
        

    }
}
