using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;


namespace BLL
{
    public class clsUsuario //Clase Usuario
    {
        public List<ExisteUsuarioResult> ConsultarUsuario(string Usuario, string Clave) //Lista para consultar Usuario 
        {
            try
            {
                DatosDataContext dc = new DatosDataContext(); //Instanciar la base de datos.
                List<ExisteUsuarioResult> data = dc.ExisteUsuario(Usuario, Clave).ToList(); //Guardar el usuario en una lista.
                return data; //Guardar la información.
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public List<ConsultarUsuarioResult> ConsultarUsuario(string usuario) //Método para Consultar Usuario 
        {
            try
            {
                DatosDataContext dc = new DatosDataContext(); //Instanciar base de datos.
                List<ConsultarUsuarioResult> data = dc.ConsultarUsuario(usuario).ToList(); //Guardar usuarios en una lista,
                return data; //retornar información.
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public List<ConsultaListaUsuarioResult> ConsultaListaUsuario() //Método Consultar Lista de Usuarios
        {
            try
            {
                DatosDataContext dc = new DatosDataContext(); //Instanciar la base de datos.
                List<ConsultaListaUsuarioResult> data = dc.ConsultaListaUsuario().ToList(); //Guardar usuario en una lista.
                return data; //retonar información.
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public bool AgregarUsuario(string Usuario, string Clave, bool activo, string rol) //Método para agregar usuario, con la información usuario, clave, si esta activo o no, y el rol
        {
            try
            {
                
                DatosDataContext dc = new DatosDataContext(); //Instanciar la Base de datos.
                int respuesta = Convert.ToInt32(dc.AgregarUsuario(Usuario, Clave,activo,rol)); //Convertir la información en Int, para guardarlo.
                if (string.IsNullOrWhiteSpace(rol))
                {
                    respuesta = 1;
                }
                if (respuesta == 0) //Si la respuesta = 0 
                {
                    return true; //se guarda la información.
                }
                else
                {
                    return false; //no se guarda la información.
                }
            }
            catch (Exception ex) //por si hay errores
            {

                throw;
            }
        }

        public bool ExisteUsuario(string Usuario, string Clave) //Método existe usuario, se piden dos parametros el usuario y la clave.
        {
            try
            {
                int respuesta = 1;
                DatosDataContext dc = new DatosDataContext(); //instanciar la Base de datos.
                //respuesta = Convert.ToInt32(dc.ExisteUsuario(Usuario, Clave));

                respuesta = 0;
                if (respuesta == 0) //Si la respuesta es =0 se guarda la información.
                {
                    return true; //se guarda la información.
                }
                else
                {
                    return false; //no se guarda
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public bool ActualizarUsuario(string Usuario, string Clave/*, bool Estado*/)
        {
            try
            {
                int respuesta = 1;
                DatosDataContext dc = new DatosDataContext();
                respuesta = dc.ActualizarUsuario(Usuario, Clave);
                if (respuesta == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool EliminarUsuario(string usuario) //Método eliminar Usuario, se tiene el parametro del usuario
        {
            try
            {
                DatosDataContext dc = new DatosDataContext(); //Instanciar la base de datos.
                dc.EliminarUsuario(usuario); //Se elimina el usuario
                return true; //se elimina efectivamente.
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public List<ObtenerRolResult> ObtenerRol(string usuario)
        {
            try
            {
                DatosDataContext dc = new DatosDataContext();
                List<ObtenerRolResult> data = dc.ObtenerRol(usuario).ToList();
                return data;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}
