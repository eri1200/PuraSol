using ProyectoPurasol.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using System.Configuration;

namespace ProyectoPurasol.Controllers
{
    public class PrincipalController : Controller
    {
        clsCliente clscliente = new clsCliente();
        // GET: Principal
        public ActionResult Index()
        {
            List<string> ListaBool = new List<string>();
            ListaBool.Add("Sí");
            ListaBool.Add("No");
            List<string> ListaCompania = new List<string>();
            ListaCompania.Add("ICE");
            ListaCompania.Add("CNFL");
            ListaCompania.Add("JASEC");
            ListaCompania.Add("ESPH");
            ListaCompania.Add("COOPELESCA");
            ListaCompania.Add("COOPEGUANACASTE");
            ListaCompania.Add("COOPESANTOS");
            ListaCompania.Add("COOPEALFARORUIZ");
            List<string> ListaTipoTarifa = new List<string>();
            ListaTipoTarifa.Add("T-RE");
            ListaTipoTarifa.Add("T-CO/IN");
            ListaTipoTarifa.Add("T-CS");
            ListaTipoTarifa.Add("T-MT");

            ViewBag.Bool = ListaBool;
            ViewBag.Compania = ListaCompania;
            ViewBag.Tarifa = ListaTipoTarifa;


            return View();
        }

        [HttpPost]
        public ActionResult Index(Principal principal)
        {
            try
            {
                List<string> ListaBool = new List<string>();
                ListaBool.Add("Sí");
                ListaBool.Add("No");
                List<string> ListaCompania = new List<string>();
                ListaCompania.Add("ICE");
                ListaCompania.Add("CNFL");
                ListaCompania.Add("JASEC");
                ListaCompania.Add("ESPH");
                ListaCompania.Add("COOPELESCA");
                ListaCompania.Add("COOPEGUANACASTE");
                ListaCompania.Add("COOPESANTOS");
                ListaCompania.Add("COOPEALFARORUIZ");
                List<string> ListaTipoTarifa = new List<string>();
                ListaTipoTarifa.Add("T-RE");
                ListaTipoTarifa.Add("T-CO/IN");
                ListaTipoTarifa.Add("T-CS");
                ListaTipoTarifa.Add("T-MT");


                var cliente = clscliente.ConsultaCliente(int.Parse(principal.Identificacion)).Select(x => new { ID = x.Correo });

                foreach (var obj in cliente)
                {
                    Session["CORREOCLIENTE"] = obj.ID;
                }
                ViewBag.Bool = ListaBool;
                ViewBag.Compania = ListaCompania;
                ViewBag.Tarifa = ListaTipoTarifa;

                string Nombre = principal.Nombre;
                string Compania = principal.Compania;
                string Tarifa = principal.Tarifa;
                string Microred = principal.Microred;

                switch (Tarifa)
                {
                    case "T-RE":
                        return View("CotizarRes");
                        break;
                    case "T-CO/IN":
                        return View("CotizarCom");
                        break;
                    case "T-MT":
                        if (principal.Microred=="Sí")
                        {
                            return View("CotizarmicroTMT");
                        }
                        else
                        {
                            return View("CotizarTMT");
                        }
                        break;
                    default:
                        return View();
                        break;

                }
            }
            catch
            {
                return View();
            }
        }

        public ActionResult CotizarRes()
        {
            List<SelectListItem> ListaNombre = new List<SelectListItem>();
            ListaNombre.AddRange(new[] { new SelectListItem() { Text = "Si", Value = "Si" }, new SelectListItem() { Text = "No", Value = "No" } });
            ViewBag.Bool = ListaNombre;


            //List<string> ListaBool = new List<string>();
            //ListaBool.Add("Sí");
            //ListaBool.Add("No");
            List<string> ListaCompania = new List<string>();
            ListaCompania.Add("ICE");
            ListaCompania.Add("CNFL");
            ListaCompania.Add("JASEC");
            ListaCompania.Add("ESPH");
            ListaCompania.Add("COOPELESCA");
            ListaCompania.Add("COOPEGUANACASTE");
            ListaCompania.Add("COOPESANTOS");
            ListaCompania.Add("COOPEALFARORUIZ");
            List<string> ListaTipoTarifa = new List<string>();
            ListaTipoTarifa.Add("T-RE");
            ListaTipoTarifa.Add("T-CO/IN");
            ListaTipoTarifa.Add("T-CS");
            List<string> ListaMantenimiento = new List<string>();
            ListaMantenimiento.Add("No");
            ListaMantenimiento.Add("GAM");
            ListaMantenimiento.Add("GAM+100km");
            ListaMantenimiento.Add("GAM+250km");
            ListaMantenimiento.Add("GAM+350km");
            List<string> ListaTecnologia = new List<string>();
            ListaTecnologia.Add("Microinversor");
            ListaTecnologia.Add("Optimizadores");
            ListaTecnologia.Add("Centralizado");
            ListaTecnologia.Add("Acople DC");
            ListaTecnologia.Add("Acople AC");

            //ViewBag.Bool = ListaBool;
            ViewBag.Compania = ListaCompania;
            ViewBag.Tarifa = ListaTipoTarifa;
            ViewBag.Mant = ListaMantenimiento;
            ViewBag.Tec = ListaTecnologia;

            return View();
        }

        [HttpPost]
        public ActionResult CotizarRes(Principal principal)
        {
            List<SelectListItem> ListaNombre = new List<SelectListItem>();
            ListaNombre.AddRange(new[] { new SelectListItem() { Text = "Si", Value = "Si" }, new SelectListItem() { Text = "No", Value = "No" } });
            ViewBag.Bool = ListaNombre;
            List<string> ListaCompania = new List<string>();
            ListaCompania.Add("ICE");
            ListaCompania.Add("CNFL");
            ListaCompania.Add("JASEC");
            ListaCompania.Add("ESPH");
            ListaCompania.Add("COOPELESCA");
            ListaCompania.Add("COOPEGUANACASTE");
            ListaCompania.Add("COOPESANTOS");
            ListaCompania.Add("COOPEALFARORUIZ");
            List<string> ListaTipoTarifa = new List<string>();
            ListaTipoTarifa.Add("T-RE");
            ListaTipoTarifa.Add("T-CO/IN");
            ListaTipoTarifa.Add("T-CS");
            List<string> ListaMantenimiento = new List<string>();
            ListaMantenimiento.Add("No");
            ListaMantenimiento.Add("GAM");
            ListaMantenimiento.Add("GAM+100km");
            ListaMantenimiento.Add("GAM+250km");
            ListaMantenimiento.Add("GAM+350km");
            List<string> ListaTecnologia = new List<string>();
            ListaTecnologia.Add("Microinversor");
            ListaTecnologia.Add("Optimizadores");
            ListaTecnologia.Add("Centralizado");
            ListaTecnologia.Add("Acople DC");
            ListaTecnologia.Add("Acople AC");

            
            ViewBag.Compania = ListaCompania;
            ViewBag.Tarifa = ListaTipoTarifa;
            ViewBag.Mant = ListaMantenimiento;
            ViewBag.Tec = ListaTecnologia;
            try
            {

                clsDatosPrincipalesRes principales = new clsDatosPrincipalesRes();
                List<BLL.Models.Reporte> reporte=principales.asignarPrincipales(principal.Nombre, principal.Compania, principal.Tarifa, principal.TechoDisponible, principal.HorasRespaldo, principal.TipoCambio, principal.PotenciaPanel,
                    principal.CostoUnitarioFijo, principal.CostoUnitarioFijoValor, principal.TamanoFijo, principal.TamanoFijoValor, principal.CostoMantenimiento, principal.CrecimientoAnual, principal.Tecnologia,
                    principal.PREne, principal.PRFeb, principal.PRMar, principal.PRAbr, principal.PRMay, principal.PRJun, principal.PRJul, principal.PRAgo, principal.PRSep, principal.PROct, principal.PRNov, principal.PRDic,
                    principal.RSGISEne, principal.RSGISFeb, principal.RSGISMar, principal.RSGISAbr, principal.RSGISMay, principal.RSGISJun, principal.RSGISJul, principal.RSGISAgo, principal.RSGISSep, principal.RSGISOct,
                    principal.RSGISNov, principal.RSGISDic);

                var cliente = clscliente.ConsultaCliente(int.Parse(principal.Identificacion)).Select(x => new { ID = x.Correo });

                foreach (var obj in cliente)
                {
                    Session["CORREOCLIENTE"] = obj.ID;
                }

               

                Session["DatosReporte"] = reporte;

                return RedirectToAction("ReporteExtra","Reporte");
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
                return View();
            }
        }

        public ActionResult CotizarCom()
        {
            List<string> ListaBool = new List<string>();
            ListaBool.Add("Sí");
            ListaBool.Add("No");
            List<string> ListaCompania = new List<string>();
            ListaCompania.Add("ICE");
            ListaCompania.Add("CNFL");
            ListaCompania.Add("JASEC");
            ListaCompania.Add("ESPH");
            ListaCompania.Add("COOPELESCA");
            ListaCompania.Add("COOPEGUANACASTE");
            ListaCompania.Add("COOPESANTOS");
            ListaCompania.Add("COOPEALFARORUIZ");
            List<string> ListaTipoTarifa = new List<string>();
            ListaTipoTarifa.Add("T-CO/IN");
            ListaTipoTarifa.Add("T-CS");
            List<string> ListaMantenimiento = new List<string>();
            ListaMantenimiento.Add("No");
            ListaMantenimiento.Add("GAM");
            ListaMantenimiento.Add("GAM+100km");
            ListaMantenimiento.Add("GAM+250km");
            ListaMantenimiento.Add("GAM+350km");
            List<string> ListaTecnologia = new List<string>();
            ListaTecnologia.Add("Microinversor");
            ListaTecnologia.Add("Optimizadores");
            ListaTecnologia.Add("Centralizado");
            ListaTecnologia.Add("Acople DC");
            ListaTecnologia.Add("Acople AC");

            ViewBag.Bool = ListaBool;
            ViewBag.Compania = ListaCompania;
            ViewBag.Tarifa = ListaTipoTarifa;
            ViewBag.Mant = ListaMantenimiento;
            ViewBag.Tec = ListaTecnologia;

            return View();
        }

        [HttpPost]
        public ActionResult CotizarCom(Principal principal)
        {
            try
            {
                clsDatosPrincipalesCom principales = new clsDatosPrincipalesCom();
                principales.asignarPrincipales(principal.Nombre, principal.Compania, principal.Tarifa, principal.TechoDisponible, principal.TipoCambio, principal.PotenciaPanel, principal.CostoUnitarioFijo, 
                    principal.CostoUnitarioFijoValor, principal.TamanoFijo, principal.TamanoFijoValor, principal.CostoMantenimiento, principal.CrecimientoAnual, principal.Tecnologia,
                    principal.PREne, principal.PRFeb, principal.PRMar, principal.PRAbr, principal.PRMay, principal.PRJun, principal.PRJul, principal.PRAgo, principal.PRSep, principal.PROct, principal.PRNov, principal.PRDic,
                    principal.PDEne, principal.PDFeb, principal.PDMar, principal.PDAbr, principal.PDMay, principal.PDJun, principal.PDJul, principal.PDAgo, principal.PDSep, principal.PDOct, principal.PDNov, principal.PDDic,
                    principal.RSGISEne, principal.RSGISFeb, principal.RSGISMar, principal.RSGISAbr, principal.RSGISMay, principal.RSGISJun, principal.RSGISJul, principal.RSGISAgo, principal.RSGISSep, principal.RSGISOct,
                    principal.RSGISNov, principal.RSGISDic, principal.UnificacionMenor3000, principal.CeroInyeccion, principal.TasaFinanciamiento, principal.Prima, principal.Plazo);

                var cliente = clscliente.ConsultaCliente(int.Parse(principal.Identificacion)).Select(x => new { ID = x.Correo });

                foreach (var obj in cliente)
                {
                    Session["CORREOCLIENTE"] = obj.ID;
                }
                List<string> ListaBool = new List<string>();
                ListaBool.Add("Sí");
                ListaBool.Add("No");
                List<string> ListaCompania = new List<string>();
                ListaCompania.Add("ICE");
                ListaCompania.Add("CNFL");
                ListaCompania.Add("JASEC");
                ListaCompania.Add("ESPH");
                ListaCompania.Add("COOPELESCA");
                ListaCompania.Add("COOPEGUANACASTE");
                ListaCompania.Add("COOPESANTOS");
                ListaCompania.Add("COOPEALFARORUIZ");
                List<string> ListaTipoTarifa = new List<string>();
                ListaTipoTarifa.Add("T-CO/IN");
                ListaTipoTarifa.Add("T-CS");
                List<string> ListaMantenimiento = new List<string>();
                ListaMantenimiento.Add("No");
                ListaMantenimiento.Add("GAM");
                ListaMantenimiento.Add("GAM+100km");
                ListaMantenimiento.Add("GAM+250km");
                ListaMantenimiento.Add("GAM+350km");
                List<string> ListaTecnologia = new List<string>();
                ListaTecnologia.Add("Microinversor");
                ListaTecnologia.Add("Optimizadores");
                ListaTecnologia.Add("Centralizado");
                ListaTecnologia.Add("Acople DC");
                ListaTecnologia.Add("Acople AC");

                ViewBag.Bool = ListaBool;
                ViewBag.Compania = ListaCompania;
                ViewBag.Tarifa = ListaTipoTarifa;
                ViewBag.Mant = ListaMantenimiento;
                ViewBag.Tec = ListaTecnologia;

                
                Session["PRINCIPAL"] = principal;
                return RedirectToAction("ReporteExtra","Reporte");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult CotizarTMT()
        {
            List<string> ListaBool = new List<string>();
            ListaBool.Add("Sí");
            ListaBool.Add("No");
            List<string> ListaCompania = new List<string>();
            ListaCompania.Add("ICE");
            ListaCompania.Add("CNFL");
            ListaCompania.Add("JASEC");
            ListaCompania.Add("ESPH");
            ListaCompania.Add("COOPELESCA");
            ListaCompania.Add("COOPEGUANACASTE");
            ListaCompania.Add("COOPESANTOS");
            ListaCompania.Add("COOPEALFARORUIZ");
            List<string> ListaTipoTarifa = new List<string>();
            ListaTipoTarifa.Add("T-MT");
            List<string> ListaMantenimiento = new List<string>();
            ListaMantenimiento.Add("No");
            ListaMantenimiento.Add("GAM");
            ListaMantenimiento.Add("GAM+100km");
            ListaMantenimiento.Add("GAM+250km");
            ListaMantenimiento.Add("GAM+350km");
            List<string> ListaTecnologia = new List<string>();
            ListaTecnologia.Add("Microinversor");
            ListaTecnologia.Add("Optimizadores");
            ListaTecnologia.Add("Centralizado");
            ListaTecnologia.Add("Acople DC");
            ListaTecnologia.Add("Acople AC");

            ViewBag.Bool = ListaBool;
            ViewBag.Compania = ListaCompania;
            ViewBag.Tarifa = ListaTipoTarifa;
            ViewBag.Mant = ListaMantenimiento;
            ViewBag.Tec = ListaTecnologia;
            return View();
        }

        [HttpPost]
        public ActionResult CotizarTMT(Principal principal)
        {
            try
            {
                clsDatosPrincipalesTMT principales = new clsDatosPrincipalesTMT();
                principales.asignarPrincipales(principal.Nombre,principal.Compania,principal.Tarifa,principal.TechoDisponible,principal.HorasRespaldo,principal.TipoCambio,principal.PotenciaPanel,principal.CostoUnitarioFijo,principal.CostoUnitarioFijoValor,principal.TamanoFijo,principal.TamanoFijoValor,principal.CostoMantenimiento,principal.CrecimientoAnual,principal.Tecnologia,
                    principal.TasaFinanciamiento,principal.Prima,principal.Plazo,principal.PREne,principal.PRFeb,principal.PRMar,principal.PRAbr,principal.PRMay,principal.PRJun,principal.PRJul,principal.PRAgo,principal.PRSep,principal.PROct,principal.PRNov,principal.PRDic,principal.VREne,principal.VRFeb,principal.VRMar,principal.VRAbr,principal.VRMay,principal.VRJun,principal.VRJul,principal.VRAgo,
                    principal.VRSep,principal.VROct,principal.VRNov,principal.VRDic,principal.NREne,principal.NRFeb,principal.NRMar,principal.NRAbr,principal.NRMay,principal.NRJun,principal.NRJul,principal.NRAgo,principal.NRSep,principal.NROct,principal.NRNov,principal.NRDic,principal.PDEne,principal.PDFeb,principal.PDMar,principal.PDAbr,principal.PDMay,principal.PDJun,principal.PDJul,
                    principal.PDAgo,principal.PDSep,principal.PDOct,principal.PDNov,principal.PDDic,principal.VDEne,principal.VDFeb,principal.VDMar,principal.VDAbr,principal.VDMay,principal.VDJun,principal.VDJul,principal.VDAgo,principal.VDSep,principal.VDOct,principal.VDNov,principal.VDDic,principal.NDEne,principal.NDFeb,principal.NDMar,principal.NDAbr,principal.NDMay,principal.NDJun,principal.NDJul,
                    principal.NDAgo,principal.NDSep,principal.NDOct,principal.NDNov,principal.NDDic,principal.RSGISEne,principal.RSGISFeb,principal.RSGISMar,principal.RSGISAbr,principal.RSGISMay,principal.RSGISJun,principal.RSGISJul,principal.RSGISAgo,principal.RSGISSep,principal.RSGISOct,principal.RSGISNov,principal.RSGISDic);

                var cliente = clscliente.ConsultaCliente(int.Parse(principal.Identificacion)).Select(x => new { ID = x.Correo });

                foreach (var obj in cliente)
                {
                    Session["CORREOCLIENTE"] = obj.ID;
                }
                List<string> ListaBool = new List<string>();
                ListaBool.Add("Sí");
                ListaBool.Add("No");
                List<string> ListaCompania = new List<string>();
                ListaCompania.Add("ICE");
                ListaCompania.Add("CNFL");
                ListaCompania.Add("JASEC");
                ListaCompania.Add("ESPH");
                ListaCompania.Add("COOPELESCA");
                ListaCompania.Add("COOPEGUANACASTE");
                ListaCompania.Add("COOPESANTOS");
                ListaCompania.Add("COOPEALFARORUIZ");
                List<string> ListaTipoTarifa = new List<string>();
                ListaTipoTarifa.Add("T-MT");
                List<string> ListaMantenimiento = new List<string>();
                ListaMantenimiento.Add("No");
                ListaMantenimiento.Add("GAM");
                ListaMantenimiento.Add("GAM+100km");
                ListaMantenimiento.Add("GAM+250km");
                ListaMantenimiento.Add("GAM+350km");
                List<string> ListaTecnologia = new List<string>();
                ListaTecnologia.Add("Microinversor");
                ListaTecnologia.Add("Optimizadores");
                ListaTecnologia.Add("Centralizado");
                ListaTecnologia.Add("Acople DC");
                ListaTecnologia.Add("Acople AC");

                ViewBag.Bool = ListaBool;
                ViewBag.Compania = ListaCompania;
                ViewBag.Tarifa = ListaTipoTarifa;
                ViewBag.Mant = ListaMantenimiento;
                ViewBag.Tec = ListaTecnologia;


                return View();
            }
            catch
            {
                return View();
            }
        }

        public ActionResult CotizarMTMT()
        {
            List<string> ListaBool = new List<string>();
            ListaBool.Add("Sí");
            ListaBool.Add("No");
            List<string> ListaCompania = new List<string>();
            ListaCompania.Add("ICE");
            ListaCompania.Add("CNFL");
            ListaCompania.Add("JASEC");
            ListaCompania.Add("ESPH");
            ListaCompania.Add("COOPELESCA");
            ListaCompania.Add("COOPEGUANACASTE");
            ListaCompania.Add("COOPESANTOS");
            ListaCompania.Add("COOPEALFARORUIZ");
            List<string> ListaTipoTarifa = new List<string>();
            ListaTipoTarifa.Add("T-MT");
            List<string> ListaMantenimiento = new List<string>();
            ListaMantenimiento.Add("No");
            ListaMantenimiento.Add("GAM");
            ListaMantenimiento.Add("GAM+100km");
            ListaMantenimiento.Add("GAM+250km");
            ListaMantenimiento.Add("GAM+350km");
            List<string> ListaTecnologia = new List<string>();
            ListaTecnologia.Add("Microinversor");
            ListaTecnologia.Add("Optimizadores");
            ListaTecnologia.Add("Centralizado");
            ListaTecnologia.Add("Acople DC");
            ListaTecnologia.Add("Acople AC");

            ViewBag.Bool = ListaBool;
            ViewBag.Compania = ListaCompania;
            ViewBag.Tarifa = ListaTipoTarifa;
            ViewBag.Mant = ListaMantenimiento;
            ViewBag.Tec = ListaTecnologia;

            return View();
        }

        [HttpPost]
        public ActionResult CotizarMTMT(Principal principal)
        {
            try
            {
                clsDatosPrincipalesmicroTMT principales = new clsDatosPrincipalesmicroTMT();
                principales.asignarPrincipales(principal.Nombre, principal.Compania, principal.Tarifa, principal.TechoDisponible, principal.TipoCambio, principal.PotenciaPanel, principal.CostoUnitarioFijo, principal.CostoUnitarioFijoValor, principal.TamanoFijo, principal.TamanoFijoValor,
                     principal.Microred, principal.Conversor, principal.AlmacenamientoFijo, principal.CostoMantenimiento, principal.CrecimientoAnual, principal.Tecnologia, principal.TasaFinanciamiento, principal.Prima, principal.Plazo, principal.PREne, principal.PRFeb, principal.PRMar, principal.PRAbr,
                     principal.PRMay, principal.PRJun, principal.PRJul, principal.PRAgo, principal.PRSep, principal.PROct, principal.PRNov, principal.PRDic, principal.VREne, principal.VRFeb, principal.VRMar, principal.VRAbr, principal.VRMay, principal.VRJun, principal.VRJul, principal.VRAgo, principal.VRSep,
                     principal.VROct, principal.VRNov, principal.VRDic, principal.NREne, principal.NRFeb, principal.NRMar, principal.NRAbr, principal.NRMay, principal.NRJun, principal.NRJul, principal.NRAgo, principal.NRSep, principal.NROct, principal.NRNov, principal.NRDic, principal.PDEne, principal.PDFeb,
                     principal.PDMar, principal.PDAbr, principal.PDMay, principal.PDJun, principal.PDJul, principal.PDAgo, principal.PDSep, principal.PDOct, principal.PDNov, principal.PDDic, principal.VDEne, principal.VDFeb, principal.VDMar, principal.VDAbr, principal.VDMay, principal.VDJun, principal.VDJul,
                     principal.VDAgo, principal.VDSep, principal.VDOct, principal.VDNov, principal.VDDic, principal.NDEne, principal.NDFeb, principal.NDMar, principal.NDAbr, principal.NDMay, principal.NDJun, principal.NDJul, principal.NDAgo, principal.NDSep, principal.NDOct, principal.NDNov, principal.NDDic,
                     principal.RSGISEne, principal.RSGISFeb, principal.RSGISMar, principal.RSGISAbr, principal.RSGISMay, principal.RSGISJun, principal.RSGISJul, principal.RSGISAgo, principal.RSGISSep, principal.RSGISOct, principal.RSGISNov, principal.RSGISDic);


                var cliente = clscliente.ConsultaCliente(int.Parse(principal.Identificacion)).Select(x => new { ID = x.Correo });

                foreach (var obj in cliente)
                {
                    Session["CORREOCLIENTE"] = obj.ID;
                }
                List<string> ListaBool = new List<string>();
                ListaBool.Add("Sí");
                ListaBool.Add("No");
                List<string> ListaCompania = new List<string>();
                ListaCompania.Add("ICE");
                ListaCompania.Add("CNFL");
                ListaCompania.Add("JASEC");
                ListaCompania.Add("ESPH");
                ListaCompania.Add("COOPELESCA");
                ListaCompania.Add("COOPEGUANACASTE");
                ListaCompania.Add("COOPESANTOS");
                ListaCompania.Add("COOPEALFARORUIZ");
                List<string> ListaTipoTarifa = new List<string>();
                ListaTipoTarifa.Add("T-MT");
                List<string> ListaMantenimiento = new List<string>();
                ListaMantenimiento.Add("No");
                ListaMantenimiento.Add("GAM");
                ListaMantenimiento.Add("GAM+100km");
                ListaMantenimiento.Add("GAM+250km");
                ListaMantenimiento.Add("GAM+350km");
                List<string> ListaTecnologia = new List<string>();
                ListaTecnologia.Add("Microinversor");
                ListaTecnologia.Add("Optimizadores");
                ListaTecnologia.Add("Centralizado");
                ListaTecnologia.Add("Acople DC");
                ListaTecnologia.Add("Acople AC");

                ViewBag.Bool = ListaBool;
                ViewBag.Compania = ListaCompania;
                ViewBag.Tarifa = ListaTipoTarifa;
                ViewBag.Mant = ListaMantenimiento;
                ViewBag.Tec = ListaTecnologia;


                return View();
            }
            catch
            {
                return View();
            }
        }
    }

}