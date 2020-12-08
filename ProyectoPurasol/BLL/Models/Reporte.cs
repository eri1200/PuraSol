using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BLL.Models
{
    public class Reporte
    {
        [Required]
        public string Nombre { get; set; } //se tienen los constructores del Nombre
        [Required]
        public string Identificacion { get; set; }//se tienen los constructores de la Identificacion
        [Required]
        [DisplayName("Compañia")]
        public string Compania { get; set; } //se tienen los constructores de la Compañia
        [Required]
        [DisplayName("Descripción")]
        public string Descripcion { get; set; } //se tienen los constructores de la Descripción
        [Required]
        public decimal Tarifa { get; set; } //se tienen los constructores del TipoCambio
        [Required]
        [DisplayName("Techo disponible")]
        public decimal TechoDisponible { get; set; } //se tienen los constructores del TechoDisponible
        [Required]
        [DisplayName("Horas de respaldo")]
        public decimal HorasRespaldo { get; set; } //se tienen los constructores del TechoDisponible
        [Required]
        [DisplayName("Tipo de cambio")]
        public decimal TipoCambio { get; set; } //se tienen los constructores del TechoDisponible
        [Required]
        [DisplayName("Potencia del panel")]
        public string PotenciadePanel { get; set; } //se tienen los constructores del TechoDisponible
        [Required]
        [DisplayName("Costo unitario fijo")]
        public decimal CostoUnitarioFijo { get; set; } //se tienen los constructores del TechoDisponible

        [Required]
        [DisplayName("Tamaño fijo")]
        public decimal TamanoFijo { get; set; } //se tienen los constructores del TechoDisponible

        [Required]
        [DisplayName("Costo de mantenimiento")]
        public decimal CostosdeMantenimiento { get; set; } //se tienen los constructores del TechoDisponible

        [Required]
        [DisplayName("Crecimiento anual")]
        public decimal CrecimientoAnual { get; set; } //se tienen los constructores del TechoDisponible

        [Required]
        [DisplayName("Numero de cotización")]
        public decimal NumCotizacion { get; set; } //se tienen los constructores del TechoDisponible

        [Required]
        [DisplayName("Tecnología")]
        public string Tecnologia { get; set; } //se tienen los constructores del TechoDisponible
        [Required]
        [DisplayName("Tecnología")]
        public string CantidadPaneles { get; set; } //se tienen los constructores del TechoDisponible
        public string Area { get; set; }

        public string CostoPorWatt { get; set; }
        public string ProduccionAnual { get; set; }
        public string Almacenamiento { get; set; }

        public string consumoCubiertoPct { get; set; }
        public string autoconsumo { get; set; }

        public string consumoTA { get; set; }

        public string retornoSimple { get; set; }
        public string ahorroaAnualesAvg { get; set; }

        public string TRhistAnual { get; set; }
        public string ChistAnual { get; set; }

        public string IhistAnual { get; set; }
        public string TRproyAnual { get; set; }

        public string TAproyAnual { get; set; }

        public string CproyAnual { get; set; }
        public string IproyAnual { get; set; }

        public List<HistFacturas> histFact = new List<HistFacturas>();


        public List<ProyFactura> proyFact = new List<ProyFactura>();





        //ELECTRODOMESTICOS LISTA
        //public string electro { get; set; }
        //public decimal Cantidad { get; set; }
        //public bool uso { get; set; }
        //[DataType(DataType.Time)]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        //public DateTime HoraInicio { get; set; }
        //[DataType(DataType.Time)]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        //public DateTime HoraFinal { get; set; }
        //public string Dia { get; set; }

        //public List<Electrodomestico> table{ get; set; }
        public Reporte() { }
}
    




}