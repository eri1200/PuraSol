using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoPurasol.Models
{
    public class Usuario
    {
        [Required]
        public string NombreUsuario { get; set; }
        [Required]
        public bool Activo { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Clave { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Correo { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public string ListaRol { get; set; }
    }
}