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
    public class LoginControllerTests
    {
        [TestMethod()]
        public void LoginTest()
        {
            //PAGINA DE INICIO
            LoginViewModel model = new LoginViewModel();
            model.Usuario = "PABLO";
            model.Password = "12345";
            model.RememberMe = true;
            LoginController login = new LoginController();
            ActionResult result = login.Login();
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }
        [TestMethod()]
        public void LoginTest2()
        {
            //CARGAR USUARIO CORRECTAMENTE
            LoginViewModel model = new LoginViewModel();
            model.Usuario = "PABLO";
            model.Password = "12345";
            model.RememberMe = true;
            LoginController login = new LoginController();
            ActionResult result = login.Login(model);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            
        }
        [TestMethod()]
        public void LoginTest3()
        {
            //CARGAR USUARIO CON DATOS INCORRECTOS
            LoginViewModel model = new LoginViewModel();
            model.Usuario = "PABLO";
            model.Password = "145";
            model.RememberMe = true;
            LoginController login = new LoginController();
            ActionResult result = login.Login(model);
            Assert.IsInstanceOfType(result, typeof(ViewResult));

        }
    }
}