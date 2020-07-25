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
    public class ErrorControllerTests
    {
        [TestMethod()]
        public void InternalServerErrorTest()
        {
            ErrorController usuario = new ErrorController();
            ActionResult result = usuario.InternalServerError();
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }
        [TestMethod()]
        public void NotFoundError()
        {
            ErrorController usuario = new ErrorController();
            ActionResult result = usuario.NotFound();
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }
    }
}