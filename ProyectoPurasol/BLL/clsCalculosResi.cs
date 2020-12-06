using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class clsCalculosResi
    {

        clsTarifas tarifas = new clsTarifas();


        public List<double> consumoEnergia = new List<double>();
        public List<double> demandaEnergia = new List<double>();

        public List<double> tarCO = new List<double>();
        public List<double> tarRE = new List<double>();
        public List<double> potMaxBloque = new List<double>();

        public double[,] calculos = new double[26, 32];

        public double[,] costoBaseEner = new double[26, 14];
        public double[,] enerProducida = new double[26, 14];
        public double[,] enerCoberturaReal = new double[26, 14];
        public double[,] enerCoberturTarAcc = new double[26, 14];
        public double[,] compraReg = new double[26, 14];
        public double[,] sobranteTA = new double[26, 14];
        public double[,] costoPredichoEner = new double[26, 14];
        public double[,] costoPredichoPot = new double[26, 14];
        public double[,] comprado = new double[26, 14];
        public double[,] costoBasePot = new double[26, 14];



        public void calculosresi(double PREne, double PRFeb, double PRMar, double PRAbr, double PRMay, double PRJun, double PRJul, double PRAgo, double PRSep, double PROct, double PRNov, double PRDic, double PRSGISEne,
            double PRSGISFeb, double PRSGISMar, double PRSGISAbr, double PRSGISMay, double PRSGISJun, double PRSGISJul, double PRSGISAgo, double PRSGISSep, double PRSGISOct, double PRSGISNov, double PRSGISDic, 
            double PromedioRecibos, double PromedioSGIS,double crecimientoAnual, string Compania, string Tarifa, clsCurvasRes curvas, List<double> pico)
        {

            
            //calcula las primeras 7 columnas de la matriz de cálculos
            for (int i = 0; i < 26; i++)
            {
                calculos[i, 0] = i;

                if (i==0)
                {
                    calculos[i, 1] = PromedioRecibos*12;
                    calculos[i, 2] = 1;
                    calculos[i, 3] = ((0.9-0.975)* calculos[i, 0]) / (0.9 - 0.975) + 0.975;
                    calculos[i, 4] = calculos[i, 3]*curvas.coberturaRealporProdAnual;
                    calculos[i, 5] = calculos[i, 3] * curvas.coberturaTAporProdAnual;
                    calculos[i, 6] = 1;
                }
                else
                {
                    calculos[i, 1] = calculos[i - 1, 1] * (1 + crecimientoAnual);
                    calculos[i, 2] = calculos[i - 1, 2] * (1 + crecimientoAnual);

                    if (calculos[i, 0]<=10)
                    {
                        calculos[i, 3] = ((0.9 - 0.975) * calculos[i, 0]) / (10 - 0) + 0.975;
                    }
                    else
                    {
                        calculos[i, 3] = ((0.8 - 0.9) * calculos[i, 0]) / (25 - 10) + 0.9-((0.8 - 0.9) * 10 / (25 - 10));
                    }
                    
                    calculos[i, 4] = calculos[i, 3] * curvas.coberturaRealporProdAnual;
                    calculos[i, 5] = calculos[i, 3] * curvas.coberturaTAporProdAnual;
                    calculos[i, 6] = calculos[i - 1, 6] * (1 + 0.05);
                }

            }

            consumoEnergia.Add(PREne);
            consumoEnergia.Add(PRFeb);
            consumoEnergia.Add(PRMar);
            consumoEnergia.Add(PRAbr);
            consumoEnergia.Add(PRMay);
            consumoEnergia.Add(PRJun);
            consumoEnergia.Add(PRJul);
            consumoEnergia.Add(PRAgo);
            consumoEnergia.Add(PRSep);
            consumoEnergia.Add(PROct);
            consumoEnergia.Add(PRNov);
            consumoEnergia.Add(PRDic);
            consumoEnergia.Add(PREne+PRFeb+PRMar+PRAbr+PRMay+PRJun+PRJul+PRAgo+PRSep+PROct+PRNov+PRDic);

            demandaEnergia = pico;

            

            if (Tarifa=="T-CO/IN")
            {

                switch (Compania)
                {
                    case "ICE":
                        tarCO.Add(tarifas.COICE3000Mas);
                        tarCO.Add(tarifas.COICE3000Menos);
                        tarCO.Add(tarifas.AICETA);
                        tarCO.Add(tarifas.APICE4150000);
                        potMaxBloque.Add(tarifas.COICE08);
                        potMaxBloque.Add(tarifas.COICE810);
                        potMaxBloque.Add(tarifas.COICE1015);
                        potMaxBloque.Add(tarifas.COICE15Mas);
                        break;
                    case "CNFL":
                        tarCO.Add(tarifas.COCNFL3000Mas);
                        tarCO.Add(tarifas.COCNFL3000Menos);
                        tarCO.Add(tarifas.ACNFLTA);
                        tarCO.Add(tarifas.APCNFL4150000);
                        potMaxBloque.Add(tarifas.COCNFL08);
                        potMaxBloque.Add(tarifas.COCNFL810);
                        potMaxBloque.Add(tarifas.COCNFL1015);
                        potMaxBloque.Add(tarifas.COCNFL15Mas);
                        break;
                    case "JASEC":
                        tarCO.Add(tarifas.COJASEC3000Mas);
                        tarCO.Add(tarifas.COJASEC3000Menos);
                        tarCO.Add(tarifas.AJASECTA);
                        tarCO.Add(tarifas.APJASEC4150000);
                        potMaxBloque.Add(tarifas.COJASEC08);
                        potMaxBloque.Add(tarifas.COJASEC810);
                        potMaxBloque.Add(tarifas.COJASEC1015);
                        potMaxBloque.Add(tarifas.COJASEC15Mas);
                        break;
                    case "ESPH":
                        tarCO.Add(tarifas.COESPH3000Mas);
                        tarCO.Add(tarifas.COESPH3000Menos);
                        tarCO.Add(tarifas.AESPHTA);
                        tarCO.Add(tarifas.APESPH4150000);
                        potMaxBloque.Add(tarifas.COESPH08);
                        potMaxBloque.Add(tarifas.COESPH810);
                        potMaxBloque.Add(tarifas.COESPH1015);
                        potMaxBloque.Add(tarifas.COESPH15Mas);
                        break;
                    case "COOPELESCA":
                        tarCO.Add(tarifas.COCOOPEL3000Mas);
                        tarCO.Add(tarifas.COCOOPEL3000Menos);
                        tarCO.Add(tarifas.ACOOPELTA);
                        tarCO.Add(tarifas.APCOOPEL4150000);
                        potMaxBloque.Add(tarifas.COCOOPEL08);
                        potMaxBloque.Add(tarifas.COCOOPEL810);
                        potMaxBloque.Add(tarifas.COCOOPEL1015);
                        potMaxBloque.Add(tarifas.COCOOPEL15Mas);
                        break;
                    case "COOPEGUANACASTE":
                        tarCO.Add(tarifas.COCOOPEG3000Mas);
                        tarCO.Add(tarifas.COCOOPEG3000Menos);
                        tarCO.Add(tarifas.ACOOPEGTA);
                        tarCO.Add(tarifas.APCOOPEG4150000);
                        potMaxBloque.Add(tarifas.COCOOPEG08);
                        potMaxBloque.Add(tarifas.COCOOPEG810);
                        potMaxBloque.Add(tarifas.COCOOPEG1015);
                        potMaxBloque.Add(tarifas.COCOOPEG15Mas);
                        break;
                    case "COOPESANTOS":
                        tarCO.Add(tarifas.COCOOPES3000Mas);
                        tarCO.Add(tarifas.COCOOPES3000Menos);
                        tarCO.Add(tarifas.ACOOPESTA);
                        tarCO.Add(tarifas.APCOOPES4150000);
                        potMaxBloque.Add(tarifas.COCOOPES08);
                        potMaxBloque.Add(tarifas.COCOOPES810);
                        potMaxBloque.Add(tarifas.COCOOPES1015);
                        potMaxBloque.Add(tarifas.COCOOPES15Mas);
                        break;
                    case "COOPEALFARORUIZ":
                        tarCO.Add(tarifas.COCOOPEA3000Mas);
                        tarCO.Add(tarifas.COCOOPEA3000Menos);
                        tarCO.Add(tarifas.ACOOPEATA);
                        tarCO.Add(tarifas.APCOOPEA4150000);
                        potMaxBloque.Add(tarifas.COCOOPEA08);
                        potMaxBloque.Add(tarifas.COCOOPEA810);
                        potMaxBloque.Add(tarifas.COCOOPEA1015);
                        potMaxBloque.Add(tarifas.COCOOPEA15Mas);
                        break;
                }
            }
            else if (Tarifa == "T-CS")
            {
                switch (Compania)
                {
                    case "ICE":
                        tarCO.Add(tarifas.CSICE0250);
                        tarCO.Add(tarifas.CSICE3000Mas);
                        tarCO.Add(tarifas.AICETA);
                        tarCO.Add(tarifas.APICE4150000);
                        potMaxBloque.Add(tarifas.CSICE08);
                        potMaxBloque.Add(tarifas.CSICE815);
                        potMaxBloque.Add(tarifas.CSICE815);
                        potMaxBloque.Add(tarifas.CSICE15Mas);
                        break;
                    case "CNFL":
                        tarCO.Add(tarifas.CSCNFL0250);
                        tarCO.Add(tarifas.CSCNFL3000Mas);
                        tarCO.Add(tarifas.ACNFLTA);
                        tarCO.Add(tarifas.APCNFL4150000);
                        potMaxBloque.Add(tarifas.CSCNFL08);
                        potMaxBloque.Add(tarifas.CSCNFL815);
                        potMaxBloque.Add(tarifas.CSCNFL815);
                        potMaxBloque.Add(tarifas.CSCNFL15Mas);
                        break;
                    case "JASEC":
                        tarCO.Add(tarifas.CSJASEC0250);
                        tarCO.Add(tarifas.CSJASEC3000Mas);
                        tarCO.Add(tarifas.AJASECTA);
                        tarCO.Add(tarifas.APJASEC4150000);
                        potMaxBloque.Add(tarifas.CSJASEC08);
                        potMaxBloque.Add(tarifas.CSJASEC815);
                        potMaxBloque.Add(tarifas.CSJASEC815);
                        potMaxBloque.Add(tarifas.CSJASEC15Mas);
                        break;
                    case "ESPH":
                        tarCO.Add(tarifas.CSESPH0250);
                        tarCO.Add(tarifas.CSESPH3000Mas);
                        tarCO.Add(tarifas.AESPHTA);
                        tarCO.Add(tarifas.APESPH4150000);
                        potMaxBloque.Add(tarifas.CSESPH08);
                        potMaxBloque.Add(tarifas.CSESPH815);
                        potMaxBloque.Add(tarifas.CSESPH815);
                        potMaxBloque.Add(tarifas.CSESPH15Mas);
                        break;
                    case "COOPELESCA":
                        tarCO.Add(tarifas.CSCOOPEL0250);
                        tarCO.Add(tarifas.CSCOOPEL3000Mas);
                        tarCO.Add(tarifas.ACOOPELTA);
                        tarCO.Add(tarifas.APCOOPEL4150000);
                        potMaxBloque.Add(tarifas.CSCOOPEL08);
                        potMaxBloque.Add(tarifas.CSCOOPEL815);
                        potMaxBloque.Add(tarifas.CSCOOPEL815);
                        potMaxBloque.Add(tarifas.CSCOOPEL15Mas);
                        break;
                    case "COOPEGUANACASTE":
                        tarCO.Add(tarifas.CSCOOPEG0250);
                        tarCO.Add(tarifas.CSCOOPEG3000Mas);
                        tarCO.Add(tarifas.ACOOPEGTA);
                        tarCO.Add(tarifas.APCOOPEG4150000);
                        potMaxBloque.Add(tarifas.CSCOOPEG08);
                        potMaxBloque.Add(tarifas.CSCOOPEG815);
                        potMaxBloque.Add(tarifas.CSCOOPEG815);
                        potMaxBloque.Add(tarifas.CSCOOPEG15Mas);
                        break;
                    case "COOPESANTOS":
                        tarCO.Add(tarifas.CSCOOPES2503000);
                        tarCO.Add(tarifas.CSCOOPES3000Mas);
                        tarCO.Add(tarifas.ACOOPESTA);
                        tarCO.Add(tarifas.APCOOPES4150000);
                        potMaxBloque.Add(tarifas.CSCOOPES08);
                        potMaxBloque.Add(tarifas.CSCOOPES815);
                        potMaxBloque.Add(tarifas.CSCOOPES815);
                        potMaxBloque.Add(tarifas.CSCOOPES15Mas);
                        break;
                    case "COOPEALFARORUIZ":
                        tarCO.Add(tarifas.CSCOOPEA0250);
                        tarCO.Add(tarifas.CSCOOPEA3000Mas);
                        tarCO.Add(tarifas.ACOOPEATA);
                        tarCO.Add(tarifas.APCOOPEA4150000);
                        potMaxBloque.Add(tarifas.CSCOOPEA08);
                        potMaxBloque.Add(tarifas.CSCOOPEA815);
                        potMaxBloque.Add(tarifas.CSCOOPEA815);
                        potMaxBloque.Add(tarifas.CSCOOPEA15Mas);
                        break;
                }

            }
            else
            {
                switch (Compania)
                {
                    case "ICE":
                        tarCO.Add(0);
                        tarCO.Add(0);
                        tarCO.Add(tarifas.AICETA);
                        tarCO.Add(tarifas.APICE4150000);
                        potMaxBloque.Add(0);
                        potMaxBloque.Add(0);
                        potMaxBloque.Add(0);
                        potMaxBloque.Add(0);
                        break;
                    case "CNFL":
                        tarCO.Add(0);
                        tarCO.Add(0);
                        tarCO.Add(tarifas.ACNFLTA);
                        tarCO.Add(tarifas.APCNFL4150000);
                        potMaxBloque.Add(0);
                        potMaxBloque.Add(0);
                        potMaxBloque.Add(0);
                        potMaxBloque.Add(0);
                        break;
                    case "JASEC":
                        tarCO.Add(0);
                        tarCO.Add(0);
                        tarCO.Add(tarifas.AJASECTA);
                        tarCO.Add(tarifas.APJASEC4150000);
                        potMaxBloque.Add(0);
                        potMaxBloque.Add(0);
                        potMaxBloque.Add(0);
                        potMaxBloque.Add(0);
                        break;
                    case "ESPH":
                        tarCO.Add(0);
                        tarCO.Add(0);
                        tarCO.Add(tarifas.AESPHTA);
                        tarCO.Add(tarifas.APESPH4150000);
                        potMaxBloque.Add(0);
                        potMaxBloque.Add(0);
                        potMaxBloque.Add(0);
                        potMaxBloque.Add(0);
                        break;
                    case "COOPELESCA":
                        tarCO.Add(0);
                        tarCO.Add(0);
                        tarCO.Add(tarifas.ACOOPELTA);
                        tarCO.Add(tarifas.APCOOPEL4150000);
                        potMaxBloque.Add(0);
                        potMaxBloque.Add(0);
                        potMaxBloque.Add(0);
                        potMaxBloque.Add(0);
                        break;
                    case "COOPEGUANACASTE":
                        tarCO.Add(0);
                        tarCO.Add(0);
                        tarCO.Add(tarifas.ACOOPEGTA);
                        tarCO.Add(tarifas.APCOOPEG4150000);
                        potMaxBloque.Add(0);
                        potMaxBloque.Add(0);
                        potMaxBloque.Add(0);
                        potMaxBloque.Add(0);
                        break;
                    case "COOPESANTOS":
                        tarCO.Add(0);
                        tarCO.Add(0);
                        tarCO.Add(tarifas.ACOOPESTA);
                        tarCO.Add(tarifas.APCOOPES4150000);
                        potMaxBloque.Add(0);
                        potMaxBloque.Add(0);
                        potMaxBloque.Add(0);
                        potMaxBloque.Add(0);
                        break;
                    case "COOPEALFARORUIZ":
                        tarCO.Add(0);
                        tarCO.Add(0);
                        tarCO.Add(tarifas.ACOOPEATA);
                        tarCO.Add(tarifas.APCOOPEA4150000);
                        potMaxBloque.Add(0);
                        potMaxBloque.Add(0);
                        potMaxBloque.Add(0);
                        potMaxBloque.Add(0);
                        break;
                }
            }

            if (Tarifa == "T-RE")
            {
                switch (Compania)
                {
                    case "ICE":
                        tarRE.Add(tarifas.REICE030);
                        tarRE.Add(tarifas.REICE3040);
                        tarRE.Add(tarifas.REICE41200);
                        tarRE.Add(tarifas.REICE200300);
                        tarRE.Add(tarifas.REICE300MAs);
                        break;
                    case "CNFL":
                        tarRE.Add(tarifas.RECNFL030);
                        tarRE.Add(tarifas.RECNFL3040);
                        tarRE.Add(tarifas.RECNFL41200);
                        tarRE.Add(tarifas.RECNFL200300);
                        tarRE.Add(tarifas.RECNFL300MAs);
                        break;
                    case "JASEC":
                        tarRE.Add(tarifas.REJASEC030);
                        tarRE.Add(tarifas.REJASEC3040);
                        tarRE.Add(tarifas.REJASEC41200);
                        tarRE.Add(tarifas.REJASEC200300);
                        tarRE.Add(tarifas.REJASEC300MAs);
                        break;
                    case "ESPH":
                        tarRE.Add(tarifas.REESPH030);
                        tarRE.Add(tarifas.REESPH3040);
                        tarRE.Add(tarifas.REESPH41200);
                        tarRE.Add(tarifas.REESPH200300);
                        tarRE.Add(tarifas.REESPH300MAs);
                        break;
                    case "COOPELESCA":
                        tarRE.Add(tarifas.RECOOPEL030);
                        tarRE.Add(tarifas.RECOOPEL3040);
                        tarRE.Add(tarifas.RECOOPEL41200);
                        tarRE.Add(tarifas.RECOOPEL200300);
                        tarRE.Add(tarifas.RECOOPEL300MAs);
                        break;
                    case "COOPEGUANACASTE":
                        tarRE.Add(tarifas.RECOOPEG030);
                        tarRE.Add(tarifas.RECOOPEG3040);
                        tarRE.Add(tarifas.RECOOPEG41200);
                        tarRE.Add(tarifas.RECOOPEG200300);
                        tarRE.Add(tarifas.RECOOPEG300MAs);
                        break;
                    case "COOPESANTOS":
                        tarRE.Add(tarifas.RECOOPES030);
                        tarRE.Add(tarifas.RECOOPES3040);
                        tarRE.Add(tarifas.RECOOPES41200);
                        tarRE.Add(tarifas.RECOOPES200300);
                        tarRE.Add(tarifas.RECOOPES300MAs);
                        break;
                    case "COOPEALFARORUIZ":
                        tarRE.Add(tarifas.RECOOPEA030);
                        tarRE.Add(tarifas.RECOOPEA3040);
                        tarRE.Add(tarifas.RECOOPEA41200);
                        tarRE.Add(tarifas.RECOOPEA200300);
                        tarRE.Add(tarifas.RECOOPEA300MAs);
                        break;
                }
            }

            
            
            // llenando la matriz de costo base energía

            for (int i = 0; i < 26; i++)
            {
                costoBaseEner[i, 0] = i;

                for (int j = 1; j < 13; j++)
                {
                    if (Tarifa == "T-CS" || Tarifa == "T-CO/IN")
                    {
                        if (consumoEnergia[j]*calculos[i,2]<3000)
                        {
                            costoBaseEner[i, j] = consumoEnergia[j-1] * calculos[i, 2]*tarCO[0]* calculos[i, 6];
                        }
                        else
                        {
                            costoBaseEner[i, j] = consumoEnergia[j-1] * calculos[i, 2] * tarCO[1] * calculos[i, 6];
                        }
                    }
                    else if (Tarifa == "T-RE")
                    {
                        if (Compania=="ICE")
                        {
                            if (consumoEnergia[j - 1] * calculos[i, 2] < 40)
                            {
                                costoBaseEner[i, j] =tarRE[0]* calculos[i, 6];
                            }
                            else if (consumoEnergia[j - 1] * calculos[i, 2] <= 200)
                            {
                                costoBaseEner[i, j] = consumoEnergia[j - 1] * calculos[i, 2]* tarRE[2] * calculos[i, 6];
                            }
                            else
                            {
                                costoBaseEner[i, j] = 200 * tarRE[2] * calculos[i, 6] + (consumoEnergia[j - 1] * calculos[i, 2]-200)* tarRE[3] * calculos[i, 6];
                            }
                        }
                        else if(Compania == "CNFL")
                        {
                            if (consumoEnergia[j - 1] * calculos[i, 2] < 30)
                            {
                                costoBaseEner[i, j] = tarRE[0] * calculos[i, 6];
                            }
                            else if (consumoEnergia[j - 1] * calculos[i, 2] <= 200)
                            {
                                costoBaseEner[i, j] = consumoEnergia[j - 1] * calculos[i, 2] * tarRE[2] * calculos[i, 6];
                            }
                            else if (consumoEnergia[j - 1] * calculos[i, 2] <= 200)
                            {
                                costoBaseEner[i, j] = 200 * tarRE[2] * calculos[i, 6] + (consumoEnergia[j - 1] * calculos[i, 2] - 200) * tarRE[3] * calculos[i, 6];
                            }
                            else
                            {
                                costoBaseEner[i, j] = 200 * tarRE[2] * calculos[i, 6] + 100 * tarRE[3] * calculos[i, 6]+(consumoEnergia[j - 1] * calculos[i, 2] - 300) * tarRE[4] * calculos[i, 6];
                            }
                        }
                        else
                        {
                            if (consumoEnergia[j - 1] * calculos[i, 2] < 30)
                            {
                                costoBaseEner[i, j] = tarRE[0] * calculos[i, 6];
                            }
                            else if (consumoEnergia[j - 1] * calculos[i, 2] <= 200)
                            {
                                costoBaseEner[i, j] = consumoEnergia[j - 1] * tarRE[2] * calculos[i, 6];
                            }
                            else
                            {
                                costoBaseEner[i, j] = 200 * tarRE[2] * calculos[i, 6] + (consumoEnergia[j - 1] * calculos[i, 2] - 200) * tarRE[3] * calculos[i, 6];
                            }
                        }
                    }
                }

                costoBaseEner[i, 13]= costoBaseEner[i, 1] + costoBaseEner[i, 2] + costoBaseEner[i, 3] + costoBaseEner[i, 4] + costoBaseEner[i, 5] + costoBaseEner[i, 6] + costoBaseEner[i, 7] + costoBaseEner[i, 8] + 
                    costoBaseEner[i, 9] + costoBaseEner[i, 10] + costoBaseEner[i, 11] + costoBaseEner[i, 12];

            }


            //llenar la primera fila de la matriz de energía producida

            for (int i = 0; i < 35040; i++)
            {
                if (i < 2976) //Enero
                {
                    enerProducida[0, 1] += curvas.cAnual[i,3];
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
                    if (i==0)
                    {
                        enerProducida[i, j] = enerProducida[i, j] * 0.25 * calculos[i, 3];
                    }
                    else
                    {
                        enerProducida[i, j] = enerProducida[0, j] * calculos[i, 3];
                    }
                }

                if (i==0)
                {
                    enerProducida[i, 13] = enerProducida[i, 1] + enerProducida[i, 2] + enerProducida[i, 3] + enerProducida[i, 4] + enerProducida[i, 5] + enerProducida[i, 6] + enerProducida[i, 7] + enerProducida[i, 8] +
                        enerProducida[i, 9] + enerProducida[i, 10] + enerProducida[i, 11] + enerProducida[i, 12];
                }
                else
                {
                    enerProducida[i, 13]= enerProducida[0, 13] * calculos[i, 3];
                }

            }



            //llenar la primera fila de la matriz de energía de cobertura real

            for (int i = 0; i < 35040; i++)
            {
                if (i < 2976) //Enero
                {
                    enerCoberturaReal [0, 1] += curvas.cAnual[i, 5];
                }
                else if (i < 5664) //Febrero
                {
                    enerCoberturaReal[0, 2] += curvas.cAnual[i, 5];
                }
                else if (i < 8640) //Marzo
                {
                    enerCoberturaReal[0, 3] += curvas.cAnual[i, 5];
                }
                else if (i < 11520) //Abril
                {
                    enerCoberturaReal[0, 4] += curvas.cAnual[i, 5];
                }
                else if (i < 14496) //Mayo
                {
                    enerCoberturaReal[0, 5] += curvas.cAnual[i, 5];
                }
                else if (i < 17376) //Junio
                {
                    enerCoberturaReal[0, 6] += curvas.cAnual[i, 5];
                }
                else if (i < 20352) //Julio
                {
                    enerCoberturaReal[0, 7] += curvas.cAnual[i, 5];
                }
                else if (i < 23328) //Agosto
                {
                    enerCoberturaReal[0, 8] += curvas.cAnual[i, 5];
                }
                else if (i < 26208) //Septiembre
                {
                    enerCoberturaReal[0, 9] += curvas.cAnual[i, 5];
                }
                else if (i < 29184) //Octubre
                {
                    enerCoberturaReal[0, 10] += curvas.cAnual[i, 5];
                }
                else if (i < 32064) //Noviembre
                {
                    enerCoberturaReal[0, 11] += curvas.cAnual[i, 5];
                }
                else  //Diciembre
                {
                    enerCoberturaReal[0, 12] += curvas.cAnual[i, 5];
                }

            }

            for (int i = 0; i < 26; i++)
            {
                enerCoberturaReal[i, 0] = i;

                for (int j = 1; j < 13; j++)
                {
                    if (i == 0)
                    {
                        enerCoberturaReal[i, j] = enerCoberturaReal[i, j] * calculos[i, 3];
                    }
                    else
                    {
                        enerCoberturaReal[i, j] = enerCoberturaReal[0, j] * calculos[i, 3];
                    }
                }

                if (i == 0)
                {
                    enerCoberturaReal[i, 13] = enerCoberturaReal[i, 1] + enerCoberturaReal[i, 2] + enerCoberturaReal[i, 3] + enerCoberturaReal[i, 4] + enerCoberturaReal[i, 5] + enerCoberturaReal[i, 6] + enerCoberturaReal[i, 7] + enerCoberturaReal[i, 8] +
                        enerCoberturaReal[i, 9] + enerCoberturaReal[i, 10] + enerCoberturaReal[i, 11] + enerCoberturaReal[i, 12];
                }
                else
                {
                    enerCoberturaReal[i, 13] = enerCoberturaReal[0, 13] * calculos[i, 3];
                }

            }


            //llenar la matriz de sobrante TA

            for (int i = 0; i < 26; i++)
            {
                sobranteTA[i, 0] = i;

                for (int j = 1; j < 13; j++)
                {
                    if (j==1)
                    {
                        if (enerProducida[i,1]>consumoEnergia[0]*calculos[i,2])
                        {
                            sobranteTA[i, j] = enerProducida[i, 1] - consumoEnergia[0] * calculos[i, 2];
                        }
                        else
                        {
                            sobranteTA[i, j] = 0;
                        }
                    }
                    else
                    {
                        if (sobranteTA[i, j-1]+ enerProducida[i, j] > consumoEnergia[j-1] * calculos[i, 2])
                        {
                            sobranteTA[i, j] = sobranteTA[i, j - 1] + enerProducida[i, j] - consumoEnergia[j-1] * calculos[i, 2];
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
                        if (enerProducida[i, 1] > consumoEnergia[0] * calculos[i, 2])
                        {
                            enerCoberturTarAcc[i, j] = consumoEnergia[0] * calculos[i, 2]- enerCoberturaReal[i,1];
                        }
                        else
                        {
                            enerCoberturTarAcc[i, j] = enerProducida[i, 1] - enerCoberturaReal[i, 1];
                        }
                    }
                    else
                    {
                        if (sobranteTA[i, j - 1] + enerProducida[i, j] > consumoEnergia[j - 1] * calculos[i, 2])
                        {
                            enerCoberturTarAcc[i, j] = consumoEnergia[j-1] * calculos[i, 2] - enerCoberturaReal[i, j];
                        }
                        else
                        {
                            enerCoberturTarAcc[i, j] = sobranteTA[i, j - 1] + enerProducida[i, j] - enerCoberturaReal[i, j];
                        }
                    }
                }

                enerCoberturTarAcc[i, 13] = Math.Floor((enerCoberturTarAcc[i, 1] + enerCoberturTarAcc[i, 2] + enerCoberturTarAcc[i, 3] + enerCoberturTarAcc[i, 4] + enerCoberturTarAcc[i, 5] + enerCoberturTarAcc[i, 6] +
                    enerCoberturTarAcc[i, 7] + enerCoberturTarAcc[i, 8] + enerCoberturTarAcc[i, 9] + enerCoberturTarAcc[i, 10] + enerCoberturTarAcc[i, 11] + enerCoberturTarAcc[i, 12]) /10)*10;

            }


            //llenar la matriz de compra regular

            for (int i = 0; i < 26; i++)
            {
                compraReg[i, 0] = i;

                for (int j = 1; j < 13; j++)
                {
                    if (j == 1)
                    {
                        if (enerProducida[i, 1] > consumoEnergia[0] * calculos[i, 2])
                        {
                            compraReg[i, j] = 0;
                        }
                        else
                        {
                            compraReg[i, j] = consumoEnergia[0] * calculos[i, 2] - enerProducida[i, 1];
                        }
                    }
                    else
                    {
                        if (sobranteTA[i, j - 1] + enerProducida[i, j] > consumoEnergia[j - 1] * calculos[i, 2])
                        {
                            compraReg[i, j] = 0;
                        }
                        else
                        {
                            compraReg[i, j] = consumoEnergia[j - 1] * calculos[i, 2] - sobranteTA[i, j - 1] - enerProducida[i, j];
                        }
                    }
                }

                compraReg[i, 13] = compraReg[i, 1] + compraReg[i, 2] + compraReg[i, 3] + compraReg[i, 4] + compraReg[i, 5] + compraReg[i, 6] + compraReg[i, 7] + compraReg[i, 8] +
                        compraReg[i, 9] + compraReg[i, 10] + compraReg[i, 11] + compraReg[i, 12];

            }


            //llenar la matriz de comprado

            for (int i = 0; i < 26; i++)
            {
                comprado[i, 0] = i;

                for (int j = 1; j < 14; j++)
                {
                    comprado[i, j] = enerCoberturTarAcc[i, j] + compraReg[i, j];
                }
            }


            //llenar la matriz de costo predicho (energia)

            for (int i = 0; i < 26; i++)
            {
                costoPredichoEner[i, 0] = i;

                for (int j = 1; j < 13; j++)
                {
                    if (compraReg[i,j]<30)
                    {
                        costoPredichoEner[i, j] = tarRE[0];
                    }
                    else if (compraReg[i, j] < 200)
                    {
                        costoPredichoEner[i, j] = (compraReg[i, j] - 30) * tarRE[2] + tarRE[0];
                    }
                    else if (compraReg[i, j] < 300)
                    {
                        costoPredichoEner[i, j] = tarRE[0] + 160 * tarRE[2] + (compraReg[i, j] - 200) * tarRE[3];
                    }
                    else
                    {
                        costoPredichoEner[i, j] = tarRE[0] + 160 * tarRE[2] + 100 * tarRE[3] + (compraReg[i, j] - 300) * tarRE[4];
                    }

                    costoPredichoEner[i, j] = (costoPredichoEner[i, j] + enerCoberturTarAcc[i, j] * tarCO[2])*calculos[i,6];
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
                    if (consumoEnergia[j - 1] <3000)
                    {
                        costoBasePot[i, j] = 0;
                    }
                    else
                    {
                        if (Compania=="ICE")
                        {
                            costoBasePot[i, j] = demandaEnergia[j - 1] * potMaxBloque[0];
                        }
                        else if (Compania == "JASEC" || Compania == "ESPH" || Compania == "CNFL")
                        {
                            if (demandaEnergia[j - 1]<8)
                            {
                                costoBasePot[i, j] = potMaxBloque[0];
                            }
                            else
                            {
                                costoBasePot[i, j] = demandaEnergia[j - 1] * potMaxBloque[1];
                            }
                        }
                        else if (Compania == "COOPELESCA" || Compania == "COOPEGUANACASTE")
                        {
                            if (demandaEnergia[j - 1] < 10)
                            {
                                costoBasePot[i, j] = potMaxBloque[0];
                            }
                            else
                            {
                                costoBasePot[i, j] = demandaEnergia[j - 1] * potMaxBloque[2];
                            }
                        }
                        else
                        {
                            if (demandaEnergia[j - 1] < 15)
                            {
                                costoBasePot[i, j] = potMaxBloque[0];
                            }
                            else
                            {
                                costoBasePot[i, j] = demandaEnergia[j - 1] * potMaxBloque[3];
                            }
                        }
                    }

                    costoBasePot[i, j] = costoBasePot[i, j] * calculos[i, 6];

                }

                costoBasePot[i, 13] = costoBasePot[i, 1] + costoBasePot[i, 2] + costoBasePot[i, 3] + costoBasePot[i, 4] + costoBasePot[i, 5] + costoBasePot[i, 6] + costoBasePot[i, 7] +
                                                costoBasePot[i, 8] + costoBasePot[i, 9] + costoBasePot[i, 10] + costoBasePot[i, 11] + costoBasePot[i, 12];
            }

            //llenar la matriz de costo base (potencia)

            for (int i = 0; i < 26; i++)
            {
                costoPredichoPot[i, 0] = i;

                for (int j = 1; j < 13; j++)
                {
                    if (comprado[i,j]<calculos[i,3])
                    {
                        costoPredichoPot[i, j] = 0;
                    }
                    else
                    {
                        costoPredichoPot[i, j] = costoBasePot[i,j];
                    }

                    costoPredichoPot[i, 13] = costoPredichoPot[i, 1] + costoPredichoPot[i, 2] + costoPredichoPot[i, 3] + costoPredichoPot[i, 4] + costoPredichoPot[i, 5] + costoPredichoPot[i, 6] + costoPredichoPot[i, 7] +
                                                costoPredichoPot[i, 8] + costoPredichoPot[i, 9] + costoPredichoPot[i, 10] + costoPredichoPot[i, 11] + costoPredichoPot[i, 12];
                }
            }



            //llenando el resto de columnas de los cálculos


            //Comparadores para el alumbrado
            double maxConsumo = 0;
            double sumConsumo = 0;
            double countConsumo = 0;

            for (int i = 0; i < 12; i++)
            {
                maxConsumo = Math.Max(maxConsumo, consumoEnergia[i]);

                if (consumoEnergia[i]<50000)
                {
                    sumConsumo += consumoEnergia[i];

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
                    maxComodin = Math.Max(maxComodin, comprado[i,j]);

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
                
                if (maxConsumo<50000)
                {
                    calculos[i, 9] = consumoEnergia[12]*calculos[i,2]*tarCO[3];
                }
                else
                {
                    calculos[i, 9] = sumConsumo * tarCO[3] * calculos[i, 2] + countConsumo * 50000 * calculos[i, 2];
                }
                    
                calculos[i, 10] = calculos[i, 7] + calculos[i, 8] + calculos[i, 9];

                calculos[i, 11] = costoPredichoEner[i, 13] + costoPredichoPot[i, 13];

                calculos[i, 12] = calculos[i, 11] * 0.13; ;

                if (maxComprado[i]<50000)
                {
                    calculos[i, 13] = comprado[i,13] * tarCO[3];
                }
                else
                {
                    calculos[i, 13] = sumComprado[i] * tarCO[3] + countComprado[i] * 500000 * tarCO[3];
                }     

                calculos[i, 14] = calculos[i, 11] + calculos[i, 12] + calculos[i, 13];

                calculos[i, 15] = calculos[i, 10] - calculos[i, 14];

                if (i==0)
                {
                    calculos[i, 16] = calculos[i, 15];
                }
                else
                {
                    calculos[i, 16] = calculos[i-1, 16] + calculos[i, 15];
                }                      

            }
        
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




                if (i==0)
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
                    if (calculos[i, 16] > costoC && calculos[i-1, 16] < costoC)
                    {
                        calculos[i, 18] = (costoC - calculos[i - 1, 16]) / (calculos[i, 16] - calculos[i - 1, 16]) + calculos[i, 0];
                    }
                    else
                    {
                        calculos[i, 18] = 0;
                    }
                }


                calculos[i, 19] = calculos[i, 15]/(Math.Pow(1+0.08, calculos[i, 0]));


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




                if (i==0)
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
                    calculos[i, 24] = calculos[i-1, 24] + calculos[i, 22];
                }


                if (i == 0)
                {
                    calculos[i, 25] = calculos[i, 23];
                }
                else
                {
                    calculos[i, 25] = calculos[i - 1, 25] + calculos[i, 23];
                }



                calculos[i, 26] = calculos[i, 24]/tipoCambio;

                calculos[i, 27] = calculos[i, 25] / tipoCambio;

                calculos[i, 28] = calculos[i, 24] / tipoCambio;

                calculos[i, 29] = calculos[i, 25] / tipoCambio  + costoC/ tipoCambio;

                calculos[i, 30] = calculos[i, 29] - calculos[i, 28];

                calculos[i, 31] = calculos[i, 15] / (Math.Pow(1+0.08, calculos[i, 0]));

            }

            

        }

    }
}
