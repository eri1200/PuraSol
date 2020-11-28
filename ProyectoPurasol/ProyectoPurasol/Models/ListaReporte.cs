using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoPurasol.Models
{
    public class ListaReporte
    {
        public int IdReporte { get; set; }
        public string Fecha { get; set; }
        public string Nombre { get; set; }
        public int Cedula { get; set; }
    }
}