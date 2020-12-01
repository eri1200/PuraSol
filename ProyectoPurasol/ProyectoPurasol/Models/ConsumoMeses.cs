using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoPurasol.Models
{
    public class ConsumoMeses
    {
        //CONSUMO Meses
        [Required]
        
        public double Enero { get; set; }
        [Required]
        public double Febrero { get; set; }
        [Required]
        public double Marzo { get; set; }
        [Required]
        public double Abril { get; set; }
        [Required]
        public double Mayo { get; set; }
        [Required]
        public double Junio { get; set; }
        [Required]
        public double Julio { get; set; }
        [Required]
        public double Agosto { get; set; }
        [Required]
        public double Setiembre { get; set; }
        [Required]
        public double Octubre { get; set; }
        [Required]
        public double Noviembre { get; set; }
        [Required]
        public double Diciembre { get; set; }

        //CONSUMO Meses SOLARGIS
        [Required]
        [DisplayName("Solargis Mes: ENERO")]
        public double SOLARGISEnero { get; set; }
        [Required]
        [DisplayName("Solargis Mes: FEBRERO")]
        public double SOLARGISFebrero { get; set; }
        [Required]
        [DisplayName("Solargis Mes: MARZO")]
        public double SOLARGISMarzo { get; set; }
        [Required]
        [DisplayName("Solargis Mes: ABRIL")]
        public double SOLARGISAbril { get; set; }
        [Required]
        [DisplayName("Solargis Mes: MAYO")]
        public double SOLARGISMayo { get; set; }
        [Required]
        [DisplayName("Solargis Mes: JUNIO")]
        public double SOLARGISJunio { get; set; }
        [Required]
        [DisplayName("Solargis Mes: JULIO")]
        public double SOLARGISJulio { get; set; }
        [Required]
        [DisplayName("Solargis Mes: AGOSTO")]
        public double SOLARGISAgosto { get; set; }
        [Required]
        [DisplayName("Solargis Mes: SETIEMBRE")]
        public double SOLARGISSetiembre { get; set; }
        [Required]
        [DisplayName("Solargis Mes: OCTUBRE")]
        public double SOLARGISOctubre { get; set; }
        [Required]
        [DisplayName("Solargis Mes: NOVIEMBRE")]
        public double SOLARGISNoviembre { get; set; }
        [Required]
        [DisplayName("Solargis Mes: DICIEMBRE")]
        public double SOLARGISDiciembre { get; set; }


    }
}