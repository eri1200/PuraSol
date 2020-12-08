using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BLL
{
    public class clsDatosPrincipalesCom
    {
        public string Nombrecliente;
        public string Compania;
        public string Tarifa;
        public double TechoDisponible;
        public double HorasRespaldo;
        public double TipoCambio;
        public double PotenciaPanel;
        public string CostoUnitarioFijo;
        public string CostoUnitarioFijoValor;
        public string TamanoFijo;
        public double TamanoFijoValor;
        public string CostoMantenimiento;
        public double CrecimientoAnual;
        public string Tecnologia;
        public double REne;
        public double RFeb;
        public double RMar;
        public double RAbr;
        public double RMay;
        public double RJun;
        public double RJul;
        public double RAgo;
        public double RSep;
        public double ROct;
        public double RNov;
        public double RDic;
        public double DEne;
        public double DFeb;
        public double DMar;
        public double DAbr;
        public double DMay;
        public double DJun;
        public double DJul;
        public double DAgo;
        public double DSep;
        public double DOct;
        public double DNov;
        public double DDic;
        public double RSGISEne;
        public double RSGISFeb;
        public double RSGISMar;
        public double RSGISAbr;
        public double RSGISMay;
        public double RSGISJun;
        public double RSGISJul;
        public double RSGISAgo;
        public double RSGISSep;
        public double RSGISOct;
        public double RSGISNov;
        public double RSGISDic;
        public string UnificacionMenor3000;
        public string CeroInyeccion;
        public double TasaFinanciamiento;
        public double Prima;
        public double Plazo;

        public List<Reporte> asignarPrincipales(string PNombrecliente, string PCompania, string PTarifa, double PTechoDisponible, double PTipoCambio, double PPotenciaPanel, string PCostoUnitarioFijo, string PCostoUnitarioFijoValor, string PTamanoFijo, double PTamanoFijoValor, string PCostoMantenimiento,
            double PCrecimientoAnual, string PTecnologia, 
            double PREne,double PRFeb,double PRMar,double PRAbr,double PRMay,double PRJun,double PRJul,double PRAgo,double PRSep,double PROct,double PRNov,double PRDic,
            double VREne,double VRFeb, double VRMar, double VRAbr, double VRMay, double VRJun, double VRJul, double VRAgo, double VRSep, double VROct, double VRNov, double VRDic,
            double PRSGISEne,double PRSGISFeb,double PRSGISMar,double PRSGISAbr,double PRSGISMay,double PRSGISJun,double PRSGISJul,double PRSGISAgo,double PRSGISSep,double PRSGISOct,double PRSGISNov,double PRSGISDic,
            string PUnificacionMenor3000, string PCeroInyeccion, double TasaFinanciamiento, double Prima, double Plazo)
        {
            Nombrecliente = PNombrecliente;
            Compania = PCompania;
            Tarifa = PTarifa;
            TechoDisponible = PTechoDisponible;
            HorasRespaldo = 0;
            TipoCambio = PTipoCambio;
            PotenciaPanel = PPotenciaPanel;
            CostoUnitarioFijo = PCostoUnitarioFijo;
            CostoUnitarioFijoValor = PCostoUnitarioFijoValor;
            TamanoFijo = PTamanoFijo;
            TamanoFijoValor = PTamanoFijoValor;
            CostoMantenimiento = PCostoMantenimiento;
            CrecimientoAnual = PCrecimientoAnual;
            Tecnologia = PTecnologia;
            UnificacionMenor3000 = PUnificacionMenor3000;
            CeroInyeccion = PCeroInyeccion;
            REne = PREne;
            RFeb = PRFeb;
            RMar = PRMar;
            RAbr = PRAbr;
            RMay = PRMay;
            RJun = PRJun;
            RJul = PRJul;
            RAgo = PRAgo;
            RSep = PRSep;
            ROct = PROct;
            RNov = PRNov;
            RDic = PRDic;
            DEne = VREne;
            DFeb = VRFeb;
            DMar = VRMar;
            DAbr = VRAbr;
            DMay = VRMay;
            DJun = VRJun;
            DJul = VRJul;
            DAgo = VRAgo;
            DSep = VRSep;
            DOct = VROct;
            DNov = VRNov;
            DDic = VRDic;
            RSGISEne = PRSGISEne;
            RSGISFeb = PRSGISFeb;
            RSGISMar = PRSGISMar;
            RSGISAbr = PRSGISAbr;
            RSGISMay = PRSGISMay;
            RSGISJun = PRSGISJun;
            RSGISJul = PRSGISJul;
            RSGISAgo = PRSGISAgo;
            RSGISSep = PRSGISSep;
            RSGISOct = PRSGISOct;
            RSGISNov = PRSGISNov;
            RSGISDic = PRSGISDic;

            double PromedioRecibos = (REne + RFeb + RMar + RAbr + RMay + RJun + RJul + RAgo + RSep + ROct + RNov + RDic)/12;
            double PromediodEMANDA = (DEne + DFeb + DMar + DAbr + DMay + DJun + DJul + DAgo + DSep + DOct + DNov + DDic) / 12;
            double PromedioSGIS = (RSGISEne + RSGISFeb + RSGISMar + RSGISAbr + RSGISMay + RSGISJun + RSGISJul + RSGISAgo + RSGISSep + RSGISOct + RSGISNov + RSGISDic) / 12;


            double AlmacenamientoFijo = 0;
            string Microred = "No";


            try
            {
                clsCConstruida cConstruida = new clsCConstruida();
                bool prueba = cConstruida.calculoCCCom(REne, RFeb, RMar, RAbr, RMay, RJun, RJul, RAgo, RSep, ROct, RNov, RDic,
              DEne, DFeb, DMar, DAbr, DMay, DJun, DJul, DAgo, DSep, DOct, DNov, DDic,
              RSGISEne, RSGISFeb, RSGISMar, RSGISAbr, RSGISMay, RSGISJun, RSGISJul, RSGISAgo, RSGISSep, RSGISOct, RSGISNov, RSGISDic);

                clsCurvasCom curvas = new clsCurvasCom();
                curvas.calcularCurvas(cConstruida, Tecnologia, TamanoFijo, TamanoFijoValor, PotenciaPanel, TechoDisponible, RSGISEne, RSGISFeb, RSGISMar, RSGISAbr, RSGISMay,
                 RSGISJun, RSGISJul, RSGISAgo, RSGISSep, RSGISOct, RSGISNov, RSGISDic, PromedioSGIS);

                clsPreliminares cPrelim = new clsPreliminares();
                cPrelim.calculaTamano(curvas.potSolarRecomendada);

                clsDatos cDatos = new clsDatos();
                List<clsCostosUnitarios> CostosUnitarios = cDatos.calculaCostosUnitarios(PotenciaPanel, PromedioRecibos, HorasRespaldo, Tarifa, AlmacenamientoFijo, Microred, cPrelim);
                clsCostosMant cMant = cDatos.calculaCostosMant(CostoMantenimiento);

                clsCalculosCom cCom = new clsCalculosCom();
                cCom.calculosCom(PREne, PRFeb, PRMar, PRAbr, PRMay, PRJun, PRJul, PRAgo, PRSep, PROct, PRNov, PRDic,
              RSGISEne, RSGISFeb, RSGISMar, RSGISAbr, RSGISMay, RSGISJun, RSGISJul, RSGISAgo, RSGISSep, RSGISOct, RSGISNov, RSGISDic,
              PromedioRecibos, PromedioSGIS, CrecimientoAnual, Compania, Tarifa, curvas, cConstruida.pico, UnificacionMenor3000, CeroInyeccion);

                clsFinanciamiento financiamiento = new clsFinanciamiento();
                List<List<double>> listaFinanciamientos = financiamiento.calcFinanciamientoCom(CostoUnitarioFijo, Convert.ToDouble(CostoUnitarioFijoValor), PromedioRecibos, HorasRespaldo, cPrelim.Tamano, TipoCambio, cCom, CostosUnitarios, cMant);

                cPrelim.calculaCostosCom(cPrelim.Tamano, Tecnologia, TipoCambio, Microred, AlmacenamientoFijo, CostoUnitarioFijo, CostoUnitarioFijoValor, listaFinanciamientos, cCom, CostosUnitarios);

                cCom.calculaResto(cPrelim.costoC, TipoCambio);

                cPrelim.calculaRestoCom(TipoCambio, CostoUnitarioFijo, CostoUnitarioFijoValor, CostoMantenimiento, cCom, cMant);

                clsReporteCurva reporte = new clsReporteCurva();
                var datos =reporte.datosReporteCom(curvas, cPrelim, cCom, AlmacenamientoFijo, Compania, TipoCambio, PPotenciaPanel, PromedioRecibos, HorasRespaldo, financiamiento, cDatos, CeroInyeccion);

                return (List<Reporte>)datos;  //Devuelve al reporte con los datos para que se impriman

            }
            catch (Exception e)
            {

                throw;
            }

        }

    }
}
