﻿using System;
using System.Collections.Generic;
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
        public double SOLARGISEnero { get; set; }
        [Required]
        public double SOLARGISFebrero { get; set; }
        [Required]
        public double SOLARGISMarzo { get; set; }
        [Required]
        public double SOLARGISAbril { get; set; }
        [Required]
        public double SOLARGISMayo { get; set; }
        [Required]
        public double SOLARGISJunio { get; set; }
        [Required]
        public double SOLARGISJulio { get; set; }
        [Required]
        public double SOLARGISAgosto { get; set; }
        [Required]
        public double SOLARGISSetiembre { get; set; }
        [Required]
        public double SOLARGISOctubre { get; set; }
        [Required]
        public double SOLARGISNoviembre { get; set; }
        [Required]
        public double SOLARGISDiciembre { get; set; }


    }
}