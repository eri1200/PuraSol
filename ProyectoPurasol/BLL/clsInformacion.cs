using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class clsInformacion //clase Información.
    {
        public List<ProvinciasResult> ObtenerProvincias() //Se crea la lista de obtener la provincia.
        {
            DatosDataContext db = new DatosDataContext(); //Instanciar la base de datos.
            List <ProvinciasResult> datos = db.Provincias().ToList(); //Se guarda las provincias en una lista.
            return datos; //Se devuelve la información de las provincias.
        }
        public List<CantonesResult> ObtenerCantones(char Provincia) //Método para obtener cantones 
        {
            DatosDataContext db = new DatosDataContext();           //Instanciar la Base de Datos.
            List<CantonesResult> datos = db.Cantones(Provincia).ToList(); //Se guarda los cantones en una lista.
            return datos; //Se devuelve la información de los cantones. 
        }
        public List<DistritosResult> ObtenerDistritos(char Provincia,string Canton) //Método para obtener distritos.
        {
            DatosDataContext db = new DatosDataContext(); //Instanciar la Base de Datos.
            List<DistritosResult> datos = db.Distritos(Provincia,Canton).ToList(); //Se guarda los distritos en una lista.
            return datos; //Se devuelve la información de los distritos.
        }
    }
}
