using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

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
    }
}
