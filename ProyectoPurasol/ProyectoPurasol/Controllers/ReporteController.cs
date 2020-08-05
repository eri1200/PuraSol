﻿using BLL;
using DAL;
using ExcelDataReader;
using ProyectoPurasol.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace ProyectoPurasol.Controllers
{
    public class ReporteController : Controller
    {
        Reporte reporte = new Reporte();
        // GET: Reporte
        public ActionResult Index()
        {
            return View();
        }

        
        

        // GET: Reporte/Create
        public ActionResult Create(int id)
        {
            try
            {
                clsReporte Reporte = new clsReporte();
                List<ObtenerCompaniasResult> listaCompanias = Reporte.ObtenerCompanias();
                List<ObtenerTarifasResult> listaTarifas = Reporte.ObtenerTarifas();
                ViewBag.listaCompania = listaCompanias;
                ViewBag.listaTarifas = listaTarifas;
                ViewBag.listaTecnologia = new SelectList(new[] {
                                   new SelectListItem { Value = "4", Text = "Microinversor" },
                                   new SelectListItem { Value = "3", Text = "Centralizado" },
                                   new SelectListItem { Value = "2", Text = "Acople DC" },
                                   new SelectListItem { Value = "1", Text = "Acople AC" },
                                   new SelectListItem {  Value = "0", Text = "Optimizadores" }
                                                               }, "Value", "Text");
                
                string NombreTarifa = string.Empty;
                switch (id)
                {
                    case 1:
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
            }
            catch (System.Exception ex)
            {

                throw;
            }

            return View();
        }
        public ActionResult Upload()
        {
            return View();
        }
        [HttpPost]
        public void Create(Reporte usuario,List<Electrodomestico> reporte)
        {
            try
            {
                //foreach (var id in reporte.Electro)
                //{
                    Console.WriteLine(usuario.table[0].Electro);
                //}
                
                // Json(new { success = true, resul = "Se cargó excelente" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                //return Json(new { success = true, resul = "Hubo Un Error" }, JsonRequestBehavior.AllowGet);
            }
           
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Upload(HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {

                if (upload != null && upload.ContentLength > 0)
                {
                    // ExcelDataReader works with the binary Excel file, so it needs a FileStream
                    // to get started. This is how we avoid dependencies on ACE or Interop:
                    Stream stream = upload.InputStream;

                    // We return the interface, so that
                    IExcelDataReader reader = null;


                    if (upload.FileName.EndsWith(".xls"))
                    {
                        reader = ExcelReaderFactory.CreateBinaryReader(stream);
                    }
                    else if (upload.FileName.EndsWith(".xlsx"))
                    {
                        reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                    }
                    else
                    {
                        ModelState.AddModelError("File", "This file format is not supported");
                        return View();
                    }

                    reader.AsDataSet();

                    DataSet result = reader.AsDataSet();
                    reader.Close();

                    return View(result.Tables[0]);
                }
                else
                {
                    ModelState.AddModelError("File", "Please Upload Your file");
                }
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
        public ActionResult ReportePrueba()
        {
            return View();
        }
        public ActionResult ConsumoDias()
        {
            return View();
        }


    }
}
