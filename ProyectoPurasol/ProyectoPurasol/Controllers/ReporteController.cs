using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoPurasol.Controllers
{
    public class ReporteController : Controller
    {
        // GET: Reporte
        public ActionResult Index()
        {
            return View();
        }

        
        

        // GET: Reporte/Create
        public ActionResult Create(int id)
        {
            string NombreTarifa = string.Empty;
            switch (id)
            {
               case  1:
                    NombreTarifa = "Comercial";
                    ViewBag.NombreTarifa = NombreTarifa;
                    break;

                case 2:
                    NombreTarifa = "Residencial";
                    ViewBag.NombreTarifa = NombreTarifa;
                    break;
                case 3:
                    NombreTarifa = "Microred";
                    ViewBag.NombreTarifa = NombreTarifa;
                    break;
                case 4:
                    NombreTarifa = "TMT";
                    ViewBag.NombreTarifa = NombreTarifa;
                    break;
                default:
                    return View();
                    
            }

            return View();
        }


        
        //[HttpPost]
        //public ActionResult Create()
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        
    }
}
