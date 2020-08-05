using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoPurasol.Models
{
    public class Electrodomestico
    {

        public string Electro { get; set; }
        public int Cantidad { get; set; }
        public bool Uso { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFinal { get; set; }
        public string Dia { get; set; }
        public Electrodomestico() { }
    }
}