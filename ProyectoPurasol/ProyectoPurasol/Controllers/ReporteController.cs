using BLL;
using DAL;
using ExcelDataReader;
using Microsoft.Reporting.WebForms;
using ProyectoPurasol.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace ProyectoPurasol.Controllers
{
    public class ReporteController : Controller
    {
        int tipofactura = 0;
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
                        tipofactura = id;
                        NombreTarifa = "Comercial";
                        ViewBag.NombreTarifa = NombreTarifa;
                        break;

                    case 2:
                        tipofactura = id;
                        NombreTarifa = "Residencial";
                        ViewBag.NombreTarifa = NombreTarifa;
                        break;
                    case 3:
                        tipofactura = id;
                        NombreTarifa = "Microred";
                        ViewBag.NombreTarifa = NombreTarifa;
                        break;
                    case 4:
                        tipofactura = id;
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
        public JsonResult Create(Reporte usuario)
        {
            try
            {
                //foreach (var id in reporte.Electro)
                //{

                //}
                if (usuario != null) {
                    Console.WriteLine(usuario.table[0].Electro);

                    //return Json (new {success=true, url= "http://localhost:51104/Reporte/MesesConsumo" }, JsonRequestBehavior.AllowGet);
                    return Json(new { success = true, url = Url.Action("MesesConsumo") }, JsonRequestBehavior.AllowGet);

                }
                else
                {
                    return Json(new { success = true, url = Url.Action("Create","Reporte",tipofactura) }, JsonRequestBehavior.AllowGet);
                }
                
            }
            catch (Exception ex)
            {

                return Json(new { success = true, url = Url.Action("Create", "Reporte", tipofactura) }, JsonRequestBehavior.AllowGet);
            }
           
            
        }
        public ActionResult MesesConsumo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MesesConsumo(ConsumoMeses consumoMeses)
        {
            return RedirectToAction("ReporteExtra");
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
        public ActionResult ReporteExtra()
        {

            ReportViewer reportViewer = new ReportViewer();
            reportViewer.ProcessingMode = ProcessingMode.Local;
            reportViewer.SizeToReportContent = true;
            reportViewer.Width = Unit.Percentage(9000);
            reportViewer.Height = Unit.Percentage(9000);
            reportViewer.ZoomMode = ZoomMode.Percent;
            reportViewer.ZoomPercent = 150;
            reportViewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"Reports\ReporteConsulta.rdlc";
            List<ReportParameter> Parametros = new List<ReportParameter>();
            Parametros.Add(new ReportParameter("Potencia", (12345).ToString(), true));
            Parametros.Add(new ReportParameter("ConsumoBajodeT", (12345).ToString(), true));
            Parametros.Add(new ReportParameter("Autoconsumo", (12345).ToString(), true));
            Parametros.Add(new ReportParameter("PorcentajeConsumoCubierto", (12345).ToString(), true));
            Parametros.Add(new ReportParameter("Almacenamiento", (12345).ToString(), true));
            Parametros.Add(new ReportParameter("ProduccionAnual", (12345).ToString(), true));
            Parametros.Add(new ReportParameter("CostoWatt", (12345).ToString(), true));
            Parametros.Add(new ReportParameter("Compania", (12345).ToString(), true));
            Parametros.Add(new ReportParameter("Area", (12345).ToString(), true));
            Parametros.Add(new ReportParameter("Paneles", (12345).ToString(), true));
            Parametros.Add(new ReportParameter("RetornoSimple", (12345).ToString(), true));
            Parametros.Add(new ReportParameter("AhorroAnualPromedio", (12345).ToString(), true));


            reportViewer.LocalReport.SetParameters(Parametros.ToArray());
            reportViewer.LocalReport.Refresh();
            reportViewer.LocalReport.Refresh();
            
            ViewBag.ReportViewer = reportViewer;
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
