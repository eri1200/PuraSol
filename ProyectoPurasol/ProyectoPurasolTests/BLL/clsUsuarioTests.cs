using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using ProyectoPurasol.Models;

namespace BLL.Tests
{
    [TestClass()]
    public class clsUsuarioTests
    {
        [TestMethod()]
        public void ConsultarUsuario1Test()
        {
            //CONSULTA USUARIO EXISTENTE
            clsUsuario usuario = new clsUsuario();
            var respuesta = usuario.ConsultarUsuario("PABLO", "3TLpk2hr5to=");
            Assert.IsInstanceOfType(respuesta, typeof(List<ExisteUsuarioResult>));
        }
        [TestMethod()]
        public void ConsultarUsuario2Test()
        {
            //ConsultaListaUsuarioResult LISTA USUARIOS
            clsUsuario usuario = new clsUsuario();
            var respuesta = usuario.ConsultarUsuario("PABLO");
            Assert.IsInstanceOfType(respuesta, typeof(List<ConsultarUsuarioResult>));
        }
        [TestMethod()]
        public void ConsultarListaUsuario2Test()
        {
            //CONSULTA USUARIOS
            clsUsuario usuario = new clsUsuario();
            var respuesta = usuario.ConsultaListaUsuario();
            Assert.IsInstanceOfType(respuesta, typeof(List<ConsultaListaUsuarioResult>));
        }
        [TestMethod()]
        public void ExisteUsuario()
        {
            //EXISTE USUARIOS
            clsUsuario usuario = new clsUsuario();
            var respuesta = usuario.ExisteUsuario("PABLO", "3TLpk2hr5to=");
            Assert.IsInstanceOfType(respuesta, typeof(Boolean));
        }
        [TestMethod()]
        public void AgregarUsuario()
        {
            //AGREGAR USUARIO
            UsuarioCrear usuariocrear = new UsuarioCrear();
            usuariocrear.NombreUsuario = "LUIS";
            usuariocrear.Contrasena = "12345";
            usuariocrear.IdUsuario = 1;
            usuariocrear.ListaRol = "Administrador";
            clsUsuario usuario = new clsUsuario();
            var respuesta = usuario.AgregarUsuario(usuariocrear.NombreUsuario,usuariocrear.Contrasena,usuariocrear.Activo,usuariocrear.ListaRol);
            Assert.IsInstanceOfType(respuesta, typeof(Boolean));
        }
        [TestMethod()]
        public void EliminarUsuario()
        {
            //ELIMINAR USUARIO
            UsuarioCrear usuariocrear = new UsuarioCrear();
            usuariocrear.NombreUsuario = "LUIS";
            usuariocrear.Contrasena = "12345";
            usuariocrear.IdUsuario = 1;
            usuariocrear.ListaRol = "Administrador";
            clsUsuario usuario = new clsUsuario();
            var respuesta = usuario.EliminarUsuario(usuariocrear.NombreUsuario);
            Assert.IsInstanceOfType(respuesta, typeof(Boolean));
        }
    }
}