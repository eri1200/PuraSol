using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using ProyectoPurasol.Models;
using System.Web.Mvc;

namespace BLL.Tests
{
    [TestClass()]
    public class clsClienteTests
    {
        [TestMethod()]
        public void ConsultarClientesTest()
        {
            //CONSULTA DE CLIENTES
            clsCliente cliente = new clsCliente();

            var result = cliente.ConsultarClientes();
            Assert.IsInstanceOfType(result, typeof(List<ListaClientesResult>));
        }
        [TestMethod()]
        public void ConsultarClienteTest()
        {
            //CLIENTE ESPECÏFICO
            clsCliente cliente = new clsCliente();

            var result = cliente.ConsultaCliente(117350893);
            Assert.IsInstanceOfType(result, typeof(List<SeleccionarClienteResult>));
        }
        [TestMethod()]
        public void AgregarClienteTest1()
        {
            //AGREGAR CLIENTE
            clsCliente clsclientes = new clsCliente();
            Cliente cliente = new Cliente();
            cliente.Apellido = "Calderon";
            cliente.Nombre = "aaaaaaaa";
            cliente.Canton = "1";
            cliente.Distrito = "1";
            cliente.Provincia = "1";
            cliente.Identificacion = "11111";
            cliente.IdCliente = 1;
            cliente.Correo = "gmail.com";
            cliente.Telefono = "11111111";
            bool respuesta =clsclientes.AgregarCliente(cliente.Identificacion, cliente.Nombre, cliente.Apellido, cliente.Correo, Convert.ToInt32(cliente.Telefono),Convert.ToInt32(cliente.Distrito), Convert.ToInt32(cliente.Canton), Convert.ToInt32(cliente.Provincia));            
            Assert.IsInstanceOfType(respuesta, typeof(bool));
        }
        [TestMethod()]
        public void AgregarClienteTest2()
        {
            //AGREGAR CLIENTE CON ERRORES
            clsCliente clsclientes = new clsCliente();
            Cliente cliente = new Cliente();
            cliente.Apellido = "Calderon";
            cliente.Nombre = "aaaaaaaa";
            cliente.Canton = "1";
            cliente.Distrito = "1";
            cliente.Provincia = "1";
            cliente.Identificacion = "111a11";
            cliente.IdCliente = 1;
            cliente.Correo = "gmail.com";
            cliente.Telefono = "11111111";
            bool respuesta = clsclientes.AgregarCliente(cliente.Identificacion, cliente.Nombre, cliente.Apellido, cliente.Correo, Convert.ToInt32(cliente.Telefono), Convert.ToInt32(cliente.Distrito), Convert.ToInt32(cliente.Canton), Convert.ToInt32(cliente.Provincia));
            Assert.IsInstanceOfType(respuesta, typeof(bool));
        }
        [TestMethod()]
        public void ActualizarClienteTest1()
        {
            //AGREGAR CLIENTE CON ERRORES
            clsCliente clsclientes = new clsCliente();
            Cliente cliente = new Cliente();
            cliente.Apellido = "Calderon";
            cliente.Nombre = "aaaaaaaa";
            cliente.Canton = "1";
            cliente.Distrito = "1";
            cliente.Provincia = "1";
            cliente.Identificacion = "11111";
            cliente.IdCliente = 1;
            cliente.Correo = "gmail.com";
            cliente.Telefono = "11111111";
            bool respuesta = clsclientes.AgregarCliente(cliente.Identificacion, cliente.Nombre, cliente.Apellido, cliente.Correo, Convert.ToInt32(cliente.Telefono), Convert.ToInt32(cliente.Distrito), Convert.ToInt32(cliente.Canton), Convert.ToInt32(cliente.Provincia));
            Assert.IsInstanceOfType(respuesta, typeof(bool));
        }
        [TestMethod()]
        public void ActualizarClienteTest2()
        {
            //AGREGAR CLIENTE CON ERRORES
            clsCliente clsclientes = new clsCliente();
            Cliente cliente = new Cliente();
            cliente.Apellido = "Calderon";
            cliente.Nombre = "aaaaaaaa";
            cliente.Canton = "1";
            cliente.Distrito = "1";
            cliente.Provincia = "1";
            cliente.Identificacion = "111a11";
            cliente.IdCliente = 1;
            cliente.Correo = "gmail.com";
            cliente.Telefono = "11111111";
            bool respuesta = clsclientes.AgregarCliente(cliente.Identificacion, cliente.Nombre, cliente.Apellido, cliente.Correo, Convert.ToInt32(cliente.Telefono), Convert.ToInt32(cliente.Distrito), Convert.ToInt32(cliente.Canton), Convert.ToInt32(cliente.Provincia));
            Assert.IsInstanceOfType(respuesta, typeof(bool));
        }
        [TestMethod()]
        public void EliminarCliente1()
        {
            //AGREGAR CLIENTE CON ERRORES
            clsCliente clsclientes = new clsCliente();
            Cliente cliente = new Cliente();
            cliente.Apellido = "Calderon";
            cliente.Nombre = "aaaaaaaa";
            cliente.Canton = "1";
            cliente.Distrito = "1";
            cliente.Provincia = "1";
            cliente.Identificacion = "11111";
            cliente.IdCliente = 1;
            cliente.Correo = "gmail.com";
            cliente.Telefono = "11111111";
            bool respuesta = clsclientes.EliminarCliente(Convert.ToInt32(cliente.Identificacion));
            Assert.IsInstanceOfType(respuesta, typeof(bool));
        }
        [TestMethod()]
        public void EliminarCliente2()
        {
            //AGREGAR CLIENTE CON ERRORES
            clsCliente clsclientes = new clsCliente();
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
            bool respuesta = clsclientes.EliminarCliente(Convert.ToInt32(cliente.Identificacion));
            Assert.IsInstanceOfType(respuesta, typeof(bool));
        }
    }
}