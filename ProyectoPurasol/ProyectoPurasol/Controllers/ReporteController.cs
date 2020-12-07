using BLL;
using DAL;
using ExcelDataReader;
using Microsoft.Reporting.WebForms;
using Newtonsoft.Json;
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
using System.Web.Routing;
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
                if (usuario.Compania != null && usuario.CostosdeMantenimiento != 0 && usuario.CostoUnitarioFijo != 0 && usuario.CrecimientoAnual != 0 && string.IsNullOrEmpty(usuario.Descripcion)==false && usuario.HorasRespaldo != 0 && string.IsNullOrEmpty(usuario.Identificacion)== false && string.IsNullOrEmpty(usuario.Nombre)==false && usuario.NumCotizacion != 0 &&
                    string.IsNullOrEmpty(usuario.PotenciadePanel)==false && usuario.TamanoFijo != 0 && usuario.Tarifa != 0 && usuario.TechoDisponible != 0) {
                     //Console.WriteLine(usuario.table[0].Electro);

                    //return Json (new {success=true, url= "http://localhost:51104/Reporte/MesesConsumo" }, JsonRequestBehavior.AllowGet);
                     var cliente=clscliente.ConsultaCliente(int.Parse(usuario.Identificacion)).Select(x => new { ID = x.Correo });
                    
                    foreach (var obj in cliente)
                    {
                        Session["CORREOCLIENTE"]  = obj.ID;
                    }

                    return Json(new { success = true, url = Url.Action("MesesConsumo") }, JsonRequestBehavior.AllowGet);
                    //return RedirectToAction("MesesConsumo");
                }
                else
                {
                    TempData["SuccessMessage"] = "Complete la informacion solicitada";
                    return Json(new { success = true, url = Url.Action("Create","Reporte",tipofactura) }, JsonRequestBehavior.AllowGet);
                    //return RedirectToAction("Create");
                }
                
            }
            catch (Exception ex)
            {
                TempData["SuccessMessage"] = "Complete la informacion solicitada";
                return Json(new { success = true, url = Url.Action("Create", "Reporte", tipofactura) }, JsonRequestBehavior.AllowGet);
                
                //return RedirectToAction("Create");
            }
           
            
        }
        public ActionResult MesesConsumo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MesesConsumo(ConsumoMeses consumoMeses)
        {
            try
            {
                if (consumoMeses.Enero!=0 && consumoMeses.Febrero != 0 && consumoMeses.Marzo != 0 && consumoMeses.Abril != 0 && consumoMeses.Mayo != 0 && consumoMeses.Junio != 0 && consumoMeses.Julio != 0 && consumoMeses.Agosto != 0 && consumoMeses.Setiembre != 0 && consumoMeses.Octubre != 0 && consumoMeses.Noviembre != 0 && consumoMeses.Diciembre != 0 &&
                    consumoMeses.SOLARGISEnero != 0 && consumoMeses.SOLARGISFebrero != 0 && consumoMeses.SOLARGISMarzo != 0 && consumoMeses.SOLARGISAbril != 0 && consumoMeses.SOLARGISMayo != 0 && consumoMeses.SOLARGISJunio != 0 && consumoMeses.SOLARGISJulio != 0 && consumoMeses.SOLARGISAgosto != 0 && consumoMeses.SOLARGISSetiembre != 0 && consumoMeses.SOLARGISOctubre != 0 && consumoMeses.SOLARGISNoviembre != 0 && consumoMeses.SOLARGISDiciembre != 0 )
                {
                    return RedirectToAction("ReporteExtra");
                }
                else
                {
                    TempData["SuccessMessage"] = "Complete la informacion solicitada";
                    return RedirectToAction("MesesConsumo");
                    
                }
                return RedirectToAction("MesesConsumo");
            }
            catch(Exception ex)
            {
                TempData["SuccessMessage"] = "Hubo un error";
                Console.WriteLine(ex);
            }
            return RedirectToAction("MesesConsumo");
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
                        ModelState.AddModelError("File", "Este archivo no es soportado");
                        return View();
                    }

                    reader.AsDataSet();

                    DataSet result = reader.AsDataSet();
                    reader.Close();

                    return View(result.Tables[0]);
                }
                else
                {
                    ModelState.AddModelError("File", "Por favor suba su archivo");
                }
            }
            return View();
        }
        public ActionResult ReporteExtra()
        {
            var Datos= Session["DatosReporte"] as List<BLL.Models.Reporte>;
            Datos.RemoveAt(1);
            
            var principal = Session["PRINCIPAL"];
            ReportViewer reportViewer = new ReportViewer();
            reportViewer.ProcessingMode = ProcessingMode.Local;
            reportViewer.SizeToReportContent = true;
            reportViewer.Width = Unit.Percentage(100);
            reportViewer.Height = Unit.Percentage(100);
            reportViewer.ZoomMode = ZoomMode.Percent;
            reportViewer.ZoomPercent = 150;
            reportViewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"Reports\ReporteConsulta.rdlc";
            List<ReportParameter> Parametros = new List<ReportParameter>();
            foreach (var item in Datos)
            {
                Parametros.Add(new ReportParameter("Compania", item.Compania, true));
                Parametros.Add(new ReportParameter("Potencia", item.PotenciadePanel, true));
                Parametros.Add(new ReportParameter("ConsumoBajodeT", item.consumoTA, true));
                Parametros.Add(new ReportParameter("Autoconsumo", item.autoconsumo, true));
                Parametros.Add(new ReportParameter("PorcentajeConsumoCubierto", item.consumoCubiertoPct, true));
                Parametros.Add(new ReportParameter("Almacenamiento", item.Almacenamiento, true));
                Parametros.Add(new ReportParameter("ProduccionAnual", item.ProduccionAnual, true));
                Parametros.Add(new ReportParameter("CostoWatt", item.CostoPorWatt, true));

                Parametros.Add(new ReportParameter("Area", item.Area, true));
                Parametros.Add(new ReportParameter("Paneles", item.CantidadPaneles, true));
                Parametros.Add(new ReportParameter("RetornoSimple", item.retornoSimple, true));
                Parametros.Add(new ReportParameter("AhorroAnualPromedio", item.ahorroaAnualesAvg, true));
            }
            


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

            //DATATABLE Proy MESES 
            

            DataTable tablaProy = new DataTable();
            tablaProy.Clear();
            tablaProy.Columns.Add("Mes");
            tablaProy.Columns.Add("HWHTarifaregular");
            tablaProy.Columns.Add("HWHTarifaacceso");
            tablaProy.Columns.Add("Carga");
            tablaProy.Columns.Add("impuesto");
            foreach (var item in Datos)
            {
                int contador = 1;
                foreach(var item2 in item.proyFact)
                {
                        
                        DataRow _ravi = tablaProy.NewRow();
                        _ravi["Mes"] = contador;
                        _ravi["HWHTarifaregular"] = item2.costoPredichoEner1;
                        _ravi["HWHTarifaacceso"] = item2.costoPredichoEner2;
                        _ravi["Carga"] = item2.enerCoberturTarAcc;
                        _ravi["impuesto"] = item2.compraReg;
                        tablaProy.Rows.Add(_ravi);
                        contador++;
                }
            }
            
            var tablaP =ToJson(tablaProy).ToString();



            //DATATABLE Hist MESES 

            DataTable tablaHist = new DataTable();
            tablaHist.Clear();
            tablaHist.Columns.Add("Mes");
            tablaHist.Columns.Add("HWHTarifaregular");
            tablaHist.Columns.Add("Carga");
            tablaHist.Columns.Add("impuesto");


            foreach (var item in Datos)
            {
                int contador = 1;
                foreach (var item2 in item.histFact)
                {
                    
                    DataRow _ravi = tablaHist.NewRow();
                    _ravi["Mes"] = contador;
                    _ravi["HWHTarifaregular"] = item2.consumoEnergia;
                    _ravi["Carga"] = item2.costoBaseEner1;
                    _ravi["impuesto"] = item2.costoBaseEner2;
                    tablaHist.Rows.Add(_ravi);
                    contador++;
                }
            }
            var tablaH = ToJson(tablaHist).ToString();

            clsReporte reporte = new clsReporte();
            reporte.CrearReporte(1111, tablaH, tablaP, "", 0.00, 0, 0.00, "", 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00);


            //
            clsCorreo clsCorreo = new clsCorreo();
            byte[] reportePDF = reportViewer.LocalReport.Render("PDF", deviceInfo, out contentType, out encoding,
                                       out extension, out streamIds, out warnings);
            //clsCorreo.EnviarPDF(Session["CORREOCLIENTE"].ToString(), reportePDF);

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
        public ActionResult BuscarCliente()
        {
            return View();
        }
        [HttpPost]
        public ActionResult BuscarCliente(string Id)
        {
            try
            {
                int Cedula = int.Parse(Id);
                clsCliente cliente = new clsCliente();
                var numclientes= cliente.ConsultaCliente(Cedula);
                if(numclientes.Count() > 0)
                {
                    clsReporte reporte = new clsReporte();
                    List<ConsultarClienteReportesResult> ReporteCliente =reporte.ConsultarClienteReportes(Cedula);

                    Session["list"] = ReporteCliente.ToList();
                    return RedirectToAction("ListaReportes",new RouteValueDictionary(ReporteCliente));
                }
                else
                {
                    RedirectToAction("Error", "Error");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return View();
        }
        public ActionResult ListaReportes()
        {
            try
            {
                var reporteCliente = Session["list"] as List<ConsultarClienteReportesResult>;
                List<ListaReporte> ListaReportes = new List<ListaReporte>();
                foreach (var item in reporteCliente)
                {
                    ListaReporte modelo = new ListaReporte();
                    modelo.Nombre = item.Nombre;
                    DateTime fecha=item.Fecha;

                    modelo.Fecha = fecha.ToString("dd-MM-yyyy");
                    modelo.IdReporte = item.IdReporte;
                    modelo.Cedula = item.Cedula;
                    ListaReportes.Add(modelo);
                }
                return View(ListaReportes);


            }catch(Exception ex){
                throw;
            }
            
        }
        public ActionResult GenerarReporte(string id)
        {
            try
            {
                clsReporte reporte = new clsReporte();
                List<ReporteInfoResult> info = reporte.ReporteInfo(int.Parse(id));
                JArray arreglo = JArray.Parse(JsonConvert.SerializeObject(info)); 
                //JArray hist = JArray.Parse(reporte.HistReporte(int.Parse(id)));
                //JArray proy = JArray.Parse(reporte.ProyReporte(int.Parse(id)));

                

                ReportViewer reportViewer = new ReportViewer();
                reportViewer.ProcessingMode = ProcessingMode.Local;
                reportViewer.SizeToReportContent = true;
                reportViewer.Width = Unit.Percentage(100);
                reportViewer.Height = Unit.Percentage(100);
                reportViewer.ZoomMode = ZoomMode.Percent;
                reportViewer.ZoomPercent = 150;
                reportViewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"Reports\ReporteConsulta.rdlc";
                List<ReportParameter> Parametros = new List<ReportParameter>();
                foreach (var item in info)
                {
                    
                    Parametros.Add(new ReportParameter("Potencia", (item.Potencia).ToString(), true));
                    Parametros.Add(new ReportParameter("ConsumoBajodeT", (item.ConsumoBajo).ToString(), true));
                    Parametros.Add(new ReportParameter("Autoconsumo", (item.AutoConsumo).ToString(), true));
                    Parametros.Add(new ReportParameter("PorcentajeConsumoCubierto", (item.ConsumoAbierto).ToString(), true));
                    Parametros.Add(new ReportParameter("Almacenamiento", (item.Almacenamiento).ToString(), true));
                    Parametros.Add(new ReportParameter("ProduccionAnual", (item.Produccion).ToString(), true));
                    Parametros.Add(new ReportParameter("CostoWatt", (item.CostoWatt).ToString(), true));
                    Parametros.Add(new ReportParameter("Compania", (item.Compania).ToString(), true));
                    Parametros.Add(new ReportParameter("Area", (item.Area).ToString(), true));
                    Parametros.Add(new ReportParameter("Paneles", (item.Paneles).ToString(), true));
                    Parametros.Add(new ReportParameter("RetornoSimple", (item.RetornoSimple).ToString(), true));
                    Parametros.Add(new ReportParameter("AhorroAnualPromedio", (item.AhorroAnual).ToString(), true));
                }

                //reportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", data));

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
                ViewBag.ReportViewer = reportViewer;
                return View();
                


            }
            catch (Exception ex)
            {
                throw;
            }
            return View();
        }

    }
}
