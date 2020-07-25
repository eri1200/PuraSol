using DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProyectoPurasol.Controllers;
using ProyectoPurasol.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ProyectoPurasol.Controllers.Tests
{
    [TestClass()]
    public class ClienteControllerTests
    {

        [TestMethod()]
        public void IndexTest()
        {
            ClienteController cliente = new ClienteController();
            ActionResult result = cliente.Index();
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }
        [TestMethod()]
        public void CrearTest1()
        {
            //CONSULTA PAGINA DE INICIO
            ClienteController cliente = new ClienteController();
            ActionResult result = cliente.Crear();
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod()]
        public void CrearTest2()
        {
            //CREAR EL CLIENTE CORRECTAMENTE
            Cliente cliente = new Cliente();
            cliente.Apellido = "Calderon";
            cliente.Nombre = "Pablo";
            cliente.Canton = "02";
            cliente.Distrito = "3";
            cliente.Provincia = "1";
            cliente.Identificacion = "11111111";
            cliente.IdCliente = '1';
            cliente.Correo = "gmail.com";
            cliente.Telefono = "11111111";
            ClienteController ClienteController = new ClienteController();
            ActionResult result = ClienteController.Crear(cliente);
            Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
            RedirectToRouteResult ruta = result as RedirectToRouteResult;
            Assert.AreEqual(ruta.RouteValues["action"], "Index");
        }

        [TestMethod()]
        public void CrearTest3()
        {
            //CREAR EL CLIENTE CON ERRORES
            Cliente cliente = new Cliente();
            cliente.Apellido = "Calderon";
            cliente.Nombre = "Pablo";
            cliente.Canton = "02";
            cliente.Distrito = "07";
            cliente.Provincia = "a9";
            cliente.Identificacion = "1";
            cliente.IdCliente = '1';
            cliente.Correo = "gmail.com";
            cliente.Telefono = "11111111";
            ClienteController ClienteController = new ClienteController();
            ActionResult result = ClienteController.Crear(cliente);
            Assert.IsInstanceOfType(result, typeof(ViewResult));

        }

        [TestMethod()]
        public void CrearTest4()
        {
            //CREAR EL CLIENTE CON ERRORES DE RESPUESTA BD
            Cliente cliente = new Cliente();
            cliente.Apellido = "Calderon";
            cliente.Nombre = "aaaaaaaa";
            cliente.Canton = "1";
            cliente.Distrito = "1";
            cliente.Provincia = "1";
            cliente.Identificacion = "09a87879";
            cliente.IdCliente = 1;
            cliente.Correo = "gmail.com";
            cliente.Telefono = "11111111";
            ClienteController ClienteController = new ClienteController();
            ActionResult result = ClienteController.Crear(cliente);
            Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));

        }

        [TestMethod()]
        public void EditarTest1()
        {
            //CONSULTA PAGINA DE INICIO
            ClienteController cliente = new ClienteController();
            ActionResult result = cliente.Editar(117350893);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod()]
        public void EditarTest2()
        {
            //ACTUALIZAR EL CLIENTE CORRECTAMENTE
            Cliente cliente = new Cliente();
            cliente.Apellido = "Calderon";
            cliente.Nombre = "Pablo";
            cliente.Canton = "02";
            cliente.Distrito = "3";
            cliente.Provincia = "1";
            cliente.Identificacion = "11111111";
            cliente.IdCliente = '1';
            cliente.Correo = "gmail.com";
            cliente.Telefono = "11111111";
            ClienteController ClienteController = new ClienteController();
            ActionResult result = ClienteController.Editar(cliente.Identificacion, cliente);
            Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
            RedirectToRouteResult ruta = result as RedirectToRouteResult;
            Assert.AreEqual(ruta.RouteValues["action"], "Index");
        }

        [TestMethod()]
        public void EditarTest3()
        {
            //ACTUALIZAR EL CLIENTE CON ERRORES
            Cliente cliente = new Cliente();
            cliente.Apellido = "Calderon";
            cliente.Nombre = "Pablo";
            cliente.Canton = "02";
            cliente.Distrito = "07";
            cliente.Provincia = "a9";
            cliente.Identificacion = "1";
            cliente.IdCliente = '1';
            cliente.Correo = "gmail.com";
            cliente.Telefono = "11111111";
            ClienteController ClienteController = new ClienteController();
            ActionResult result = ClienteController.Editar(cliente.Identificacion, cliente);
            Assert.IsInstanceOfType(result, typeof(ViewResult));

        }

        [TestMethod()]
        public void EditarTest4()
        {

            //ACTUALIZAR EL CLIENTE CORRECTAMENTE
            Cliente cliente = new Cliente();
            cliente.Apellido = "Calderon";
            cliente.Nombre = "aaaaaaaa";
            cliente.Canton = "1";
            cliente.Distrito = "1";
            cliente.Provincia = "1";
            cliente.Identificacion = "09a87879";
            cliente.IdCliente = 1;
            cliente.Correo = "gmail.com";
            cliente.Telefono = "11111111";
            ClienteController ClienteController = new ClienteController();
            ActionResult result = ClienteController.Editar(cliente.Identificacion, cliente);
            Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));

        }

        [TestMethod()]
        public void EliminarTest1()
        {
            //ELIMINAR EL CLIENTE CORRECTAMENTE
            Cliente cliente = new Cliente();
            cliente.Apellido = "Calderon";
            cliente.Nombre = "aaaaaaaa";
            cliente.Canton = "1";
            cliente.Distrito = "1";
            cliente.Provincia = "1";
            cliente.Identificacion = "11111111";
            cliente.IdCliente = 1;
            cliente.Correo = "gmail.com";
            cliente.Telefono = "11111111";
            ClienteController ClienteController = new ClienteController();
            ActionResult result = ClienteController.Eliminar(cliente.Identificacion);
            Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
            RedirectToRouteResult ruta = result as RedirectToRouteResult;
            Assert.AreEqual(ruta.RouteValues["action"], "Index");
        }

        [TestMethod()]
        public void EliminarTest2()
        {
            //ELIMINAR EL CLIENTE CON ERRORES BD
            Cliente cliente = new Cliente();
            cliente.Apellido = "Calderon";
            cliente.Nombre = "aaaaaaaa";
            cliente.Canton = "1";
            cliente.Distrito = "1";
            cliente.Provincia = "1";
            cliente.Identificacion = "111";
            cliente.IdCliente = 1;
            cliente.Correo = "gmail.com";
            cliente.Telefono = "11111111";
            ClienteController ClienteController = new ClienteController();
            ActionResult result = ClienteController.Eliminar(cliente.Identificacion);
            Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
            RedirectToRouteResult ruta = result as RedirectToRouteResult;
            Assert.AreEqual(ruta.RouteValues["action"], "Index");
        }
        [TestMethod()]
        public void EliminarTest3()
        {
            //ELIMINAR EL CLIENTE CON ERRORES
            Cliente cliente = new Cliente();
            cliente.Apellido = "Calderon";
            cliente.Nombre = "aaaaaaaa";
            cliente.Canton = "1";
            cliente.Distrito = "1";
            cliente.Provincia = "1";
            cliente.Identificacion = "111a";
            cliente.IdCliente = 1;
            cliente.Correo = "gmail.com";
            cliente.Telefono = "11111111";
            ClienteController ClienteController = new ClienteController();
            ActionResult result = ClienteController.Eliminar(cliente.Identificacion);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod()]
        public void cargaprovinciasTest()
        {
            ClienteController cliente = new ClienteController();

            var result = cliente.CargaProvincias();
            Assert.IsInstanceOfType(result, typeof(List<ProvinciasResult>));
        }
        [TestMethod()]
        public void cargacantonTest()
        {
            ClienteController cliente = new ClienteController();

            var result = cliente.CargaCanton('1');
            Assert.IsInstanceOfType(result, typeof(List<CantonesResult>));
        }
        [TestMethod()]
        public void cargadistritoTest()
        {
            ClienteController cliente = new ClienteController();

            var result = cliente.CargaDistrito('1', "1");
            Assert.IsInstanceOfType(result, typeof(List<DistritosResult>));
        }
        [TestMethod()]
        public void cargacantonesTest()
        {
            ClienteController cliente = new ClienteController();

            var result = cliente.CargaCantones('1');
            Assert.IsInstanceOfType(result, typeof(JsonResult));
        }
        [TestMethod()]
        public void cargadistritosTest()
        {
            ClienteController cliente = new ClienteController();

            var result = cliente.CargaDistritos('1', "1");
            Assert.IsInstanceOfType(result, typeof(JsonResult));
        }

    }
}