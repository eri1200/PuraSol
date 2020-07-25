using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProyectoPurasol.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPurasol.Tools.Tests
{
    [TestClass()]
    public class SecurityTests
    {
        [TestMethod()]
        public void EncriptarTest()
        {
            
            string respuesta = Security.Encriptar("Hola");
            Assert.IsInstanceOfType(respuesta, typeof(string));
        }
        [TestMethod()]
        public void DesencriptarTest()
        {

            string respuesta = Security.Desencriptar("Hola");
            Assert.IsInstanceOfType(respuesta, typeof(string));
        }
    }
}