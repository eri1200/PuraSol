using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BLL
{
    public class clsDatosPrincipalesmicroTMT
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
        public double PiREne;
        public double PiRFeb;
        public double PiRMar;
        public double PiRAbr;
        public double PiRMay;
        public double PiRJun;
        public double PiRJul;
        public double PiRAgo;
        public double PiRSep;
        public double PiROct;
        public double PiRNov;
        public double PiRDic;
        public double VaREne;
        public double VaRFeb;
        public double VaRMar;
        public double VaRAbr;
        public double VaRMay;
        public double VaRJun;
        public double VaRJul;
        public double VaRAgo;
        public double VaRSep;
        public double VaROct;
        public double VaRNov;
        public double VaRDic;
        public double NoREne;
        public double NoRFeb;
        public double NoRMar;
        public double NoRAbr;
        public double NoRMay;
        public double NoRJun;
        public double NoRJul;
        public double NoRAgo;
        public double NoRSep;
        public double NoROct;
        public double NoRNov;
        public double NoRDic;
        public double PiDEne;
        public double PiDFeb;
        public double PiDMar;
        public double PiDAbr;
        public double PiDMay;
        public double PiDJun;
        public double PiDJul;
        public double PiDAgo;
        public double PiDSep;
        public double PiDOct;
        public double PiDNov;
        public double PiDDic;
        public double VaDEne;
        public double VaDFeb;
        public double VaDMar;
        public double VaDAbr;
        public double VaDMay;
        public double VaDJun;
        public double VaDJul;
        public double VaDAgo;
        public double VaDSep;
        public double VaDOct;
        public double VaDNov;
        public double VaDDic;
        public double NoDEne;
        public double NoDFeb;
        public double NoDMar;
        public double NoDAbr;
        public double NoDMay;
        public double NoDJun;
        public double NoDJul;
        public double NoDAgo;
        public double NoDSep;
        public double NoDOct;
        public double NoDNov;
        public double NoDDic;
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
        public string Microred="Sí";
        public double Conversor;
        public double AlmacenamientoFijo;
        public double TasaFinanciamiento;
        public double Prima;
        public double Plazo;

        public List<Reporte> asignarPrincipales(string PNombrecliente,string PCompania,string PTarifa,double PTechoDisponible,double PTipoCambio,double PPotenciaPanel,string PCostoUnitarioFijo,string PCostoUnitarioFijoValor,string PTamanoFijo,double PTamanoFijoValor,string PMicrored,double PConversor,double PAlmacenamientoFijo,
            string PCostoMantenimiento,double PCrecimientoAnual,string PTecnologia,double PTasaFinanciamiento,double PPrima,double PPlazo,double PPREne,double PPRFeb,double PPRMar,double PPRAbr,double PPRMay,double PPRJun,double PPRJul,double PPRAgo,double PPRSep,double PPROct,double PPRNov,double PPRDic,double PVREne,
            double PVRFeb,double PVRMar,double PVRAbr,double PVRMay,double PVRJun,double PVRJul,double PVRAgo,double PVRSep,double PVROct,double PVRNov,double PVRDic,double PNREne,double PNRFeb,double PNRMar,double PNRAbr,double PNRMay,double PNRJun,double PNRJul,double PNRAgo,double PNRSep,double PNROct,double PNRNov,
            double PNRDic,double PPDEne,double PPDFeb,double PPDMar,double PPDAbr,double PPDMay,double PPDJun,double PPDJul,double PPDAgo,double PPDSep,double PPDOct,double PPDNov,double PPDDic,double PVDEne,double PVDFeb,double PVDMar,double PVDAbr,double PVDMay,double PVDJun,double PVDJul,double PVDAgo,double PVDSep,
            double PVDOct,double PVDNov,double PVDDic,double PNDEne,double PNDFeb,double PNDMar,double PNDAbr,double PNDMay,double PNDJun,double PNDJul,double PNDAgo,double PNDSep,double PNDOct,double PNDNov,double PNDDic,double PRSGISEne,double PRSGISFeb,double PRSGISMar,double PRSGISAbr,double PRSGISMay,
            double PRSGISJun,double PRSGISJul,double PRSGISAgo,double PRSGISSep,double PRSGISOct,double PRSGISNov,double PRSGISDic)
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
            AlmacenamientoFijo = PAlmacenamientoFijo;
            Tecnologia = PTecnologia;
            Conversor = PConversor;
            Microred = PMicrored;
            PiREne = PPREne;
            PiRFeb = PPRFeb;
            PiRMar = PPRMar;
            PiRAbr = PPRAbr;
            PiRMay = PPRMay;
            PiRJun = PPRJun;
            PiRJul = PPRJul;
            PiRAgo = PPRAgo;
            PiRSep = PPRSep;
            PiROct = PPROct;
            PiRNov = PPRNov;
            PiRDic = PPRDic;
            VaREne = PVREne;
            VaRFeb = PVRFeb;
            VaRMar = PVRMar;
            VaRAbr = PVRAbr;
            VaRMay = PVRMay;
            VaRJun = PVRJun;
            VaRJul = PVRJul;
            VaRAgo = PVRAgo;
            VaRSep = PVRSep;
            VaROct = PVROct;
            VaRNov = PVRNov;
            VaRDic = PVRDic;
            NoREne = PNREne;
            NoRFeb = PNRFeb;
            NoRMar = PNRMar;
            NoRAbr = PNRAbr;
            NoRMay = PNRMay;
            NoRJun = PNRJun;
            NoRJul = PNRJul;
            NoRAgo = PNRAgo;
            NoRSep = PNRSep;
            NoROct = PNROct;
            NoRNov = PNRNov;
            NoRDic = PNRDic;
            PiDEne = PPDEne;
            PiDFeb = PPDFeb;
            PiDMar = PPDMar;
            PiDAbr = PPDAbr;
            PiDMay = PPDMay;
            PiDJun = PPDJun;
            PiDJul = PPDJul;
            PiDAgo = PPDAgo;
            PiDSep = PPDSep;
            PiDOct = PPDOct;
            PiDNov = PPDNov;
            PiDDic = PPDDic;
            VaDEne = PVDEne;
            VaDFeb = PVDFeb;
            VaDMar = PVDMar;
            VaDAbr = PVDAbr;
            VaDMay = PVDMay;
            VaDJun = PVDJun;
            VaDJul = PVDJul;
            VaDAgo = PVDAgo;
            VaDSep = PVDSep;
            VaDOct = PVDOct;
            VaDNov = PVDNov;
            VaDDic = PVDDic;
            NoDEne = PNDEne;
            NoDFeb = PNDFeb;
            NoDMar = PNDMar;
            NoDAbr = PNDAbr;
            NoDMay = PNDMay;
            NoDJun = PNDJun;
            NoDJul = PNDJul;
            NoDAgo = PNDAgo;
            NoDSep = PNDSep;
            NoDOct = PNDOct;
            NoDNov = PNDNov;
            NoDDic = PNDDic;
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


            double PromedioPRecibos = (PiREne + PiRFeb + PiRMar + PiRAbr + PiRMay + PiRJun + PiRJul + PiRAgo + PiRSep + PiROct + PiRNov + PiRDic)/12;
            double PromedioRecibos = (PiREne + PiRFeb + PiRMar + PiRAbr + PiRMay + PiRJun + PiRJul + PiRAgo + PiRSep + PiROct + PiRNov + PiRDic) / 12;
            double PromedioVRecibos = (VaREne + VaRFeb + VaRMar + VaRAbr + VaRMay + VaRJun + VaRJul + VaRAgo + VaRSep + VaROct + VaRNov + VaRDic) / 12;
            double PromedioNRecibos = (NoREne + NoRFeb + NoRMar + NoRAbr + NoRMay + NoRJun + NoRJul + NoRAgo + NoRSep + NoROct + NoRNov + NoRDic) / 12;
            double PromedioPDemanda = (PiDEne + PiDFeb + PiDMar + PiDAbr + PiDMay + PiDJun + PiDJul + PiDAgo + PiDSep + PiDOct + PiDNov + PiDDic) / 12;
            double PromedioVDemanda = (VaDEne + VaDFeb + VaDMar + VaDAbr + VaDMay + VaDJun + VaDJul + VaDAgo + VaDSep + VaDOct + VaDNov + VaDDic) / 12;
            double PromedioNDemanda = (NoDEne + NoDFeb + NoDMar + NoDAbr + NoDMay + NoDJun + NoDJul + NoDAgo + NoDSep + NoDOct + NoDNov + NoDDic) / 12;
            double PromedioSGIS = (RSGISEne + RSGISFeb + RSGISMar + RSGISAbr + RSGISMay + RSGISJun + RSGISJul + RSGISAgo + RSGISSep + RSGISOct + RSGISNov + RSGISDic) / 12;

            try
            {
                clsCConstruida cConstruida = new clsCConstruida();
                bool prueba = cConstruida.calculoCCMTMT(PiREne, PiRFeb, PiRMar, PiRAbr, PiRMay, PiRJun, PiRJul, PiRAgo, PiRSep, PiROct, PiRNov, PiRDic,
              VaREne, VaRFeb, VaRMar, VaRAbr, VaRMay, VaRJun, VaRJul, VaRAgo, VaRSep, VaROct, VaRNov, VaRDic,
              NoREne, NoRFeb, NoRMar, NoRAbr, NoRMay, NoRJun, NoRJul, NoRAgo, NoRSep, NoROct, NoRNov, NoRDic,
              PiDEne, PiDFeb, PiDMar, PiDAbr, PiDMay, PiDJun, PiDJul, PiDAgo, PiDSep, PiDOct, PiDNov, PiDDic,
              VaDEne, VaDFeb, VaDMar, VaDAbr, VaDMay, VaDJun, VaDJul, VaDAgo, VaDSep, VaDOct, VaDNov, VaDDic,
              NoDEne, NoDFeb, NoDMar, NoDAbr, NoDMay, NoDJun, NoDJul, NoDAgo, NoDSep, NoDOct, NoDNov, NoDDic,
              PRSGISEne, PRSGISFeb, PRSGISMar, PRSGISAbr, PRSGISMay, PRSGISJun, PRSGISJul, PRSGISAgo, PRSGISSep, PRSGISOct, PRSGISNov, PRSGISDic);

                clsCurvasMTMT curvas = new clsCurvasMTMT();
                curvas.calcularCurvas(cConstruida, Tecnologia, TamanoFijo, TamanoFijoValor, PotenciaPanel, TechoDisponible, RSGISEne, RSGISFeb, RSGISMar, RSGISAbr, RSGISMay,
                 RSGISJun, RSGISJul, RSGISAgo, RSGISSep, RSGISOct, RSGISNov, RSGISDic, PromedioSGIS, Conversor, Microred, PAlmacenamientoFijo);

                clsPreliminares cPrelim = new clsPreliminares();
                cPrelim.calculaTamano(curvas.potSolarRecomendada);

                clsDatos cDatos = new clsDatos();
                List<clsCostosUnitarios> CostosUnitarios = cDatos.calculaCostosUnitarios(PotenciaPanel, PromedioRecibos, HorasRespaldo, Tarifa, AlmacenamientoFijo, Microred, cPrelim);
                clsCostosMant cMant = cDatos.calculaCostosMant(CostoMantenimiento);

                clsCalculosMTMT cMTMT = new clsCalculosMTMT();
                cMTMT.calculosMTMT(PiREne, PiRFeb, PiRMar, PiRAbr, PiRMay, PiRJun, PiRJul, PiRAgo, PiRSep, PiROct, PiRNov, PiRDic,
              VaREne, VaRFeb, VaRMar, VaRAbr, VaRMay, VaRJun, VaRJul, VaRAgo, VaRSep, VaROct, VaRNov, VaRDic,
              NoREne, NoRFeb, NoRMar, NoRAbr, NoRMay, NoRJun, NoRJul, NoRAgo, NoRSep, NoROct, NoRNov, NoRDic,
              PiDEne, PiDFeb, PiDMar, PiDAbr, PiDMay, PiDJun, PiDJul, PiDAgo, PiDSep, PiDOct, PiDNov, PiDDic,
              VaDEne, VaDFeb, VaDMar, VaDAbr, VaDMay, VaDJun, VaDJul, VaDAgo, VaDSep, VaDOct, VaDNov, VaDDic,
              NoDEne, NoDFeb, NoDMar, NoDAbr, NoDMay, NoDJun, NoDJul, NoDAgo, NoDSep, NoDOct, NoDNov, NoDDic,
              PRSGISEne, PRSGISFeb, PRSGISMar, PRSGISAbr, PRSGISMay, PRSGISJun, PRSGISJul, PRSGISAgo, PRSGISSep, PRSGISOct, PRSGISNov, PRSGISDic, 
              PromedioRecibos, PromedioSGIS, CrecimientoAnual, Compania, Tarifa, curvas, cConstruida.pico);

                clsFinanciamiento financiamiento = new clsFinanciamiento();
                List<List<double>> listaFinanciamientos = financiamiento.calcFinanciamientoMTMT(CostoUnitarioFijo, Convert.ToDouble(CostoUnitarioFijoValor), PromedioRecibos, HorasRespaldo, cPrelim.Tamano, TipoCambio, cMTMT, CostosUnitarios, cMant);

                cPrelim.calculaCostosMTMT(cPrelim.Tamano, Tecnologia, TipoCambio,Microred, AlmacenamientoFijo, CostoUnitarioFijo, CostoUnitarioFijoValor, listaFinanciamientos, cMTMT, CostosUnitarios);

                cMTMT.calculaResto(cPrelim.costoC, TipoCambio);

                cPrelim.calculaRestoMTMT(TipoCambio, CostoUnitarioFijo, CostoUnitarioFijoValor, CostoMantenimiento, cMTMT, cMant);

                clsReporteCurva reporte = new clsReporteCurva();
               var datos= reporte.datosReporteMTMT(curvas, cPrelim, cMTMT,AlmacenamientoFijo, Compania, TipoCambio, PPotenciaPanel, PromedioRecibos, HorasRespaldo, financiamiento, cDatos);

                return (List<Reporte>)datos;

            }
            catch (Exception e)
            {

                throw;
            }



        }

    }
}
