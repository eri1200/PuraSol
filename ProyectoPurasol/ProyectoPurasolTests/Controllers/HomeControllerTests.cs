using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProyectoPurasol.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ProyectoPurasol.Controllers.Tests
{
    [TestClass()]
    public class HomeControllerTests
    {
        [TestMethod()]
        public void IndexTest()
        {
            HomeController usuario = new HomeController();
            ActionResult result = usuario.Index();
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }
        [TestMethod()]
        public void AnotherLinkTest()
        {
            HomeController usuario = new HomeController();
            ActionResult result = usuario.AnotherLink();
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }
    }
}