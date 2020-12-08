using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BLL
{
    public class clsDatosPrincipalesTMT
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
        public double TasaFinanciamiento;
        public double Prima;
        public double Plazo;
        public double PREne;
        public double PRFeb;
        public double PRMar;
        public double PRAbr;
        public double PRMay;
        public double PRJun;
        public double PRJul;
        public double PRAgo;
        public double PRSep;
        public double PROct;
        public double PRNov;
        public double PRDic;
        public double VREne;
        public double VRFeb;
        public double VRMar;
        public double VRAbr;
        public double VRMay;
        public double VRJun;
        public double VRJul;
        public double VRAgo;
        public double VRSep;
        public double VROct;
        public double VRNov;
        public double VRDic;
        public double NREne;
        public double NRFeb;
        public double NRMar;
        public double NRAbr;
        public double NRMay;
        public double NRJun;
        public double NRJul;
        public double NRAgo;
        public double NRSep;
        public double NROct;
        public double NRNov;
        public double NRDic;
        public double PDEne;
        public double PDFeb;
        public double PDMar;
        public double PDAbr;
        public double PDMay;
        public double PDJun;
        public double PDJul;
        public double PDAgo;
        public double PDSep;
        public double PDOct;
        public double PDNov;
        public double PDDic;
        public double VDEne;
        public double VDFeb;
        public double VDMar;
        public double VDAbr;
        public double VDMay;
        public double VDJun;
        public double VDJul;
        public double VDAgo;
        public double VDSep;
        public double VDOct;
        public double VDNov;
        public double VDDic;
        public double NDEne;
        public double NDFeb;
        public double NDMar;
        public double NDAbr;
        public double NDMay;
        public double NDJun;
        public double NDJul;
        public double NDAgo;
        public double NDSep;
        public double NDOct;
        public double NDNov;
        public double NDDic;
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
        public string Microred="No";
        public double Conversor;
        public double AlmacenamientoFijo;


        public List<Reporte> asignarPrincipales(string PNombrecliente,string PCompania,string PTarifa,double PTechoDisponible,double PHorasRespaldo,double PTipoCambio,double PPotenciaPanel,string PCostoUnitarioFijo,string PCostoUnitarioFijoValor,string PTamanoFijo,double PTamanoFijoValor,string PCostoMantenimiento,double PCrecimientoAnual,string PTecnologia,double PTasaFinanciamiento,double PPrima,double PPlazo,
            double PPREne,double PPRFeb,double PPRMar,double PPRAbr,double PPRMay,double PPRJun,double PPRJul,double PPRAgo,double PPRSep,double PPROct,double PPRNov,double PPRDic,double PVREne,double PVRFeb,double PVRMar,double PVRAbr,double PVRMay,double PVRJun,double PVRJul,double PVRAgo,double PVRSep,
            double PVROct,double PVRNov,double PVRDic,double PNREne,double PNRFeb,double PNRMar,double PNRAbr,double PNRMay,double PNRJun,double PNRJul,double PNRAgo,double PNRSep,double PNROct,double PNRNov,double PNRDic,double PPDEne,double PPDFeb,double PPDMar,double PPDAbr,double PPDMay,double PPDJun,double PPDJul,
            double PPDAgo,double PPDSep,double PPDOct,double PPDNov,double PPDDic,double PVDEne,double PVDFeb,double PVDMar,double PVDAbr,double PVDMay,double PVDJun,double PVDJul,double PVDAgo,double PVDSep,double PVDOct,double PVDNov,double PVDDic,double PNDEne,double PNDFeb,double PNDMar,double PNDAbr,double PNDMay,
            double PNDJun,double PNDJul,double PNDAgo,double PNDSep,double PNDOct,double PNDNov,double PNDDic,double PRGISEne,double PRSGISFeb,double PRSGISMar,double PRSGISAbr,double PRSGISMay,double PRSGISJun,double PRSGISJul,double PRSGISAgo,double PRSGISSep,double PRSGISOct,
            double PRSGISNov,double PRSGISDic)
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
            TasaFinanciamiento = PTasaFinanciamiento;
            Prima= PPrima;
            Plazo=PPlazo;
            PREne = PPREne;
            PRFeb = PPRFeb;
            PRMar = PPRMar;
            PRAbr = PPRAbr;
            PRMay = PPRMay;
            PRJun = PPRJun;
            PRJul = PPRJul;
            PRAgo = PPRAgo;
            PRSep = PPRSep;
            PROct = PPROct;
            PRNov = PPRNov;
            PRDic = PPRDic;
            VREne = PVREne;
            VRFeb = PVRFeb;
            VRMar = PVRMar;
            VRAbr = PVRAbr;
            VRMay = PVRMay;
            VRJun = PVRJun;
            VRJul = PVRJul;
            VRAgo = PVRAgo;
            VRSep = PVRSep;
            VROct = PVROct;
            VRNov = PVRNov;
            VRDic = PVRDic;
            NREne = PNREne;
            NRFeb = PNRFeb;
            NRMar = PNRMar;
            NRAbr = PNRAbr;
            NRMay = PNRMay;
            NRJun = PNRJun;
            NRJul = PNRJul;
            NRAgo = PNRAgo;
            NRSep = PNRSep;
            NROct = PNROct;
            NRNov = PNRNov;
            NRDic = PNRDic;
            PDEne = PPDEne;
            PDFeb = PPDFeb;
            PDMar = PPDMar;
            PDAbr = PPDAbr;
            PDMay = PPDMay;
            PDJun = PPDJun;
            PDJul = PPDJul;
            PDAgo = PPDAgo;
            PDSep = PPDSep;
            PDOct = PPDOct;
            PDNov = PPDNov;
            PDDic = PPDDic;
            VDEne = PVDEne;
            VDFeb = PVDFeb;
            VDMar = PVDMar;
            VDAbr = PVDAbr;
            VDMay = PVDMay;
            VDJun = PVDJun;
            VDJul = PVDJul;
            VDAgo = PVDAgo;
            VDSep = PVDSep;
            VDOct = PVDOct;
            VDNov = PVDNov;
            VDDic = PVDDic;
            NDEne = PNDEne;
            NDFeb = PNDFeb;
            NDMar = PNDMar;
            NDAbr = PNDAbr;
            NDMay = PNDMay;
            NDJun = PNDJun;
            NDJul = PNDJul;
            NDAgo = PNDAgo;
            NDSep = PNDSep;
            NDOct = PNDOct;
            NDNov = PNDNov;
            NDDic = PNDDic;
            RSGISEne = PRGISEne;
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

            double PromedioPRecibos = (PREne + PRFeb + PRMar + PRAbr + PRMay + PRJun + PRJul + PRAgo + PRSep + PROct + PRNov + PRDic) / 12;
            double PromedioVRecibos = (VREne + VRFeb + VRMar + VRAbr + VRMay + VRJun + VRJul + VRAgo + VRSep + VROct + VRNov + VRDic) / 12;
            double PromedioNRecibos = (NREne + NRFeb + NRMar + NRAbr + NRMay + NRJun + NRJul + NRAgo + NRSep + NROct + NRNov + NRDic) / 12;
            double PromedioPDemanda = (PDEne + PDFeb + PDMar + PDAbr + PDMay + PDJun + PDJul + PDAgo + PDSep + PDOct + PDNov + PDDic) / 12;
            double PromedioVDemanda = (VDEne + VDFeb + VDMar + VDAbr + VDMay + VDJun + VDJul + VDAgo + VDSep + VDOct + VDNov + VDDic) / 12;
            double PromedioNDemanda = (NDEne + NDFeb + NDMar + NDAbr + NDMay + NDJun + NDJul + NDAgo + NDSep + NDOct + NDNov + NDDic) / 12;
            double PromedioRecibos = (PREne + PRFeb + PRMar + PRAbr + PRMay + PRJun + PRJul + PRAgo + PRSep + PROct + PRNov + PRDic) / 12;
            double PromedioSGIS = (RSGISEne + RSGISFeb + RSGISMar + RSGISAbr + RSGISMay + RSGISJun + RSGISJul + RSGISAgo + RSGISSep + RSGISOct + RSGISNov + RSGISDic) / 12;
            

            try
            {
                clsCConstruida cConstruida = new clsCConstruida();
                bool prueba = cConstruida.calculoCCTMT(PREne, PRFeb, PRMar, PRAbr, PRMay, PRJun, PRJul, PRAgo, PRSep, PROct, PRNov, PRDic,
              VREne, VRFeb, VRMar, VRAbr, VRMay, VRJun, VRJul, VRAgo, VRSep, VROct, VRNov, VRDic,
              NREne, NRFeb, NRMar, NRAbr, NRMay, NRJun, NRJul, NRAgo, NRSep, NROct, NRNov, NRDic,
              PDEne, PDFeb, PDMar, PDAbr, PDMay, PDJun, PDJul, PDAgo, PDSep, PDOct, PDNov, PDDic,
              VDEne, VDFeb, VDMar, VDAbr, VDMay, VDJun, VDJul, VDAgo, VDSep, VDOct, VDNov, VDDic,
              NDEne, NDFeb, NDMar, NDAbr, NDMay, NDJun, NDJul, NDAgo, NDSep, NDOct, NDNov, NDDic,
              RSGISEne, RSGISFeb, RSGISMar, RSGISAbr, RSGISMay, RSGISJun, RSGISJul,RSGISAgo,RSGISSep, RSGISOct, RSGISNov, RSGISDic);

                clsCurvasTMT curvas = new clsCurvasTMT();
                curvas.calcularCurvas(cConstruida, Tecnologia, TamanoFijo, TamanoFijoValor, PotenciaPanel, TechoDisponible, RSGISEne, RSGISFeb, RSGISMar, RSGISAbr, RSGISMay,
                 RSGISJun, RSGISJul, RSGISAgo, RSGISSep, RSGISOct, RSGISNov, RSGISDic, PromedioSGIS, Conversor, Microred, AlmacenamientoFijo);

                clsPreliminares cPrelim = new clsPreliminares();
                cPrelim.calculaTamano(curvas.potSolarRecomendada);

                clsDatos cDatos = new clsDatos();
                List<clsCostosUnitarios> CostosUnitarios = cDatos.calculaCostosUnitarios(PotenciaPanel, PromedioRecibos, HorasRespaldo, Tarifa, AlmacenamientoFijo, Microred, cPrelim);
                clsCostosMant cMant = cDatos.calculaCostosMant(CostoMantenimiento);

                clsCalculosTMT cTMT = new clsCalculosTMT();
                cTMT.calculosTMT(PREne, PRFeb, PRMar, PRAbr, PRMay, PRJun, PRJul, PRAgo, PRSep, PROct, PRNov, PRDic,
              VREne, VRFeb, VRMar, VRAbr, VRMay, VRJun, VRJul, VRAgo, VRSep, VROct, VRNov, VRDic,
              NREne, NRFeb, NRMar, NRAbr, NRMay, NRJun, NRJul, NRAgo, NRSep, NROct, NRNov, NRDic,
              PDEne, PDFeb, PDMar, PDAbr, PDMay, PDJun, PDJul, PDAgo, PDSep, PDOct, PDNov, PDDic,
              VDEne, VDFeb, VDMar, VDAbr, VDMay, VDJun, VDJul, VDAgo, VDSep, VDOct, VDNov, VDDic,
              NDEne, NDFeb, NDMar, NDAbr, NDMay, NDJun, NDJul, NDAgo, NDSep, NDOct, NDNov, NDDic,
              RSGISEne, RSGISFeb, RSGISMar, RSGISAbr, RSGISMay, RSGISJun, RSGISJul, RSGISAgo, RSGISSep, RSGISOct, RSGISNov, RSGISDic,
              PromedioRecibos, PromedioSGIS, CrecimientoAnual, Compania, Tarifa, curvas, cConstruida.pico);

            clsFinanciamiento financiamiento = new clsFinanciamiento();
            List<List<double>> listaFinanciamientos = financiamiento.calcFinanciamientoTMT(CostoUnitarioFijo, Convert.ToDouble(CostoUnitarioFijoValor), PromedioRecibos, HorasRespaldo, cPrelim.Tamano, TipoCambio, cTMT, CostosUnitarios, cMant);

            cPrelim.calculaCostosTMT(cPrelim.Tamano, Tecnologia, TipoCambio, Microred, AlmacenamientoFijo, CostoUnitarioFijo, CostoUnitarioFijoValor, listaFinanciamientos, cTMT, CostosUnitarios);

            cTMT.calculaResto(cPrelim.costoC, TipoCambio);

            cPrelim.calculaRestoTMT(TipoCambio, CostoUnitarioFijo, CostoUnitarioFijoValor, CostoMantenimiento, cTMT, cMant);

            clsReporteCurva reporte = new clsReporteCurva();
             var datos=reporte.datosReporteTMT(curvas, cPrelim, cTMT, AlmacenamientoFijo, Compania, TipoCambio, PPotenciaPanel, PromedioRecibos, HorasRespaldo, financiamiento, cDatos);

             return (List<Reporte>)datos; //Devuelve al reporte con los datos para que se impriman

            }
            catch (Exception e)
            {

                throw;
            }



        }

    }
}
