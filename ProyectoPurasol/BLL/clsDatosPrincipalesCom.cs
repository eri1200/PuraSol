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

        public void asignarPrincipales(string PNombrecliente, string PCompania, string PTarifa, double PTechoDisponible, double PTipoCambio, double PPotenciaPanel, string PCostoUnitarioFijo, string PCostoUnitarioFijoValor, string PTamanoFijo, double PTamanoFijoValor, string PCostoMantenimiento,
            double PCrecimientoAnual, string PTecnologia, double PREne,double PRFeb,double PRMar,double PRAbr,double PRMay,double PRJun,double PRJul,double PRAgo,double PRSep,double PROct,double PRNov,double PRDic,double PDEne,double PDFeb,double PDMar,double PDAbr,double PDMay,double PDJun,
            double PDJul,double PDAgo,double PDSep,double PDOct,double PDNov,double PDDic,double PRSGISEne,double PRSGISFeb,double PRSGISMar,double PRSGISAbr,double PRSGISMay,double PRSGISJun,double PRSGISJul,double PRSGISAgo,double PRSGISSep,double PRSGISOct,double PRSGISNov,double PRSGISDic,
            string UnificacionMenor3000, string CeroInyeccion, double TasaFinanciamiento, double Prima, double Plazo)
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
            DEne = PDEne;
            DFeb = PDFeb;
            DMar = PDMar;
            DAbr = PDAbr;
            DMay = PDMay;
            DJun = PDJun;
            DJul = PDJul;
            DAgo = PDAgo;
            DSep = PDSep;
            DOct = PDOct;
            DNov = PDNov;
            DDic = PDDic;
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

            clsDatos cDatos = new clsDatos();
            double AlmacenamientoFijo = 0;
            string Microred = string.Empty;
            clsPreliminares cPrelim = new clsPreliminares();
            //cPrelim.calculaTamano(curvas.potSolarRecomendada);
            List<clsCostosUnitarios> CostosUnitarios = cDatos.calculaCostosUnitarios(PotenciaPanel, PromedioRecibos, HorasRespaldo, Tarifa, AlmacenamientoFijo, Microred, cPrelim);
            clsCostosMant cMant = cDatos.calculaCostosMant(CostoMantenimiento);

            

        }

    }
}
