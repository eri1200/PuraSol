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
        public double Tarifa { get; set; } //se tienen los constructores del TipoCambio
        [Required]
        public double TechoDisponible { get; set; } //se tienen los constructores del TechoDisponible
        [Required]
        public int HorasRespaldo { get; set; } //se tienen los constructores del TechoDisponible
        [Required]
        public double TipoCambio { get; set; } //se tienen los constructores del TechoDisponible
        [Required]
        public string PotenciadePanel { get; set; } //se tienen los constructores del TechoDisponible
        
        public double CostoUnitarioFijo { get; set; } //se tienen los constructores del TechoDisponible
        
        public int TamanoFijo { get; set; } //se tienen los constructores del TechoDisponible

        
        public double CostosdeMantenimiento { get; set; } //se tienen los constructores del TechoDisponible

        [Required]
        public double CrecimientoAnual { get; set; } //se tienen los constructores del TechoDisponible

        [Required]
        public int NumCotizacion { get; set; } //se tienen los constructores del TechoDisponible

        [Required]
        public string Tecnologia { get; set; } //se tienen los constructores del TechoDisponible


        //ELECTRODOMESTICOS LISTA
        public string electro { get; set; }
        public int Cantidad { get; set; }
        public bool uso { get; set; }
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime HoraInicio { get; set; }
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime HoraFinal { get; set; }
        public string Dia { get; set; }

        public List<Electrodomestico> table{ get; set; }
        public Reporte() { }
}
    




}