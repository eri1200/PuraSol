using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace BLL
{
    public class clsPreliminares
    {
        public double Tamano=1;
        public double costoD;
        public double costoC;
        public double toneladasCO2;
        public double TIR;
        public double VAN;
        public double costoUD;
        public double costoUC;
        public double mantanual;
        public double costoMantValor;

        public void calculaTamano(double tamano)
        {
            Tamano=tamano;

        }

        public void calculaCostos(string tecnologia,double tipoCambio,string costoUnitatioFijo, string costoUnitatioFijoValor, List<List<double>> listaFinanciamientos, clsCalculosResi calculos)
        {
            
            
            //calcular el costo en dólares
            
            if (tecnologia=="Microinversor")
            {
                costoD = listaFinanciamientos[0][3];
            }
            else if (tecnologia == "Optimizadores")
            {
                costoD = listaFinanciamientos[1][3];
            }
            else if (tecnologia == "Centralizado")
            {
                costoD = listaFinanciamientos[2][3];
            }
            else if (tecnologia=="Acople DC")
            {
                costoD = listaFinanciamientos[3][3];
            }
            else if (tecnologia == "Acople AC")
            {
                costoD = listaFinanciamientos[4][3];
            }

            
            
            //calcular el costo en colones
            
            costoC = costoD * tipoCambio;

            double sumComodin = 0;


            for (int i = 0; i < 26; i++)
            {
                sumComodin = calculos.enerProducida[i, 13];
            }


            toneladasCO2 = sumComodin * 0.0824 / 1000;

        }

       
        public void calculaResto(double tipoCambio, string costoUnitatioFijo, string costoUnitatioFijoValor,string costoMantenimiento, clsCalculosResi calculos, clsCostosMant cMant)
        {
            double[] sumTotal = new double[11];
            double sumVAN = 0;

            for (int i = 0; i < 11; i++)
            {
                sumTotal[i] = calculos.calculos[i, 22] - calculos.calculos[i, 23];

                sumVAN = sumVAN + calculos.calculos[i, 31];
            }

            //TIR = Financial.IRR(ref sumTotal, 3500.00);



            VAN = (sumVAN - costoD) / tipoCambio;


            if (costoUnitatioFijo == "Sí")
            {
                costoUD = Convert.ToDouble(costoUnitatioFijoValor);
            }
            else
            {
                costoUD = costoD / (Tamano * 1000);
            }




            if (costoUnitatioFijo == "Sí")
            {
                costoUC = Convert.ToDouble(costoUnitatioFijoValor)*tipoCambio;
            }
            else
            {
                costoUC = costoC / (Tamano * 1000);
            }




            if (Tamano< cMant.Pot1)
            {
                costoMantValor = cMant.Precio1;
            }
            else if (Tamano < cMant.Pot2)
            {
                costoMantValor = cMant.Precio2;
            }
            else if (Tamano < cMant.Pot3)
            {
                costoMantValor = cMant.Precio3;
            }
            else if (Tamano < cMant.Pot4)
            {
                costoMantValor = cMant.Precio4;
            }
            else
            {
                costoMantValor = 0;
            }





            if (costoMantenimiento == "No")
            {
                mantanual = 0;
            }
            else if (costoMantenimiento == "GAM")
            {
                mantanual = costoMantValor;
            }
            else if (costoMantenimiento == "GAM+100km")
            {
                mantanual = costoMantValor*Tamano;
            }
            else
            {
                mantanual = 0;
            }

         

        }


        public void calculaCostosMTMT(double tamano, string tecnologia, double tipoCambio, string Microred, double Almacenamiento, string costoUnitatioFijo, string costoUnitatioFijoValor, List<List<double>> listaFinanciamientos, clsCalculosMTMT calculos, List<clsCostosUnitarios> costos)
        {


            //calcular el costo en dólares
            double comodin = 0;
            double montoAsegurado = 0;

            if (Microred == "Sí")
            {
                if (costoUnitatioFijo == "Sí")
                {
                    comodin = Convert.ToDouble(costoUnitatioFijoValor) * Almacenamiento;
                }
                else
                {
                    if (costoUnitatioFijo == "Sí")
                    {
                        comodin = Convert.ToDouble(costoUnitatioFijoValor);
                    }
                    else
                    {
                        if (Almacenamiento < 1000)
                        {
                            comodin = costos[1].Precio8;
                        }
                        else if (Almacenamiento < 1500)
                        {
                            comodin = costos[1].Precio9;
                        }
                        else
                        {
                            comodin = 0;
                        }
                    }
                }
            }
            else
            {
                comodin = 0;
            }

            if (tamano < costos[0].Pot1)
            {
                montoAsegurado = costos[0].Precio1;
            }
            else if (tamano < costos[0].Pot2)
            {
                montoAsegurado = costos[0].Precio2;
            }
            else if (tamano < costos[0].Pot3)
            {
                montoAsegurado = costos[0].Precio3;
            }
            else if (tamano < costos[0].Pot4)
            {
                montoAsegurado = costos[0].Precio4;
            }
            else if (tamano < costos[0].Pot5)
            {
                montoAsegurado = costos[0].Precio5;
            }
            else if (tamano < costos[0].Pot6)
            {
                montoAsegurado = costos[0].Precio6;
            }
            else
            {
                montoAsegurado = 0;
            }

            costoD = montoAsegurado + comodin;




            //calcular el costo en colones

            costoC = costoD * tipoCambio;

            double sumComodin = 0;


            for (int i = 0; i < 26; i++)
            {
                sumComodin = calculos.enerProducida[i, 13];
            }


            toneladasCO2 = sumComodin * 0.0824 / 1000;

        }


        public void calculaRestoMTMT(double tipoCambio, string costoUnitatioFijo, string costoUnitatioFijoValor, string costoMantenimiento, clsCalculosMTMT calculos, clsCostosMant cMant)
        {
            double[] sumTotal = new double[11];
            double sumVAN = 0;

            for (int i = 0; i < 11; i++)
            {
                sumTotal[i] = calculos.calculos[i, 22] - calculos.calculos[i, 23];

                sumVAN = sumVAN + calculos.calculos[i, 31];
            }

            //TIR = Financial.IRR(ref sumTotal, 3500.00);



            VAN = (sumVAN - costoD) / tipoCambio;


            if (costoUnitatioFijo == "Sí")
            {
                costoUD = Convert.ToDouble(costoUnitatioFijoValor);
            }
            else
            {
                costoUD = costoD / (Tamano * 1000);
            }




            if (costoUnitatioFijo == "Sí")
            {
                costoUC = Convert.ToDouble(costoUnitatioFijoValor) * tipoCambio;
            }
            else
            {
                costoUC = costoC / (Tamano * 1000);
            }




            if (Tamano < cMant.Pot1)
            {
                costoMantValor = cMant.Precio1;
            }
            else if (Tamano < cMant.Pot2)
            {
                costoMantValor = cMant.Precio2;
            }
            else if (Tamano < cMant.Pot3)
            {
                costoMantValor = cMant.Precio3;
            }
            else if (Tamano < cMant.Pot4)
            {
                costoMantValor = cMant.Precio4;
            }
            else
            {
                costoMantValor = 0;
            }





            if (costoMantenimiento == "No")
            {
                mantanual = 0;
            }
            else if (costoMantenimiento == "GAM")
            {
                mantanual = costoMantValor;
            }
            else if (costoMantenimiento == "GAM+100km")
            {
                mantanual = costoMantValor * Tamano;
            }
            else
            {
                mantanual = 0;
            }



        }


        public void calculaCostosTMT(double tamano, string tecnologia, double tipoCambio, string Microred, double Almacenamiento, string costoUnitatioFijo, string costoUnitatioFijoValor, List<List<double>> listaFinanciamientos, clsCalculosTMT calculos, List<clsCostosUnitarios> costos)
        {


            //calcular el costo en dólares
            double comodin = 0;
            double montoAsegurado = 0;

            if (costoUnitatioFijo == "Sí")
            {
                costoD = tamano * Convert.ToDouble(costoUnitatioFijoValor) * 1000;
            }
            else
            {
                if (tamano < costos[0].Pot1)
                {
                    montoAsegurado = costos[0].Precio1;
                }
                else if (tamano < costos[0].Pot2)
                {
                    montoAsegurado = costos[0].Precio2;
                }
                else if (tamano < costos[0].Pot3)
                {
                    montoAsegurado = costos[0].Precio3;
                }
                else if (tamano < costos[0].Pot4)
                {
                    montoAsegurado = costos[0].Precio4;
                }
                else if (tamano < costos[0].Pot5)
                {
                    montoAsegurado = costos[0].Precio5;
                }
                else if (tamano < costos[0].Pot6)
                {
                    montoAsegurado = costos[0].Precio6;
                }
                else
                {
                    montoAsegurado = 0;
                }

                costoD = montoAsegurado;
            }


            //calcular el costo en colones

            costoC = costoD * tipoCambio;

            double sumComodin = 0;


            for (int i = 0; i < 26; i++)
            {
                sumComodin = calculos.enerProducida[i, 13];
            }


            toneladasCO2 = sumComodin * 0.0824 / 1000;

        }


        public void calculaRestoTMT(double tipoCambio, string costoUnitatioFijo, string costoUnitatioFijoValor, string costoMantenimiento, clsCalculosTMT calculos, clsCostosMant cMant)
        {
            double[] sumTotal = new double[11];
            double sumVAN = 0;

            for (int i = 0; i < 11; i++)
            {
                sumTotal[i] = calculos.calculos[i, 22] - calculos.calculos[i, 23];

                sumVAN = sumVAN + calculos.calculos[i, 31];
            }

            //TIR = Financial.IRR(ref sumTotal, 3500.00);



            VAN = (sumVAN - costoD) / tipoCambio;


            if (costoUnitatioFijo == "Sí")
            {
                costoUD = Convert.ToDouble(costoUnitatioFijoValor);
            }
            else
            {
                costoUD = costoD / (Tamano * 1000);
            }




            if (costoUnitatioFijo == "Sí")
            {
                costoUC = Convert.ToDouble(costoUnitatioFijoValor) * tipoCambio;
            }
            else
            {
                costoUC = costoC / (Tamano * 1000);
            }




            if (Tamano < cMant.Pot1)
            {
                costoMantValor = cMant.Precio1;
            }
            else if (Tamano < cMant.Pot2)
            {
                costoMantValor = cMant.Precio2;
            }
            else if (Tamano < cMant.Pot3)
            {
                costoMantValor = cMant.Precio3;
            }
            else if (Tamano < cMant.Pot4)
            {
                costoMantValor = cMant.Precio4;
            }
            else
            {
                costoMantValor = 0;
            }





            if (costoMantenimiento == "No")
            {
                mantanual = 0;
            }
            else if (costoMantenimiento == "GAM")
            {
                mantanual = costoMantValor;
            }
            else if (costoMantenimiento == "GAM+100km")
            {
                mantanual = costoMantValor * Tamano;
            }
            else
            {
                mantanual = 0;
            }



        }

    }
}
