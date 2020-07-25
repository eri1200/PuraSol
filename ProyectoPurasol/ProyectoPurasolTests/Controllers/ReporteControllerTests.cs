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
    public class ReporteControllerTests
    {
        [TestMethod()]
        public void IndexTest()
        {
            //PAGINA DE INICIO
            
            ReporteController Reporte = new ReporteController();
            ActionResult result = Reporte.Index();
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }
    

        [TestMethod()]
        public void CreateTest1()
        {
            //ASIGNAR EL TIPO DE REPORTE 1
            ReporteController Reporte = new ReporteController();
            
            ActionResult result = Reporte.Create(1);
            Assert.IsInstanceOfType(result, typeof(ViewResult));

            
            
        }
        [TestMethod()]
        public void CreateTest2()
        {
            //ASIGNAR EL TIPO DE REPORTE 2
            ReporteController Reporte = new ReporteController();

            ActionResult result = Reporte.Create(2);
            Assert.IsInstanceOfType(result, typeof(ViewResult));



        }
        [TestMethod()]
        public void CreateTest3()
        {
            //ASIGNAR EL TIPO DE REPORTE 3
            ReporteController Reporte = new ReporteController();

            ActionResult result = Reporte.Create(3);
            Assert.IsInstanceOfType(result, typeof(ViewResult));



        }
        [TestMethod()]
        public void CreateTest4()
        {
            //ASIGNAR EL TIPO DE REPORTE 4
            ReporteController Reporte = new ReporteController();

            ActionResult result = Reporte.Create(4);
            Assert.IsInstanceOfType(result, typeof(ViewResult));



        }
        [TestMethod()]
        public void CreateTest5()
        {
            //ASIGNAR EL TIPO DE REPORTE ERRONEO
            ReporteController Reporte = new ReporteController();

            ActionResult result = Reporte.Create(5);
            Assert.IsInstanceOfType(result, typeof(ViewResult));



        }

    }
}
