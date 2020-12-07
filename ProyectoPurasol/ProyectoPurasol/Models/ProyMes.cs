using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoPurasol.Models
{
    public class ProyMes
    {
        public int IdProyeccionMes { get; set; }
        public int IdReporte { get; set; }
        public int IdMes { get; set; }
        public double kWh_tarifa_regular { get; set; }
        public double Cargo { get; set; }
        public double Impuestos { get; set; }
        public double kWh_tarifa_acceso { get; set; }
        
    }
}