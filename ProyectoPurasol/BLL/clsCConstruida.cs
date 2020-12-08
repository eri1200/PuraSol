using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class clsCConstruida
    {
        

        public double[,] ccLaV = new double[24, 14];
        public double[,] ccSab = new double[24, 14];
        public double[,] ccDom = new double[24, 14];
        public double[,] ccAnual = new double[35040, 5];
        public double[,] ccMenusal = new double[2976, 5];
        public double[,] ccDiaria = new double[96, 5];
        public List<double> pico = new List<double>();

        public bool calculoCCRes(double PREne, double PRFeb, double PRMar, double PRAbr, double PRMay, double PRJun, double PRJul, double PRAgo, double PRSep, double PROct, double PRNov, double PRDic, double PRSGISEne,
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


        public bool calculoCCMTMT(double PiREne,double PiRFeb,double PiRMar,double PiRAbr,double PiRMay,double PiRJun,double PiRJul,double PiRAgo,double PiRSep,double PiROct,double PiRNov,double PiRDic,
            double VaREne,double VaRFeb,double VaRMar,double VaRAbr,double VaRMay,double VaRJun,double VaRJul,double VaRAgo,double VaRSep,double VaROct,double VaRNov,double VaRDic,
            double NoREne,double NoRFeb,double NoRMar,double NoRAbr,double NoRMay,double NoRJun,double NoRJul,double NoRAgo,double NoRSep,double NoROct,double NoRNov,double NoRDic,
            double PiDEne,double PiDFeb,double PiDMar,double PiDAbr,double PiDMay,double PiDJun,double PiDJul,double PiDAgo,double PiDSep,double PiDOct,double PiDNov,double PiDDic,
            double VaDEne,double VaDFeb,double VaDMar,double VaDAbr,double VaDMay,double VaDJun,double VaDJul,double VaDAgo,double VaDSep,double VaDOct,double VaDNov,double VaDDic,
            double NoDEne,double NoDFeb,double NoDMar,double NoDAbr,double NoDMay,double NoDJun,double NoDJul,double NoDAgo,double NoDSep,double NoDOct,double NoDNov,double NoDDic,
            double PRSGISEne,double PRSGISFeb, double PRSGISMar, double PRSGISAbr, double PRSGISMay, double PRSGISJun, double PRSGISJul, double PRSGISAgo, double PRSGISSep, double PRSGISOct, double PRSGISNov, double PRSGISDic)
        {
            
            double PromedioPRecibos = (PiREne + PiRFeb + PiRMar + PiRAbr + PiRMay + PiRJun + PiRJul + PiRAgo + PiRSep + PiROct + PiRNov + PiRDic) / 12;
            double PromedioVRecibos = (VaREne + VaRFeb + VaRMar + VaRAbr + VaRMay + VaRJun + VaRJul + VaRAgo + VaRSep + VaROct + VaRNov + VaRDic) / 12;
            double PromedioNRecibos = (NoREne + NoRFeb + NoRMar + NoRAbr + NoRMay + NoRJun + NoRJul + NoRAgo + NoRSep + NoROct + NoRNov + NoRDic) / 12;
            double PromedioPDemanda = (PiDEne + PiDFeb + PiDMar + PiDAbr + PiDMay + PiDJun + PiDJul + PiDAgo + PiDSep + PiDOct + PiDNov + PiDDic) / 12;
            double PromedioVDemanda = (VaDEne + VaDFeb + VaDMar + VaDAbr + VaDMay + VaDJun + VaDJul + VaDAgo + VaDSep + VaDOct + VaDNov + VaDDic) / 12;
            double PromedioNDemanda = (NoDEne + NoDFeb + NoDMar + NoDAbr + NoDMay + NoDJun + NoDJul + NoDAgo + NoDSep + NoDOct + NoDNov + NoDDic) / 12;
            double avdSGIS = PRSGISEne + PRSGISFeb + PRSGISMar + PRSGISAbr + PRSGISMay + PRSGISJun + PRSGISJul + PRSGISAgo + PRSGISSep + PRSGISOct + PRSGISNov + PRSGISDic;

            List<double> demandaP = new List<double>();
            List<double> demandaV = new List<double>();
            List<double> demandaN = new List<double>();

            //demanda diaria horas pico
            demandaP.Add(PiDEne);
            demandaP.Add(PiDFeb);
            demandaP.Add(PiDMar);
            demandaP.Add(PiDAbr);
            demandaP.Add(PiDMay);
            demandaP.Add(PiDJun);
            demandaP.Add(PiDJul);
            demandaP.Add(PiDAgo);
            demandaP.Add(PiDSep);
            demandaP.Add(PiDOct);
            demandaP.Add(PiDNov);
            demandaP.Add(PiDDic);

            //demanda diaria horas valle
            demandaV.Add(VaDEne);
            demandaV.Add(VaDFeb);
            demandaV.Add(VaDMar);
            demandaV.Add(VaDAbr);
            demandaV.Add(VaDMay);
            demandaV.Add(VaDJun);
            demandaV.Add(VaDJul);
            demandaV.Add(VaDAgo);
            demandaV.Add(VaDSep);
            demandaV.Add(VaDOct);
            demandaV.Add(VaDNov);
            demandaV.Add(VaDDic);

            //demanda diaria hpras noche
            demandaN.Add(NoDEne);
            demandaN.Add(NoDFeb);
            demandaN.Add(NoDMar);
            demandaN.Add(NoDAbr);
            demandaN.Add(NoDMay);
            demandaN.Add(NoDJun);
            demandaN.Add(NoDJul);
            demandaN.Add(NoDAgo);
            demandaN.Add(NoDSep);
            demandaN.Add(NoDOct);
            demandaN.Add(NoDNov);
            demandaN.Add(NoDDic);
            
            
            
            
            List<double> diarioPR = new List<double>();
            List<double> diarioVR = new List<double>();
            List<double> diarioNR = new List<double>();
            List<double> potenciaT = new List<double>();



            List<double> pctConsumoLV = new List<double>();
            List<double> pctConsumoS = new List<double>();
            List<double> pctConsumoD = new List<double>();

            //consumo diario horas pico
            diarioPR.Add(PiREne / 31);
            diarioPR.Add(PiRFeb / 28);
            diarioPR.Add(PiRMar / 31);
            diarioPR.Add(PiRAbr / 30);
            diarioPR.Add(PiRMay / 31);
            diarioPR.Add(PiRJun / 30);
            diarioPR.Add(PiRJul / 31);
            diarioPR.Add(PiRAgo / 31);
            diarioPR.Add(PiRSep / 30);
            diarioPR.Add(PiROct / 31);
            diarioPR.Add(PiRNov / 30);
            diarioPR.Add(PiRDic / 31);

            //consumo diario horas valle
            diarioVR.Add(VaREne / 31);
            diarioVR.Add(VaRFeb / 28);
            diarioVR.Add(VaRMar / 31);
            diarioVR.Add(VaRAbr / 30);
            diarioVR.Add(VaRMay / 31);
            diarioVR.Add(VaRJun / 30);
            diarioVR.Add(VaRJul / 31);
            diarioVR.Add(VaRAgo / 31);
            diarioVR.Add(VaRSep / 30);
            diarioVR.Add(VaROct / 31);
            diarioVR.Add(VaRNov / 30);
            diarioVR.Add(VaRDic / 31);

            //consumo diario hpras noche
            diarioNR.Add(NoREne / 31);
            diarioNR.Add(NoRFeb / 28);
            diarioNR.Add(NoRMar / 31);
            diarioNR.Add(NoRAbr / 30);
            diarioNR.Add(NoRMay / 31);
            diarioNR.Add(NoRJun / 30);
            diarioNR.Add(NoRJul / 31);
            diarioNR.Add(NoRAgo / 31);
            diarioNR.Add(NoRSep / 30);
            diarioNR.Add(NoROct / 31);
            diarioNR.Add(NoRNov / 30);
            diarioNR.Add(NoRDic / 31);

            double avgDiarioPR = 0;
            double avgDiarioVR = 0;
            double avgDiarioNR = 0;

            for (int i = 0; i < 12; i++)
            {
                avgDiarioPR += diarioPR[i];
                avgDiarioVR += diarioVR[i];
                avgDiarioNR += diarioNR[i];
            }

            diarioPR.Add(avgDiarioPR / 12);
            diarioVR.Add(avgDiarioVR / 12);
            diarioNR.Add(avgDiarioNR / 12);


            //llenando la potencia
            //Pico de demanda
            for (int i = 0; i < 12; i++)
            {
                pico.Add(Math.Max(demandaP[i], Math.Max(demandaV[i], demandaN[i])));
            }

            double avgPico = 0;

            foreach (var item in pico)
            {
                avgPico += item;
            }
            pico.Add(avgPico / 12);

            //Pct Consumo de lunes a Viernes
            pctConsumoLV.Add(0.35);
            pctConsumoLV.Add(0.35);
            pctConsumoLV.Add(0.35);
            pctConsumoLV.Add(0.35);
            pctConsumoLV.Add(0.55);
            pctConsumoLV.Add(0.55);
            pctConsumoLV.Add(0.55);
            pctConsumoLV.Add(0.55);
            pctConsumoLV.Add(0.80);
            pctConsumoLV.Add(0.80);
            pctConsumoLV.Add(0.80);
            pctConsumoLV.Add(0.80);
            pctConsumoLV.Add(0.80);
            pctConsumoLV.Add(0.80);
            pctConsumoLV.Add(0.80);
            pctConsumoLV.Add(0.80);
            pctConsumoLV.Add(0.80);
            pctConsumoLV.Add(0.55);
            pctConsumoLV.Add(0.55);
            pctConsumoLV.Add(0.55);
            pctConsumoLV.Add(0.55);
            pctConsumoLV.Add(0.55);
            pctConsumoLV.Add(0.35);
            pctConsumoLV.Add(0.35);

            double sumpctConsumoLV = 0;
            foreach (var item in pctConsumoLV)
            {
                sumpctConsumoLV += item;
            }

            //Pct Consumo de sábados
            pctConsumoS.Add(0.35);
            pctConsumoS.Add(0.35);
            pctConsumoS.Add(0.35);
            pctConsumoS.Add(0.35);
            pctConsumoS.Add(0.55);
            pctConsumoS.Add(0.55);
            pctConsumoS.Add(0.55);
            pctConsumoS.Add(0.55);
            pctConsumoS.Add(0.80);
            pctConsumoS.Add(0.80);
            pctConsumoS.Add(0.80);
            pctConsumoS.Add(0.80);
            pctConsumoS.Add(0.80);
            pctConsumoS.Add(0.80);
            pctConsumoS.Add(0.80);
            pctConsumoS.Add(0.80);
            pctConsumoS.Add(0.80);
            pctConsumoS.Add(0.55);
            pctConsumoS.Add(0.55);
            pctConsumoS.Add(0.55);
            pctConsumoS.Add(0.55);
            pctConsumoS.Add(0.55);
            pctConsumoS.Add(0.35);
            pctConsumoS.Add(0.35);

            double sumpctConsumoS = 0;
            foreach (var item in pctConsumoS)
            {
                sumpctConsumoS += item;
            }

            //Pct Consumo de domingos
            pctConsumoD.Add(0.35);
            pctConsumoD.Add(0.35);
            pctConsumoD.Add(0.35);
            pctConsumoD.Add(0.35);
            pctConsumoD.Add(0.55);
            pctConsumoD.Add(0.55);
            pctConsumoD.Add(0.55);
            pctConsumoD.Add(0.55);
            pctConsumoD.Add(0.80);
            pctConsumoD.Add(0.80);
            pctConsumoD.Add(0.80);
            pctConsumoD.Add(0.80);
            pctConsumoD.Add(0.80);
            pctConsumoD.Add(0.80);
            pctConsumoD.Add(0.80);
            pctConsumoD.Add(0.80);
            pctConsumoD.Add(0.80);
            pctConsumoD.Add(0.55);
            pctConsumoD.Add(0.55);
            pctConsumoD.Add(0.55);
            pctConsumoD.Add(0.55);
            pctConsumoD.Add(0.55);
            pctConsumoD.Add(0.35);
            pctConsumoD.Add(0.35);

            double sumpctConsumoD = 0;
            foreach (var item in pctConsumoD)
            {
                sumpctConsumoD += item;
            }

            //suma de porcentaje de consumo
            double sumTotal = (5 * sumpctConsumoLV + sumpctConsumoS + sumpctConsumoD) / 7;

            

            //Comportamiento de lunes a viernes por mes
            for (int i = 0; i < 24; i++)
            {
                ccLaV[i, 0] = i;

                for (int j = 1; j < 13; j++)
                {
                    ccLaV[i, j] = pico[j - 1] * pctConsumoLV[i];
                }

                ccLaV[i, 13] = (ccLaV[i, 1] + ccLaV[i, 2] + ccLaV[i, 3] + ccLaV[i, 4] + ccLaV[i, 5] + ccLaV[i, 6] + ccLaV[i, 7] + ccLaV[i, 8] + ccLaV[i, 8] + ccLaV[i, 10] + ccLaV[i, 11] + ccLaV[i, 12]) / 12;
            }

            //Comportamiento de sábados por mes
            for (int i = 0; i < 24; i++)
            {
                ccSab[i, 0] = i;

                for (int j = 1; j < 13; j++)
                {
                    ccSab[i, j] = pico[j - 1] * pctConsumoS[i];
                }

                ccSab[i, 13] = (ccSab[i, 1] + ccSab[i, 2] + ccSab[i, 3] + ccSab[i, 4] + ccSab[i, 5] + ccSab[i, 6] + ccSab[i, 7] + ccSab[i, 8] + ccSab[i, 8] + ccSab[i, 10] + ccSab[i, 11] + ccSab[i, 12]) / 12;
            }


            //Comportamiento de domingos por mes
            for (int i = 0; i < 24; i++)
            {
                ccDom[i, 0] = i;

                for (int j = 1; j < 13; j++)
                {
                    ccDom[i, j] = pico[j - 1] * pctConsumoD[i];
                }

                ccDom[i, 13] = (ccDom[i, 1] + ccDom[i, 2] + ccDom[i, 3] + ccDom[i, 4] + ccDom[i, 5] + ccDom[i, 6] + ccDom[i, 7] + ccDom[i, 8] + ccDom[i, 8] + ccDom[i, 10] + ccDom[i, 11] + ccDom[i, 12]) / 12;
            }




            List<double> avgEnergiaDiariaP = new List<double>();
            List<double> avgEnergiaDiariaV = new List<double>();
            List<double> avgEnergiaDiariaN = new List<double>();

            for (int i = 1; i < 13; i++)
            {

                double sumLaVP = 0;
                double sumSabP = 0;
                double sumDomP = 0;

                double sumLaVV = 0;
                double sumSabV = 0;
                double sumDomV = 0;

                double sumLaVN = 0;
                double sumSabN = 0;
                double sumDomN = 0;

                sumLaVP = ccLaV[10, i] + ccLaV[11, i] + ccLaV[12, i] + ccLaV[18, i] + ccLaV[19, i];
                sumSabP = ccSab[10, i] + ccSab[11, i] + ccSab[12, i] + ccSab[18, i] + ccSab[19, i];
                sumDomP = ccDom[10, i] + ccDom[11, i] + ccDom[12, i] + ccDom[18, i] + ccDom[19, i];

                avgEnergiaDiariaP.Add((5 * sumLaVP + sumSabP + sumDomP) / 7);

                sumLaVV = ccLaV[6, i] + ccLaV[7, i] + ccLaV[8, i] + ccLaV[9, i] + ccLaV[13, i] + ccLaV[14, i] + ccLaV[15, i] + ccLaV[16, i] + ccLaV[17, i];
                sumSabV = ccSab[6, i] + ccSab[7, i] + ccSab[8, i] + ccSab[9, i] + ccSab[13, i] + ccSab[14, i] + ccSab[15, i] + ccSab[16, i] + ccSab[17, i];
                sumDomV = ccDom[6, i] + ccDom[7, i] + ccDom[8, i] + ccDom[9, i] + ccDom[13, i] + ccDom[14, i] + ccDom[15, i] + ccDom[16, i] + ccDom[17, i];

                avgEnergiaDiariaV.Add((5 * sumLaVV + sumSabV + sumDomV) / 7);

                sumLaVN = ccLaV[0, i] + ccLaV[1, i] + ccLaV[2, i] + ccLaV[3, i] + ccLaV[4, i] + ccLaV[5, i] + ccLaV[20, i] + ccLaV[21, i] + ccLaV[22, i] + ccLaV[23, i];
                sumSabN = ccSab[0, i] + ccSab[1, i] + ccSab[2, i] + ccSab[3, i] + ccSab[4, i] + ccSab[5, i] + ccSab[20, i] + ccSab[21, i] + ccSab[22, i] + ccSab[23, i];
                sumDomN = ccDom[0, i] + ccDom[1, i] + ccDom[2, i] + ccDom[3, i] + ccDom[4, i] + ccDom[5, i] + ccDom[20, i] + ccDom[21, i] + ccDom[22, i] + ccDom[23, i];

                avgEnergiaDiariaN.Add((5 * sumLaVN + sumSabN + sumDomN) / 7);


            }

            

            double sumadorP = 0;
            double sumadorV = 0;
            double sumadorN = 0;

            for (int i = 0; i < 12; i++)
            {
                sumadorP += avgEnergiaDiariaP[i];
                sumadorV += avgEnergiaDiariaV[i];
                sumadorN += avgEnergiaDiariaN[i];
            }

            avgEnergiaDiariaP.Add(sumadorP / 12);
            avgEnergiaDiariaV.Add(sumadorV / 12);
            avgEnergiaDiariaN.Add(sumadorN / 12);

            List<double> errorAsociadoP = new List<double>();
            List<double> errorAsociadoV = new List<double>();
            List<double> errorAsociadoN = new List<double>();
            List<double> factorCargaP = new List<double>();
            List<double> factorCargaV = new List<double>();
            List<double> factorCargaN = new List<double>();

            for (int i = 0; i < 12; i++)
            {
                if ((diarioPR[i] - avgEnergiaDiariaP[i]) / diarioPR[i] > 0)
                {
                    errorAsociadoP.Add((diarioPR[i] - avgEnergiaDiariaP[i]) / diarioPR[i]);
                }
                else
                {
                    errorAsociadoP.Add(0);
                }

                factorCargaP.Add(avgEnergiaDiariaP[i] / (pico[i] * 24));
            }

            for (int i = 0; i < 12; i++)
            {
                if ((diarioVR[i] - avgEnergiaDiariaV[i]) / diarioVR[i] > 0)
                {
                    errorAsociadoV.Add((diarioVR[i] - avgEnergiaDiariaV[i]) / diarioVR[i]);
                }
                else
                {
                    errorAsociadoV.Add(0);
                }

                factorCargaV.Add(avgEnergiaDiariaV[i] / (pico[i] * 24));
            }

            for (int i = 0; i < 12; i++)
            {
                if ((diarioNR[i] - avgEnergiaDiariaN[i]) / diarioNR[i] > 0)
                {
                    errorAsociadoN.Add((diarioNR[i] - avgEnergiaDiariaN[i]) / diarioNR[i]);
                }
                else
                {
                    errorAsociadoN.Add(0);
                }

                factorCargaN.Add(avgEnergiaDiariaN[i] / (pico[i] * 24));
            }


            double hora = 0;
            int dia = 0;
            int dSemana = -1;
            ccAnual[0, 0] = hora;


            //Calcula la Curva de carga Anual
            for (int i = 0; i < 35040; i = i + 4)
            {
                if (i < 2976) //Enero
                {

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
                else if (i < 5664) //Febrero
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
                else if (i < 8640) //Marzo
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

                ccDiaria[i, 3] = (ccMenusal[i, 3] + ccMenusal[i + 96, 3] + ccMenusal[i + 192, 3] + ccMenusal[i + 288, 3] + ccMenusal[i + 384, 3] + ccMenusal[i + 480, 3] + ccMenusal[i + 576, 3] + ccMenusal[i + 672, 3] + ccMenusal[i + 768, 3] + ccMenusal[i + 864, 3] + ccMenusal[i + 960, 3] + ccMenusal[i + 1056, 3] + ccMenusal[i + 1152, 3] + ccMenusal[i + 1248, 3] + ccMenusal[i + 1344, 3] + ccMenusal[i + 1440, 3] + ccMenusal[i + 1536, 3] + ccMenusal[i + 1632, 3] + ccMenusal[i + 1728, 3] + ccMenusal[i + 1824, 3] + ccMenusal[i + 1920, 3] + ccMenusal[i + 2016, 3] + ccMenusal[i + 2112, 3] + ccMenusal[i + 2208, 3] + ccMenusal[i + 2304, 3] + ccMenusal[i + 2400, 3] + ccMenusal[i + 2496, 3] + ccMenusal[i + 2592, 3] + ccMenusal[i + 2688, 3] + ccMenusal[i + 2784, 3] + ccMenusal[i + 2880, 3]) / 31;

                ccDiaria[i, 4] = ccDiaria[i, 3] * 0.25;
            }

            return true;
        }


        public bool calculoCCTMT(double PiREne, double PiRFeb, double PiRMar, double PiRAbr, double PiRMay, double PiRJun, double PiRJul, double PiRAgo, double PiRSep, double PiROct, double PiRNov, double PiRDic,
            double VaREne, double VaRFeb, double VaRMar, double VaRAbr, double VaRMay, double VaRJun, double VaRJul, double VaRAgo, double VaRSep, double VaROct, double VaRNov, double VaRDic,
            double NoREne, double NoRFeb, double NoRMar, double NoRAbr, double NoRMay, double NoRJun, double NoRJul, double NoRAgo, double NoRSep, double NoROct, double NoRNov, double NoRDic,
            double PiDEne, double PiDFeb, double PiDMar, double PiDAbr, double PiDMay, double PiDJun, double PiDJul, double PiDAgo, double PiDSep, double PiDOct, double PiDNov, double PiDDic,
            double VaDEne, double VaDFeb, double VaDMar, double VaDAbr, double VaDMay, double VaDJun, double VaDJul, double VaDAgo, double VaDSep, double VaDOct, double VaDNov, double VaDDic,
            double NoDEne, double NoDFeb, double NoDMar, double NoDAbr, double NoDMay, double NoDJun, double NoDJul, double NoDAgo, double NoDSep, double NoDOct, double NoDNov, double NoDDic,
            double PRSGISEne, double PRSGISFeb, double PRSGISMar, double PRSGISAbr, double PRSGISMay, double PRSGISJun, double PRSGISJul, double PRSGISAgo, double PRSGISSep, double PRSGISOct, double PRSGISNov, double PRSGISDic)
        {

            double PromedioPRecibos = (PiREne + PiRFeb + PiRMar + PiRAbr + PiRMay + PiRJun + PiRJul + PiRAgo + PiRSep + PiROct + PiRNov + PiRDic) / 12;
            double PromedioVRecibos = (VaREne + VaRFeb + VaRMar + VaRAbr + VaRMay + VaRJun + VaRJul + VaRAgo + VaRSep + VaROct + VaRNov + VaRDic) / 12;
            double PromedioNRecibos = (NoREne + NoRFeb + NoRMar + NoRAbr + NoRMay + NoRJun + NoRJul + NoRAgo + NoRSep + NoROct + NoRNov + NoRDic) / 12;
            double PromedioPDemanda = (PiDEne + PiDFeb + PiDMar + PiDAbr + PiDMay + PiDJun + PiDJul + PiDAgo + PiDSep + PiDOct + PiDNov + PiDDic) / 12;
            double PromedioVDemanda = (VaDEne + VaDFeb + VaDMar + VaDAbr + VaDMay + VaDJun + VaDJul + VaDAgo + VaDSep + VaDOct + VaDNov + VaDDic) / 12;
            double PromedioNDemanda = (NoDEne + NoDFeb + NoDMar + NoDAbr + NoDMay + NoDJun + NoDJul + NoDAgo + NoDSep + NoDOct + NoDNov + NoDDic) / 12;
            double avdSGIS = PRSGISEne + PRSGISFeb + PRSGISMar + PRSGISAbr + PRSGISMay + PRSGISJun + PRSGISJul + PRSGISAgo + PRSGISSep + PRSGISOct + PRSGISNov + PRSGISDic;

            List<double> demandaP = new List<double>();
            List<double> demandaV = new List<double>();
            List<double> demandaN = new List<double>();

            //demanda diaria horas pico
            demandaP.Add(PiDEne);
            demandaP.Add(PiDFeb);
            demandaP.Add(PiDMar);
            demandaP.Add(PiDAbr);
            demandaP.Add(PiDMay);
            demandaP.Add(PiDJun);
            demandaP.Add(PiDJul);
            demandaP.Add(PiDAgo);
            demandaP.Add(PiDSep);
            demandaP.Add(PiDOct);
            demandaP.Add(PiDNov);
            demandaP.Add(PiDDic);

            //demanda diaria horas valle
            demandaV.Add(VaDEne);
            demandaV.Add(VaDFeb);
            demandaV.Add(VaDMar);
            demandaV.Add(VaDAbr);
            demandaV.Add(VaDMay);
            demandaV.Add(VaDJun);
            demandaV.Add(VaDJul);
            demandaV.Add(VaDAgo);
            demandaV.Add(VaDSep);
            demandaV.Add(VaDOct);
            demandaV.Add(VaDNov);
            demandaV.Add(VaDDic);

            //demanda diaria hpras noche
            demandaN.Add(NoDEne);
            demandaN.Add(NoDFeb);
            demandaN.Add(NoDMar);
            demandaN.Add(NoDAbr);
            demandaN.Add(NoDMay);
            demandaN.Add(NoDJun);
            demandaN.Add(NoDJul);
            demandaN.Add(NoDAgo);
            demandaN.Add(NoDSep);
            demandaN.Add(NoDOct);
            demandaN.Add(NoDNov);
            demandaN.Add(NoDDic);




            List<double> diarioPR = new List<double>();
            List<double> diarioVR = new List<double>();
            List<double> diarioNR = new List<double>();
            List<double> potenciaT = new List<double>();



            List<double> pctConsumoLV = new List<double>();
            List<double> pctConsumoS = new List<double>();
            List<double> pctConsumoD = new List<double>();

            //consumo diario horas pico
            diarioPR.Add(PiREne / 31);
            diarioPR.Add(PiRFeb / 28);
            diarioPR.Add(PiRMar / 31);
            diarioPR.Add(PiRAbr / 30);
            diarioPR.Add(PiRMay / 31);
            diarioPR.Add(PiRJun / 30);
            diarioPR.Add(PiRJul / 31);
            diarioPR.Add(PiRAgo / 31);
            diarioPR.Add(PiRSep / 30);
            diarioPR.Add(PiROct / 31);
            diarioPR.Add(PiRNov / 30);
            diarioPR.Add(PiRDic / 31);

            //consumo diario horas valle
            diarioVR.Add(VaREne / 31);
            diarioVR.Add(VaRFeb / 28);
            diarioVR.Add(VaRMar / 31);
            diarioVR.Add(VaRAbr / 30);
            diarioVR.Add(VaRMay / 31);
            diarioVR.Add(VaRJun / 30);
            diarioVR.Add(VaRJul / 31);
            diarioVR.Add(VaRAgo / 31);
            diarioVR.Add(VaRSep / 30);
            diarioVR.Add(VaROct / 31);
            diarioVR.Add(VaRNov / 30);
            diarioVR.Add(VaRDic / 31);

            //consumo diario hpras noche
            diarioNR.Add(NoREne / 31);
            diarioNR.Add(NoRFeb / 28);
            diarioNR.Add(NoRMar / 31);
            diarioNR.Add(NoRAbr / 30);
            diarioNR.Add(NoRMay / 31);
            diarioNR.Add(NoRJun / 30);
            diarioNR.Add(NoRJul / 31);
            diarioNR.Add(NoRAgo / 31);
            diarioNR.Add(NoRSep / 30);
            diarioNR.Add(NoROct / 31);
            diarioNR.Add(NoRNov / 30);
            diarioNR.Add(NoRDic / 31);

            double avgDiarioPR = 0;
            double avgDiarioVR = 0;
            double avgDiarioNR = 0;

            for (int i = 0; i < 12; i++)
            {
                avgDiarioPR += diarioPR[i];
                avgDiarioVR += diarioVR[i];
                avgDiarioNR += diarioNR[i];
            }

            diarioPR.Add(avgDiarioPR / 12);
            diarioVR.Add(avgDiarioVR / 12);
            diarioNR.Add(avgDiarioNR / 12);


            //llenando la potencia
            //Pico de demanda
            for (int i = 0; i < 12; i++)
            {
                pico.Add(Math.Max(demandaP[i], Math.Max(demandaV[i], demandaN[i])));
            }

            double avgPico = 0;

            foreach (var item in pico)
            {
                avgPico += item;
            }
            pico.Add(avgPico / 12);

            //Pct Consumo de lunes a Viernes
            pctConsumoLV.Add(0.35);
            pctConsumoLV.Add(0.35);
            pctConsumoLV.Add(0.35);
            pctConsumoLV.Add(0.35);
            pctConsumoLV.Add(0.55);
            pctConsumoLV.Add(0.55);
            pctConsumoLV.Add(0.55);
            pctConsumoLV.Add(0.55);
            pctConsumoLV.Add(0.80);
            pctConsumoLV.Add(0.80);
            pctConsumoLV.Add(0.80);
            pctConsumoLV.Add(0.80);
            pctConsumoLV.Add(0.80);
            pctConsumoLV.Add(0.80);
            pctConsumoLV.Add(0.80);
            pctConsumoLV.Add(0.80);
            pctConsumoLV.Add(0.80);
            pctConsumoLV.Add(0.55);
            pctConsumoLV.Add(0.55);
            pctConsumoLV.Add(0.55);
            pctConsumoLV.Add(0.55);
            pctConsumoLV.Add(0.55);
            pctConsumoLV.Add(0.35);
            pctConsumoLV.Add(0.35);

            double sumpctConsumoLV = 0;
            foreach (var item in pctConsumoLV)
            {
                sumpctConsumoLV += item;
            }

            //Pct Consumo de sábados
            pctConsumoS.Add(0.35);
            pctConsumoS.Add(0.35);
            pctConsumoS.Add(0.35);
            pctConsumoS.Add(0.35);
            pctConsumoS.Add(0.55);
            pctConsumoS.Add(0.55);
            pctConsumoS.Add(0.55);
            pctConsumoS.Add(0.55);
            pctConsumoS.Add(0.80);
            pctConsumoS.Add(0.80);
            pctConsumoS.Add(0.80);
            pctConsumoS.Add(0.80);
            pctConsumoS.Add(0.80);
            pctConsumoS.Add(0.80);
            pctConsumoS.Add(0.80);
            pctConsumoS.Add(0.80);
            pctConsumoS.Add(0.80);
            pctConsumoS.Add(0.55);
            pctConsumoS.Add(0.55);
            pctConsumoS.Add(0.55);
            pctConsumoS.Add(0.55);
            pctConsumoS.Add(0.55);
            pctConsumoS.Add(0.35);
            pctConsumoS.Add(0.35);

            double sumpctConsumoS = 0;
            foreach (var item in pctConsumoS)
            {
                sumpctConsumoS += item;
            }

            //Pct Consumo de domingos
            pctConsumoD.Add(0.35);
            pctConsumoD.Add(0.35);
            pctConsumoD.Add(0.35);
            pctConsumoD.Add(0.35);
            pctConsumoD.Add(0.35);
            pctConsumoD.Add(0.35);
            pctConsumoD.Add(0.35);
            pctConsumoD.Add(0.35);
            pctConsumoD.Add(0.35);
            pctConsumoD.Add(0.35);
            pctConsumoD.Add(0.35);
            pctConsumoD.Add(0.35);
            pctConsumoD.Add(0.35);
            pctConsumoD.Add(0.35);
            pctConsumoD.Add(0.35);
            pctConsumoD.Add(0.35);
            pctConsumoD.Add(0.35);
            pctConsumoD.Add(0.35);
            pctConsumoD.Add(0.35);
            pctConsumoD.Add(0.35);
            pctConsumoD.Add(0.35);
            pctConsumoD.Add(0.35);
            pctConsumoD.Add(0.35);
            pctConsumoD.Add(0.35);

            double sumpctConsumoD = 0;
            foreach (var item in pctConsumoD)
            {
                sumpctConsumoD += item;
            }

            //suma de porcentaje de consumo
            double sumTotal = (5 * sumpctConsumoLV + sumpctConsumoS + sumpctConsumoD) / 7;



            //Comportamiento de lunes a viernes por mes
            for (int i = 0; i < 24; i++)
            {
                ccLaV[i, 0] = i;

                for (int j = 1; j < 13; j++)
                {
                    ccLaV[i, j] = pico[j - 1] * pctConsumoLV[i];
                }

                ccLaV[i, 13] = (ccLaV[i, 1] + ccLaV[i, 2] + ccLaV[i, 3] + ccLaV[i, 4] + ccLaV[i, 5] + ccLaV[i, 6] + ccLaV[i, 7] + ccLaV[i, 8] + ccLaV[i, 8] + ccLaV[i, 10] + ccLaV[i, 11] + ccLaV[i, 12]) / 12;
            }

            //Comportamiento de sábados por mes
            for (int i = 0; i < 24; i++)
            {
                ccSab[i, 0] = i;

                for (int j = 1; j < 13; j++)
                {
                    ccSab[i, j] = pico[j - 1] * pctConsumoS[i];
                }

                ccSab[i, 13] = (ccSab[i, 1] + ccSab[i, 2] + ccSab[i, 3] + ccSab[i, 4] + ccSab[i, 5] + ccSab[i, 6] + ccSab[i, 7] + ccSab[i, 8] + ccSab[i, 8] + ccSab[i, 10] + ccSab[i, 11] + ccSab[i, 12]) / 12;
            }


            //Comportamiento de domingos por mes
            for (int i = 0; i < 24; i++)
            {
                ccDom[i, 0] = i;

                for (int j = 1; j < 13; j++)
                {
                    ccDom[i, j] = pico[j - 1] * pctConsumoD[i];
                }

                ccDom[i, 13] = (ccDom[i, 1] + ccDom[i, 2] + ccDom[i, 3] + ccDom[i, 4] + ccDom[i, 5] + ccDom[i, 6] + ccDom[i, 7] + ccDom[i, 8] + ccDom[i, 8] + ccDom[i, 10] + ccDom[i, 11] + ccDom[i, 12]) / 12;
            }




            List<double> avgEnergiaDiariaP = new List<double>();
            List<double> avgEnergiaDiariaV = new List<double>();
            List<double> avgEnergiaDiariaN = new List<double>();

            for (int i = 1; i < 13; i++)
            {

                double sumLaVP = 0;
                double sumSabP = 0;
                double sumDomP = 0;

                double sumLaVV = 0;
                double sumSabV = 0;
                double sumDomV = 0;

                double sumLaVN = 0;
                double sumSabN = 0;
                double sumDomN = 0;

                sumLaVP = ccLaV[10, i] + ccLaV[11, i] + ccLaV[12, i] + ccLaV[18, i] + ccLaV[19, i];
                sumSabP = ccSab[10, i] + ccSab[11, i] + ccSab[12, i] + ccSab[18, i] + ccSab[19, i];
                sumDomP = ccDom[10, i] + ccDom[11, i] + ccDom[12, i] + ccDom[18, i] + ccDom[19, i];

                avgEnergiaDiariaP.Add((5 * sumLaVP + sumSabP + sumDomP) / 7);

                sumLaVV = ccLaV[6, i] + ccLaV[7, i] + ccLaV[8, i] + ccLaV[9, i] + ccLaV[13, i] + ccLaV[14, i] + ccLaV[15, i] + ccLaV[16, i] + ccLaV[17, i];
                sumSabV = ccSab[6, i] + ccSab[7, i] + ccSab[8, i] + ccSab[9, i] + ccSab[13, i] + ccSab[14, i] + ccSab[15, i] + ccSab[16, i] + ccSab[17, i];
                sumDomV = ccDom[6, i] + ccDom[7, i] + ccDom[8, i] + ccDom[9, i] + ccDom[13, i] + ccDom[14, i] + ccDom[15, i] + ccDom[16, i] + ccDom[17, i];

                avgEnergiaDiariaV.Add((5 * sumLaVV + sumSabV + sumDomV) / 7);

                sumLaVN = ccLaV[0, i] + ccLaV[1, i] + ccLaV[2, i] + ccLaV[3, i] + ccLaV[4, i] + ccLaV[5, i] + ccLaV[20, i] + ccLaV[21, i] + ccLaV[22, i] + ccLaV[23, i];
                sumSabN = ccSab[0, i] + ccSab[1, i] + ccSab[2, i] + ccSab[3, i] + ccSab[4, i] + ccSab[5, i] + ccSab[20, i] + ccSab[21, i] + ccSab[22, i] + ccSab[23, i];
                sumDomN = ccDom[0, i] + ccDom[1, i] + ccDom[2, i] + ccDom[3, i] + ccDom[4, i] + ccDom[5, i] + ccDom[20, i] + ccDom[21, i] + ccDom[22, i] + ccDom[23, i];

                avgEnergiaDiariaN.Add((5 * sumLaVN + sumSabN + sumDomN) / 7);


            }



            double sumadorP = 0;
            double sumadorV = 0;
            double sumadorN = 0;

            for (int i = 0; i < 12; i++)
            {
                sumadorP += avgEnergiaDiariaP[i];
                sumadorV += avgEnergiaDiariaV[i];
                sumadorN += avgEnergiaDiariaN[i];
            }

            avgEnergiaDiariaP.Add(sumadorP / 12);
            avgEnergiaDiariaV.Add(sumadorV / 12);
            avgEnergiaDiariaN.Add(sumadorN / 12);

            List<double> errorAsociadoP = new List<double>();
            List<double> errorAsociadoV = new List<double>();
            List<double> errorAsociadoN = new List<double>();
            List<double> factorCarga = new List<double>();


            errorAsociadoP.Clear();
            errorAsociadoV.Clear();
            errorAsociadoN.Clear();
            factorCarga.Clear();


            for (int i = 0; i < 12; i++)
            {
                if ((avgEnergiaDiariaP[i] - diarioPR[i]) / diarioPR[i] > 0)
                {
                    errorAsociadoP.Add((avgEnergiaDiariaP[i] - diarioPR[i]) / diarioPR[i]);
                }
                else
                {
                    errorAsociadoP.Add(0);
                }

            }

            for (int i = 0; i < 12; i++)
            {
                if ((avgEnergiaDiariaV[i] - diarioVR[i]) / diarioPR[i] > 0)
                {
                    errorAsociadoV.Add((avgEnergiaDiariaV[i] - diarioVR[i]) / diarioPR[i]);
                }
                else
                {
                    errorAsociadoV.Add(0);
                }

            }

            for (int i = 0; i < 12; i++)
            {
                if ((avgEnergiaDiariaN[i] - diarioNR[i]) / diarioPR[i] > 0)
                {
                    errorAsociadoN.Add((avgEnergiaDiariaN[i] - diarioNR[i]) / diarioPR[i]);
                }
                else
                {
                    errorAsociadoN.Add(0);
                }

                factorCarga.Add((avgEnergiaDiariaP[i] + avgEnergiaDiariaV[i] + avgEnergiaDiariaN[i]) / (pico[i] * 24));
            }


            double hora = 0;
            int dia = 0;
            int dSemana = -1;
            ccAnual[0, 0] = hora;


            //Calcula la Curva de carga Anual
            for (int i = 0; i < 35040; i = i + 4)
            {
                if (i < 2976) //Enero
                {

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
                else if (i < 5664) //Febrero
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
                else if (i < 8640) //Marzo
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

                ccDiaria[i, 3] = (ccMenusal[i, 3] + ccMenusal[i + 96, 3] + ccMenusal[i + 192, 3] + ccMenusal[i + 288, 3] + ccMenusal[i + 384, 3] + ccMenusal[i + 480, 3] + ccMenusal[i + 576, 3] + ccMenusal[i + 672, 3] + ccMenusal[i + 768, 3] + ccMenusal[i + 864, 3] + ccMenusal[i + 960, 3] + ccMenusal[i + 1056, 3] + ccMenusal[i + 1152, 3] + ccMenusal[i + 1248, 3] + ccMenusal[i + 1344, 3] + ccMenusal[i + 1440, 3] + ccMenusal[i + 1536, 3] + ccMenusal[i + 1632, 3] + ccMenusal[i + 1728, 3] + ccMenusal[i + 1824, 3] + ccMenusal[i + 1920, 3] + ccMenusal[i + 2016, 3] + ccMenusal[i + 2112, 3] + ccMenusal[i + 2208, 3] + ccMenusal[i + 2304, 3] + ccMenusal[i + 2400, 3] + ccMenusal[i + 2496, 3] + ccMenusal[i + 2592, 3] + ccMenusal[i + 2688, 3] + ccMenusal[i + 2784, 3] + ccMenusal[i + 2880, 3]) / 31;

                ccDiaria[i, 4] = ccDiaria[i, 3] * 0.25;
            }

            return true;
        }


        public bool calculoCCCom(double PREne, double PRFeb, double PRMar, double PRAbr, double PRMay, double PRJun, double PRJul, double PRAgo, double PRSep, double PROct, double PRNov, double PRDic,
            double PDEne, double PDFeb, double PDMar, double PDAbr, double PDMay, double PDJun, double PDJul, double PDAgo, double PDSep, double PDOct, double PDNov, double PDDic,
            double PRSGISEne, double PRSGISFeb, double PRSGISMar, double PRSGISAbr, double PRSGISMay, double PRSGISJun, double PRSGISJul, double PRSGISAgo, double PRSGISSep, double PRSGISOct, double PRSGISNov, double PRSGISDic)
        {

            double avgRec = PREne + PRFeb + PRMar + PRAbr + PRMay + PRJun + PRJul + PRAgo + PRSep + PROct + PRNov + PRDic;
            double avdSGIS = PRSGISEne + PRSGISFeb + PRSGISMar + PRSGISAbr + PRSGISMay + PRSGISJun + PRSGISJul + PRSGISAgo + PRSGISSep + PRSGISOct + PRSGISNov + PRSGISDic;

            List<double> diario = new List<double>();
            List<double> potencia = new List<double>();

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

            potencia.Add(PDEne / 31);
            potencia.Add(PDFeb / 28);
            potencia.Add(PDMar / 31);
            potencia.Add(PDAbr / 30);
            potencia.Add(PDMay / 31);
            potencia.Add(PDJun / 30);
            potencia.Add(PDJul / 31);
            potencia.Add(PDAgo / 31);
            potencia.Add(PDSep / 30);
            potencia.Add(PDOct / 31);
            potencia.Add(PDNov / 30);
            potencia.Add(PDDic / 31);

            double avgPot = 0;
            foreach (var item in diario)
            {
                avgPot += item;
            }
            potencia.Add(avgPot / 12);

            //Pct Consumo de lunes a Viernes
            pctConsumoLV.Add(0.035);
            pctConsumoLV.Add(0.035);
            pctConsumoLV.Add(0.035);
            pctConsumoLV.Add(0.035);
            pctConsumoLV.Add(0.035);
            pctConsumoLV.Add(0.035);
            pctConsumoLV.Add(0.035);
            pctConsumoLV.Add(0.035);
            pctConsumoLV.Add(0.65);
            pctConsumoLV.Add(0.90);
            pctConsumoLV.Add(0.85);
            pctConsumoLV.Add(0.90);
            pctConsumoLV.Add(0.55);
            pctConsumoLV.Add(0.70);
            pctConsumoLV.Add(0.95);
            pctConsumoLV.Add(0.95);
            pctConsumoLV.Add(0.95);
            pctConsumoLV.Add(0.35);
            pctConsumoLV.Add(0.035);
            pctConsumoLV.Add(0.035);
            pctConsumoLV.Add(0.035);
            pctConsumoLV.Add(0.035);
            pctConsumoLV.Add(0.035);
            pctConsumoLV.Add(0.035);

            double sumpctConsumoLV = 0;
            foreach (var item in pctConsumoLV)
            {
                sumpctConsumoLV += item;
            }

            //Pct Consumo de sábados


            for (int i = 0; i < 24; i++)
            {
                pctConsumoS.Add(0.035);
                pctConsumoD.Add(0.035);
            }
            
            
            double sumpctConsumoS = 0;
            foreach (var item in pctConsumoS)
            {
                sumpctConsumoS += item;
            }

            //Pct Consumo de domingos
                       

            double sumpctConsumoD = 0;
            foreach (var item in pctConsumoD)
            {
                sumpctConsumoD += item;
            }

            //suma de porcentaje de consumo
            double sumTotal = (5 * sumpctConsumoLV + sumpctConsumoS + sumpctConsumoD) / 7;

            //Pico de demanda
            pico.Clear();

            pico.Add(PDEne);
            pico.Add(PDFeb);
            pico.Add(PDMar);
            pico.Add(PDAbr);
            pico.Add(PDMay);
            pico.Add(PDJun);
            pico.Add(PDJul);
            pico.Add(PDAgo);
            pico.Add(PDSep);
            pico.Add(PDOct);
            pico.Add(PDNov);
            pico.Add(PDDic);


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
                    ccLaV[i, j] = pico[j - 1] * pctConsumoLV[i];
                }

                ccLaV[i, 13] = (ccLaV[i, 1] + ccLaV[i, 2] + ccLaV[i, 3] + ccLaV[i, 4] + ccLaV[i, 5] + ccLaV[i, 6] + ccLaV[i, 7] + ccLaV[i, 8] + ccLaV[i, 8] + ccLaV[i, 10] + ccLaV[i, 11] + ccLaV[i, 12]) / 12;
            }

            //Comportamiento de sábados por mes
            for (int i = 0; i < 24; i++)
            {
                ccSab[i, 0] = i;

                for (int j = 1; j < 13; j++)
                {
                    ccSab[i, j] = pico[j - 1] * pctConsumoS[i];
                }

                ccSab[i, 13] = (ccSab[i, 1] + ccSab[i, 2] + ccSab[i, 3] + ccSab[i, 4] + ccSab[i, 5] + ccSab[i, 6] + ccSab[i, 7] + ccSab[i, 8] + ccSab[i, 8] + ccSab[i, 10] + ccSab[i, 11] + ccSab[i, 12]) / 12;
            }


            //Comportamiento de domingos por mes
            for (int i = 0; i < 24; i++)
            {
                ccDom[i, 0] = i;

                for (int j = 1; j < 13; j++)
                {
                    ccDom[i, j] = pico[j - 1] * pctConsumoD[i];
                }

                ccDom[i, 13] = (ccDom[i, 1] + ccDom[i, 2] + ccDom[i, 3] + ccDom[i, 4] + ccDom[i, 5] + ccDom[i, 6] + ccDom[i, 7] + ccDom[i, 8] + ccDom[i, 8] + ccDom[i, 10] + ccDom[i, 11] + ccDom[i, 12]) / 12;
            }


            List<double> avgEnergiaDiaria = new List<double>();
            avgEnergiaDiaria.Clear();



            for (int i = 1; i < 13; i++)
            {
                double sumLaV = 0;
                double sumSab = 0;
                double sumDom = 0;

                for (int j = 0; j < 24; j++)
                {
                    sumLaV += ccLaV[j, i];
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

            avgEnergiaDiaria.Add(sumador / 12);

            List<double> errorAsociado = new List<double>();
            List<double> factorCarga = new List<double>();

            errorAsociado.Clear();
            factorCarga.Clear();

            for (int i = 0; i < 12; i++)
            {
                if ((avgEnergiaDiaria[i] - diario[i]) / diario[i] > 0)
                {
                    errorAsociado.Add((avgEnergiaDiaria[i] - diario[i]) / diario[i]);
                }
                else
                {
                    errorAsociado.Add(0);
                }

                factorCarga.Add(avgEnergiaDiaria[i] / (pico[i] * 24));
            }


            double hora = 0;
            int dia = 0;
            int dSemana = -1;
            ccAnual[0, 0] = hora;


            //Calcula la Curva de carga Anual
            for (int i = 0; i < 35040; i = i + 4)
            {
                if (i < 2976) //Enero
                {

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
                else if (i < 5664) //Febrero
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
                else if (i < 8640) //Marzo
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

                ccDiaria[i, 3] = (ccMenusal[i, 3] + ccMenusal[i + 96, 3] + ccMenusal[i + 192, 3] + ccMenusal[i + 288, 3] + ccMenusal[i + 384, 3] + ccMenusal[i + 480, 3] + ccMenusal[i + 576, 3] + ccMenusal[i + 672, 3] + ccMenusal[i + 768, 3] + ccMenusal[i + 864, 3] + ccMenusal[i + 960, 3] + ccMenusal[i + 1056, 3] + ccMenusal[i + 1152, 3] + ccMenusal[i + 1248, 3] + ccMenusal[i + 1344, 3] + ccMenusal[i + 1440, 3] + ccMenusal[i + 1536, 3] + ccMenusal[i + 1632, 3] + ccMenusal[i + 1728, 3] + ccMenusal[i + 1824, 3] + ccMenusal[i + 1920, 3] + ccMenusal[i + 2016, 3] + ccMenusal[i + 2112, 3] + ccMenusal[i + 2208, 3] + ccMenusal[i + 2304, 3] + ccMenusal[i + 2400, 3] + ccMenusal[i + 2496, 3] + ccMenusal[i + 2592, 3] + ccMenusal[i + 2688, 3] + ccMenusal[i + 2784, 3] + ccMenusal[i + 2880, 3]) / 31;

                ccDiaria[i, 4] = ccDiaria[i, 3] * 0.25;
            }

            return true;
        }




    }

}
