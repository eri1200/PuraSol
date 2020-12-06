using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BLL
{
    public class clsDatosPrincipalesRes
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


        public List<Reporte> asignarPrincipales(string PNombrecliente,string PCompania,string PTarifa,double PTechoDisponible,double PHorasRespaldo,double PTipoCambio,double PPotenciaPanel,string PCostoUnitarioFijo,
            string PCostoUnitarioFijoValor,string PTamanoFijo,double PTamanoFijoValor,string PCostoMantenimiento,double PCrecimientoAnual,string PTecnologia,double PREne,double PRFeb,double PRMar,
            double PRAbr,double PRMay,double PRJun,double PRJul,double PRAgo,double PRSep,double PROct,double PRNov,double PRDic,double PRSGISEne,double PRSGISFeb,double PRSGISMar,double PRSGISAbr,double PRSGISMay,
            double PRSGISJun,double PRSGISJul,double PRSGISAgo,double PRSGISSep,double PRSGISOct,double PRSGISNov,double PRSGISDic)
        {
            Nombrecliente = PNombrecliente;
            Compania = PCompania;
            Tarifa = PTarifa;
            TechoDisponible = PTechoDisponible;
            HorasRespaldo = PHorasRespaldo;
            TipoCambio = PTipoCambio;
            PotenciaPanel = PPotenciaPanel;
            CostoUnitarioFijo = PCostoUnitarioFijo;
            CostoUnitarioFijoValor = PCostoUnitarioFijoValor;
            TamanoFijo = PTamanoFijo;
            TamanoFijoValor = PTamanoFijoValor;
            CostoMantenimiento = PCostoMantenimiento;
            CrecimientoAnual = PCrecimientoAnual;
            Tecnologia = PTecnologia;
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
            double PromedioSGIS = (RSGISEne + RSGISFeb + RSGISMar + RSGISAbr + RSGISMay + RSGISJun + RSGISJul + RSGISAgo + RSGISSep + RSGISOct + RSGISNov + RSGISDic) / 12;

            try
            {
                clsCConstruida cConstruida = new clsCConstruida();
                bool prueba = cConstruida.calculoCC(REne, RFeb, RMar, RAbr, RMay, RJun, RJul, RAgo, RSep, ROct, RNov, RDic, RSGISEne, RSGISFeb, RSGISMar, RSGISAbr, RSGISMay,
                 RSGISJun, RSGISJul, RSGISAgo, RSGISSep, RSGISOct, RSGISNov, RSGISDic);

                clsCurvasRes curvas = new clsCurvasRes();
                curvas.calcularCurvas(cConstruida, Tecnologia, TamanoFijo, TamanoFijoValor, PotenciaPanel, TechoDisponible, RSGISEne, RSGISFeb, RSGISMar, RSGISAbr, RSGISMay,
                 RSGISJun, RSGISJul, RSGISAgo, RSGISSep, RSGISOct, RSGISNov, RSGISDic, PromedioSGIS);

                clsPreliminares cPrelim = new clsPreliminares();
                cPrelim.calculaTamano(curvas.potSolarRecomendada);

                clsDatos cDatos = new clsDatos();
                double AlmacenamientoFijo = 0;
                string Microred = string.Empty;
                List<clsCostosUnitarios> CostosUnitarios = cDatos.calculaCostosUnitarios(PotenciaPanel, PromedioRecibos, HorasRespaldo, Tarifa, AlmacenamientoFijo, Microred, cPrelim);
                clsCostosMant cMant = cDatos.calculaCostosMant(CostoMantenimiento);

                clsCalculosResi cResi = new clsCalculosResi();
                cResi.calculosresi(REne, RFeb, RMar, RAbr, RMay, RJun, RJul, RAgo, RSep, ROct, RNov, RDic, RSGISEne, RSGISFeb, RSGISMar, RSGISAbr, RSGISMay,
                 RSGISJun, RSGISJul, RSGISAgo, RSGISSep, RSGISOct, RSGISNov, RSGISDic, PromedioRecibos, PromedioSGIS, CrecimientoAnual, Compania, Tarifa, curvas, cConstruida.pico);

                clsFinanciamiento financiamiento = new clsFinanciamiento();
                List<List<double>> listaFinanciamientos = financiamiento.calcFinanciamiento(CostoUnitarioFijo, Convert.ToDouble(CostoUnitarioFijoValor), PromedioRecibos, HorasRespaldo, cPrelim.Tamano, TipoCambio, cResi, CostosUnitarios, cMant);

                cPrelim.calculaCostos(Tecnologia, TipoCambio, CostoUnitarioFijo, CostoUnitarioFijoValor, listaFinanciamientos, cResi);

                cResi.calculaResto(cPrelim.costoC, TipoCambio);

                cPrelim.calculaResto(TipoCambio, CostoUnitarioFijo, CostoUnitarioFijoValor, CostoMantenimiento, cResi, cMant);

                clsReporteCurva reporte = new clsReporteCurva();
                var datos = reporte.datosReporte(curvas, cPrelim, cResi, Compania, TipoCambio, PPotenciaPanel, PromedioRecibos, HorasRespaldo, financiamiento, cDatos);

                return (List<Reporte>)datos; //Devuelve al reporte con los datos para que se impriman

            }
            catch (Exception e)
            {

                throw;
            }

            
            


            

        }

    }
}
