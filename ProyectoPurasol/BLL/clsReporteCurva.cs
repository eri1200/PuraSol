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
            itemReporte.PotenciadePanel = Math.Round(potSistema,2).ToString();
            cantPaneles = Math.Ceiling(potSistema / (potPanel / 1000));
            itemReporte.CantidadPaneles = cantPaneles.ToString();
            itemReporte.Area = Math.Round((cantPaneles * 2.1 / 0.8),2).ToString();
            itemReporte.CostoPorWatt = Math.Round(invPremium / potSistema / 1000,2).ToString();
            itemReporte.ProduccionAnual = Math.Round(calculos.enerProducida[0,13],2).ToString();
            itemReporte.Almacenamiento = Math.Round(datos.selecAlmacenamiento(avgRecibos, horasRespaldo)[1],2).ToString();
            itemReporte.consumoCubiertoPct = Math.Round(curvas.coberturaTeorica,2).ToString();
            itemReporte.autoconsumo = Math.Round(curvas.coberturaRealporConsumoAnual,2).ToString();
            itemReporte.consumoTA = Math.Round(curvas.coberturaTAporConsumoAnual,2).ToString();

            for (int i = 0; i < 26; i++)
            {
                retornoSimple += calculos.calculos[i, 18];
            }

            itemReporte.retornoSimple = Math.Round(retornoSimple,2).ToString();

            for (int i = 0; i < 11; i++)
            {
                ahorroaAnualesAvg += calculos.calculos[i, 15];
            }

            ahorroaAnualesAvg = ahorroaAnualesAvg / 11;
            ahorroaAnualesAvg = Math.Round(ahorroaAnualesAvg / tipoCambio,2);

            itemReporte.ahorroaAnualesAvg = Math.Truncate(ahorroaAnualesAvg).ToString();

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
            itemReporte.TRhistAnual= Math.Round(calculos.consumoEnergia[12]).ToString();
            itemReporte.ChistAnual= Math.Round(calculos.costoBaseEner[0, 13] / tipoCambio).ToString();
            itemReporte.IhistAnual = Math.Round(calculos.calculos[0, 8] / tipoCambio).ToString();




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
            itemReporte.TRproyAnual = Math.Round(calculos.compraReg[0, 13]).ToString();
            itemReporte.TAproyAnual = Math.Round(calculos.enerCoberturTarAcc[0, 13]).ToString();
            itemReporte.CproyAnual = Math.Round(calculos.costoPredichoEner[0, 13] / tipoCambio).ToString();
            itemReporte.IproyAnual = Math.Round(calculos.calculos[0, 12] / tipoCambio).ToString();

            reportes.Add(itemReporte);
            return (reportes);
        }
        public object datosReporteMTMT(clsCurvasMTMT curvas, clsPreliminares cPrelim, clsCalculosMTMT calculos, double almacenamientoFijo, string Compania, double tipoCambio, double potPanel, double avgRecibos, double horasRespaldo, clsFinanciamiento financiamiento, clsDatos datos)
        {

            List<Reporte> reportes = new List<Reporte>();
            Reporte itemReporte = new Reporte();

            invPremium = cPrelim.costoD;
            potSistema = cPrelim.Tamano;
            itemReporte.PotenciadePanel = potSistema.ToString();
            cantPaneles = Math.Ceiling(potSistema / (potPanel / 1000));
            itemReporte.CantidadPaneles = cantPaneles.ToString();
            itemReporte.Area = (cantPaneles * (1.05 * 2.11) / 0.8).ToString();
            itemReporte.CostoPorWatt = (invPremium / potSistema / 1000).ToString();
            itemReporte.ProduccionAnual = calculos.enerProducida[0, 13].ToString();
            itemReporte.Almacenamiento = almacenamientoFijo.ToString();
            itemReporte.autoconsumo = curvas.coberturaRealporConsumoAnual.ToString();
            itemReporte.consumoTA = curvas.coberturaTAporConsumoAnual.ToString();
            itemReporte.consumoCubiertoPct = (autoconsumo + consumoTA).ToString();
            itemReporte.retornoSimple = (0).ToString();
            ahorroaAnualesAvg = 0;



            

            for (int i = 0; i < 26; i++)
            {
                retornoSimple += calculos.calculos[i, 18];
            }

            for (int i = 0; i < 10; i++)
            {
                ahorroaAnualesAvg += calculos.calculos[i, 15];
            }

            ahorroaAnualesAvg = ahorroaAnualesAvg / 10;
            ahorroaAnualesAvg = ahorroaAnualesAvg / tipoCambio;

            itemReporte.ahorroaAnualesAvg = ahorroaAnualesAvg.ToString();
            itemReporte.Compania = Compania;


            //Revisar cuando hay costo unitario sí, tamaño fijo sí, mantenimiento GAM



            Inversor.Add(Math.Round(financiamiento.Centralizado[12]));
            Inversor.Add(financiamiento.Centralizado[1] * 100);
            Inversor.Add(Math.Round(financiamiento.Centralizado[2]));
            Inversor.Add(2);
            Inversor.Add(Math.Round(financiamiento.Centralizado[14]));

            Optimizador.Add(Math.Round(financiamiento.Optimizadores[12]));
            Optimizador.Add(financiamiento.Optimizadores[1] * 100);
            Optimizador.Add(Math.Round(financiamiento.Optimizadores[2]));
            Optimizador.Add(2);
            Optimizador.Add(Math.Round(financiamiento.Optimizadores[14]));

            Microinversor.Add(Math.Round(financiamiento.Microinversor[12]));
            Microinversor.Add(financiamiento.Microinversor[1] * 100);
            Microinversor.Add(Math.Round(financiamiento.Microinversor[2]));
            Microinversor.Add(2);
            Microinversor.Add(Math.Round(financiamiento.Microinversor[14]));



            //Histórico de facturas

            for (int i = 0; i < 12; i++)
            {
                HistFacturas itemhistFact = new HistFacturas();
                itemhistFact.consumoEnergia = Math.Round(calculos.consumoEnergiaTot[i]).ToString();
                itemhistFact.costoBaseEner1 = Math.Round(calculos.costoBaseEner[0, i + 1] / tipoCambio).ToString();
               // energiaDetalle[3, i] = Math.Round(0.13 * (calculos.costoBaseEner[0, i + 1] + calculos.costoBasePot[0, i + 1]) / tipoCambio);
                itemhistFact.costoBaseEner2 = Math.Round(calculos.costoBasePot[0, i + 1] / tipoCambio).ToString();
                itemReporte.histFact.Add(itemhistFact);
            }
            
            //Anuales
            itemReporte.TRhistAnual = Math.Round(calculos.consumoEnergiaTot[12]).ToString();
            itemReporte.ChistAnual = Math.Round(calculos.costoBaseEner[0, 13] / tipoCambio).ToString();
            //energiaDetalle[3, 12] = Math.Round(calculos.calculos[0, 8] / tipoCambio);
            itemReporte.IhistAnual = Math.Round(calculos.costoBasePot[0, 13] / tipoCambio).ToString();



            //Proyección con Energía Solar


            for (int i = 0; i < 12; i++)
            {
                ProyFactura itemproyFact = new ProyFactura();
                itemproyFact.compraReg = Math.Round(calculos.compraRegP[0, i + 1] + calculos.compraRegV[0, i + 1] + calculos.compraRegN[0, i + 1]).ToString();
                itemproyFact.enerCoberturTarAcc = Math.Round(calculos.enerCoberturTarAcc[0, i + 1]).ToString();
                itemproyFact.costoPredichoEner1 = Math.Round(calculos.costoPredichoEner[0, i + 1] / tipoCambio).ToString();
                //potenciaDetalle[4, i] = Math.Round(0.13 * (calculos.costoPredichoEner[0, i + 1] + calculos.costoPredichoPot[0, i + 1]) / tipoCambio);
                itemproyFact.costoPredichoEner2 = Math.Round(calculos.costoPredichoPot[0, i + 1] / tipoCambio).ToString();
                itemReporte.proyFact.Add(itemproyFact);
            }
            //Anuales
            itemReporte.TRproyAnual = Math.Round(calculos.compraRegP[0, 13] + calculos.compraRegV[0, 13] + calculos.compraRegN[0, 13]).ToString();
            itemReporte.TAproyAnual = Math.Round(calculos.enerCoberturTarAcc[0, 13]).ToString();
            itemReporte.CproyAnual = Math.Round(calculos.costoPredichoEner[0, 13] / tipoCambio).ToString();
            //potenciaDetalle[4, 12] = Math.Round(calculos.calculos[0, 12] / tipoCambio);
            itemReporte.IproyAnual = Math.Round(calculos.costoPredichoPot[0, 13] / tipoCambio).ToString();



            reportes.Add(itemReporte);
            return (reportes);
        }
        public object datosReporteTMT(clsCurvasTMT curvas, clsPreliminares cPrelim, clsCalculosTMT calculos, double almacenamientoFijo, string Compania, double tipoCambio, double potPanel, double avgRecibos, double horasRespaldo, clsFinanciamiento financiamiento, clsDatos datos)
        {
            List<Reporte> reportes = new List<Reporte>();
            Reporte itemReporte = new Reporte();

            invPremium = cPrelim.costoD;
            potSistema = cPrelim.Tamano;
            itemReporte.PotenciadePanel = potSistema.ToString();
            cantPaneles = Math.Ceiling(potSistema / (potPanel / 1000));
            itemReporte.CantidadPaneles = cantPaneles.ToString();
            itemReporte.Area = (cantPaneles * (1.05 * 2.11) / 0.8).ToString();
            itemReporte.CostoPorWatt = (invPremium / potSistema / 1000).ToString();
            itemReporte.ProduccionAnual = calculos.enerProducida[0, 13].ToString();
            itemReporte.Almacenamiento = almacenamientoFijo.ToString();
            itemReporte.autoconsumo = curvas.coberturaRealporConsumoAnual.ToString();
            itemReporte.consumoTA = curvas.coberturaTAporConsumoAnual.ToString();
            itemReporte.consumoCubiertoPct = (autoconsumo + consumoTA).ToString();
            itemReporte.retornoSimple = (0).ToString();
            ahorroaAnualesAvg = 0;




            for (int i = 0; i < 26; i++)
            {
                retornoSimple += calculos.calculos[i, 18];
            }

            for (int i = 0; i < 10; i++)
            {
                ahorroaAnualesAvg += calculos.calculos[i, 15];
            }

            ahorroaAnualesAvg = ahorroaAnualesAvg / 10;
            ahorroaAnualesAvg = ahorroaAnualesAvg / tipoCambio;
            compania = Compania;

            itemReporte.ahorroaAnualesAvg = ahorroaAnualesAvg.ToString();
            itemReporte.Compania = Compania;


            //Revisar cuando hay costo unitario sí, tamaño fijo sí, mantenimiento GAM



            Inversor.Add(Math.Round(financiamiento.Centralizado[12]));
            Inversor.Add(financiamiento.Centralizado[1] * 100);
            Inversor.Add(Math.Round(financiamiento.Centralizado[2]));
            Inversor.Add(2);
            Inversor.Add(Math.Round(financiamiento.Centralizado[14]));

            Optimizador.Add(Math.Round(financiamiento.Optimizadores[12]));
            Optimizador.Add(financiamiento.Optimizadores[1] * 100);
            Optimizador.Add(Math.Round(financiamiento.Optimizadores[2]));
            Optimizador.Add(2);
            Optimizador.Add(Math.Round(financiamiento.Optimizadores[14]));

            Microinversor.Add(Math.Round(financiamiento.Microinversor[12]));
            Microinversor.Add(financiamiento.Microinversor[1] * 100);
            Microinversor.Add(Math.Round(financiamiento.Microinversor[2]));
            Microinversor.Add(2);
            Microinversor.Add(Math.Round(financiamiento.Microinversor[14]));



            //Histórico de facturas

            for (int i = 0; i < 12; i++)
            {
                HistFacturas itemhistFact = new HistFacturas();
                itemhistFact.consumoEnergia = Math.Round(calculos.consumoEnergiaTot[i]).ToString();
                itemhistFact.costoBaseEner1 = Math.Round(calculos.costoBaseEner[0, i + 1] / tipoCambio).ToString();
                // energiaDetalle[3, i] = Math.Round(0.13 * (calculos.costoBaseEner[0, i + 1] + calculos.costoBasePot[0, i + 1]) / tipoCambio);
                itemhistFact.costoBaseEner2 = Math.Round(calculos.costoBasePot[0, i + 1] / tipoCambio).ToString();
                itemReporte.histFact.Add(itemhistFact);

            }
            //Anuales
            itemReporte.TRhistAnual = Math.Round(calculos.consumoEnergiaTot[12]).ToString();
            itemReporte.ChistAnual = Math.Round(calculos.costoBaseEner[0, 13] / tipoCambio).ToString();
            //energiaDetalle[3, 12] = Math.Round(calculos.calculos[0, 8] / tipoCambio);
            itemReporte.IhistAnual = Math.Round(calculos.costoBasePot[0, 13] / tipoCambio).ToString();



            //Proyección con Energía Solar


            for (int i = 0; i < 12; i++)
            {
                ProyFactura itemproyFact = new ProyFactura();
                itemproyFact.compraReg = Math.Round(calculos.compraRegP[0, i + 1] + calculos.compraRegV[0, i + 1] + calculos.compraRegN[0, i + 1]).ToString();
                itemproyFact.enerCoberturTarAcc = Math.Round(calculos.enerCoberturTarAcc[0, i + 1]).ToString();
                itemproyFact.costoPredichoEner1 = Math.Round(calculos.costoPredichoEner[0, i + 1] / tipoCambio).ToString();
                //potenciaDetalle[4, i] = Math.Round(0.13 * (calculos.costoPredichoEner[0, i + 1] + calculos.costoPredichoPot[0, i + 1]) / tipoCambio);
                itemproyFact.costoPredichoEner2 = Math.Round(calculos.costoPredichoPot[0, i + 1] / tipoCambio).ToString();
                itemReporte.proyFact.Add(itemproyFact);
            }
            //Anuales
            itemReporte.TRproyAnual = Math.Round(calculos.compraRegP[0, 13] + calculos.compraRegV[0, 13] + calculos.compraRegN[0, 13]).ToString();
            itemReporte.TAproyAnual = Math.Round(calculos.enerCoberturTarAcc[0, 13]).ToString();
            itemReporte.CproyAnual = Math.Round(calculos.costoPredichoEner[0, 13] / tipoCambio).ToString();
            //potenciaDetalle[4, 12] = Math.Round(calculos.calculos[0, 12] / tipoCambio);
            itemReporte.IproyAnual = Math.Round(calculos.costoPredichoPot[0, 13] / tipoCambio).ToString();

            reportes.Add(itemReporte);
            return (reportes);
        }
        public object datosReporteCom(clsCurvasCom curvas, clsPreliminares cPrelim, clsCalculosCom calculos, double almacenamientoFijo, string Compania, double tipoCambio, double potPanel, double avgRecibos, double horasRespaldo, clsFinanciamiento financiamiento, clsDatos datos, string CeroInyeccion)
        {

            List<Reporte> reportes = new List<Reporte>();
            Reporte itemReporte = new Reporte();

            invPremium = cPrelim.costoD;
            potSistema = cPrelim.Tamano;
            itemReporte.PotenciadePanel = potSistema.ToString();
            cantPaneles = Math.Ceiling(potSistema / (potPanel / 1000));
            itemReporte.CantidadPaneles = cantPaneles.ToString();
            itemReporte.Area = (cantPaneles * (1.05 * 2.11) / 0.8).ToString();
            itemReporte.CostoPorWatt = (invPremium / potSistema / 1000).ToString();
            itemReporte.ProduccionAnual = calculos.enerProducida[0, 13].ToString();
            itemReporte.Almacenamiento = almacenamientoFijo.ToString();
            itemReporte.autoconsumo = curvas.coberturaRealporConsumoAnual.ToString();




            if (CeroInyeccion == "Sí")
            {
                itemReporte.consumoTA = (0).ToString();
            }
            else
            {
                itemReporte.consumoTA = curvas.coberturaTAporConsumoAnual.ToString();
            }


            itemReporte.consumoCubiertoPct = (autoconsumo + consumoTA).ToString();
            itemReporte.retornoSimple = (0).ToString();
            ahorroaAnualesAvg = 0;


            for (int i = 0; i < 26; i++)
            {
                retornoSimple += calculos.calculos[i, 18];
            }

            for (int i = 0; i < 10; i++)
            {
                ahorroaAnualesAvg += calculos.calculos[i, 15];
            }

            ahorroaAnualesAvg = ahorroaAnualesAvg / 10;
            ahorroaAnualesAvg = ahorroaAnualesAvg / tipoCambio;
            compania = Compania;

            itemReporte.ahorroaAnualesAvg = ahorroaAnualesAvg.ToString();
            itemReporte.Compania = Compania;


            //Revisar cuando hay costo unitario sí, tamaño fijo sí, mantenimiento GAM



            Inversor.Add(Math.Round(financiamiento.Centralizado[12]));
            Inversor.Add(financiamiento.Centralizado[1] * 100);
            Inversor.Add(Math.Round(financiamiento.Centralizado[2]));
            Inversor.Add(2);
            Inversor.Add(Math.Round(financiamiento.Centralizado[14]));

            Optimizador.Add(Math.Round(financiamiento.Optimizadores[12]));
            Optimizador.Add(financiamiento.Optimizadores[1] * 100);
            Optimizador.Add(Math.Round(financiamiento.Optimizadores[2]));
            Optimizador.Add(2);
            Optimizador.Add(Math.Round(financiamiento.Optimizadores[14]));

            Microinversor.Add(Math.Round(financiamiento.Microinversor[12]));
            Microinversor.Add(financiamiento.Microinversor[1] * 100);
            Microinversor.Add(Math.Round(financiamiento.Microinversor[2]));
            Microinversor.Add(2);
            Microinversor.Add(Math.Round(financiamiento.Microinversor[14]));



            //Histórico de facturas

            for (int i = 0; i < 12; i++)
            {
                HistFacturas itemhistFact = new HistFacturas();
                itemhistFact.consumoEnergia = Math.Round(calculos.consumoEnergia[i]).ToString();
                itemhistFact.costoBaseEner1 = Math.Round(calculos.costoBaseEner[0, i + 1] / tipoCambio).ToString();
                //energiaDetalle[3, i] = Math.Round(0.13 * (calculos.costoBaseEner[0, i + 1] + calculos.costoBasePot[0, i + 1]) / tipoCambio);
                itemhistFact.costoBaseEner2 = Math.Round(calculos.costoBasePot[0, i + 1] / tipoCambio).ToString();
                itemReporte.histFact.Add(itemhistFact);
                
            }
            //Anuales
            itemReporte.TRhistAnual = Math.Round(calculos.consumoEnergia[12]).ToString();
            itemReporte.ChistAnual = Math.Round(calculos.costoBaseEner[0, 13] / tipoCambio).ToString();
            //energiaDetalle[3, 12] = Math.Round(calculos.calculos[0, 8] / tipoCambio);
            itemReporte.IhistAnual = Math.Round(calculos.costoBasePot[0, 13] / tipoCambio).ToString();

            

            //Proyección con Energía Solar


            double sumador1 = 0;




            for (int i = 0; i < 12; i++)
            {
                ProyFactura itemproyFact = new ProyFactura();
                if (CeroInyeccion == "No")
                {
                    sumador1 = 0;
                }
                else
                {
                    sumador1 = calculos.enerCoberturTarAcc[0, i];
                }

                itemproyFact.compraReg = Math.Round(calculos.compraReg[0, i + 1] + sumador1).ToString();

                if (CeroInyeccion == "Sí")
                {
                    itemproyFact.enerCoberturTarAcc = (0).ToString();
                }
                else
                {
                    itemproyFact.enerCoberturTarAcc = Math.Round(calculos.enerCoberturTarAcc[0, i + 1]).ToString();
                }


                itemproyFact.costoPredichoEner1 = Math.Round(calculos.costoPredichoEner[0, i + 1] / tipoCambio).ToString();
                //potenciaDetalle[4, i] = Math.Round(0.13 * (calculos.costoPredichoEner[0, i + 1] + calculos.costoPredichoPot[0, i + 1]) / tipoCambio);
                itemproyFact.costoPredichoEner2 = Math.Round(calculos.costoPredichoPot[0, i + 1] / tipoCambio).ToString();

                
                 
                itemReporte.proyFact.Add(itemproyFact);
            }
            
            //Anuales

            if (CeroInyeccion == "No")
            {
                sumador1 = 0;
            }
            else
            {
                sumador1 = calculos.enerCoberturTarAcc[0, 13];
            }


            itemReporte.TRproyAnual = Math.Round(calculos.compraReg[0, 13] + sumador1).ToString();

            if (CeroInyeccion == "Sí")
            {
                itemReporte.TAproyAnual = (0).ToString();
            }
            else
            {
                itemReporte.TAproyAnual = Math.Round(calculos.enerCoberturTarAcc[0, 13]).ToString();
            }

            itemReporte.CproyAnual = Math.Round(calculos.costoPredichoEner[0, 13] / tipoCambio).ToString();
            //potenciaDetalle[4, 12] = Math.Round(calculos.calculos[0, 12] / tipoCambio);
            itemReporte.IproyAnual = Math.Round(calculos.costoPredichoPot[0, 13] / tipoCambio).ToString();


            reportes.Add(itemReporte);
            return (reportes);
        }
    }
}

