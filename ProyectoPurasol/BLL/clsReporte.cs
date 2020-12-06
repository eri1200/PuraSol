using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Newtonsoft.Json;

namespace BLL
{
    public class clsReporte
    {
        public List<ObtenerCompaniasResult> ObtenerCompanias(){
            try
            {
                DatosDataContext data = new DatosDataContext();
                List<ObtenerCompaniasResult> lista = data.ObtenerCompanias().ToList();
                return lista;
            }
            catch(Exception ex)
            {
                 Console.WriteLine(ex);
                throw;
            }
            
        
        }
        public List<ObtenerTarifasResult> ObtenerTarifas()
        {
            try
            {
                DatosDataContext data = new DatosDataContext();
                List<ObtenerTarifasResult> lista = data.ObtenerTarifas().ToList();
                return lista;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }


        }
        public bool CrearReporte(int cliente, string datosHist,string datosProy,string descripcion,double potencia, int paneles,double area,string compania,double costo,double produccion, double almacenamiento
            ,double consumoAbierto, double autoconsumo, double consumobajo, double RetornoSimple, double ahorroAnual)
        {
            try
            {
                DatosDataContext data = new DatosDataContext();
                int repuesta = data.CrearReporte( cliente, datosHist, datosProy,  descripcion,  potencia,  paneles,  area,  compania,  costo,  produccion,  almacenamiento,  consumoAbierto,  autoconsumo,  consumobajo,  RetornoSimple,  ahorroAnual);
                if (repuesta == 0)
                {
                    return true;
                }else
                {
                    return false;
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }


        }
        public List<ConsultarClienteReportesResult> ConsultarClienteReportes(int Cedula)
        {
            try
            {
                DatosDataContext data = new DatosDataContext();
                List<ConsultarClienteReportesResult> lista = data.ConsultarClienteReportes(Cedula).ToList();
                return lista;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }


        }
        public string HistReporte(int reporte)
        {
            try
            {
                DatosDataContext data = new DatosDataContext();
                var hist = data.HistoricoReporte(reporte).ToString();
                return hist;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }


        }
        public string ProyReporte(int reporte)
        {
            try
            {
                DatosDataContext data = new DatosDataContext();
                var proy = data.ProyeccionReporte(reporte).ToString();
                return proy;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }


        }
        public List<ReporteInfoResult> ReporteInfo(int reporte)
        {
            try
            {
                DatosDataContext data = new DatosDataContext();
                List<ReporteInfoResult> info = data.ReporteInfo(reporte).ToList();

                // or
                // var obj = JsonConvert.DeserializeObject<Array<T>>(result)

                return info;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }


        }
    }
}
