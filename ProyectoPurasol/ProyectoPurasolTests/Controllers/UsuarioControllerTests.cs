using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProyectoPurasol.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using ProyectoPurasol.Models;

namespace ProyectoPurasol.Controllers.Tests
{
    [TestClass()]
    public class UsuarioControllerTests
    {
        [TestMethod()]
        public void IndexTest()
        {
            //PAGINA DE INICIO

            UsuarioController Reporte = new UsuarioController();
            ActionResult result = Reporte.Index();
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }
        [TestMethod()]
        public void CrearTest1()
        {
            //PAGINA DE CREACIÖN DE USUARIO

            UsuarioController usuario = new UsuarioController();
            ActionResult result = usuario.Create();
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }
        [TestMethod()]
        public void CrearTest2()
        {
            //CREACIÖN DE USUARIO CORRECTAMENTE
            UsuarioCrear usuariocrear = new UsuarioCrear();
            usuariocrear.NombreUsuario = "LUIS";
            usuariocrear.Contrasena = "12345";
            usuariocrear.IdUsuario = 1;
            usuariocrear.ListaRol = "Administrador";
            usuariocrear.Activo = true;
            UsuarioController usuario = new UsuarioController();
            ActionResult result = usuario.Create(usuariocrear,true);
            Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
            RedirectToRouteResult ruta = result as RedirectToRouteResult;
            Assert.AreEqual(ruta.RouteValues["action"], "Index");
        }
        [TestMethod()]
        public void CrearTest3()
        {
            //CREACIÖN DE USUARIO CON ERRORES BD
            UsuarioCrear usuariocrear = new UsuarioCrear();
            usuariocrear.NombreUsuario = "LUIS";
            usuariocrear.Contrasena = "1234";
            usuariocrear.IdUsuario = 1;
            usuariocrear.ListaRol = null;
            usuariocrear.Activo = true;
            UsuarioController usuario = new UsuarioController();
            ActionResult result = usuario.Create(usuariocrear, true);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            
        }
        [TestMethod()]
        public void CrearTest4()
        {
            //CREACIÖN DE USUARIO CON ERRORES DE VERIFICACIón
            UsuarioCrear usuariocrear = new UsuarioCrear();
            usuariocrear.NombreUsuario = "LUIS";
            usuariocrear.Contrasena = "12345";
            usuariocrear.IdUsuario = 1;
            usuariocrear.ListaRol = "Administrador";
            usuariocrear.Activo = true;
            UsuarioController usuario = new UsuarioController();
            ActionResult result = usuario.Create(usuariocrear, false);
            Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
            RedirectToRouteResult ruta = result as RedirectToRouteResult;
            Assert.AreEqual(ruta.RouteValues["action"], "Create");

        }
        //[TestMethod()]
        //public void CrearTest5()
        //{
        //    //CREACIÖN DE USUARIO CON ERRORES DE EXCEPCIón
        //    UsuarioCrear usuariocrear = new UsuarioCrear();
        //    usuariocrear.NombreUsuario = "LUIS";
        //    usuariocrear.Contrasena = "12345";
        //    usuariocrear.IdUsuario = 1;
        //    usuariocrear.ListaRol = "Administrador";
        //    usuariocrear.Activo = true;
        //    UsuarioCrear user= new UsuarioCrear();
        //    UsuarioController usuario = new UsuarioController();
        //    ActionResult result = usuario.Create(user, false);
        //    Assert.IsInstanceOfType(result, typeof(ViewResult));
            

        //}

    }
}