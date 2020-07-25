using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoPurasol.Models
{
    public class Reporte
    {
        [Required]
        public string Nombre { get; set; } //se tienen los constructores del Nombre
        [Required]
        public string Compania { get; set; } //se tienen los constructores de la Compañia
        [Required]
        public string Descripcion { get; set; } //se tienen los constructores de la Descripción
        [Required]
        public string TipoCambio { get; set; } //se tienen los constructores del TipoCambio
        [Required]
        public string TechoDisponible { get; set; } //se tienen los constructores del TechoDisponible

    }
}