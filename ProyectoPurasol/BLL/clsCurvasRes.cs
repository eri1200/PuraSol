using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class clsCurvasRes
    {
        public double[,] cAnual = new double[35040, 8];
        public double[,] cMenusal = new double[2976, 8];
        public double[,] cDiaria = new double[96, 8];
        public double coberturaRealporProdAnual = 0;
        public double coberturaRealporConsumoAnual = 0;
        public double coberturaTAporProdAnual = 0;
        public double coberturaTAporConsumoAnual = 0;
        public double coberturaTeorica = 0;

        public double coberturaReal = 0;
        public double coberturaTA = 0;
        public double consumoTotAnualProm = 0;
        public double prodTotAnualProm = 0;
        public double error = 0;
        public double pctTA = 0;

        public double consumoDiurno = 0;
        public double consumoDiurnoPct = 0;
        public double consumoNocturno = 0;
        public double consumoNocturnoPct = 0;
        public double consumoTotAvg = 0;
        public double avgProdDiaria = 0;
        public double consumoTotDiarioProm = 0;

        //Cálculo de la potencia solar recomendada aka Tamaño
        public double potSolarRecomendada = 0;

        double horaInicial = 6.5;
        double horaFinal = 17.5;
        public double desviavcion = (17.5 - 6.5) / 6;
        public double media = 6.5+(17.5-6.5)/2;
        public double factorSeguridad = 0;
        public double potMaxposible;

        public void calcularCurvas(clsCConstruida construida, string tecnologia,string TamanoFijo,double TamanoFijoValor, double PotenciaPanel, double TechoDisponible, double RSGISEne, double RSGISFeb, double RSGISMar, double RSGISAbr, double RSGISMay,
             double RSGISJun, double RSGISJul, double RSGISAgo, double RSGISSep, double RSGISOct, double RSGISNov, double RSGISDic, double PromedioSGIS)
        {

            

            
            potMaxposible = TechoDisponible *(0.8/(1.05 * 2.11))*PotenciaPanel/1000;


            for (int i = 0; i < 35040; i++)
            {
                cAnual[i, 0] = construida.ccAnual[i, 0];
                cAnual[i, 1] = construida.ccAnual[i, 3];
                cAnual[i, 2] = construida.ccAnual[i, 4];
            }
            for (int i = 0; i < 2976; i++)
            {
                cMenusal[i, 0] = construida.ccMenusal[i, 0];
                cMenusal[i, 1] = construida.ccMenusal[i, 3];
                cMenusal[i, 2] = construida.ccMenusal[i, 4];
            }
            for (int i = 0; i < 96; i++)
            {
                cDiaria[i, 0] = construida.ccDiaria[i, 0];
                cDiaria[i, 1] = construida.ccDiaria[i, 3];
                cDiaria[i, 2] = construida.ccDiaria[i, 4];
            }

            consumoDiurno = 0;
            consumoDiurnoPct = 0;
            consumoNocturno = 0;
            consumoNocturnoPct = 0;
            consumoTotAvg = 0;

            for (int i = 0; i < 45; i++)
            {
                consumoDiurno += cDiaria[i + 26, 2];
            }

            for (int i = 0; i < 96; i++)
            {
                consumoTotAvg += cDiaria[i, 2];
            }

            consumoDiurnoPct = consumoDiurno / consumoTotAvg;

            consumoNocturno = consumoTotAvg - consumoDiurno;

            consumoNocturnoPct = consumoNocturno / consumoTotAvg;

            double comparador1 = Math.Ceiling(consumoDiurno / PromedioSGIS / (PotenciaPanel / 1000)) * (PotenciaPanel / 1000);
            double comparador2 = (6 * PotenciaPanel) / 1000;
            double comparador3 = (8 * PotenciaPanel) / 1000;
            double comparador4 = (10 * PotenciaPanel) / 1000;
            double comparador5;

            if (comparador1< potMaxposible)
            {
                comparador5 = comparador1;
            }
            else
            {
                comparador5 = potMaxposible;
            }

            if (TamanoFijo=="Sí")
            {
                potSolarRecomendada = TamanoFijoValor;
            }
            else if(comparador5<comparador2)
            {
                potSolarRecomendada = comparador2;  
            }
            else if (comparador5 < comparador3)
            {
                potSolarRecomendada = comparador3;
            }
            else if (comparador5 < comparador4)
            {
                potSolarRecomendada = comparador2;
            }
            else
            {
                potSolarRecomendada = comparador5;
            }




            if (tecnologia == "Microinversor")
            {
                factorSeguridad = 0.9;
            }
            else if (tecnologia == "Optimizadores")
            {
                factorSeguridad = 0.88;
            }
            else if (tecnologia == "Centralizado")
            {
                factorSeguridad = 0.85;
            }
            else if (tecnologia == "Acople DC")
            {
                factorSeguridad = 0.85;
            }
            else if (tecnologia == "Acople AC")
            {
                factorSeguridad = 0.9;
            }


            avgProdDiaria = factorSeguridad*potSolarRecomendada*PromedioSGIS;

            List<double> prodEspecificaDiaria = new List<double>();
            prodEspecificaDiaria.Add(RSGISEne * factorSeguridad * potSolarRecomendada);
            prodEspecificaDiaria.Add(RSGISFeb * factorSeguridad * potSolarRecomendada);
            prodEspecificaDiaria.Add(RSGISMar * factorSeguridad * potSolarRecomendada);
            prodEspecificaDiaria.Add(RSGISAbr * factorSeguridad * potSolarRecomendada);
            prodEspecificaDiaria.Add(RSGISMay * factorSeguridad * potSolarRecomendada);
            prodEspecificaDiaria.Add(RSGISJun * factorSeguridad * potSolarRecomendada);
            prodEspecificaDiaria.Add(RSGISJul * factorSeguridad * potSolarRecomendada);
            prodEspecificaDiaria.Add(RSGISAgo * factorSeguridad * potSolarRecomendada);
            prodEspecificaDiaria.Add(RSGISSep * factorSeguridad * potSolarRecomendada);
            prodEspecificaDiaria.Add(RSGISOct * factorSeguridad * potSolarRecomendada);
            prodEspecificaDiaria.Add(RSGISNov * factorSeguridad * potSolarRecomendada);
            prodEspecificaDiaria.Add(RSGISDic * factorSeguridad * potSolarRecomendada);

            for (int i = 0; i < 35040; i++)
            {
                if (i < 2976)
                {
                    if (cAnual[i, 0]<6.51)
                    {
                        cAnual[i, 3] = 0;
                    }
                    else
                    {
                        cAnual[i, 3] = prodEspecificaDiaria[0] / (Math.Sqrt(2*Math.PI)*desviavcion)*Math.Pow(Math.E,-1*(Math.Pow(cAnual[i, 0]-media,2))/(2* (Math.Pow(desviavcion,2))));
                    }

                    
                    if (cAnual[i, 1]>= cAnual[i, 3])
                    {
                        cAnual[i, 4] = cAnual[i, 3];
                    }
                    else
                    {
                        cAnual[i, 4] = cAnual[i, 1];
                    }


                    cAnual[i, 5] = cAnual[i, 4] * 0.25;


                    if (cAnual[i, 1] > cAnual[i, 3])
                    {
                        cAnual[i, 6] = 0;
                    }
                    else
                    {
                        cAnual[i, 6] = cAnual[i, 3] - cAnual[i, 1];
                    }

                    cAnual[i, 7] = cAnual[i, 6] * 0.25;


                }
                else if (i < 5664)
                {
                    if (cAnual[i, 0] < 6.51)
                    {
                        cAnual[i, 3] = 0;
                    }
                    else
                    {
                        cAnual[i, 3] = prodEspecificaDiaria[1] / (Math.Sqrt(2 * Math.PI) * desviavcion) * Math.Pow(Math.E, -1 * (Math.Pow(cAnual[i, 0] - media, 2)) / (2 * (Math.Pow(desviavcion, 2))));
                    }

                    if (cAnual[i, 1] >= cAnual[i, 3])
                    {
                        cAnual[i, 4] = cAnual[i, 3];
                    }
                    else
                    {
                        cAnual[i, 4] = cAnual[i, 1];
                    }


                    cAnual[i, 5] = cAnual[i, 4] * 0.25;


                    if (cAnual[i, 1] > cAnual[i, 3])
                    {
                        cAnual[i, 6] = 0;
                    }
                    else
                    {
                        cAnual[i, 6] = cAnual[i, 3] - cAnual[i, 1];
                    }

                    cAnual[i, 7] = cAnual[i, 6] * 0.25;
                }
                else if (i < 8640)
                {
                    if (cAnual[i, 0] < 6.51)
                    {
                        cAnual[i, 3] = 0;
                    }
                    else
                    {
                        cAnual[i, 3] = prodEspecificaDiaria[2] / (Math.Sqrt(2 * Math.PI) * desviavcion) * Math.Pow(Math.E, -1 * (Math.Pow(cAnual[i, 0] - media, 2)) / (2 * (Math.Pow(desviavcion, 2))));
                    }

                    if (cAnual[i, 1] >= cAnual[i, 3])
                    {
                        cAnual[i, 4] = cAnual[i, 3];
                    }
                    else
                    {
                        cAnual[i, 4] = cAnual[i, 1];
                    }


                    cAnual[i, 5] = cAnual[i, 4] * 0.25;


                    if (cAnual[i, 1] > cAnual[i, 3])
                    {
                        cAnual[i, 6] = 0;
                    }
                    else
                    {
                        cAnual[i, 6] = cAnual[i, 3] - cAnual[i, 1];
                    }

                    cAnual[i, 7] = cAnual[i, 6] * 0.25;
                }
                else if (i < 11520)
                {
                    if (cAnual[i, 0] < 6.51)
                    {
                        cAnual[i, 3] = 0;
                    }
                    else
                    {
                        cAnual[i, 3] = prodEspecificaDiaria[3] / (Math.Sqrt(2 * Math.PI) * desviavcion) * Math.Pow(Math.E, -1 * (Math.Pow(cAnual[i, 0] - media, 2)) / (2 * (Math.Pow(desviavcion, 2))));
                    }

                    if (cAnual[i, 1] >= cAnual[i, 3])
                    {
                        cAnual[i, 4] = cAnual[i, 3];
                    }
                    else
                    {
                        cAnual[i, 4] = cAnual[i, 1];
                    }


                    cAnual[i, 5] = cAnual[i, 4] * 0.25;


                    if (cAnual[i, 1] > cAnual[i, 3])
                    {
                        cAnual[i, 6] = 0;
                    }
                    else
                    {
                        cAnual[i, 6] = cAnual[i, 3] - cAnual[i, 1];
                    }

                    cAnual[i, 7] = cAnual[i, 6] * 0.25;
                }
                else if (i < 14496)
                {
                    if (cAnual[i, 0] < 6.51)
                    {
                        cAnual[i, 3] = 0;
                    }
                    else
                    {
                        cAnual[i, 3] = prodEspecificaDiaria[4] / (Math.Sqrt(2 * Math.PI) * desviavcion) * Math.Pow(Math.E, -1 * (Math.Pow(cAnual[i, 0] - media, 2)) / (2 * (Math.Pow(desviavcion, 2))));
                    }

                    if (cAnual[i, 1] >= cAnual[i, 3])
                    {
                        cAnual[i, 4] = cAnual[i, 3];
                    }
                    else
                    {
                        cAnual[i, 4] = cAnual[i, 1];
                    }


                    cAnual[i, 5] = cAnual[i, 4] * 0.25;


                    if (cAnual[i, 1] > cAnual[i, 3])
                    {
                        cAnual[i, 6] = 0;
                    }
                    else
                    {
                        cAnual[i, 6] = cAnual[i, 3] - cAnual[i, 1];
                    }

                    cAnual[i, 7] = cAnual[i, 6] * 0.25;
                }
                else if (i < 17376)
                {
                    if (cAnual[i, 0] < 6.51)
                    {
                        cAnual[i, 3] = 0;
                    }
                    else
                    {
                        cAnual[i, 3] = prodEspecificaDiaria[5] / (Math.Sqrt(2 * Math.PI) * desviavcion) * Math.Pow(Math.E, -1 * (Math.Pow(cAnual[i, 0] - media, 2)) / (2 * (Math.Pow(desviavcion, 2))));
                    }

                    if (cAnual[i, 1] >= cAnual[i, 3])
                    {
                        cAnual[i, 4] = cAnual[i, 3];
                    }
                    else
                    {
                        cAnual[i, 4] = cAnual[i, 1];
                    }


                    cAnual[i, 5] = cAnual[i, 4] * 0.25;


                    if (cAnual[i, 1] > cAnual[i, 3])
                    {
                        cAnual[i, 6] = 0;
                    }
                    else
                    {
                        cAnual[i, 6] = cAnual[i, 3] - cAnual[i, 1];
                    }

                    cAnual[i, 7] = cAnual[i, 6] * 0.25;
                }
                else if (i < 20352)
                {
                    if (cAnual[i, 0] < 6.51)
                    {
                        cAnual[i, 3] = 0;
                    }
                    else
                    {
                        cAnual[i, 3] = prodEspecificaDiaria[6] / (Math.Sqrt(2 * Math.PI) * desviavcion) * Math.Pow(Math.E, -1 * (Math.Pow(cAnual[i, 0] - media, 2)) / (2 * (Math.Pow(desviavcion, 2))));
                    }

                    if (cAnual[i, 1] >= cAnual[i, 3])
                    {
                        cAnual[i, 4] = cAnual[i, 3];
                    }
                    else
                    {
                        cAnual[i, 4] = cAnual[i, 1];
                    }


                    cAnual[i, 5] = cAnual[i, 4] * 0.25;


                    if (cAnual[i, 1] > cAnual[i, 3])
                    {
                        cAnual[i, 6] = 0;
                    }
                    else
                    {
                        cAnual[i, 6] = cAnual[i, 3] - cAnual[i, 1];
                    }

                    cAnual[i, 7] = cAnual[i, 6] * 0.25;
                }
                else if (i < 23328)
                {
                    if (cAnual[i, 0] < 6.51)
                    {
                        cAnual[i, 3] = 0;
                    }
                    else
                    {
                        cAnual[i, 3] = prodEspecificaDiaria[7] / (Math.Sqrt(2 * Math.PI) * desviavcion) * Math.Pow(Math.E, -1 * (Math.Pow(cAnual[i, 0] - media, 2)) / (2 * (Math.Pow(desviavcion, 2))));
                    }

                    if (cAnual[i, 1] >= cAnual[i, 3])
                    {
                        cAnual[i, 4] = cAnual[i, 3];
                    }
                    else
                    {
                        cAnual[i, 4] = cAnual[i, 1];
                    }


                    cAnual[i, 5] = cAnual[i, 4] * 0.25;


                    if (cAnual[i, 1] > cAnual[i, 3])
                    {
                        cAnual[i, 6] = 0;
                    }
                    else
                    {
                        cAnual[i, 6] = cAnual[i, 3] - cAnual[i, 1];
                    }

                    cAnual[i, 7] = cAnual[i, 6] * 0.25;
                }
                else if (i < 26208)
                {
                    if (cAnual[i, 0] < 6.51)
                    {
                        cAnual[i, 3] = 0;
                    }
                    else
                    {
                        cAnual[i, 3] = prodEspecificaDiaria[8] / (Math.Sqrt(2 * Math.PI) * desviavcion) * Math.Pow(Math.E, -1 * (Math.Pow(cAnual[i, 0] - media, 2)) / (2 * (Math.Pow(desviavcion, 2))));
                    }

                    if (cAnual[i, 1] >= cAnual[i, 3])
                    {
                        cAnual[i, 4] = cAnual[i, 3];
                    }
                    else
                    {
                        cAnual[i, 4] = cAnual[i, 1];
                    }


                    cAnual[i, 5] = cAnual[i, 4] * 0.25;


                    if (cAnual[i, 1] > cAnual[i, 3])
                    {
                        cAnual[i, 6] = 0;
                    }
                    else
                    {
                        cAnual[i, 6] = cAnual[i, 3] - cAnual[i, 1];
                    }

                    cAnual[i, 7] = cAnual[i, 6] * 0.25;
                }
                else if (i < 29184)
                {
                    if (cAnual[i, 0] < 6.51)
                    {
                        cAnual[i, 3] = 0;
                    }
                    else
                    {
                        cAnual[i, 3] = prodEspecificaDiaria[9] / (Math.Sqrt(2 * Math.PI) * desviavcion) * Math.Pow(Math.E, -1 * (Math.Pow(cAnual[i, 0] - media, 2)) / (2 * (Math.Pow(desviavcion, 2))));
                    }

                    if (cAnual[i, 1] >= cAnual[i, 3])
                    {
                        cAnual[i, 4] = cAnual[i, 3];
                    }
                    else
                    {
                        cAnual[i, 4] = cAnual[i, 1];
                    }


                    cAnual[i, 5] = cAnual[i, 4] * 0.25;


                    if (cAnual[i, 1] > cAnual[i, 3])
                    {
                        cAnual[i, 6] = 0;
                    }
                    else
                    {
                        cAnual[i, 6] = cAnual[i, 3] - cAnual[i, 1];
                    }

                    cAnual[i, 7] = cAnual[i, 6] * 0.25;
                }
                else if (i < 32064)
                {
                    if (cAnual[i, 0] < 6.51)
                    {
                        cAnual[i, 3] = 0;
                    }
                    else
                    {
                        cAnual[i, 3] = prodEspecificaDiaria[10] / (Math.Sqrt(2 * Math.PI) * desviavcion) * Math.Pow(Math.E, -1 * (Math.Pow(cAnual[i, 0] - media, 2)) / (2 * (Math.Pow(desviavcion, 2))));
                    }

                    if (cAnual[i, 1] >= cAnual[i, 3])
                    {
                        cAnual[i, 4] = cAnual[i, 3];
                    }
                    else
                    {
                        cAnual[i, 4] = cAnual[i, 1];
                    }


                    cAnual[i, 5] = cAnual[i, 4] * 0.25;


                    if (cAnual[i, 1] > cAnual[i, 3])
                    {
                        cAnual[i, 6] = 0;
                    }
                    else
                    {
                        cAnual[i, 6] = cAnual[i, 3] - cAnual[i, 1];
                    }

                    cAnual[i, 7] = cAnual[i, 6] * 0.25;
                }
                else
                {
                    if (cAnual[i, 0] < 6.51)
                    {
                        cAnual[i, 3] = 0;
                    }
                    else
                    {
                        cAnual[i, 3] = prodEspecificaDiaria[11] / (Math.Sqrt(2 * Math.PI) * desviavcion) * Math.Pow(Math.E, -1 * (Math.Pow(cAnual[i, 0] - media, 2)) / (2 * (Math.Pow(desviavcion, 2))));
                    }

                    if (cAnual[i, 1] >= cAnual[i, 3])
                    {
                        cAnual[i, 4] = cAnual[i, 3];
                    }
                    else
                    {
                        cAnual[i, 4] = cAnual[i, 1];
                    }


                    cAnual[i, 5] = cAnual[i, 4] * 0.25;


                    if (cAnual[i, 1] > cAnual[i, 3])
                    {
                        cAnual[i, 6] = 0;
                    }
                    else
                    {
                        cAnual[i, 6] = cAnual[i, 3] - cAnual[i, 1];
                    }

                    cAnual[i, 7] = cAnual[i, 6] * 0.25;
                }

            }


            
            for (int i = 0; i < 2976; i++)
            {
                cMenusal[i, 3] = (cAnual[i, 3] + cAnual[i + 2976, 3] + cAnual[i + 5664, 3] + cAnual[i + 8640, 3] + cAnual[i + 11520, 3] + cAnual[i + 14496, 3] + cAnual[i + 17376, 3] + cAnual[i + 20352, 3] + cAnual[i + 23328, 3] + cAnual[i + 26208, 3] + cAnual[i + 29184, 3] + cAnual[i + 32064, 3]) / 12;

                if (cMenusal[i, 1] >= cMenusal[i, 3])
                {
                    cMenusal[i, 4] = cMenusal[i, 3];
                }
                else
                {
                    cMenusal[i, 4] = cMenusal[i, 1];
                }


                cMenusal[i, 5] = cMenusal[i, 4] * 0.25;


                if (cMenusal[i, 1] > cMenusal[i, 3])
                {
                    cMenusal[i, 6] = 0;
                }
                else
                {
                    cMenusal[i, 6] = cMenusal[i, 3] - cMenusal[i, 1];
                }

                cMenusal[i, 7] = cMenusal[i, 6] * 0.25;
            }


            for (int i = 0; i < 96; i++)
            {


                cDiaria[i, 3] = (cMenusal[i, 3] + cMenusal[i + 96, 3] + cMenusal[i + 192, 3] + cMenusal[i + 288, 3] + cMenusal[i + 384, 3] + cMenusal[i + 480, 3] + cMenusal[i + 576, 3] + cMenusal[i + 672, 3] + cMenusal[i + 768, 3] + cMenusal[i + 864, 3] + cMenusal[i + 960, 3] + cMenusal[i + 1056, 3] +
                    cMenusal[i + 1152, 3] + cMenusal[i + 1248, 3] + cMenusal[i + 1344, 3] + cMenusal[i + 1440, 3] + cMenusal[i + 1536, 3] + cMenusal[i + 1632, 3] + cMenusal[i + 1728, 3] + cMenusal[i + 1824, 3] + cMenusal[i + 1920, 3] + cMenusal[i + 2016, 3] + cMenusal[i + 2112, 3] +
                    cMenusal[i + 2208, 3] + cMenusal[i + 2304, 3] + cMenusal[i + 2400, 3] + cMenusal[i + 2496, 3] + cMenusal[i + 2592, 3] + cMenusal[i + 2688, 3] + cMenusal[i + 2784, 3] + cMenusal[i + 2880, 3]) / 31;

                cDiaria[i, 4] = (cMenusal[i, 4] + cMenusal[i + 96, 4] + cMenusal[i + 192, 4] + cMenusal[i + 288, 4] + cMenusal[i + 384, 4] + cMenusal[i + 480, 4] + cMenusal[i + 576, 4] + cMenusal[i + 672, 4] + cMenusal[i + 768, 4] + cMenusal[i + 864, 4] + cMenusal[i + 960, 4] + cMenusal[i + 1056, 4] +
                    cMenusal[i + 1152, 4] + cMenusal[i + 1248, 4] + cMenusal[i + 1344, 4] + cMenusal[i + 1440, 4] + cMenusal[i + 1536, 4] + cMenusal[i + 1632, 4] + cMenusal[i + 1728, 4] + cMenusal[i + 1824, 4] + cMenusal[i + 1920, 4] + cMenusal[i + 2016, 4] + cMenusal[i + 2112, 4] +
                    cMenusal[i + 2208, 4] + cMenusal[i + 2304, 4] + cMenusal[i + 2400, 4] + cMenusal[i + 2496, 4] + cMenusal[i + 2592, 4] + cMenusal[i + 2688, 4] + cMenusal[i + 2784, 4] + cMenusal[i + 2880, 4]) / 31;

                cDiaria[i, 5] = (cMenusal[i, 5] + cMenusal[i + 96, 5] + cMenusal[i + 192, 5] + cMenusal[i + 288, 5] + cMenusal[i + 384, 5] + cMenusal[i + 480, 5] + cMenusal[i + 576, 5] + cMenusal[i + 672, 5] + cMenusal[i + 768, 5] + cMenusal[i + 864, 5] + cMenusal[i + 960, 5] + cMenusal[i + 1056, 5] +
                    cMenusal[i + 1152, 5] + cMenusal[i + 1248, 5] + cMenusal[i + 1344, 5] + cMenusal[i + 1440, 5] + cMenusal[i + 1536, 5] + cMenusal[i + 1632, 5] + cMenusal[i + 1728, 5] + cMenusal[i + 1824, 5] + cMenusal[i + 1920, 5] + cMenusal[i + 2016, 5] + cMenusal[i + 2112, 5] +
                    cMenusal[i + 2208, 5] + cMenusal[i + 2304, 5] + cMenusal[i + 2400, 5] + cMenusal[i + 2496, 5] + cMenusal[i + 2592, 5] + cMenusal[i + 2688, 5] + cMenusal[i + 2784, 5] + cMenusal[i + 2880, 5]) / 31;

                cDiaria[i, 6] = (cMenusal[i, 6] + cMenusal[i + 96, 6] + cMenusal[i + 192, 6] + cMenusal[i + 288, 6] + cMenusal[i + 384, 6] + cMenusal[i + 480, 6] + cMenusal[i + 576, 6] + cMenusal[i + 672, 6] + cMenusal[i + 768, 6] + cMenusal[i + 864, 6] + cMenusal[i + 960, 6] + cMenusal[i + 1056, 6] +
                    cMenusal[i + 1152, 6] + cMenusal[i + 1248, 6] + cMenusal[i + 1344, 6] + cMenusal[i + 1440, 6] + cMenusal[i + 1536, 6] + cMenusal[i + 1632, 6] + cMenusal[i + 1728, 6] + cMenusal[i + 1824, 6] + cMenusal[i + 1920, 6] + cMenusal[i + 2016, 6] + cMenusal[i + 2112, 6] +
                    cMenusal[i + 2208, 6] + cMenusal[i + 2304, 6] + cMenusal[i + 2400, 6] + cMenusal[i + 2496, 6] + cMenusal[i + 2592, 6] + cMenusal[i + 2688, 6] + cMenusal[i + 2784, 6] + cMenusal[i + 2880, 6]) / 31;

                cDiaria[i, 7] = (cMenusal[i, 7] + cMenusal[i + 96, 7] + cMenusal[i + 192, 7] + cMenusal[i + 288, 7] + cMenusal[i + 384, 7] + cMenusal[i + 480, 7] + cMenusal[i + 576, 7] + cMenusal[i + 672, 7] + cMenusal[i + 768, 7] + cMenusal[i + 864, 7] + cMenusal[i + 960, 7] + cMenusal[i + 1056, 7] +
                    cMenusal[i + 1152, 7] + cMenusal[i + 1248, 7] + cMenusal[i + 1344, 7] + cMenusal[i + 1440, 7] + cMenusal[i + 1536, 7] + cMenusal[i + 1632, 7] + cMenusal[i + 1728, 7] + cMenusal[i + 1824, 7] + cMenusal[i + 1920, 7] + cMenusal[i + 2016, 7] + cMenusal[i + 2112, 7] +
                    cMenusal[i + 2208, 7] + cMenusal[i + 2304, 7] + cMenusal[i + 2400, 7] + cMenusal[i + 2496, 7] + cMenusal[i + 2592, 7] + cMenusal[i + 2688, 7] + cMenusal[i + 2784, 7] + cMenusal[i + 2880, 7]) / 31;

            }


            for (int i = 0; i < 96; i++)
            {
                consumoTotDiarioProm += cDiaria[i, 2];
            }

            coberturaTeorica = avgProdDiaria/ consumoTotDiarioProm;

            coberturaReal = 0;
            coberturaTA = 0;
            consumoTotAnualProm = 0;
            prodTotAnualProm = 0;

            for (int i = 0; i < 35040; i++)
            {
                consumoTotAnualProm += cAnual[i, 2];
                prodTotAnualProm += cAnual[i, 3];
                coberturaReal +=cAnual[i,5];
                coberturaTA += cAnual[i, 7];
            }

            prodTotAnualProm = prodTotAnualProm * 0.25;

            pctTA = coberturaTA / prodTotAnualProm;

            coberturaRealporProdAnual = coberturaReal/ prodTotAnualProm;
            coberturaRealporConsumoAnual = coberturaReal/ consumoTotAnualProm;
            coberturaTAporProdAnual = coberturaTA / prodTotAnualProm;
            coberturaTAporConsumoAnual = coberturaTA / consumoTotAnualProm;

            error = 0;
            double dummy = 0;

            for (int i = 0; i < 96; i++)
            {
                dummy += cAnual[i, 3];
            }

            error = (avgProdDiaria - dummy * 0.25) / avgProdDiaria;
            int stop = 0;

        }
    }
}
