using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoPurasol.Models
{
    public class PrincipalTMT
    {
        [Required]
        [DisplayName("Nombre Cliente")]
        public string Nombrecliente { get; set; }
        [Required]
        [DisplayName("Compañia")]
        public string Compania { get; set; }
        [Required]
        [DisplayName("Tarifa")]
        public string Tarifa { get; set; }
        [Required]
        [DisplayName("Techo Disponible")]
        public double TechoDisponible { get; set; }
        [Required]
        [DisplayName("Tipo de Cambio")]
        public double TipoCambio { get; set; }
        [Required]
        [DisplayName("Potencia Panel")]
        public double PotenciaPanel { get; set; }
        [Required]
        [DisplayName("Costo Unitario Fijo")]
        public string CostoUnitarioFijo { get; set; }
        [Required]
        [DisplayName("Costo Fijo Valor")]
        public string CostoUnitarioFijoValor { get; set; }
        [Required]
        [DisplayName("Tamaño Fijo")]
        public string TamanoFijo { get; set; }
        [Required]
        [DisplayName("Tamaño Fijo")]
        public double TamanoFijoValor { get; set; }
        [Required]
        [DisplayName("Costo Mantenimiento")]
        public string CostoMantenimiento { get; set; }
        [Required]
        [DisplayName("Crecimiento Anual")]
        public double CrecimientoAnual { get; set; }
        [Required]
        [DisplayName("Tacnología")]
        public string Tecnologia { get; set; }
        [Required]
        [DisplayName("Tasa Financiamiento")]
        public double TasaFinanciamiento { get; set; }

       
        public double Prima { get; set; }
        public double Plazo { get; set; }
        [Required]
        [DisplayName("Punta Recibo Enero")]
        public double PREne { get; set; }
        [Required]
        [DisplayName("Punta Recibo Febrero")]
        public double PRFeb { get; set; }
        public double PRMar { get; set; }
        public double PRAbr { get; set; }
        public double PRMay { get; set; }
        public double PRJun { get; set; }
        public double PRJul { get; set; }
        public double PRAgo { get; set; }
        public double PRSep { get; set; }
        public double PROct { get; set; }
        public double PRNov { get; set; }
        public double PRDic { get; set; }
        public double VREne { get; set; }
        public double VRFeb { get; set; }
        public double VRMar { get; set; }
        public double VRAbr { get; set; }
        public double VRMay { get; set; }
        public double VRJun { get; set; }
        public double VRJul { get; set; }
        public double VRAgo { get; set; }
        public double VRSep { get; set; }
        public double VROct { get; set; }
        public double VRNov { get; set; }
        public double VRDic { get; set; }
        public double NREne { get; set; }
        public double NRFeb { get; set; }
        public double NRMar { get; set; }
        public double NRAbr { get; set; }
        public double NRMay { get; set; }
        public double NRJun { get; set; }
        public double NRJul { get; set; }
        public double NRAgo { get; set; }
        public double NRSep { get; set; }
        public double NROct { get; set; }
        public double NRNov { get; set; }
        public double NRDic { get; set; }
        public double PDEne { get; set; }
        public double PDFeb { get; set; }
        public double PDMar { get; set; }
        public double PDAbr { get; set; }
        public double PDMay { get; set; }
        public double PDJun { get; set; }
        public double PDJul { get; set; }
        public double PDAgo { get; set; }
        public double PDSep { get; set; }
        public double PDOct { get; set; }
        public double PDNov { get; set; }
        public double PDDic { get; set; }
        public double VDEne { get; set; }
        public double VDFeb { get; set; }
        public double VDMar { get; set; }
        public double VDAbr { get; set; }
        public double VDMay { get; set; }
        public double VDJun { get; set; }
        public double VDJul { get; set; }
        public double VDAgo { get; set; }
        public double VDSep { get; set; }
        public double VDOct { get; set; }
        public double VDNov { get; set; }
        public double VDDic { get; set; }
        public double NDEne { get; set; }
        public double NDFeb { get; set; }
        public double NDMar { get; set; }
        public double NDAbr { get; set; }
        public double NDMay { get; set; }
        public double NDJun { get; set; }
        public double NDJul { get; set; }
        public double NDAgo { get; set; }
        public double NDSep { get; set; }
        public double NDOct { get; set; }
        public double NDNov { get; set; }
        public double NDDic { get; set; }
        public double RGISEne { get; set; }
        public double RSGISFeb { get; set; }
        public double RSGISMar { get; set; }
        public double RSGISAbr { get; set; }
        public double RSGISEMay { get; set; }
        public double RSGISJun { get; set; }
        public double RSGISJul { get; set; }
        public double RSGISAgo { get; set; }
        public double RSGISSep { get; set; }
        public double RSGISOct { get; set; }
        public double RSGISNov { get; set; }
        public double RSGISDic { get; set; }
    }
}