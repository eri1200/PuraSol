using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoPurasol.Models
{
    public class Usuario
    {
        public string NombreUsuario { get; set; }
        public bool Activo { get; set; }
        public string Clave { get; set; }

        public string ListaRol { get; set; }
    }
}