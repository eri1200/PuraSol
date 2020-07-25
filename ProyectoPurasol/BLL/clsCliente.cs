using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class clsCliente //cCreación de clase Cliente
    {
        public List<ListaClientesResult> ConsultarClientes() //Lista de Clientes
        {
            try 
            {
                DatosDataContext dc = new DatosDataContext(); //Instancia de Base de Datos
                List<ListaClientesResult> data = dc.ListaClientes().ToList(); //Guardar el objeto en una lista
                return data; //devolver el objeto
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public List<SeleccionarClienteResult> ConsultaCliente(int Codigo) //Consultar cliente, por medio del código 
        {
            try
            {
                DatosDataContext dc = new DatosDataContext(); //Instancia de Base de Datos
                List<SeleccionarClienteResult> data = dc.SeleccionarCliente(Codigo).ToList(); //Seleccionar al cliente por medio del código y guardarlo en una lista
                return data; //devolver el cliente.
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        //Agregar Cliente y su información como nombre, identificación,apellidos, correo, telefono, distrito, canton, provincia
        public bool AgregarCliente(string cedula, string Nombre, string Apellido1, string Correo, int Telefono,  int Distrito, int Canton, int Provincia) 
        {
            try
            {
                int Identificacion =Convert.ToInt32(cedula);
                int respuesta = 1; 
                DatosDataContext dc = new DatosDataContext(); //Instancia Base de Datos
                respuesta = Convert.ToInt32(dc.CrearActualizarCliente( Identificacion, Nombre,Apellido1, Telefono, Correo, Distrito,Provincia,Canton)); //Convertir la información del cliente a un entero.

                if (respuesta==0) //si la respuesta es cero
                {
                    return true; //guardar la información
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }
        }
        //Actualizar Cliente y su información como nombre, identificación,apellidos, correo, telefono, distrito, canton, provincia

        public bool ActualizarCliente(string cedula, string Nombre, string Apellido1, string Correo, int Telefono, int Distrito, int Canton, int Provincia) 
        {
            try
            {
                int Identificacion = Convert.ToInt32(cedula);
                int respuesta = 1;
                DatosDataContext dc = new DatosDataContext(); //Instancia Base de Datos
                respuesta = Convert.ToInt32(dc.CrearActualizarCliente(Identificacion, Nombre, Apellido1, Telefono, Correo, Distrito, Provincia, Canton)); //Convertir la información del cliente a un entero.
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
        public bool EliminarCliente(int IdCliente) //Método Eliminar Cliente, se recibe de párametro el IdCliente.
        {
            try
            {
                DatosDataContext dc = new DatosDataContext(); //Instanciar Base de Datos.
                int respuesta = dc.EliminarCliente(IdCliente); //eliminar el cliente en la base de datos.
                if(respuesta==0){
                    return true; //Se elimina en la base de datos.
                }
                else
                {
                    return false; //Se elimina en la base de datos.
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
