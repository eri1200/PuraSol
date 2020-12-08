using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class clsCalculosTMT
    {
        clsTarifas tarifas = new clsTarifas();


        public List<double> consumoEnergiaP = new List<double>();
        public List<double> demandaEnergiaP = new List<double>();
        public List<double> consumoEnergiaV = new List<double>();
        public List<double> demandaEnergiaV = new List<double>();
        public List<double> consumoEnergiaN = new List<double>();
        public List<double> demandaEnergiaN = new List<double>();
        public List<double> consumoEnergiaTot = new List<double>();

        public List<double> demandaPotP = new List<double>();
        public List<double> demandaPotV = new List<double>();
        public List<double> demandaPotN = new List<double>();


        public List<double> tarMT = new List<double>();
        //public List<double> tarRE = new List<double>();
        public List<double> potMaxBloque = new List<double>();

        public double[,] calculos = new double[26, 32];

        public double[,] costoBaseEner = new double[26, 14];
        public double[,] enerProducida = new double[26, 14];
        public double[,] enerCoberturaRealP = new double[26, 14];
        public double[,] compraRegP = new double[26, 14];
        public double[,] enerCoberturaRealV = new double[26, 14];
        public double[,] compraRegV = new double[26, 14];
        public double[,] enerCoberturaRealN = new double[26, 14];
        public double[,] compraRegN = new double[26, 14];
        public double[,] enerCoberturTarAcc = new double[26, 14];
        public double[,] sobranteTA = new double[26, 14];
        public double[,] costoPredichoEner = new double[26, 14];
        public double[,] costoPredichoPot = new double[26, 14];
        public double[,] comprado = new double[26, 14];
        public double[,] costoBasePot = new double[26, 14];


        public void calculosTMT(double PPREne, double PPRFeb, double PPRMar, double PPRAbr, double PPRMay, double PPRJun, double PPRJul, double PPRAgo, double PPRSep, double PPROct, double PPRNov, double PPRDic,
    double PVREne, double PVRFeb, double PVRMar, double PVRAbr, double PVRMay, double PVRJun, double PVRJul, double PVRAgo, double PVRSep, double PVROct, double PVRNov, double PVRDic,
    double PNREne, double PNRFeb, double PNRMar, double PNRAbr, double PNRMay, double PNRJun, double PNRJul, double PNRAgo, double PNRSep, double PNROct, double PNRNov,
    double PNRDic, double PPDEne, double PPDFeb, double PPDMar, double PPDAbr, double PPDMay, double PPDJun, double PPDJul, double PPDAgo, double PPDSep, double PPDOct, double PPDNov, double PPDDic,
    double PVDEne, double PVDFeb, double PVDMar, double PVDAbr, double PVDMay, double PVDJun, double PVDJul, double PVDAgo, double PVDSep,
    double PVDOct, double PVDNov, double PVDDic, double PNDEne, double PNDFeb, double PNDMar, double PNDAbr, double PNDMay, double PNDJun, double PNDJul, double PNDAgo, double PNDSep, double PNDOct, double PNDNov, double PNDDic,
    double PRSGISEne, double PRSGISFeb, double PRSGISMar, double PRSGISAbr, double PRSGISMay, double PRSGISJun, double PRSGISJul, double PRSGISAgo, double PRSGISSep, double PRSGISOct, double PRSGISNov, double PRSGISDic,
    double PromedioRecibos, double PromedioSGIS, double crecimientoAnual, string Compania, string Tarifa, clsCurvasTMT curvas, List<double> pico)
        {

            consumoEnergiaP.Add(PPREne);
            consumoEnergiaP.Add(PPRFeb);
            consumoEnergiaP.Add(PPRMar);
            consumoEnergiaP.Add(PPRAbr);
            consumoEnergiaP.Add(PPRMay);
            consumoEnergiaP.Add(PPRJun);
            consumoEnergiaP.Add(PPRJul);
            consumoEnergiaP.Add(PPRAgo);
            consumoEnergiaP.Add(PPRSep);
            consumoEnergiaP.Add(PPROct);
            consumoEnergiaP.Add(PPRNov);
            consumoEnergiaP.Add(PPRDic);
            consumoEnergiaP.Add(PPREne + PPRFeb + PPRMar + PPRAbr + PPRMay + PPRJun + PPRJul + PPRAgo + PPRSep + PPROct + PPRNov + PPRDic);

            consumoEnergiaV.Add(PVREne);
            consumoEnergiaV.Add(PVRFeb);
            consumoEnergiaV.Add(PVRMar);
            consumoEnergiaV.Add(PVRAbr);
            consumoEnergiaV.Add(PVRMay);
            consumoEnergiaV.Add(PVRJun);
            consumoEnergiaV.Add(PVRJul);
            consumoEnergiaV.Add(PVRAgo);
            consumoEnergiaV.Add(PVRSep);
            consumoEnergiaV.Add(PVROct);
            consumoEnergiaV.Add(PVRNov);
            consumoEnergiaV.Add(PVRDic);
            consumoEnergiaV.Add(PVREne + PVRFeb + PVRMar + PVRAbr + PVRMay + PVRJun + PVRJul + PVRAgo + PVRSep + PVROct + PVRNov + PVRDic);

            consumoEnergiaN.Add(PNREne);
            consumoEnergiaN.Add(PNRFeb);
            consumoEnergiaN.Add(PNRMar);
            consumoEnergiaN.Add(PNRAbr);
            consumoEnergiaN.Add(PNRMay);
            consumoEnergiaN.Add(PNRJun);
            consumoEnergiaN.Add(PNRJul);
            consumoEnergiaN.Add(PNRAgo);
            consumoEnergiaN.Add(PNRSep);
            consumoEnergiaN.Add(PNROct);
            consumoEnergiaN.Add(PNRNov);
            consumoEnergiaN.Add(PNRDic);
            consumoEnergiaN.Add(PNREne + PNRFeb + PNRMar + PNRAbr + PNRMay + PNRJun + PNRJul + PNRAgo + PNRSep + PNROct + PNRNov + PNRDic);

            double consumoSum = 0;

            for (int i = 0; i < 12; i++)
            {
                consumoEnergiaTot.Add(consumoEnergiaP[i] + consumoEnergiaV[i] + consumoEnergiaN[i]);
                consumoSum += consumoEnergiaP[i] + consumoEnergiaV[i] + consumoEnergiaN[i];
            }

            consumoEnergiaTot.Add(consumoSum);

            demandaEnergiaP.Add(PNDEne);
            demandaEnergiaP.Add(PNDFeb);
            demandaEnergiaP.Add(PNDMar);
            demandaEnergiaP.Add(PNDAbr);
            demandaEnergiaP.Add(PNDMay);
            demandaEnergiaP.Add(PNDJun);
            demandaEnergiaP.Add(PNDJul);
            demandaEnergiaP.Add(PNDAgo);
            demandaEnergiaP.Add(PNDSep);
            demandaEnergiaP.Add(PNDOct);
            demandaEnergiaP.Add(PNDNov);
            demandaEnergiaP.Add(PNDDic);

            demandaEnergiaV.Add(PNDEne);
            demandaEnergiaV.Add(PNDFeb);
            demandaEnergiaV.Add(PNDMar);
            demandaEnergiaV.Add(PNDAbr);
            demandaEnergiaV.Add(PNDMay);
            demandaEnergiaV.Add(PNDJun);
            demandaEnergiaV.Add(PNDJul);
            demandaEnergiaV.Add(PNDAgo);
            demandaEnergiaV.Add(PNDSep);
            demandaEnergiaV.Add(PNDOct);
            demandaEnergiaV.Add(PNDNov);
            demandaEnergiaV.Add(PNDDic);

            demandaEnergiaN.Add(PNDEne);
            demandaEnergiaN.Add(PNDFeb);
            demandaEnergiaN.Add(PNDMar);
            demandaEnergiaN.Add(PNDAbr);
            demandaEnergiaN.Add(PNDMay);
            demandaEnergiaN.Add(PNDJun);
            demandaEnergiaN.Add(PNDJul);
            demandaEnergiaN.Add(PNDAgo);
            demandaEnergiaN.Add(PNDSep);
            demandaEnergiaN.Add(PNDOct);
            demandaEnergiaN.Add(PNDNov);
            demandaEnergiaN.Add(PNDDic);

            double maxP = 0;
            double maxV = 0;
            double maxN = 0;

            for (int i = 0; i < 12; i++)
            {
                maxP = Math.Max(maxP, demandaEnergiaP[i]);
                maxV = Math.Max(maxV, demandaEnergiaV[i]);
                maxN = Math.Max(maxN, demandaEnergiaN[i]);
            }

            demandaEnergiaP.Add(maxP);
            demandaEnergiaV.Add(maxV);
            demandaEnergiaN.Add(maxN);

            //calcula las primeras 7 columnas de la matriz de cálculos
            for (int i = 0; i < 26; i++)
            {
                calculos[i, 0] = i;

                if (i == 0)
                {
                    calculos[i, 1] = consumoEnergiaTot[12];
                    calculos[i, 2] = 1;
                    calculos[i, 3] = ((0.9 - 0.975) * calculos[i, 0]) / (10 - 0) + 0.975; //Rendimiento del panel
                    calculos[i, 4] = calculos[i, 3] * curvas.coberturaRealporProdAnual;
                    calculos[i, 5] = calculos[i, 3] * curvas.coberturaTAporProdAnual;
                    calculos[i, 6] = 1;
                }
                else
                {
                    calculos[i, 1] = calculos[i - 1, 1] * (1 + crecimientoAnual);
                    calculos[i, 2] = calculos[i - 1, 2] * (1 + crecimientoAnual);

                    if (calculos[i, 0] <= 10)
                    {
                        calculos[i, 3] = ((0.9 - 0.975) * calculos[i, 0]) / (10 - 0) + 0.975; //Rendimiento del panel
                    }
                    else
                    {
                        calculos[i, 3] = ((0.8 - 0.9) * calculos[i, 0]) / (25 - 10) + 0.9 - ((0.8 - 0.9) * 10 / (25 - 10)); //Rendimiento del panel
                    }

                    calculos[i, 4] = calculos[i, 3] * curvas.coberturaRealporProdAnual;
                    calculos[i, 5] = calculos[i, 3] * curvas.coberturaTAporProdAnual;
                    calculos[i, 6] = calculos[i - 1, 6] * (1 + 0.05);
                }

            }




            switch (Compania)
            {
                case "ICE":
                    tarMT.Add(tarifas.MTICEEPUNTA);
                    tarMT.Add(tarifas.MTICEEVALLE);
                    tarMT.Add(tarifas.MTICEENOCHE);
                    tarMT.Add(tarifas.AICETA);
                    tarMT.Add(tarifas.APICE4150000);

                    potMaxBloque.Add(tarifas.MTICEPPUNTA);
                    potMaxBloque.Add(tarifas.MTICEPVALLE);
                    potMaxBloque.Add(tarifas.MTICEPNOCHE);

                    break;
                case "CNFL":
                    tarMT.Add(tarifas.MTCNFLEPUNTA);
                    tarMT.Add(tarifas.MTCNFLEVALLE);
                    tarMT.Add(tarifas.MTCNFLENOCHE);
                    tarMT.Add(tarifas.ACNFLTA);
                    tarMT.Add(tarifas.APCNFL3040);

                    potMaxBloque.Add(tarifas.MTCNFLPPUNTA);
                    potMaxBloque.Add(tarifas.MTCNFLPVALLE);
                    potMaxBloque.Add(tarifas.MTCNFLPNOCHE);
                    break;
                case "JASEC":
                    tarMT.Add(tarifas.MTJASECEPUNTA);
                    tarMT.Add(tarifas.MTJASECEVALLE);
                    tarMT.Add(tarifas.MTJASECENOCHE);
                    tarMT.Add(tarifas.AJASECTA);
                    tarMT.Add(tarifas.APJASEC3040);

                    potMaxBloque.Add(tarifas.MTJASECPPUNTA);
                    potMaxBloque.Add(tarifas.MTJASECPVALLE);
                    potMaxBloque.Add(tarifas.MTJASECPNOCHE);
                    break;
                case "ESPH":
                    tarMT.Add(tarifas.MTESPHEPUNTA);
                    tarMT.Add(tarifas.MTESPHEVALLE);
                    tarMT.Add(tarifas.MTESPHENOCHE);
                    tarMT.Add(tarifas.AESPHTA);
                    tarMT.Add(tarifas.APESPH3040);

                    potMaxBloque.Add(tarifas.MTESPHPPUNTA);
                    potMaxBloque.Add(tarifas.MTESPHPVALLE);
                    potMaxBloque.Add(tarifas.MTESPHPNOCHE);
                    break;
                case "COOPELESCA":
                    tarMT.Add(tarifas.MTCOOPELEPUNTA);
                    tarMT.Add(tarifas.MTCOOPELEVALLE);
                    tarMT.Add(tarifas.MTCOOPELENOCHE);
                    tarMT.Add(tarifas.ACOOPELTA);
                    tarMT.Add(tarifas.APCOOPEL3040);

                    potMaxBloque.Add(tarifas.MTCOOPELPPUNTA);
                    potMaxBloque.Add(tarifas.MTCOOPELPVALLE);
                    potMaxBloque.Add(tarifas.MTCOOPELPNOCHE);
                    break;
                case "COOPEGUANACASTE":
                    tarMT.Add(tarifas.MTCOOPEGEPUNTA);
                    tarMT.Add(tarifas.MTCOOPEGEVALLE);
                    tarMT.Add(tarifas.MTCOOPEGENOCHE);
                    tarMT.Add(tarifas.ACOOPEGTA);
                    tarMT.Add(tarifas.APCOOPEG3040);

                    potMaxBloque.Add(tarifas.MTCOOPEGPPUNTA);
                    potMaxBloque.Add(tarifas.MTCOOPEGPVALLE);
                    potMaxBloque.Add(tarifas.MTCOOPEGPNOCHE);
                    break;
                case "COOPESANTOS":
                    tarMT.Add(tarifas.MTCOOPESEPUNTA);
                    tarMT.Add(tarifas.MTCOOPESEVALLE);
                    tarMT.Add(tarifas.MTCOOPESENOCHE);
                    tarMT.Add(tarifas.ACOOPESTA);
                    tarMT.Add(tarifas.APCOOPES4150000);

                    potMaxBloque.Add(tarifas.MTCOOPESPPUNTA);
                    potMaxBloque.Add(tarifas.MTCOOPESPVALLE);
                    potMaxBloque.Add(tarifas.MTCOOPESPNOCHE);
                    break;
                case "COOPEALFARORUIZ":
                    tarMT.Add(tarifas.MTCOOPEAEPUNTA);
                    tarMT.Add(tarifas.MTCOOPEAEVALLE);
                    tarMT.Add(tarifas.MTCOOPEAENOCHE);
                    tarMT.Add(tarifas.ACOOPEATA);
                    tarMT.Add(tarifas.APCOOPEA3040);

                    potMaxBloque.Add(tarifas.MTCOOPEAPPUNTA);
                    potMaxBloque.Add(tarifas.MTCOOPEAPVALLE);
                    potMaxBloque.Add(tarifas.MTCOOPEAPNOCHE);
                    break;
            }



            // llenando la matriz de costo base energía

            for (int i = 0; i < 26; i++)
            {
                costoBaseEner[i, 0] = i;

                for (int j = 1; j < 13; j++)
                {

                    if (i == 0)
                    {
                        costoBaseEner[i, j] = consumoEnergiaP[j - 1] * tarMT[0] + consumoEnergiaV[j - 1] * tarMT[1] + consumoEnergiaN[j - 1] * tarMT[2];
                    }
                    else
                    {
                        costoBaseEner[i, j] = costoBaseEner[0, j] * calculos[i, 6];
                    }
                }

                costoBaseEner[i, 13] = costoBaseEner[i, 1] + costoBaseEner[i, 2] + costoBaseEner[i, 3] + costoBaseEner[i, 4] + costoBaseEner[i, 5] + costoBaseEner[i, 6] + costoBaseEner[i, 7] + costoBaseEner[i, 8] +
                    costoBaseEner[i, 9] + costoBaseEner[i, 10] + costoBaseEner[i, 11] + costoBaseEner[i, 12];
            }


            //llenar la primera fila de la matriz de energía producida

            for (int i = 0; i < 35040; i++)
            {
                if (i < 2976) //Enero
                {
                    enerProducida[0, 1] += curvas.cAnual[i, 3];
                }
                else if (i < 5664) //Febrero
                {
                    enerProducida[0, 2] += curvas.cAnual[i, 3];
                }
                else if (i < 8640) //Marzo
                {
                    enerProducida[0, 3] += curvas.cAnual[i, 3];
                }
                else if (i < 11520) //Abril
                {
                    enerProducida[0, 4] += curvas.cAnual[i, 3];
                }
                else if (i < 14496) //Mayo
                {
                    enerProducida[0, 5] += curvas.cAnual[i, 3];
                }
                else if (i < 17376) //Junio
                {
                    enerProducida[0, 6] += curvas.cAnual[i, 3];
                }
                else if (i < 20352) //Julio
                {
                    enerProducida[0, 7] += curvas.cAnual[i, 3];
                }
                else if (i < 23328) //Agosto
                {
                    enerProducida[0, 8] += curvas.cAnual[i, 3];
                }
                else if (i < 26208) //Septiembre
                {
                    enerProducida[0, 9] += curvas.cAnual[i, 3];
                }
                else if (i < 29184) //Octubre
                {
                    enerProducida[0, 10] += curvas.cAnual[i, 3];
                }
                else if (i < 32064) //Noviembre
                {
                    enerProducida[0, 11] += curvas.cAnual[i, 3];
                }
                else  //Diciembre
                {
                    enerProducida[0, 12] += curvas.cAnual[i, 3];
                }

            }

            for (int i = 0; i < 26; i++)
            {
                enerProducida[0, 0] = 0;

                for (int j = 1; j < 13; j++)
                {
                    if (i == 0)
                    {
                        enerProducida[i, j] = enerProducida[i, j] * 0.25 * calculos[i, 3];
                    }
                    else
                    {
                        enerProducida[i, j] = enerProducida[0, j] * calculos[i, 3];
                    }
                }

                enerProducida[i, 13] = enerProducida[i, 1] + enerProducida[i, 2] + enerProducida[i, 3] + enerProducida[i, 4] + enerProducida[i, 5] + enerProducida[i, 6] + enerProducida[i, 7] + enerProducida[i, 8] +
                    enerProducida[i, 9] + enerProducida[i, 10] + enerProducida[i, 11] + enerProducida[i, 12];


            }



            //llenar la  matriz de energía de cobertura real en punta

            for (int i = 0; i < 35040; i++)
            {
                if (i < 2976) //Enero
                {
                    enerCoberturaRealP[0, 1] += curvas.cAnual[i, 9];
                }
                else if (i < 5664) //Febrero
                {
                    enerCoberturaRealP[0, 2] += curvas.cAnual[i, 9];
                }
                else if (i < 8640) //Marzo
                {
                    enerCoberturaRealP[0, 3] += curvas.cAnual[i, 9];
                }
                else if (i < 11520) //Abril
                {
                    enerCoberturaRealP[0, 4] += curvas.cAnual[i, 9];
                }
                else if (i < 14496) //Mayo
                {
                    enerCoberturaRealP[0, 5] += curvas.cAnual[i, 9];
                }
                else if (i < 17376) //Junio
                {
                    enerCoberturaRealP[0, 6] += curvas.cAnual[i, 9];
                }
                else if (i < 20352) //Julio
                {
                    enerCoberturaRealP[0, 7] += curvas.cAnual[i, 9];
                }
                else if (i < 23328) //Agosto
                {
                    enerCoberturaRealP[0, 8] += curvas.cAnual[i, 9];
                }
                else if (i < 26208) //Septiembre
                {
                    enerCoberturaRealP[0, 9] += curvas.cAnual[i, 9];
                }
                else if (i < 29184) //Octubre
                {
                    enerCoberturaRealP[0, 10] += curvas.cAnual[i, 9];
                }
                else if (i < 32064) //Noviembre
                {
                    enerCoberturaRealP[0, 11] += curvas.cAnual[i, 9];
                }
                else  //Diciembre
                {
                    enerCoberturaRealP[0, 12] += curvas.cAnual[i, 9];
                }

            }


            for (int i = 0; i < 26; i++)
            {
                enerCoberturaRealP[i, 0] = i;

                for (int j = 1; j < 13; j++)
                {
                    if (i == 0)
                    {
                        enerCoberturaRealP[i, j] = enerCoberturaRealP[i, j] * 0.25 * calculos[i, 3];
                    }
                    else
                    {
                        enerCoberturaRealP[i, j] = enerCoberturaRealP[0, j] * calculos[i, 3];
                    }
                }

                enerCoberturaRealP[i, 13] = enerCoberturaRealP[i, 1] + enerCoberturaRealP[i, 2] + enerCoberturaRealP[i, 3] + enerCoberturaRealP[i, 4] + enerCoberturaRealP[i, 5] + enerCoberturaRealP[i, 6] + enerCoberturaRealP[i, 7] + enerCoberturaRealP[i, 8] +
                        enerCoberturaRealP[i, 9] + enerCoberturaRealP[i, 10] + enerCoberturaRealP[i, 11] + enerCoberturaRealP[i, 12];


            }


            //llenar la matriz de compra regular en punta

            for (int i = 0; i < 26; i++)
            {
                compraRegP[i, 0] = i;

                for (int j = 1; j < 14; j++)
                {
                    if (i == 0)
                    {
                        compraRegP[i, j] = consumoEnergiaP[j-1] - enerCoberturaRealP[i, j];
                    }
                    else
                    {
                        compraRegP[i, j] = compraRegP[0, j] * calculos[i, 6];
                    }
                }

            }

            //llenar la primera fila de la matriz de energía de cobertura real en valle
            for (int i = 0; i < 35040; i++)
            {
                if (i < 2976) //Enero
                {
                    enerCoberturaRealV[0, 1] += curvas.cAnual[i, 12];
                }
                else if (i < 5664) //Febrero
                {
                    enerCoberturaRealV[0, 2] += curvas.cAnual[i, 12];
                }
                else if (i < 8640) //Marzo
                {
                    enerCoberturaRealV[0, 3] += curvas.cAnual[i, 12];
                }
                else if (i < 11520) //Abril
                {
                    enerCoberturaRealV[0, 4] += curvas.cAnual[i, 12];
                }
                else if (i < 14496) //Mayo
                {
                    enerCoberturaRealV[0, 5] += curvas.cAnual[i, 12];
                }
                else if (i < 17376) //Junio
                {
                    enerCoberturaRealV[0, 6] += curvas.cAnual[i, 12];
                }
                else if (i < 20352) //Julio
                {
                    enerCoberturaRealV[0, 7] += curvas.cAnual[i, 12];
                }
                else if (i < 23328) //Agosto
                {
                    enerCoberturaRealV[0, 8] += curvas.cAnual[i, 12];
                }
                else if (i < 26208) //Septiembre
                {
                    enerCoberturaRealV[0, 9] += curvas.cAnual[i, 12];
                }
                else if (i < 29184) //Octubre
                {
                    enerCoberturaRealV[0, 10] += curvas.cAnual[i, 12];
                }
                else if (i < 32064) //Noviembre
                {
                    enerCoberturaRealV[0, 11] += curvas.cAnual[i, 12];
                }
                else  //Diciembre
                {
                    enerCoberturaRealV[0, 12] += curvas.cAnual[i, 12];
                }

            }


            for (int i = 0; i < 26; i++)
            {
                enerCoberturaRealV[i, 0] = i;

                for (int j = 1; j < 13; j++)
                {
                    if (i == 0)
                    {
                        enerCoberturaRealV[i, j] = enerCoberturaRealV[i, j] * 0.25 * calculos[i, 3];
                    }
                    else
                    {
                        enerCoberturaRealV[i, j] = enerCoberturaRealV[0, j] * calculos[i, 3];
                    }
                }

                enerCoberturaRealV[i, 13] = enerCoberturaRealV[i, 1] + enerCoberturaRealV[i, 2] + enerCoberturaRealV[i, 3] + enerCoberturaRealV[i, 4] + enerCoberturaRealV[i, 5] + enerCoberturaRealV[i, 6] + enerCoberturaRealV[i, 7] + enerCoberturaRealV[i, 8] +
                        enerCoberturaRealV[i, 9] + enerCoberturaRealV[i, 10] + enerCoberturaRealV[i, 11] + enerCoberturaRealV[i, 12];


            }


            //llenar la matriz de compra regular en valle

            for (int i = 0; i < 26; i++)
            {
                compraRegV[i, 0] = i;

                for (int j = 1; j < 14; j++)
                {
                    if (i == 0)
                    {
                        compraRegV[i, j] = consumoEnergiaV[j-1] - enerCoberturaRealV[i, j];
                    }
                    else
                    {
                        compraRegV[i, j] = compraRegV[0, j] * calculos[i, 6];
                    }
                }

            }

            //llenar la matriz de energía de cobertura real en noche
            for (int i = 0; i < 35040; i++)
            {
                if (i < 2976) //Enero
                {
                    enerCoberturaRealN[0, 1] += curvas.cAnual[i, 15];
                }
                else if (i < 5664) //Febrero
                {
                    enerCoberturaRealN[0, 2] += curvas.cAnual[i, 15];
                }
                else if (i < 8640) //Marzo
                {
                    enerCoberturaRealN[0, 3] += curvas.cAnual[i, 15];
                }
                else if (i < 11520) //Abril
                {
                    enerCoberturaRealN[0, 4] += curvas.cAnual[i, 15];
                }
                else if (i < 14496) //Mayo
                {
                    enerCoberturaRealN[0, 5] += curvas.cAnual[i, 15];
                }
                else if (i < 17376) //Junio
                {
                    enerCoberturaRealN[0, 6] += curvas.cAnual[i, 15];
                }
                else if (i < 20352) //Julio
                {
                    enerCoberturaRealN[0, 7] += curvas.cAnual[i, 15];
                }
                else if (i < 23328) //Agosto
                {
                    enerCoberturaRealN[0, 8] += curvas.cAnual[i, 15];
                }
                else if (i < 26208) //Septiembre
                {
                    enerCoberturaRealN[0, 9] += curvas.cAnual[i, 15];
                }
                else if (i < 29184) //Octubre
                {
                    enerCoberturaRealN[0, 10] += curvas.cAnual[i, 15];
                }
                else if (i < 32064) //Noviembre
                {
                    enerCoberturaRealN[0, 11] += curvas.cAnual[i, 15];
                }
                else  //Diciembre
                {
                    enerCoberturaRealN[0, 12] += curvas.cAnual[i, 15];
                }

            }


            for (int i = 0; i < 26; i++)
            {
                enerCoberturaRealN[i, 0] = i;

                for (int j = 1; j < 13; j++)
                {
                    if (i == 0)
                    {
                        enerCoberturaRealN[i, j] = enerCoberturaRealN[i, j] * 0.25 * calculos[i, 3];
                    }
                    else
                    {
                        enerCoberturaRealN[i, j] = enerCoberturaRealN[0, j] * calculos[i, 3];
                    }
                }

                enerCoberturaRealN[i, 13] = enerCoberturaRealN[i, 1] + enerCoberturaRealN[i, 2] + enerCoberturaRealN[i, 3] + enerCoberturaRealN[i, 4] + enerCoberturaRealN[i, 5] + enerCoberturaRealN[i, 6] + enerCoberturaRealN[i, 7] + enerCoberturaRealN[i, 8] +
                        enerCoberturaRealN[i, 9] + enerCoberturaRealN[i, 10] + enerCoberturaRealN[i, 11] + enerCoberturaRealN[i, 12];


            }


            //llenar la matriz de compra regular en noche

            for (int i = 0; i < 26; i++)
            {
                compraRegN[i, 0] = i;

                for (int j = 1; j < 14; j++)
                {
                    if (i == 0)
                    {
                        compraRegN[i, j] = consumoEnergiaN[j-1] - enerCoberturaRealN[i, j];
                    }
                    else
                    {
                        compraRegN[i, j] = compraRegN[0, j] * calculos[i, 6];
                    }
                }

            }

            //llenar la matriz de sobrante TA

            for (int i = 0; i < 26; i++)
            {
                sobranteTA[i, 0] = i;

                for (int j = 1; j < 13; j++)
                {
                    if (j == 1)
                    {
                        if (enerProducida[i, j] > (consumoEnergiaP[j - 1] + consumoEnergiaV[j - 1] + consumoEnergiaN[j - 1]) * calculos[i, 2])
                        {
                            sobranteTA[i, j] = enerProducida[i, j] - ((consumoEnergiaP[j - 1] + consumoEnergiaV[j - 1] + consumoEnergiaN[j - 1]) * calculos[i, 2]);
                        }
                        else
                        {
                            sobranteTA[i, j] = 0;
                        }
                    }
                    else
                    {
                        if ((sobranteTA[i, j - 1] + enerProducida[i, j]) > (consumoEnergiaP[j - 1] + consumoEnergiaV[j - 1] + consumoEnergiaN[j - 1]) * calculos[i, 2])
                        {
                            sobranteTA[i, j] = sobranteTA[i, j - 1] + enerProducida[i, j] - ((consumoEnergiaP[j - 1] + consumoEnergiaV[j - 1] + consumoEnergiaN[j - 1]) * calculos[i, 2]);
                        }
                        else
                        {
                            sobranteTA[i, j] = 0;
                        }
                    }
                }

                sobranteTA[i, 13] = sobranteTA[i, 12];

            }

            //llenar la matriz de energía por tarifa de acceso

            for (int i = 0; i < 26; i++)
            {
                enerCoberturTarAcc[i, 0] = i;

                for (int j = 1; j < 13; j++)
                {
                    if (j == 1)
                    {
                        if (enerProducida[i, j] > (consumoEnergiaP[j - 1] + consumoEnergiaV[j - 1] + consumoEnergiaN[j - 1]) * calculos[i, 2])
                        {
                            enerCoberturTarAcc[i, j] = (consumoEnergiaP[j - 1] + consumoEnergiaV[j - 1] + consumoEnergiaN[j - 1]) * calculos[i, 2] - (enerCoberturaRealP[i, j] + enerCoberturaRealV[i, j] + enerCoberturaRealN[i, j]);
                        }
                        else
                        {
                            enerCoberturTarAcc[i, j] = enerProducida[i, j] - (enerCoberturaRealP[i, j] + enerCoberturaRealV[i, j] + enerCoberturaRealN[i, j]);
                        }
                    }
                    else
                    {
                        if ((sobranteTA[i, j - 1] + enerProducida[i, j]) > (consumoEnergiaP[j - 1] + consumoEnergiaV[j - 1] + consumoEnergiaN[j - 1]) * calculos[i, 2])
                        {
                            enerCoberturTarAcc[i, j] = (consumoEnergiaP[j - 1] + consumoEnergiaV[j - 1] + consumoEnergiaN[j - 1]) * calculos[i, 2] - (enerCoberturaRealP[i, j] + enerCoberturaRealV[i, j] + enerCoberturaRealN[i, j]);
                        }
                        else
                        {
                            enerCoberturTarAcc[i, j] = (sobranteTA[i, j - 1] + enerProducida[i, j]) - (enerCoberturaRealP[i, j] + enerCoberturaRealV[i, j] + enerCoberturaRealN[i, j]);
                        }
                    }
                }

                enerCoberturTarAcc[i, 13] = Math.Floor((enerCoberturTarAcc[i, 1] + enerCoberturTarAcc[i, 2] + enerCoberturTarAcc[i, 3] + enerCoberturTarAcc[i, 4] + enerCoberturTarAcc[i, 5] + enerCoberturTarAcc[i, 6] +
                    enerCoberturTarAcc[i, 7] + enerCoberturTarAcc[i, 8] + enerCoberturTarAcc[i, 9] + enerCoberturTarAcc[i, 10] + enerCoberturTarAcc[i, 11] + enerCoberturTarAcc[i, 12]) / 10) * 10;

            }



            


            //llenar la matriz de comprado

            for (int i = 0; i < 26; i++)
            {
                comprado[i, 0] = i;

                for (int j = 1; j < 14; j++)
                {
                    comprado[i, j] = (compraRegP[i, j] + compraRegV[i, j] + compraRegN[i, j]) + enerCoberturTarAcc[i, j];
                }
            }


            //llenar la matriz de costo predicho (energia)

            for (int i = 0; i < 26; i++)  ////Revisar el costoPredichoEner[0, 2] que dé 13481.796
            {
                costoPredichoEner[i, 0] = i;

                for (int j = 1; j < 13; j++)
                {
                    costoPredichoEner[i, j] = compraRegP[i, j] * tarMT[0] + compraRegV[i, j] * tarMT[1] + compraRegN[i, j] * tarMT[2] + enerCoberturTarAcc[i, j] * tarMT[3];
                }

                costoPredichoEner[i, 13] = costoPredichoEner[i, 1] + costoPredichoEner[i, 2] + costoPredichoEner[i, 3] + costoPredichoEner[i, 4] + costoPredichoEner[i, 5] + costoPredichoEner[i, 6] + costoPredichoEner[i, 7] +
                    costoPredichoEner[i, 8] + costoPredichoEner[i, 9] + costoPredichoEner[i, 10] + costoPredichoEner[i, 11] + costoPredichoEner[i, 12];
            }



            //llenar la matriz de costo base (potencia)

            for (int i = 0; i < 26; i++)
            {
                costoBasePot[i, 0] = i;

                for (int j = 1; j < 13; j++)
                {
                    if (i == 0)
                    {
                        costoBasePot[i, j] = demandaEnergiaP[j - 1] * potMaxBloque[0] + demandaEnergiaV[j - 1] * potMaxBloque[1] + demandaEnergiaN[j - 1] * potMaxBloque[2];
                    }
                    else
                    {
                        costoBasePot[i, j] = costoBasePot[0, j] * calculos[i, 6];

                    }
                }

                costoBasePot[i, 13] = costoBasePot[i, 1] + costoBasePot[i, 2] + costoBasePot[i, 3] + costoBasePot[i, 4] + costoBasePot[i, 5] + costoBasePot[i, 6] + costoBasePot[i, 7] +
                                                costoBasePot[i, 8] + costoBasePot[i, 9] + costoBasePot[i, 10] + costoBasePot[i, 11] + costoBasePot[i, 12];
            }

            //llenar la matriz de costo predicho (potencia)

            for (int i = 0; i < 26; i++)
            {
                

                for (int j = 1; j < 14; j++)
                {
                    costoPredichoPot[i, j] = costoBasePot[i, j];

                }

            }





            //llenando el resto de columnas de los cálculos


            //Comparadores para el alumbrado
            double maxConsumo = 0;
            double sumConsumo = 0;
            double countConsumo = 0;

            for (int i = 0; i < 12; i++)
            {
                maxConsumo = Math.Max(maxConsumo, consumoEnergiaTot[i]);

                if (consumoEnergiaTot[i] < 50000)
                {
                    sumConsumo += consumoEnergiaTot[i];

                }
                else
                {
                    countConsumo += 1;
                }
            }



            List<double> maxComprado = new List<double>();
            List<double> sumComprado = new List<double>();
            List<double> countComprado = new List<double>();



            for (int i = 0; i < 26; i++)
            {
                double maxComodin = 0;
                double sumComodin = 0;
                double countComodin = 0;

                for (int j = 1; j < 13; j++)
                {
                    maxComodin = Math.Max(maxComodin, comprado[i, j]);

                    if (comprado[i, j] < 50000)
                    {
                        sumComodin += comprado[i, j];

                    }
                    else
                    {
                        countComodin += 1;
                    }
                }

                maxComprado.Add(maxComodin);
                sumComprado.Add(sumComodin);
                countComprado.Add(countComodin);

            }

            //Llenando las columnas medias de la matriz de cálculos

            for (int i = 0; i < 26; i++)
            {
                calculos[i, 16] = 0;
            }



            for (int i = 0; i < 26; i++)
            {

                calculos[i, 7] = costoBaseEner[i, 13] + costoBasePot[i, 13];

                calculos[i, 8] = calculos[i, 7] * 0.13;

                if (maxConsumo * calculos[i, 2] < 50000)
                {
                    calculos[i, 9] = consumoEnergiaTot[12] * calculos[i, 2] * tarMT[4];
                }
                else
                {
                    calculos[i, 9] = sumConsumo * tarMT[4] * calculos[i, 2] + countConsumo * 50000 * tarMT[4];
                }

                calculos[i, 10] = calculos[i, 7] + calculos[i, 8] + calculos[i, 9];

                calculos[i, 11] = costoPredichoEner[i, 13] + costoPredichoPot[i, 13];

                calculos[i, 12] = calculos[i, 11] * 0.13; ;

                if (maxComprado[i] < 50000)
                {
                    calculos[i, 13] = comprado[i, 13] * tarMT[4];
                }
                else
                {
                    calculos[i, 13] = sumComprado[i] * tarMT[4] + countComprado[i] * 500000 * tarMT[4];
                }

                calculos[i, 14] = calculos[i, 11] + calculos[i, 12] + calculos[i, 13];

                calculos[i, 15] = calculos[i, 10] - calculos[i, 14];

                if (i == 0)
                {
                    calculos[i, 16] = calculos[i, 15];
                }
                else
                {
                    calculos[i, 16] = calculos[i - 1, 16] + calculos[i, 15];
                }

            }

            int stop = 0;

        }

        public void calculaResto(double costoC, double tipoCambio)
        {

            for (int i = 0; i < 26; i++)
            {
                if (calculos[i, 16] >= costoC)
                {
                    calculos[i, 17] = 1; //1 significa retorno
                }
                else
                {
                    calculos[i, 17] = 0; // 0 significa "-"
                }




                if (i == 0)
                {
                    if (calculos[i, 16] > costoC)
                    {
                        calculos[i, 18] = (costoC - 0) / (calculos[i, 16] - 0) + calculos[i, 0];
                    }
                    else
                    {
                        calculos[i, 18] = 0;
                    }
                }
                else
                {
                    if (calculos[i, 16] > costoC && calculos[i - 1, 16] < costoC)
                    {
                        calculos[i, 18] = (costoC - calculos[i - 1, 16]) / (calculos[i, 16] - calculos[i - 1, 16]) + calculos[i, 0];
                    }
                    else
                    {
                        calculos[i, 18] = 0;
                    }
                }


                calculos[i, 19] = calculos[i, 15] / (Math.Pow(1 + 0.08, calculos[i, 0]));


                if (calculos[i, 19] >= costoC)
                {
                    calculos[i, 20] = 1; //1 significa retorno
                }
                else
                {
                    calculos[i, 20] = 0; // 0 significa "-"
                }




                if (i == 0)
                {
                    if (calculos[i, 19] > costoC)
                    {
                        calculos[i, 21] = (costoC - 0) / (calculos[i, 19] - 0) + calculos[i, 0];
                    }
                    else
                    {
                        calculos[i, 18] = 0;
                    }
                }
                else
                {
                    if (calculos[i, 19] > costoC && calculos[i - 1, 19] < costoC)
                    {
                        calculos[i, 21] = (costoC - calculos[i - 1, 19]) / (calculos[i, 19] - calculos[i - 1, 19]) + calculos[i, 0];
                    }
                    else
                    {
                        calculos[i, 21] = 0;
                    }
                }




                calculos[i, 22] = -calculos[i, 10];




                if (i == 0)
                {
                    calculos[i, 23] = -(calculos[i, 14] + costoC);
                }
                else
                {
                    calculos[i, 23] = -calculos[i, 14];
                }




                if (i == 0)
                {
                    calculos[i, 24] = calculos[i, 22];
                }
                else
                {
                    calculos[i, 24] = calculos[i - 1, 24] + calculos[i, 22];
                }


                if (i == 0)
                {
                    calculos[i, 25] = calculos[i, 23];
                }
                else
                {
                    calculos[i, 25] = calculos[i - 1, 25] + calculos[i, 23];
                }



                calculos[i, 26] = calculos[i, 24] / tipoCambio;

                calculos[i, 27] = calculos[i, 25] / tipoCambio;

                calculos[i, 28] = calculos[i, 24] / tipoCambio;

                calculos[i, 29] = calculos[i, 25] / tipoCambio + costoC / tipoCambio;

                calculos[i, 30] = calculos[i, 29] - calculos[i, 28];

                calculos[i, 31] = calculos[i, 15] / (Math.Pow(1 + 0.08, calculos[i, 0]));

            }

            int stop = 0;

        }
    }
}
