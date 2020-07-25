using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoPurasol.Models
{
    public class Cliente //se crea la clase cliente
    {
        [Required]
        public int IdCliente { get; set; }  //se tienen los constructores del IdCliente

        [Required]
        public string Identificacion { get; set; } //se tienen los constructores del Identificacion

        [Required]
        public string Nombre { get; set; } //se tienen los constructores del Nombre

        [Required]
        public string Apellido { get; set; } //se tienen los constructores del Apellido


        [Required]
        public string Correo { get; set; } //se tienen los constructores del Correo

        [Required]
        public string Telefono { get; set; } //se tienen los constructores del Telefono

        [Required]
        public string Provincia { get; set; } //se tienen los constructores de la Provincia

        [Required]
        public string Canton { get; set; } //se tienen los constructores del Canton

        [Required]
        public string Distrito { get; set; } //se tienen los constructores del Distrito



    }
}