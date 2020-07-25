using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class clsRol //Clase Rol
    {
        public List<ListaRolesResult> ConsultarRoles() //Método para consultar lista
        {
            try
            {
                DatosDataContext dc = new DatosDataContext(); //Instanciar la Base de datos.
                List<ListaRolesResult> data = dc.ListaRoles().ToList(); //Obtener lista de roles y se guarda en una lista.
                return data; //devolver la información.
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}
