using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BLL
{
    class clsReporteCurva
    {
        public double invPremium;
        public double potSistema;
        public double cantPaneles;
        public double area;
        public double costoPorWatt;
        public double prodAnualSistema;
        public double almacenamiento;
        public double consumoCubiertoPct;
        public double autoconsumo;
        public double consumoTA;
        public double retornoSimple;
        public double ahorroaAnualesAvg;
        public string compania;

        public List<double> Inversor = new List<double>();
        public List<double> Optimizador = new List<double>();
        public List<double> Microinversor = new List<double>();
        public double[,] energiaDetalle = new double[3, 13];
        public double[,] potenciaDetalle = new double[4, 13];

        //ObjetoReporte
        

        public Object datosReporte(clsCurvasRes curvas, clsPreliminares cPrelim, clsCalculosResi calculos,string Compania, double tipoCambio, double potPanel,double avgRecibos, double horasRespaldo, clsFinanciamiento financiamiento, clsDatos datos)
        {
            List<Reporte> reportes = new List<Reporte>();
            Reporte itemReporte = new Reporte();

            
            

            invPremium = cPrelim.costoD;
            
            potSistema = cPrelim.Tamano;
            itemReporte.PotenciadePanel = potSistema.ToString();
            cantPaneles = Math.Ceiling(potSistema / (potPanel / 1000));
            itemReporte.CantidadPaneles = cantPaneles.ToString();
            itemReporte.Area = (cantPaneles * 2.1 / 0.8).ToString();
            itemReporte.CostoPorWatt = (invPremium / potSistema / 1000).ToString();
            itemReporte.ProduccionAnual = calculos.enerProducida[0,13].ToString();
            itemReporte.Almacenamiento = datos.selecAlmacenamiento(avgRecibos, horasRespaldo)[1].ToString();
            itemReporte.consumoCubiertoPct = curvas.coberturaTeorica.ToString();
            itemReporte.autoconsumo = curvas.coberturaRealporConsumoAnual.ToString();
            itemReporte.consumoTA = curvas.coberturaTAporConsumoAnual.ToString();

            for (int i = 0; i < 26; i++)
            {
                retornoSimple += calculos.calculos[i, 18];
            }

            itemReporte.retornoSimple = retornoSimple.ToString();

            for (int i = 0; i < 11; i++)
            {
                ahorroaAnualesAvg += calculos.calculos[i, 15];
            }

            ahorroaAnualesAvg = ahorroaAnualesAvg / 11;
            ahorroaAnualesAvg = ahorroaAnualesAvg / tipoCambio;

            itemReporte.ahorroaAnualesAvg = ahorroaAnualesAvg.ToString();

            itemReporte.Compania = Compania;

            reportes.Add(itemReporte);
            //Revisar cuando hay costo unitario sí, tamaño fijo sí, mantenimiento GAM
            Inversor.Add(Math.Round(financiamiento.Centralizado[12]));
            Inversor.Add(Math.Round(financiamiento.Centralizado[1]));
            Inversor.Add(Math.Round(financiamiento.Centralizado[2]));
            Inversor.Add(2);
            Inversor.Add(Math.Round(financiamiento.Centralizado[14]));

            Optimizador.Add(Math.Round(financiamiento.Optimizadores[12]));
            Optimizador.Add(Math.Round(financiamiento.Optimizadores[1]));
            Optimizador.Add(Math.Round(financiamiento.Optimizadores[2]));
            Optimizador.Add(2);
            Optimizador.Add(Math.Round(financiamiento.Optimizadores[14]));

            Microinversor.Add(Math.Round(financiamiento.Microinversor[12]));
            Microinversor.Add(Math.Round(financiamiento.Microinversor[1]));
            Microinversor.Add(Math.Round(financiamiento.Microinversor[2]));
            Microinversor.Add(2);
            Microinversor.Add(Math.Round(financiamiento.Microinversor[14]));

            

            //Histórico de facturas

            for (int i = 0; i < 12; i++)
            {
                HistFacturas itemhistFact = new HistFacturas();
                itemhistFact.consumoEnergia = Math.Round(calculos.consumoEnergia[i]).ToString();
                itemhistFact.costoBaseEner1 = Math.Round(calculos.costoBaseEner[0, i + 1] / tipoCambio).ToString();
                itemhistFact.costoBaseEner2 = Math.Round(0.13 * (calculos.costoBaseEner[0, i + 1] + calculos.costoBasePot[0, i + 1]) / tipoCambio).ToString();

                 itemReporte.histFact.Add(itemhistFact);
            }
            //Anuales
            energiaDetalle[0, 12] = Math.Round(calculos.consumoEnergia[12]);
            energiaDetalle[1, 12] = Math.Round(calculos.costoBaseEner[0, 13] / tipoCambio);
            energiaDetalle[2, 12] = Math.Round(calculos.calculos[0, 8] / tipoCambio);




            //Proyección con Energía Solar


            for (int i = 0; i < 12; i++)
            {
                ProyFactura itemproyFact = new ProyFactura();
                itemproyFact.compraReg = Math.Round(calculos.compraReg[0, i + 1]).ToString();
                itemproyFact.enerCoberturTarAcc = Math.Round(calculos.enerCoberturTarAcc[0, i + 1]).ToString();
                itemproyFact.costoPredichoEner1 = Math.Round(calculos.costoPredichoEner[0, i + 1] / tipoCambio).ToString();
                itemproyFact.costoPredichoEner2 = Math.Round(0.13 * (calculos.costoPredichoEner[0, i + 1] + calculos.costoPredichoPot[0, i + 1]) / tipoCambio).ToString();
                 itemReporte.proyFact.Add(itemproyFact);
            }
            //Anuales
            potenciaDetalle[0, 12] = Math.Round(calculos.compraReg[0, 13]);
            potenciaDetalle[1, 12] = Math.Round(calculos.enerCoberturTarAcc[0, 13]);
            potenciaDetalle[2, 12] = Math.Round(calculos.costoPredichoEner[0, 13] / tipoCambio);
            potenciaDetalle[3, 12] = Math.Round(calculos.calculos[0, 12] / tipoCambio);

            reportes.Add(itemReporte);
            return (reportes);
        }
    }
}
