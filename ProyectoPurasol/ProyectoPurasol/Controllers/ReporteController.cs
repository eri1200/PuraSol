using BLL;
using DAL;
using ExcelDataReader;
using Microsoft.Reporting.WebForms;
using Newtonsoft.Json.Linq;
using ProyectoPurasol.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace ProyectoPurasol.Controllers
{
    public class ReporteController : Controller
    {
        

        

        clsCliente clscliente = new clsCliente();
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
                     var cliente=clscliente.ConsultaCliente(int.Parse(usuario.Identificacion)).Select(x => new { ID = x.Correo });
                    
                    foreach (var obj in cliente)
                    {
                        Session["CORREOCLIENTE"]  = obj.ID;
                    }
                    
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

            Warning[] warnings;
            string[] streamIds;
            string contentType;
            string encoding;
            string extension;
            string deviceInfo = @"<DeviceInfo>
                      <OutputFormat>EMF</OutputFormat>
                      <PageWidth>8.5in</PageWidth>
                      <PageHeight>11in</PageHeight>
                      <MarginTop>0.25in</MarginTop>
                      <MarginLeft>0.25in</MarginLeft>
                      <MarginRight>0.25in</MarginRight>
                      <MarginBottom>0.25in</MarginBottom>
                    </DeviceInfo>"; //DATOS PARA EXPORTACIÓN

            //Export the RDLC Report to Byte Array.

            //DATATABLE MESES 

            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("Mes");
            dt.Columns.Add("HWHTarifaregular");
            dt.Columns.Add("HWHTarifaacceso");
            dt.Columns.Add("Carga");
            dt.Columns.Add("impuesto");
            
            for (int x = 1;x <= 12; x++)
            {
                DataRow _ravi = dt.NewRow();
                _ravi["Mes"] = x;
                _ravi["HWHTarifaregular"] = "500";
                _ravi["HWHTarifaacceso"] = "500";
                _ravi["Carga"] = "500";
                _ravi["impuesto"] = "500";
                dt.Rows.Add(_ravi);
            }
            var tabla =ToJson(dt).ToString();

            clsReporte reporte = new clsReporte();
            reporte.CrearReporte(1111,  tabla, "", 0.00, 0, 0.00, "", 0.00, 0.00, 0.00
            , 0.00, 0.00, 0.00, 0.00, 0.00);


            //
            clsCorreo clsCorreo = new clsCorreo();
            byte[] reportePDF = reportViewer.LocalReport.Render("PDF", deviceInfo, out contentType, out encoding,
                                       out extension, out streamIds, out warnings);
            clsCorreo.EnviarPDF(Session["CORREOCLIENTE"].ToString(), reportePDF);

            ViewBag.ReportViewer = reportViewer;
            return View();
        }



        public JArray ToJson(System.Data.DataTable source)
        {
            JArray result = new JArray();
            JObject row;
            foreach (System.Data.DataRow dr in source.Rows)
            {
                row = new JObject();
                foreach (System.Data.DataColumn col in source.Columns)
                {
                    row.Add(col.ColumnName.Trim(), JToken.FromObject(dr[col]));
                }
                result.Add(row);
            }
            return result;
        }
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
