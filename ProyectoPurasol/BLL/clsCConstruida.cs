using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class clsCConstruida
    {
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
        public double[,] ccLaV = new double[24, 14];
        public double[,] ccSab = new double[24, 14];
        public double[,] ccDom = new double[24, 14];
        public double[,] ccAnual = new double[35040, 5];
        public double[,] ccMenusal = new double[2976, 5];
        public double[,] ccDiaria = new double[96, 5];
        public List<double> pico = new List<double>();

        public bool calculoCC(double PREne, double PRFeb, double PRMar, double PRAbr, double PRMay, double PRJun, double PRJul, double PRAgo, double PRSep, double PROct, double PRNov, double PRDic, double PRSGISEne,
            double PRSGISFeb, double PRSGISMar, double PRSGISAbr, double PRSGISMay, double PRSGISJun, double PRSGISJul, double PRSGISAgo, double PRSGISSep, double PRSGISOct, double PRSGISNov, double PRSGISDic)
        {

            double avgRec = PREne + PRFeb + PRMar + PRAbr + PRMay + PRJun + PRJul+ PRAgo+ PRSep+ PROct+ PRNov+ PRDic;
            double avdSGIS = PRSGISEne+ PRSGISFeb+ PRSGISMar+ PRSGISAbr+ PRSGISMay+ PRSGISJun+ PRSGISJul+ PRSGISAgo+ PRSGISSep+ PRSGISOct+ PRSGISNov+ PRSGISDic;

            List<double> diario = new List<double>();

            List<double> pctConsumoLV = new List<double>();
            List<double> pctConsumoS = new List<double>();
            List<double> pctConsumoD = new List<double>();
            
            //consumo diario
            diario.Add(PREne / 31);
            diario.Add(PRFeb / 28);
            diario.Add(PRMar / 31);
            diario.Add(PRAbr / 30);
            diario.Add(PRMay / 31);
            diario.Add(PRJun / 30);
            diario.Add(PRJul / 31);
            diario.Add(PRAgo / 31);
            diario.Add(PRSep / 30);
            diario.Add(PROct / 31);
            diario.Add(PRNov / 30);
            diario.Add(PRDic / 31);

            double avgDiario = 0;
            foreach (var item in diario)
            {
                avgDiario += item;
            }
            diario.Add(avgDiario / 12);

            //Pct Consumo de lunes a Viernes
            pctConsumoLV.Add(0.2);
            pctConsumoLV.Add(0.2);
            pctConsumoLV.Add(0.2);
            pctConsumoLV.Add(0.2);
            pctConsumoLV.Add(0.2);
            pctConsumoLV.Add(0.35);
            pctConsumoLV.Add(0.50);
            pctConsumoLV.Add(0.75);
            pctConsumoLV.Add(0.85);
            pctConsumoLV.Add(0.75);
            pctConsumoLV.Add(0.50);
            pctConsumoLV.Add(0.50);
            pctConsumoLV.Add(0.75);
            pctConsumoLV.Add(0.85);
            pctConsumoLV.Add(0.50);
            pctConsumoLV.Add(0.50);
            pctConsumoLV.Add(0.50);
            pctConsumoLV.Add(0.50);
            pctConsumoLV.Add(0.65);
            pctConsumoLV.Add(0.75);
            pctConsumoLV.Add(0.60);
            pctConsumoLV.Add(0.2);
            pctConsumoLV.Add(0.2);
            pctConsumoLV.Add(0.2);

            double sumpctConsumoLV = 0;
            foreach (var item in pctConsumoLV)
            {
                sumpctConsumoLV += item;
            }

            //Pct Consumo de sábados
            pctConsumoS.Add(0.2);
            pctConsumoS.Add(0.2);
            pctConsumoS.Add(0.2);
            pctConsumoS.Add(0.2);
            pctConsumoS.Add(0.2);
            pctConsumoS.Add(0.2);
            pctConsumoS.Add(0.2);
            pctConsumoS.Add(0.75);
            pctConsumoS.Add(0.85);
            pctConsumoS.Add(0.75);
            pctConsumoS.Add(0.50);
            pctConsumoS.Add(0.50);
            pctConsumoS.Add(0.75);
            pctConsumoS.Add(0.85);
            pctConsumoS.Add(0.50);
            pctConsumoS.Add(0.50);
            pctConsumoS.Add(0.50);
            pctConsumoS.Add(0.50);
            pctConsumoS.Add(0.65);
            pctConsumoS.Add(0.75);
            pctConsumoS.Add(0.60);
            pctConsumoS.Add(0.2);
            pctConsumoS.Add(0.2);
            pctConsumoS.Add(0.2);

            double sumpctConsumoS = 0;
            foreach (var item in pctConsumoS)
            {
                sumpctConsumoS += item;
            }

            //Pct Consumo de domingos
            pctConsumoD.Add(0.2);
            pctConsumoD.Add(0.2);
            pctConsumoD.Add(0.2);
            pctConsumoD.Add(0.2);
            pctConsumoD.Add(0.2);
            pctConsumoD.Add(0.2);
            pctConsumoD.Add(0.2);
            pctConsumoD.Add(0.75);
            pctConsumoD.Add(0.85);
            pctConsumoD.Add(0.75);
            pctConsumoD.Add(0.50);
            pctConsumoD.Add(0.50);
            pctConsumoD.Add(0.75);
            pctConsumoD.Add(0.85);
            pctConsumoD.Add(0.50);
            pctConsumoD.Add(0.50);
            pctConsumoD.Add(0.50);
            pctConsumoD.Add(0.50);
            pctConsumoD.Add(0.65);
            pctConsumoD.Add(0.75);
            pctConsumoD.Add(0.60);
            pctConsumoD.Add(0.2);
            pctConsumoD.Add(0.2);
            pctConsumoD.Add(0.2);

            double sumpctConsumoD = 0;
            foreach (var item in pctConsumoD)
            {
                sumpctConsumoD += item;
            }

            //suma de porcentaje de consumo
            double sumTotal = (5 * sumpctConsumoLV + sumpctConsumoS + sumpctConsumoD)/7;

            //Pico de demanda
            for (int i = 0; i < 12; i++)
            {
                pico.Add(diario[i] /sumTotal);
            }

            double avgPico = 0;

            foreach (var item in pico)
            {
                avgPico += item;
            }
            pico.Add(avgPico / 12);

            //Comportamiento de lunes a viernes por mes
            for (int i = 0; i < 24; i++)
            {
                ccLaV[i, 0] = i;

                for (int j = 1; j < 13; j++)
                {
                    ccLaV[i,j]=pico[j-1]*pctConsumoLV[i];
                }

                ccLaV[i, 13] = (ccLaV[i, 1]+ ccLaV[i, 2]+ ccLaV[i, 3]+ ccLaV[i, 4]+ ccLaV[i, 5]+ ccLaV[i, 6]+ ccLaV[i, 7]+ ccLaV[i, 8]+ ccLaV[i, 8]+ ccLaV[i, 10]+ ccLaV[i, 11]+ ccLaV[i, 12])/12;
            }

            //Comportamiento de sábados por mes
            for (int i = 0; i < 24; i++)
            {
                ccSab[i, 0] = i;

                for (int j = 1; j < 13; j++)
                {
                    ccSab[i, j] = pico[j-1] * pctConsumoS[i];
                }

                ccSab[i, 13] = (ccSab[i, 1] + ccSab[i, 2] + ccSab[i, 3] + ccSab[i, 4] + ccSab[i, 5] + ccSab[i, 6] + ccSab[i, 7] + ccSab[i, 8] + ccSab[i, 8] + ccSab[i, 10] + ccSab[i, 11] + ccSab[i, 12])/12;
            }


            //Comportamiento de domingos por mes
            for (int i = 0; i < 24; i++)
            {
                ccDom[i, 0] = i;

                for (int j = 1; j < 13; j++)
                {
                    ccDom[i, j] = pico[j-1] * pctConsumoD[i];
                }

                ccDom[i, 13] = (ccDom[i, 1] + ccDom[i, 2] + ccDom[i, 3] + ccDom[i, 4] + ccDom[i, 5] + ccDom[i, 6] + ccDom[i, 7] + ccDom[i, 8] + ccDom[i, 8] + ccDom[i, 10] + ccDom[i, 11] + ccDom[i, 12])/12;
            }


            List<double> avgEnergiaDiaria = new List<double>();



            for (int i = 1; i < 13; i++)
            {
                double sumLaV = 0;
                double sumSab = 0;
                double sumDom = 0;

                for (int j = 0; j < 24; j++)
                {
                    sumLaV += ccLaV[j,i];
                    sumSab += ccSab[j, i];
                    sumDom += ccDom[j, i];
                }

                avgEnergiaDiaria.Add((5 * sumLaV + sumSab + sumDom) / 7);
            }

            double sumador = 0;

            foreach (var item in avgEnergiaDiaria)
            {
                sumador += item;
            }

            avgEnergiaDiaria.Add(sumador/12);

            List<double> errorAsociado = new List<double>();
            List<double> factorCarga = new List<double>();

            for (int i = 0; i < 12; i++)
            {
                if ((diario[i] - avgEnergiaDiaria[i]) / diario[i]>0)
                {
                    errorAsociado.Add((diario[i] - avgEnergiaDiaria[i]) / diario[i]);
                }
                else
                {
                    errorAsociado.Add(0);
                }
                
                factorCarga.Add(avgEnergiaDiaria[i]/(pico[i]*24));
            }

                                                                              
            double hora = 0;
            int dia = 0;
            int dSemana = -1;
            ccAnual[0, 0] = hora;


            //Calcula la Curva de carga Anual
            for (int i = 0; i < 35040; i=i+4)
            {
                if (i<2976) //Enero
                {

                    for (int j = i; j < i+4; j++)
                    {
                        if (j % 96 == 0)
                        {
                            hora = 0;
                            dia += 1;
                            dSemana += 1;
                            if (dSemana % 7 == 0)
                            {
                                dSemana = 0;
                            }

                            ccAnual[j, 0] = hora;
                            ccAnual[j, 1] = dia;
                            ccAnual[j, 2] = dSemana;

                        }
                        else
                        {
                            hora += 0.25;
                            ccAnual[j, 0] = hora;
                            ccAnual[j, 1] = dia;
                            ccAnual[j, 2] = dSemana;
                        }
                        if (dSemana<5)
                        {
                            ccAnual[j, 3] = ccLaV[Convert.ToInt32(decimal.Truncate((decimal)hora)), 1];
                            ccAnual[j, 4] = ccAnual[j, 3] * 0.25;
                        }
                        else if (dSemana == 5)
                        {
                            ccAnual[j, 3] = ccSab[Convert.ToInt32(decimal.Truncate((decimal)hora)), 1];
                            ccAnual[j, 4] = ccAnual[j, 3] * 0.25;
                        }
                        else
                        {
                            ccAnual[j, 3] = ccDom[Convert.ToInt32(decimal.Truncate((decimal)hora)), 1];
                            ccAnual[j, 4] = ccAnual[j, 3] * 0.25;
                        }

                    }        
                }
                else if (i<5664) //Febrero
                {
                    dia = 0;
                    for (int j = i; j < i + 4; j++)
                    {
                        if (j % 96 == 0)
                        {
                            hora = 0;
                            dia += 1;
                            dSemana += 1;
                            if (dSemana % 7 == 0)
                            {
                                dSemana = 0;
                            }

                            ccAnual[j, 0] = hora;
                            ccAnual[j, 1] = dia;
                            ccAnual[j, 2] = dSemana;

                        }
                        else
                        {
                            hora += 0.25;
                            ccAnual[j, 0] = hora;
                            ccAnual[j, 1] = dia;
                            ccAnual[j, 2] = dSemana;
                        }
                        if (dSemana < 5)
                        {
                            ccAnual[j, 3] = ccLaV[Convert.ToInt32(decimal.Truncate((decimal)hora)), 2];
                            ccAnual[j, 4] = ccAnual[j, 3] * 0.25;
                        }
                        else if (dSemana == 5)
                        {
                            ccAnual[j, 3] = ccSab[Convert.ToInt32(decimal.Truncate((decimal)hora)), 2];
                            ccAnual[j, 4] = ccAnual[j, 3] * 0.25;
                        }
                        else
                        {
                            ccAnual[j, 3] = ccDom[Convert.ToInt32(decimal.Truncate((decimal)hora)), 2];
                            ccAnual[j, 4] = ccAnual[j, 3] * 0.25;
                        }

                    }
                }
                else if (i<8640) //Marzo
                {
                    dia = 0;
                    for (int j = i; j < i + 4; j++)
                    {
                        if (j % 96 == 0)
                        {
                            hora = 0;
                            dia += 1;
                            dSemana += 1;
                            if (dSemana % 7 == 0)
                            {
                                dSemana = 0;
                            }

                            ccAnual[j, 0] = hora;
                            ccAnual[j, 1] = dia;
                            ccAnual[j, 2] = dSemana;

                        }
                        else
                        {
                            hora += 0.25;
                            ccAnual[j, 0] = hora;
                            ccAnual[j, 1] = dia;
                            ccAnual[j, 2] = dSemana;
                        }
                        if (dSemana < 5)
                        {
                            ccAnual[j, 3] = ccLaV[Convert.ToInt32(decimal.Truncate((decimal)hora)), 3];
                            ccAnual[j, 4] = ccAnual[j, 3] * 0.25;
                        }
                        else if (dSemana == 5)
                        {
                            ccAnual[j, 3] = ccSab[Convert.ToInt32(decimal.Truncate((decimal)hora)), 3];
                            ccAnual[j, 4] = ccAnual[j, 3] * 0.25;
                        }
                        else
                        {
                            ccAnual[j, 3] = ccDom[Convert.ToInt32(decimal.Truncate((decimal)hora)), 3];
                            ccAnual[j, 4] = ccAnual[j, 3] * 0.25;
                        }

                    }
                }
                else if (i < 11520) //Abril
                {
                    dia = 0;
                    for (int j = i; j < i + 4; j++)
                    {
                        if (j % 96 == 0)
                        {
                            hora = 0;
                            dia += 1;
                            dSemana += 1;
                            if (dSemana % 7 == 0)
                            {
                                dSemana = 0;
                            }

                            ccAnual[j, 0] = hora;
                            ccAnual[j, 1] = dia;
                            ccAnual[j, 2] = dSemana;

                        }
                        else
                        {
                            hora += 0.25;
                            ccAnual[j, 0] = hora;
                            ccAnual[j, 1] = dia;
                            ccAnual[j, 2] = dSemana;
                        }
                        if (dSemana < 5)
                        {
                            ccAnual[j, 3] = ccLaV[Convert.ToInt32(decimal.Truncate((decimal)hora)), 4];
                            ccAnual[j, 4] = ccAnual[j, 3] * 0.25;
                        }
                        else if (dSemana == 5)
                        {
                            ccAnual[j, 3] = ccSab[Convert.ToInt32(decimal.Truncate((decimal)hora)), 4];
                            ccAnual[j, 4] = ccAnual[j, 3] * 0.25;
                        }
                        else
                        {
                            ccAnual[j, 3] = ccDom[Convert.ToInt32(decimal.Truncate((decimal)hora)), 4];
                            ccAnual[j, 4] = ccAnual[j, 3] * 0.25;
                        }

                    }
                }
                else if (i < 14496) //Mayo
                {
                    dia = 0;
                    for (int j = i; j < i + 4; j++)
                    {
                        if (j % 96 == 0)
                        {
                            hora = 0;
                            dia += 1;
                            dSemana += 1;
                            if (dSemana % 7 == 0)
                            {
                                dSemana = 0;
                            }

                            ccAnual[j, 0] = hora;
                            ccAnual[j, 1] = dia;
                            ccAnual[j, 2] = dSemana;

                        }
                        else
                        {
                            hora += 0.25;
                            ccAnual[j, 0] = hora;
                            ccAnual[j, 1] = dia;
                            ccAnual[j, 2] = dSemana;
                        }
                        if (dSemana < 5)
                        {
                            ccAnual[j, 3] = ccLaV[Convert.ToInt32(decimal.Truncate((decimal)hora)), 5];
                            ccAnual[j, 4] = ccAnual[j, 3] * 0.25;
                        }
                        else if (dSemana == 5)
                        {
                            ccAnual[j, 3] = ccSab[Convert.ToInt32(decimal.Truncate((decimal)hora)), 5];
                            ccAnual[j, 4] = ccAnual[j, 3] * 0.25;
                        }
                        else
                        {
                            ccAnual[j, 3] = ccDom[Convert.ToInt32(decimal.Truncate((decimal)hora)), 5];
                            ccAnual[j, 4] = ccAnual[j, 3] * 0.25;
                        }

                    }
                }
                else if (i < 17376) //Junio
                {
                    dia = 0;
                    for (int j = i; j < i + 4; j++)
                    {
                        if (j % 96 == 0)
                        {
                            hora = 0;
                            dia += 1;
                            dSemana += 1;
                            if (dSemana % 7 == 0)
                            {
                                dSemana = 0;
                            }

                            ccAnual[j, 0] = hora;
                            ccAnual[j, 1] = dia;
                            ccAnual[j, 2] = dSemana;

                        }
                        else
                        {
                            hora += 0.25;
                            ccAnual[j, 0] = hora;
                            ccAnual[j, 1] = dia;
                            ccAnual[j, 2] = dSemana;
                        }
                        if (dSemana < 5)
                        {
                            ccAnual[j, 3] = ccLaV[Convert.ToInt32(decimal.Truncate((decimal)hora)), 6];
                            ccAnual[j, 4] = ccAnual[j, 3] * 0.25;
                        }
                        else if (dSemana == 5)
                        {
                            ccAnual[j, 3] = ccSab[Convert.ToInt32(decimal.Truncate((decimal)hora)), 6];
                            ccAnual[j, 4] = ccAnual[j, 3] * 0.25;
                        }
                        else
                        {
                            ccAnual[j, 3] = ccDom[Convert.ToInt32(decimal.Truncate((decimal)hora)), 6];
                            ccAnual[j, 4] = ccAnual[j, 3] * 0.25;
                        }

                    }
                }
                else if (i < 20352) //Julio
                {
                    dia = 0;
                    for (int j = i; j < i + 4; j++)
                    {
                        if (j % 96 == 0)
                        {
                            hora = 0;
                            dia += 1;
                            dSemana += 1;
                            if (dSemana % 7 == 0)
                            {
                                dSemana = 0;
                            }

                            ccAnual[j, 0] = hora;
                            ccAnual[j, 1] = dia;
                            ccAnual[j, 2] = dSemana;

                        }
                        else
                        {
                            hora += 0.25;
                            ccAnual[j, 0] = hora;
                            ccAnual[j, 1] = dia;
                            ccAnual[j, 2] = dSemana;
                        }
                        if (dSemana < 5)
                        {
                            ccAnual[j, 3] = ccLaV[Convert.ToInt32(decimal.Truncate((decimal)hora)), 7];
                            ccAnual[j, 4] = ccAnual[j, 3] * 0.25;
                        }
                        else if (dSemana == 5)
                        {
                            ccAnual[j, 3] = ccSab[Convert.ToInt32(decimal.Truncate((decimal)hora)), 7];
                            ccAnual[j, 4] = ccAnual[j, 3] * 0.25;
                        }
                        else
                        {
                            ccAnual[j, 3] = ccDom[Convert.ToInt32(decimal.Truncate((decimal)hora)), 7];
                            ccAnual[j, 4] = ccAnual[j, 3] * 0.25;
                        }

                    }
                }
                else if (i < 23328) //Agosto
                {
                    dia = 0;
                    for (int j = i; j < i + 4; j++)
                    {
                        if (j % 96 == 0)
                        {
                            hora = 0;
                            dia += 1;
                            dSemana += 1;
                            if (dSemana % 7 == 0)
                            {
                                dSemana = 0;
                            }

                            ccAnual[j, 0] = hora;
                            ccAnual[j, 1] = dia;
                            ccAnual[j, 2] = dSemana;

                        }
                        else
                        {
                            hora += 0.25;
                            ccAnual[j, 0] = hora;
                            ccAnual[j, 1] = dia;
                            ccAnual[j, 2] = dSemana;
                        }
                        if (dSemana < 5)
                        {
                            ccAnual[j, 3] = ccLaV[Convert.ToInt32(decimal.Truncate((decimal)hora)), 8];
                            ccAnual[j, 4] = ccAnual[j, 3] * 0.25;
                        }
                        else if (dSemana == 5)
                        {
                            ccAnual[j, 3] = ccSab[Convert.ToInt32(decimal.Truncate((decimal)hora)), 8];
                            ccAnual[j, 4] = ccAnual[j, 3] * 0.25;
                        }
                        else
                        {
                            ccAnual[j, 3] = ccDom[Convert.ToInt32(decimal.Truncate((decimal)hora)), 8];
                            ccAnual[j, 4] = ccAnual[j, 3] * 0.25;
                        }

                    }
                }
                else if (i < 26208) //Septiembre
                {
                    dia = 0;
                    for (int j = i; j < i + 4; j++)
                    {
                        if (j % 96 == 0)
                        {
                            hora = 0;
                            dia += 1;
                            dSemana += 1;
                            if (dSemana % 7 == 0)
                            {
                                dSemana = 0;
                            }

                            ccAnual[j, 0] = hora;
                            ccAnual[j, 1] = dia;
                            ccAnual[j, 2] = dSemana;

                        }
                        else
                        {
                            hora += 0.25;
                            ccAnual[j, 0] = hora;
                            ccAnual[j, 1] = dia;
                            ccAnual[j, 2] = dSemana;
                        }
                        if (dSemana < 5)
                        {
                            ccAnual[j, 3] = ccLaV[Convert.ToInt32(decimal.Truncate((decimal)hora)), 9];
                            ccAnual[j, 4] = ccAnual[j, 3] * 0.25;
                        }
                        else if (dSemana == 5)
                        {
                            ccAnual[j, 3] = ccSab[Convert.ToInt32(decimal.Truncate((decimal)hora)), 9];
                            ccAnual[j, 4] = ccAnual[j, 3] * 0.25;
                        }
                        else
                        {
                            ccAnual[j, 3] = ccDom[Convert.ToInt32(decimal.Truncate((decimal)hora)), 9];
                            ccAnual[j, 4] = ccAnual[j, 3] * 0.25;
                        }

                    }
                }
                else if (i < 29184) //Octubre
                {
                    dia = 0;
                    for (int j = i; j < i + 4; j++)
                    {
                        if (j % 96 == 0)
                        {
                            hora = 0;
                            dia += 1;
                            dSemana += 1;
                            if (dSemana % 7 == 0)
                            {
                                dSemana = 0;
                            }

                            ccAnual[j, 0] = hora;
                            ccAnual[j, 1] = dia;
                            ccAnual[j, 2] = dSemana;

                        }
                        else
                        {
                            hora += 0.25;
                            ccAnual[j, 0] = hora;
                            ccAnual[j, 1] = dia;
                            ccAnual[j, 2] = dSemana;
                        }
                        if (dSemana < 5)
                        {
                            ccAnual[j, 3] = ccLaV[Convert.ToInt32(decimal.Truncate((decimal)hora)), 10];
                            ccAnual[j, 4] = ccAnual[j, 3] * 0.25;
                        }
                        else if (dSemana == 5)
                        {
                            ccAnual[j, 3] = ccSab[Convert.ToInt32(decimal.Truncate((decimal)hora)), 10];
                            ccAnual[j, 4] = ccAnual[j, 3] * 0.25;
                        }
                        else
                        {
                            ccAnual[j, 3] = ccDom[Convert.ToInt32(decimal.Truncate((decimal)hora)), 10];
                            ccAnual[j, 4] = ccAnual[j, 3] * 0.25;
                        }

                    }
                }
                else if (i < 32064) //Noviembre
                {
                    dia = 0;
                    for (int j = i; j < i + 4; j++)
                    {
                        if (j % 96 == 0)
                        {
                            hora = 0;
                            dia += 1;
                            dSemana += 1;
                            if (dSemana % 7 == 0)
                            {
                                dSemana = 0;
                            }

                            ccAnual[j, 0] = hora;
                            ccAnual[j, 1] = dia;
                            ccAnual[j, 2] = dSemana;

                        }
                        else
                        {
                            hora += 0.25;
                            ccAnual[j, 0] = hora;
                            ccAnual[j, 1] = dia;
                            ccAnual[j, 2] = dSemana;
                        }
                        if (dSemana < 5)
                        {
                            ccAnual[j, 3] = ccLaV[Convert.ToInt32(decimal.Truncate((decimal)hora)), 11];
                            ccAnual[j, 4] = ccAnual[j, 3] * 0.25;
                        }
                        else if (dSemana == 5)
                        {
                            ccAnual[j, 3] = ccSab[Convert.ToInt32(decimal.Truncate((decimal)hora)), 11];
                            ccAnual[j, 4] = ccAnual[j, 3] * 0.25;
                        }
                        else
                        {
                            ccAnual[j, 3] = ccDom[Convert.ToInt32(decimal.Truncate((decimal)hora)), 11];
                            ccAnual[j, 4] = ccAnual[j, 3] * 0.25;
                        }

                    }
                }
                else  //Diciembre
                {
                    dia = 0;
                    for (int j = i; j < i + 4; j++)
                    {
                        if (j % 96 == 0)
                        {
                            hora = 0;
                            dia += 1;
                            dSemana += 1;
                            if (dSemana % 7 == 0)
                            {
                                dSemana = 0;
                            }

                            ccAnual[j, 0] = hora;
                            ccAnual[j, 1] = dia;
                            ccAnual[j, 2] = dSemana;

                        }
                        else
                        {
                            hora += 0.25;
                            ccAnual[j, 0] = hora;
                            ccAnual[j, 1] = dia;
                            ccAnual[j, 2] = dSemana;
                        }
                        if (dSemana < 5)
                        {
                            ccAnual[j, 3] = ccLaV[Convert.ToInt32(decimal.Truncate((decimal)hora)), 12];
                            ccAnual[j, 4] = ccAnual[j, 3] * 0.25;
                        }
                        else if (dSemana == 5)
                        {
                            ccAnual[j, 3] = ccSab[Convert.ToInt32(decimal.Truncate((decimal)hora)), 12];
                            ccAnual[j, 4] = ccAnual[j, 3] * 0.25;
                        }
                        else
                        {
                            ccAnual[j, 3] = ccDom[Convert.ToInt32(decimal.Truncate((decimal)hora)), 12];
                            ccAnual[j, 4] = ccAnual[j, 3] * 0.25;
                        }

                    }
                }

            }



            for (int i = 0; i < 2976; i++)
            {

                ccMenusal[i, 0] = ccAnual[i, 0];
                ccMenusal[i, 1] = ccAnual[i, 1];
                ccMenusal[i, 2] = ccAnual[i, 2];

                ccMenusal[i, 3] = (ccAnual[i, 3] + ccAnual[i + 2976, 3] + ccAnual[i + 5664, 3] + ccAnual[i + 8640, 3] + ccAnual[i + 11520, 3] + ccAnual[i + 14496, 3] + ccAnual[i + 17376, 3] + ccAnual[i + 20352, 3] + ccAnual[i + 23328, 3] + ccAnual[i + 26208, 3] + ccAnual[i + 29184, 3] + ccAnual[i + 32064, 3]) / 12;
                ccMenusal[i, 4] = ccMenusal[i, 3] * 0.25;
            }


            for (int i = 0; i < 96; i++)
            {

                ccDiaria[i, 0] = ccMenusal[i, 0];
                ccDiaria[i, 1] = ccMenusal[i, 1];
                ccDiaria[i, 2] = ccMenusal[i, 2];

                ccDiaria[i, 3] = (ccMenusal[i, 3] + ccMenusal[i + 96, 3] + ccMenusal[i + 192, 3] + ccMenusal[i + 288, 3] + ccMenusal[i +384, 3] + ccMenusal[i +480, 3] + ccMenusal[i +576, 3] + ccMenusal[i +672, 3] + ccMenusal[i +768, 3] + ccMenusal[i+864, 3] + ccMenusal[i +960, 3] + ccMenusal[i +1056, 3] +ccMenusal[i +1152, 3] + ccMenusal[i +1248, 3] + ccMenusal[i +1344, 3] + ccMenusal[i +1440, 3] + ccMenusal[i +1536, 3] + ccMenusal[i +1632, 3] + ccMenusal[i +1728, 3] + ccMenusal[i +1824, 3] + ccMenusal[i +1920, 3] + ccMenusal[i +2016, 3] + ccMenusal[i +2112, 3] +ccMenusal[i +2208, 3] + ccMenusal[i +2304, 3] + ccMenusal[i +2400, 3] + ccMenusal[i +2496, 3] + ccMenusal[i +2592, 3] + ccMenusal[i +2688, 3] + ccMenusal[i +2784, 3] + ccMenusal[i +2880, 3]) / 31;
                
                ccDiaria[i, 4] = ccDiaria[i, 3]*0.25;
            }

            return true;
        }

    }

}
