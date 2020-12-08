using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace BLL
{
    class clsFinanciamiento
    {
        public List<double> Microinversor = new List<double>();
        public List<double> Centralizado = new List<double>();
        public List<double> Optimizadores = new List<double>();
        public List<double> AcopleAC = new List<double>();
        public List<double> AcopleDC = new List<double>();

        public List<List<double>> financiamiento = new List<List<double>>();


        public List<List<double>> calcFinanciamiento(string costoUnitarioFijo,double costoUnitarioFijoValor,double avgRecibos, double horasRespaldo, double tamano, double tipoCambio ,clsCalculosResi calculo,List<clsCostosUnitarios> costos, clsCostosMant cMant)
        {


            Microinversor.Clear();
            Centralizado.Clear();
            Optimizadores.Clear();
            AcopleAC.Clear();
            financiamiento.Clear();
            AcopleDC.Clear();

            //Costos del Microinversor
            double montoCredito = 0;
            double primaPct = 0;
            double montoAsegurado = 0;
            double primaDinero = 0;
            double tasa = 0;
            double plazo = 120;
            double gracia = 0;
            double cuotas = 12;
            double comision = 0.01;
            double poliza = 0;
            double mantenimiento = 0;
            double cuotaMensual = 0;
            double cuotaPoliza = 0;
            double ahorroAnual = 0;
            double ahorroMensual = 0;
            double ahorroAnualMicro = 0;
            double montoAseguradoMicro = 0;
            double ahorroAnualCent = 0;
            double ahorroAnualOpt = 0;

            if (costoUnitarioFijo=="Sí")
            {
                montoAsegurado = tamano*costoUnitarioFijoValor*1000;
            }
            else
            {
                if (tamano<costos[0].Pot1)
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
            }

            montoAseguradoMicro = montoAsegurado;

            primaPct = 0.25;

            montoCredito = montoAsegurado * (1-primaPct);

            primaDinero = montoAsegurado - montoCredito;

            tasa = 0.145;

            poliza = (montoAsegurado * 0.0012064) * 1.13;



            if (tamano<cMant.Pot1)
            {
                mantenimiento = cMant.Precio1;
            }
            else if (tamano < cMant.Pot2)
            {
                mantenimiento = cMant.Precio2;
            }
            else if (tamano < cMant.Pot3)
            {
                mantenimiento = cMant.Precio3;
            }
            else if (tamano < cMant.Pot4)
            {
                mantenimiento = cMant.Precio4;
            }

            mantenimiento = mantenimiento / 12;

            for (int i = 0; i < 11; i++)
            {
                ahorroAnual += calculo.calculos[i,15];
            }

            ahorroAnual = (ahorroAnual / 11) / tipoCambio;
            ahorroAnualMicro = ahorroAnual;


            ahorroMensual = ahorroAnual / 12;

            double comodin1 = 0;

            if (cuotas >= plazo)
            {
                comodin1 = cuotas;
            }
            else
            {
                comodin1 = plazo;
            }

            cuotaMensual = - Financial.Pmt(tasa/12,comodin1-gracia,montoCredito);

            cuotaPoliza = poliza + mantenimiento + cuotaMensual;

            Microinversor.Add(montoCredito);
            Microinversor.Add(primaPct);
            Microinversor.Add(primaDinero);
            Microinversor.Add(montoAsegurado);
            Microinversor.Add(tasa);
            Microinversor.Add(plazo);
            Microinversor.Add(gracia);
            Microinversor.Add(cuotas);
            Microinversor.Add(comision);
            Microinversor.Add(poliza);
            Microinversor.Add(mantenimiento);
            Microinversor.Add(cuotaMensual);
            Microinversor.Add(cuotaPoliza);
            Microinversor.Add(ahorroAnual);
            Microinversor.Add(ahorroMensual);

            financiamiento.Add(Microinversor);


            //Costos del Optimizadores
            montoCredito = 0;
            primaPct = 0;
            montoAsegurado = 0;
            primaDinero = 0;
            tasa = 0;
            plazo = 120;
            gracia = 0;
            cuotas = 12;
            comision = 0.01;
            poliza = 0;
            mantenimiento = 0;
            cuotaMensual = 0;
            cuotaPoliza = 0;
            ahorroAnual = 0;
            ahorroMensual = 0;

            if (costoUnitarioFijo == "Sí")
            {
                montoAsegurado = tamano * costoUnitarioFijoValor * 1000;
            }
            else
            {
                if (tamano < costos[1].Pot1)
                {
                    montoAsegurado = costos[1].Precio1;
                }
                else if (tamano < costos[1].Pot2)
                {
                    montoAsegurado = costos[1].Precio2;
                }
                else if (tamano < costos[1].Pot3)
                {
                    montoAsegurado = costos[1].Precio3;
                }
                else if (tamano < costos[1].Pot4)
                {
                    montoAsegurado = costos[1].Precio4;
                }
                else if (tamano < costos[1].Pot5)
                {
                    montoAsegurado = costos[1].Precio5;
                }
                else if (tamano < costos[1].Pot6)
                {
                    montoAsegurado = costos[1].Precio6;
                }
                else
                {
                    montoAsegurado = 0;
                }
            }

            primaPct = 0.25;

            montoCredito = montoAsegurado * (1 - primaPct);

            primaDinero = montoAsegurado - montoCredito;

            tasa = 0.145;

            poliza = (montoAsegurado * 0.0012064) * 1.13;



            if (tamano < cMant.Pot1)
            {
                mantenimiento = cMant.Precio1;
            }
            else if (tamano < cMant.Pot2)
            {
                mantenimiento = cMant.Precio2;
            }
            else if (tamano < cMant.Pot3)
            {
                mantenimiento = cMant.Precio3;
            }
            else if (tamano < cMant.Pot4)
            {
                mantenimiento = cMant.Precio4;
            }

            mantenimiento = mantenimiento / 12;

            for (int i = 0; i < 11; i++)
            {
                ahorroAnual += calculo.calculos[i, 15];
            }

            ahorroAnual = ahorroAnualMicro*0.98;
            ahorroAnualOpt = ahorroAnual;

            ahorroMensual = ahorroAnual / 12;

            comodin1 = 0;

            if (cuotas >= plazo)
            {
                comodin1 = cuotas;
            }
            else
            {
                comodin1 = plazo;
            }

            cuotaMensual = -Financial.Pmt(tasa / 12, comodin1 - gracia, montoCredito);

            cuotaPoliza = poliza + mantenimiento + cuotaMensual;

            Optimizadores.Add(montoCredito);
            Optimizadores.Add(primaPct);
            Optimizadores.Add(primaDinero);
            Optimizadores.Add(montoAsegurado);
            Optimizadores.Add(tasa);
            Optimizadores.Add(plazo);
            Optimizadores.Add(gracia);
            Optimizadores.Add(cuotas);
            Optimizadores.Add(comision);
            Optimizadores.Add(poliza);
            Optimizadores.Add(mantenimiento);
            Optimizadores.Add(cuotaMensual);
            Optimizadores.Add(cuotaPoliza);
            Optimizadores.Add(ahorroAnual);
            Optimizadores.Add(ahorroMensual);

            financiamiento.Add(Optimizadores);

            
            
            //Costos del Centralizado
            montoCredito = 0;
            primaPct = 0;
            montoAsegurado = 0;
            primaDinero = 0;
            tasa = 0;
            plazo = 120;
            gracia = 0;
            cuotas = 12;
            comision = 0.01;
            poliza = 0;
            mantenimiento = 0;
            cuotaMensual = 0;
            cuotaPoliza = 0;
            ahorroAnual = 0;
            ahorroMensual = 0;

            if (costoUnitarioFijo == "Sí")
            {
                montoAsegurado = tamano * costoUnitarioFijoValor * 1000;
            }
            else
            {
                if (tamano < costos[2].Pot1)
                {
                    montoAsegurado = costos[2].Precio1;
                }
                else if (tamano < costos[2].Pot2)
                {
                    montoAsegurado = costos[2].Precio2;
                }
                else if (tamano < costos[2].Pot3)
                {
                    montoAsegurado = costos[2].Precio3;
                }
                else if (tamano < costos[2].Pot4)
                {
                    montoAsegurado = costos[2].Precio4;
                }
                else if (tamano < costos[2].Pot5)
                {
                    montoAsegurado = costos[2].Precio5;
                }
                else if (tamano < costos[2].Pot6)
                {
                    montoAsegurado = costos[2].Precio6;
                }
                else
                {
                    montoAsegurado = 0;
                }
            }

            primaPct = 0.25;

            montoCredito = montoAsegurado * (1 - primaPct);

            primaDinero = montoAsegurado - montoCredito;

            tasa = 0.145;

            poliza = (montoAsegurado * 0.0012064) * 1.13;



            if (tamano < cMant.Pot1)
            {
                mantenimiento = cMant.Precio1;
            }
            else if (tamano < cMant.Pot2)
            {
                mantenimiento = cMant.Precio2;
            }
            else if (tamano < cMant.Pot3)
            {
                mantenimiento = cMant.Precio3;
            }
            else if (tamano < cMant.Pot4)
            {
                mantenimiento = cMant.Precio4;
            }

            mantenimiento = mantenimiento / 12;

            for (int i = 0; i < 11; i++)
            {
                ahorroAnual += calculo.calculos[i, 15];
            }

            ahorroAnual = ahorroAnualMicro*(0.85/0.9);
            ahorroAnualCent = ahorroAnual;

            ahorroMensual = ahorroAnual / 12;

            comodin1 = 0;

            if (cuotas >= plazo)
            {
                comodin1 = cuotas;
            }
            else
            {
                comodin1 = plazo;
            }

            cuotaMensual = -Financial.Pmt(tasa / 12, comodin1 - gracia, montoCredito);

            cuotaPoliza = poliza + mantenimiento + cuotaMensual;

            Centralizado.Add(montoCredito);
            Centralizado.Add(primaPct);
            Centralizado.Add(primaDinero);
            Centralizado.Add(montoAsegurado);
            Centralizado.Add(tasa);
            Centralizado.Add(plazo);
            Centralizado.Add(gracia);
            Centralizado.Add(cuotas);
            Centralizado.Add(comision);
            Centralizado.Add(poliza);
            Centralizado.Add(mantenimiento);
            Centralizado.Add(cuotaMensual);
            Centralizado.Add(cuotaPoliza);
            Centralizado.Add(ahorroAnual);
            Centralizado.Add(ahorroMensual);


            financiamiento.Add(Centralizado);


            //Costos del Acople DC

            AcopleDC.Clear();
            montoCredito = 0;
            primaPct = 0;
            montoAsegurado = 0;
            primaDinero = 0;
            tasa = 0;
            plazo = 120;
            gracia = 0;
            cuotas = 12;
            comision = 0.01;
            poliza = 0;
            mantenimiento = 0;
            cuotaMensual = 0;
            cuotaPoliza = 0;
            ahorroAnual = 0;
            ahorroMensual = 0;

            if (costoUnitarioFijo == "Sí")
            {
                montoAsegurado = tamano * costoUnitarioFijoValor * 1000;
            }
            else
            {
                if (tamano < costos[3].PotI1)
                {
                    montoAsegurado = costos[3].Precio1;
                }
                else if (tamano < costos[3].PotI2)
                {
                    montoAsegurado = costos[3].Precio2;
                }
                else if (tamano < costos[3].PotI3)
                {
                    montoAsegurado = costos[3].Precio3;
                }
                else
                {
                    montoAsegurado = 0;
                }
            }

            primaPct = 0;

            montoCredito = montoAsegurado * (1 - primaPct);

            primaDinero = montoAsegurado - montoCredito;

            tasa = 0.145;

            poliza = (montoAsegurado * 0.0012064) * 1.13;



            if (tamano < cMant.Pot1)
            {
                mantenimiento = cMant.Precio1;
            }
            else if (tamano < cMant.Pot2)
            {
                mantenimiento = cMant.Precio2;
            }
            else if (tamano < cMant.Pot3)
            {
                mantenimiento = cMant.Precio3;
            }
            else if (tamano < cMant.Pot4)
            {
                mantenimiento = cMant.Precio4;
            }

            mantenimiento = mantenimiento / 12;

            for (int i = 0; i < 11; i++)
            {
                ahorroAnual += calculo.calculos[i, 15];
            }

            ahorroAnual = ahorroAnualCent;

            ahorroMensual = ahorroAnual / 12;

            comodin1 = 0;

            if (cuotas >= plazo)
            {
                comodin1 = cuotas;
            }
            else
            {
                comodin1 = plazo;
            }

            cuotaMensual = Microinversor[11];

            cuotaPoliza = poliza + mantenimiento + cuotaMensual;

            AcopleDC.Add(montoCredito);
            AcopleDC.Add(primaPct);
            AcopleDC.Add(primaDinero);
            AcopleDC.Add(montoAsegurado);
            AcopleDC.Add(tasa);
            AcopleDC.Add(plazo);
            AcopleDC.Add(gracia);
            AcopleDC.Add(cuotas);
            AcopleDC.Add(comision);
            AcopleDC.Add(poliza);
            AcopleDC.Add(mantenimiento);
            AcopleDC.Add(cuotaMensual);//hay que revisar pero no tiene dependencias
            AcopleDC.Add(cuotaPoliza);//hay que revisar pero no tiene dependencias
            AcopleDC.Add(ahorroAnual);
            AcopleDC.Add(ahorroMensual);


            financiamiento.Add(AcopleDC);


            //Costos del Acople AC
            clsDatos datos = new clsDatos();
            List<double> acopleAC = datos.selecAlmacenamiento(avgRecibos, horasRespaldo);
            montoCredito = 0;
            primaPct = 0;
            montoAsegurado = 0;
            primaDinero = 0;
            tasa = 0;
            plazo = 120;
            gracia = 0;
            cuotas = 12;
            comision = 0.01;
            poliza = 0;
            mantenimiento = 0;
            cuotaMensual = 0;
            cuotaPoliza = 0;
            ahorroAnual = 0;
            ahorroMensual = 0;

            montoAsegurado = montoAseguradoMicro + acopleAC[2] + acopleAC[4];

            primaPct = 0;

            montoCredito = montoAsegurado * (1 - primaPct);

            primaDinero = montoAsegurado - montoCredito;

            tasa = 0.145;

            poliza = (montoAsegurado * 0.0012064) * 1.13;



            if (tamano < cMant.Pot1)
            {
                mantenimiento = cMant.Precio1;
            }
            else if (tamano < cMant.Pot2)
            {
                mantenimiento = cMant.Precio2;
            }
            else if (tamano < cMant.Pot3)
            {
                mantenimiento = cMant.Precio3;
            }
            else if (tamano < cMant.Pot4)
            {
                mantenimiento = cMant.Precio4;
            }

            mantenimiento = mantenimiento / 12;

            for (int i = 0; i < 11; i++)
            {
                ahorroAnual += calculo.calculos[i, 15];
            }

            ahorroAnual = ahorroAnualMicro;

            ahorroMensual = ahorroAnual / 12;

            comodin1 = 0;

            if (cuotas >= plazo)
            {
                comodin1 = cuotas;
            }
            else
            {
                comodin1 = plazo;
            }

            cuotaMensual = Microinversor[11];

            cuotaPoliza = poliza + mantenimiento + cuotaMensual;

            AcopleAC.Add(montoCredito);
            AcopleAC.Add(primaPct);
            AcopleAC.Add(primaDinero);
            AcopleAC.Add(montoAsegurado);
            AcopleAC.Add(tasa);
            AcopleAC.Add(plazo);
            AcopleAC.Add(gracia);
            AcopleAC.Add(cuotas);
            AcopleAC.Add(comision);
            AcopleAC.Add(poliza);
            AcopleAC.Add(mantenimiento);
            AcopleAC.Add(cuotaMensual);//hay que revisar pero no tiene dependencias
            AcopleAC.Add(cuotaPoliza);//hay que revisar pero no tiene dependencias
            AcopleAC.Add(ahorroAnual);
            AcopleAC.Add(ahorroMensual);

            financiamiento.Add(AcopleAC);
            //financiamiento.Clear();
            return financiamiento;
        }

        public List<List<double>> calcFinanciamientoMTMT(string costoUnitarioFijo, double costoUnitarioFijoValor, double avgRecibos, double horasRespaldo, double tamano, double tipoCambio, clsCalculosMTMT calculo, List<clsCostosUnitarios> costos, clsCostosMant cMant)
        {


            Microinversor.Clear();
            Centralizado.Clear();
            Optimizadores.Clear();
            financiamiento.Clear();

            //Costos del Microinversor
            double montoCredito = 0;
            double primaPct = 0;
            double montoAsegurado = 0;
            double primaDinero = 0;
            double tasa = 0;
            double plazo = 120;
            double gracia = 0;
            double cuotas = 12;
            double comision = 0.01;
            double poliza = 0;
            double mantenimiento = 0;
            double cuotaMensual = 0;
            double cuotaPoliza = 0;
            double ahorroAnual = 0;
            double ahorroMensual = 0;
            double ahorroAnualMicro = 0;
            double montoAseguradoMicro = 0;
            double ahorroAnualCent = 0;
            double ahorroAnualOpt = 0;

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

            montoAseguradoMicro = montoAsegurado;

            primaPct = 0.25;

            montoCredito = montoAsegurado * (1 - primaPct);

            primaDinero = montoAsegurado - montoCredito;

            tasa = 0.145;

            poliza = (montoAsegurado * 0.0012064) * 1.13;



            if (tamano < cMant.Pot1)
            {
                mantenimiento = cMant.Precio1;
            }
            else if (tamano < cMant.Pot2)
            {
                mantenimiento = cMant.Precio2;
            }
            else if (tamano < cMant.Pot3)
            {
                mantenimiento = cMant.Precio3;
            }
            else if (tamano < cMant.Pot4)
            {
                mantenimiento = cMant.Precio4;
            }

            mantenimiento = mantenimiento / 12;

            for (int i = 1; i < 11; i++)
            {
                ahorroAnual += calculo.calculos[i, 15];
            }

            ahorroAnual = (ahorroAnual / 10) / tipoCambio;
            ahorroAnualMicro = ahorroAnual;


            ahorroMensual = ahorroAnual / 12;

            double comodin1 = 0;

            if (cuotas >= plazo)
            {
                comodin1 = cuotas;
            }
            else
            {
                comodin1 = plazo;
            }

            cuotaMensual = -Financial.Pmt(tasa / 12, comodin1 - gracia, montoCredito);

            cuotaPoliza = poliza + mantenimiento + cuotaMensual;

            Microinversor.Add(montoCredito);
            Microinversor.Add(primaPct);
            Microinversor.Add(primaDinero);
            Microinversor.Add(montoAsegurado);
            Microinversor.Add(tasa);
            Microinversor.Add(plazo);
            Microinversor.Add(gracia);
            Microinversor.Add(cuotas);
            Microinversor.Add(comision);
            Microinversor.Add(poliza);
            Microinversor.Add(mantenimiento);
            Microinversor.Add(cuotaMensual);
            Microinversor.Add(cuotaPoliza);
            Microinversor.Add(ahorroAnual);
            Microinversor.Add(ahorroMensual);

            financiamiento.Add(Microinversor);


            //Costos del Optimizadores
            montoCredito = 0;
            primaPct = 0;
            montoAsegurado = 0;
            primaDinero = 0;
            tasa = 0;
            plazo = 120;
            gracia = 0;
            cuotas = 12;
            comision = 0.01;
            poliza = 0;
            mantenimiento = 0;
            cuotaMensual = 0;
            cuotaPoliza = 0;
            ahorroAnual = 0;
            ahorroMensual = 0;

            if (tamano < costos[1].Pot1)
            {
                montoAsegurado = costos[1].Precio1;
            }
            else if (tamano < costos[1].Pot2)
            {
                montoAsegurado = costos[1].Precio2;
            }
            else if (tamano < costos[1].Pot3)
            {
                montoAsegurado = costos[1].Precio3;
            }
            else if (tamano < costos[1].Pot4)
            {
                montoAsegurado = costos[1].Precio4;
            }
            else if (tamano < costos[1].Pot5)
            {
                montoAsegurado = costos[1].Precio5;
            }
            else if (tamano < costos[1].Pot6)
            {
                montoAsegurado = costos[1].Precio6;
            }
            else
            {
                montoAsegurado = 0;
            }

            primaPct = 0.25;

            montoCredito = montoAsegurado * (1 - primaPct);

            primaDinero = montoAsegurado - montoCredito;

            tasa = 0.145;

            poliza = (montoAsegurado * 0.0012064) * 1.13;



            if (tamano < cMant.Pot1)
            {
                mantenimiento = cMant.Precio1;
            }
            else if (tamano < cMant.Pot2)
            {
                mantenimiento = cMant.Precio2;
            }
            else if (tamano < cMant.Pot3)
            {
                mantenimiento = cMant.Precio3;
            }
            else if (tamano < cMant.Pot4)
            {
                mantenimiento = cMant.Precio4;
            }

            mantenimiento = mantenimiento / 12;

            for (int i = 1; i < 11; i++)
            {
                ahorroAnual += calculo.calculos[i, 15];
            }

            ahorroAnual = ahorroAnualMicro * (0.88/0.9);
            ahorroAnualOpt = ahorroAnual;

            ahorroMensual = ahorroAnual / 12;

            comodin1 = 0;

            if (cuotas >= plazo)
            {
                comodin1 = cuotas;
            }
            else
            {
                comodin1 = plazo;
            }

            cuotaMensual = -Financial.Pmt(tasa / 12, comodin1 - gracia, montoCredito);

            cuotaPoliza = poliza + mantenimiento + cuotaMensual;

            Optimizadores.Add(montoCredito);
            Optimizadores.Add(primaPct);
            Optimizadores.Add(primaDinero);
            Optimizadores.Add(montoAsegurado);
            Optimizadores.Add(tasa);
            Optimizadores.Add(plazo);
            Optimizadores.Add(gracia);
            Optimizadores.Add(cuotas);
            Optimizadores.Add(comision);
            Optimizadores.Add(poliza);
            Optimizadores.Add(mantenimiento);
            Optimizadores.Add(cuotaMensual);
            Optimizadores.Add(cuotaPoliza);
            Optimizadores.Add(ahorroAnual);
            Optimizadores.Add(ahorroMensual);

            financiamiento.Add(Optimizadores);



            //Costos del Centralizado
            montoCredito = 0;
            primaPct = 0;
            montoAsegurado = 0;
            primaDinero = 0;
            tasa = 0;
            plazo = 120;
            gracia = 0;
            cuotas = 12;
            comision = 0.01;
            poliza = 0;
            mantenimiento = 0;
            cuotaMensual = 0;
            cuotaPoliza = 0;
            ahorroAnual = 0;
            ahorroMensual = 0;

            if (tamano < costos[2].Pot1)
            {
                montoAsegurado = costos[2].Precio1;
            }
            else if (tamano < costos[2].Pot2)
            {
                montoAsegurado = costos[2].Precio2;
            }
            else if (tamano < costos[2].Pot3)
            {
                montoAsegurado = costos[2].Precio3;
            }
            else if (tamano < costos[2].Pot4)
            {
                montoAsegurado = costos[2].Precio4;
            }
            else if (tamano < costos[2].Pot5)
            {
                montoAsegurado = costos[2].Precio5;
            }
            else if (tamano < costos[2].Pot6)
            {
                montoAsegurado = costos[2].Precio6;
            }
            else
            {
                montoAsegurado = 0;
            }

            primaPct = 0.25;

            montoCredito = montoAsegurado * (1 - primaPct);

            primaDinero = montoAsegurado - montoCredito;

            tasa = 0.145;

            poliza = (montoAsegurado * 0.0012064) * 1.13;



            if (tamano < cMant.Pot1)
            {
                mantenimiento = cMant.Precio1;
            }
            else if (tamano < cMant.Pot2)
            {
                mantenimiento = cMant.Precio2;
            }
            else if (tamano < cMant.Pot3)
            {
                mantenimiento = cMant.Precio3;
            }
            else if (tamano < cMant.Pot4)
            {
                mantenimiento = cMant.Precio4;
            }

            mantenimiento = mantenimiento / 12;

            for (int i = 0; i < 11; i++)
            {
                ahorroAnual += calculo.calculos[i, 15];
            }

            ahorroAnual = ahorroAnualMicro * (0.85 / 0.9);
            ahorroAnualCent = ahorroAnual;

            ahorroMensual = ahorroAnual / 12;

            comodin1 = 0;

            if (cuotas >= plazo)
            {
                comodin1 = cuotas;
            }
            else
            {
                comodin1 = plazo;
            }

            cuotaMensual = -Financial.Pmt(tasa / 12, comodin1 - gracia, montoCredito);

            cuotaPoliza = poliza + mantenimiento + cuotaMensual;

            Centralizado.Add(montoCredito);
            Centralizado.Add(primaPct);
            Centralizado.Add(primaDinero);
            Centralizado.Add(montoAsegurado);
            Centralizado.Add(tasa);
            Centralizado.Add(plazo);
            Centralizado.Add(gracia);
            Centralizado.Add(cuotas);
            Centralizado.Add(comision);
            Centralizado.Add(poliza);
            Centralizado.Add(mantenimiento);
            Centralizado.Add(cuotaMensual);
            Centralizado.Add(cuotaPoliza);
            Centralizado.Add(ahorroAnual);
            Centralizado.Add(ahorroMensual);


            financiamiento.Add(Centralizado);

            //financiamiento.Clear();
            return financiamiento;
        }

        public List<List<double>> calcFinanciamientoTMT(string costoUnitarioFijo, double costoUnitarioFijoValor, double avgRecibos, double horasRespaldo, double tamano, double tipoCambio, clsCalculosTMT calculo, List<clsCostosUnitarios> costos, clsCostosMant cMant)
        {


            Microinversor.Clear();
            Centralizado.Clear();
            Optimizadores.Clear();
            financiamiento.Clear();

            //Costos del Microinversor
            double montoCredito = 0;
            double primaPct = 0;
            double montoAsegurado = 0;
            double primaDinero = 0;
            double tasa = 0;
            double plazo = 120;
            double gracia = 0;
            double cuotas = 12;
            double comision = 0.01;
            double poliza = 0;
            double mantenimiento = 0;
            double cuotaMensual = 0;
            double cuotaPoliza = 0;
            double ahorroAnual = 0;
            double ahorroMensual = 0;
            double ahorroAnualMicro = 0;
            double montoAseguradoMicro = 0;
            double ahorroAnualCent = 0;
            double ahorroAnualOpt = 0;

            if (costoUnitarioFijo == "Sí")
            {
                montoAsegurado = tamano * Convert.ToDouble(costoUnitarioFijoValor) * 1000;
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
            }

            

            montoAseguradoMicro = montoAsegurado;

            primaPct = 0.25;

            montoCredito = montoAsegurado * (1 - primaPct);

            primaDinero = montoAsegurado - montoCredito;

            tasa = 0.145;

            poliza = (montoAsegurado * 0.0012064) * 1.13;



            if (tamano < cMant.Pot1)
            {
                mantenimiento = cMant.Precio1;
            }
            else if (tamano < cMant.Pot2)
            {
                mantenimiento = cMant.Precio2;
            }
            else if (tamano < cMant.Pot3)
            {
                mantenimiento = cMant.Precio3;
            }
            else if (tamano < cMant.Pot4)
            {
                mantenimiento = cMant.Precio4;
            }

            mantenimiento = mantenimiento / 12;

            for (int i = 1; i < 11; i++)
            {
                ahorroAnual += calculo.calculos[i, 15];
            }

            ahorroAnual = (ahorroAnual / 10) / tipoCambio;
            ahorroAnualMicro = ahorroAnual;


            ahorroMensual = ahorroAnual / 12;

            double comodin1 = 0;

            if (cuotas >= plazo)
            {
                comodin1 = cuotas;
            }
            else
            {
                comodin1 = plazo;
            }

            cuotaMensual = -Financial.Pmt(tasa / 12, comodin1 - gracia, montoCredito);

            cuotaPoliza = poliza + mantenimiento + cuotaMensual;

            Microinversor.Add(montoCredito);
            Microinversor.Add(primaPct);
            Microinversor.Add(primaDinero);
            Microinversor.Add(montoAsegurado);
            Microinversor.Add(tasa);
            Microinversor.Add(plazo);
            Microinversor.Add(gracia);
            Microinversor.Add(cuotas);
            Microinversor.Add(comision);
            Microinversor.Add(poliza);
            Microinversor.Add(mantenimiento);
            Microinversor.Add(cuotaMensual);
            Microinversor.Add(cuotaPoliza);
            Microinversor.Add(ahorroAnual);
            Microinversor.Add(ahorroMensual);

            financiamiento.Add(Microinversor);


            //Costos del Optimizadores
            montoCredito = 0;
            primaPct = 0;
            montoAsegurado = 0;
            primaDinero = 0;
            tasa = 0;
            plazo = 120;
            gracia = 0;
            cuotas = 12;
            comision = 0.01;
            poliza = 0;
            mantenimiento = 0;
            cuotaMensual = 0;
            cuotaPoliza = 0;
            ahorroAnual = 0;
            ahorroMensual = 0;

            if (costoUnitarioFijo == "Sí")
            {
                montoAsegurado = tamano * Convert.ToDouble(costoUnitarioFijoValor) * 1000;
            }
            else
            {
                if (tamano < costos[1].Pot1)
                {
                    montoAsegurado = costos[1].Precio1;
                }
                else if (tamano < costos[1].Pot2)
                {
                    montoAsegurado = costos[1].Precio2;
                }
                else if (tamano < costos[1].Pot3)
                {
                    montoAsegurado = costos[1].Precio3;
                }
                else if (tamano < costos[1].Pot4)
                {
                    montoAsegurado = costos[1].Precio4;
                }
                else if (tamano < costos[1].Pot5)
                {
                    montoAsegurado = costos[1].Precio5;
                }
                else if (tamano < costos[1].Pot6)
                {
                    montoAsegurado = costos[1].Precio6;
                }
                else
                {
                    montoAsegurado = 0;
                }
            }

            primaPct = 0.25;

            montoCredito = montoAsegurado * (1 - primaPct);

            primaDinero = montoAsegurado - montoCredito;

            tasa = 0.145;

            poliza = (montoAsegurado * 0.0012064) * 1.13;



            if (tamano < cMant.Pot1)
            {
                mantenimiento = cMant.Precio1;
            }
            else if (tamano < cMant.Pot2)
            {
                mantenimiento = cMant.Precio2;
            }
            else if (tamano < cMant.Pot3)
            {
                mantenimiento = cMant.Precio3;
            }
            else if (tamano < cMant.Pot4)
            {
                mantenimiento = cMant.Precio4;
            }

            mantenimiento = mantenimiento / 12;

            for (int i = 1; i < 11; i++)
            {
                ahorroAnual += calculo.calculos[i, 15];
            }

            ahorroAnual = ahorroAnualMicro * (0.88 / 0.9);
            ahorroAnualOpt = ahorroAnual;

            ahorroMensual = ahorroAnual / 12;

            comodin1 = 0;

            if (cuotas >= plazo)
            {
                comodin1 = cuotas;
            }
            else
            {
                comodin1 = plazo;
            }

            cuotaMensual = -Financial.Pmt(tasa / 12, comodin1 - gracia, montoCredito);

            cuotaPoliza = poliza + mantenimiento + cuotaMensual;

            Optimizadores.Add(montoCredito);
            Optimizadores.Add(primaPct);
            Optimizadores.Add(primaDinero);
            Optimizadores.Add(montoAsegurado);
            Optimizadores.Add(tasa);
            Optimizadores.Add(plazo);
            Optimizadores.Add(gracia);
            Optimizadores.Add(cuotas);
            Optimizadores.Add(comision);
            Optimizadores.Add(poliza);
            Optimizadores.Add(mantenimiento);
            Optimizadores.Add(cuotaMensual);
            Optimizadores.Add(cuotaPoliza);
            Optimizadores.Add(ahorroAnual);
            Optimizadores.Add(ahorroMensual);

            financiamiento.Add(Optimizadores);



            //Costos del Centralizado
            montoCredito = 0;
            primaPct = 0;
            montoAsegurado = 0;
            primaDinero = 0;
            tasa = 0;
            plazo = 120;
            gracia = 0;
            cuotas = 12;
            comision = 0.01;
            poliza = 0;
            mantenimiento = 0;
            cuotaMensual = 0;
            cuotaPoliza = 0;
            ahorroAnual = 0;
            ahorroMensual = 0;

            if (costoUnitarioFijo == "Sí")
            {
                montoAsegurado = tamano * Convert.ToDouble(costoUnitarioFijoValor) * 1000;
            }
            else
            {
                if (tamano < costos[2].Pot1)
                {
                    montoAsegurado = costos[2].Precio1;
                }
                else if (tamano < costos[2].Pot2)
                {
                    montoAsegurado = costos[2].Precio2;
                }
                else if (tamano < costos[2].Pot3)
                {
                    montoAsegurado = costos[2].Precio3;
                }
                else if (tamano < costos[2].Pot4)
                {
                    montoAsegurado = costos[2].Precio4;
                }
                else if (tamano < costos[2].Pot5)
                {
                    montoAsegurado = costos[2].Precio5;
                }
                else if (tamano < costos[2].Pot6)
                {
                    montoAsegurado = costos[2].Precio6;
                }
                else
                {
                    montoAsegurado = 0;
                }
            }

            primaPct = 0.25;

            montoCredito = montoAsegurado * (1 - primaPct);

            primaDinero = montoAsegurado - montoCredito;

            tasa = 0.145;

            poliza = (montoAsegurado * 0.0012064) * 1.13;



            if (tamano < cMant.Pot1)
            {
                mantenimiento = cMant.Precio1;
            }
            else if (tamano < cMant.Pot2)
            {
                mantenimiento = cMant.Precio2;
            }
            else if (tamano < cMant.Pot3)
            {
                mantenimiento = cMant.Precio3;
            }
            else if (tamano < cMant.Pot4)
            {
                mantenimiento = cMant.Precio4;
            }

            mantenimiento = mantenimiento / 12;

            for (int i = 0; i < 11; i++)
            {
                ahorroAnual += calculo.calculos[i, 15];
            }

            ahorroAnual = ahorroAnualMicro * (0.85 / 0.9);
            ahorroAnualCent = ahorroAnual;

            ahorroMensual = ahorroAnual / 12;

            comodin1 = 0;

            if (cuotas >= plazo)
            {
                comodin1 = cuotas;
            }
            else
            {
                comodin1 = plazo;
            }

            cuotaMensual = -Financial.Pmt(tasa / 12, comodin1 - gracia, montoCredito);

            cuotaPoliza = poliza + mantenimiento + cuotaMensual;

            Centralizado.Add(montoCredito);
            Centralizado.Add(primaPct);
            Centralizado.Add(primaDinero);
            Centralizado.Add(montoAsegurado);
            Centralizado.Add(tasa);
            Centralizado.Add(plazo);
            Centralizado.Add(gracia);
            Centralizado.Add(cuotas);
            Centralizado.Add(comision);
            Centralizado.Add(poliza);
            Centralizado.Add(mantenimiento);
            Centralizado.Add(cuotaMensual);
            Centralizado.Add(cuotaPoliza);
            Centralizado.Add(ahorroAnual);
            Centralizado.Add(ahorroMensual);


            financiamiento.Add(Centralizado);

            //financiamiento.Clear();
            return financiamiento;
        }

        public List<List<double>> calcFinanciamientoCom(string costoUnitarioFijo, double costoUnitarioFijoValor, double avgRecibos, double horasRespaldo, double tamano, double tipoCambio, clsCalculosCom calculo, List<clsCostosUnitarios> costos, clsCostosMant cMant)
        {


            Microinversor.Clear();
            Centralizado.Clear();
            Optimizadores.Clear();
            financiamiento.Clear();

            //Costos del Microinversor
            double montoCredito = 0;
            double primaPct = 0;
            double montoAsegurado = 0;
            double primaDinero = 0;
            double tasa = 0;
            double plazo = 120;
            double gracia = 0;
            double cuotas = 12;
            double comision = 0.01;
            double poliza = 0;
            double mantenimiento = 0;
            double cuotaMensual = 0;
            double cuotaPoliza = 0;
            double ahorroAnual = 0;
            double ahorroMensual = 0;
            double ahorroAnualMicro = 0;
            double montoAseguradoMicro = 0;
            double ahorroAnualCent = 0;
            double ahorroAnualOpt = 0;

            if (costoUnitarioFijo == "Sí")
            {
                montoAsegurado = tamano * Convert.ToDouble(costoUnitarioFijoValor) * 1000;
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
            }



            montoAseguradoMicro = montoAsegurado;

            primaPct = 0.25;

            montoCredito = montoAsegurado * (1 - primaPct);

            primaDinero = montoAsegurado - montoCredito;

            tasa = 0.145;

            poliza = (montoAsegurado * 0.0012064) * 1.13;



            if (tamano < cMant.Pot1)
            {
                mantenimiento = cMant.Precio1;
            }
            else if (tamano < cMant.Pot2)
            {
                mantenimiento = cMant.Precio2;
            }
            else if (tamano < cMant.Pot3)
            {
                mantenimiento = cMant.Precio3;
            }
            else if (tamano < cMant.Pot4)
            {
                mantenimiento = cMant.Precio4;
            }

            mantenimiento = mantenimiento / 12;

            for (int i = 1; i < 11; i++)
            {
                ahorroAnual += calculo.calculos[i, 15];
            }

            ahorroAnual = (ahorroAnual / 10) / tipoCambio;
            ahorroAnualMicro = ahorroAnual;


            ahorroMensual = ahorroAnual / 12;

            double comodin1 = 0;

            if (cuotas >= plazo)
            {
                comodin1 = cuotas;
            }
            else
            {
                comodin1 = plazo;
            }

            cuotaMensual = -Financial.Pmt(tasa / 12, comodin1 - gracia, montoCredito);

            cuotaPoliza = poliza + mantenimiento + cuotaMensual;

            Microinversor.Add(montoCredito);
            Microinversor.Add(primaPct);
            Microinversor.Add(primaDinero);
            Microinversor.Add(montoAsegurado);
            Microinversor.Add(tasa);
            Microinversor.Add(plazo);
            Microinversor.Add(gracia);
            Microinversor.Add(cuotas);
            Microinversor.Add(comision);
            Microinversor.Add(poliza);
            Microinversor.Add(mantenimiento);
            Microinversor.Add(cuotaMensual);
            Microinversor.Add(cuotaPoliza);
            Microinversor.Add(ahorroAnual);
            Microinversor.Add(ahorroMensual);

            financiamiento.Add(Microinversor);


            //Costos del Optimizadores
            montoCredito = 0;
            primaPct = 0;
            montoAsegurado = 0;
            primaDinero = 0;
            tasa = 0;
            plazo = 120;
            gracia = 0;
            cuotas = 12;
            comision = 0.01;
            poliza = 0;
            mantenimiento = 0;
            cuotaMensual = 0;
            cuotaPoliza = 0;
            ahorroAnual = 0;
            ahorroMensual = 0;

            if (costoUnitarioFijo == "Sí")
            {
                montoAsegurado = tamano * Convert.ToDouble(costoUnitarioFijoValor) * 1000;
            }
            else
            {
                if (tamano < costos[1].Pot1)
                {
                    montoAsegurado = costos[1].Precio1;
                }
                else if (tamano < costos[1].Pot2)
                {
                    montoAsegurado = costos[1].Precio2;
                }
                else if (tamano < costos[1].Pot3)
                {
                    montoAsegurado = costos[1].Precio3;
                }
                else if (tamano < costos[1].Pot4)
                {
                    montoAsegurado = costos[1].Precio4;
                }
                else if (tamano < costos[1].Pot5)
                {
                    montoAsegurado = costos[1].Precio5;
                }
                else if (tamano < costos[1].Pot6)
                {
                    montoAsegurado = costos[1].Precio6;
                }
                else
                {
                    montoAsegurado = 0;
                }
            }

            primaPct = 0.25;

            montoCredito = montoAsegurado * (1 - primaPct);

            primaDinero = montoAsegurado - montoCredito;

            tasa = 0.145;

            poliza = (montoAsegurado * 0.0012064) * 1.13;



            if (tamano < cMant.Pot1)
            {
                mantenimiento = cMant.Precio1;
            }
            else if (tamano < cMant.Pot2)
            {
                mantenimiento = cMant.Precio2;
            }
            else if (tamano < cMant.Pot3)
            {
                mantenimiento = cMant.Precio3;
            }
            else if (tamano < cMant.Pot4)
            {
                mantenimiento = cMant.Precio4;
            }

            mantenimiento = mantenimiento / 12;

            for (int i = 1; i < 11; i++)
            {
                ahorroAnual += calculo.calculos[i, 15];
            }

            ahorroAnual = ahorroAnualMicro * (0.88 / 0.9);
            ahorroAnualOpt = ahorroAnual;

            ahorroMensual = ahorroAnual / 12;

            comodin1 = 0;

            if (cuotas >= plazo)
            {
                comodin1 = cuotas;
            }
            else
            {
                comodin1 = plazo;
            }

            cuotaMensual = -Financial.Pmt(tasa / 12, comodin1 - gracia, montoCredito);

            cuotaPoliza = poliza + mantenimiento + cuotaMensual;

            Optimizadores.Add(montoCredito);
            Optimizadores.Add(primaPct);
            Optimizadores.Add(primaDinero);
            Optimizadores.Add(montoAsegurado);
            Optimizadores.Add(tasa);
            Optimizadores.Add(plazo);
            Optimizadores.Add(gracia);
            Optimizadores.Add(cuotas);
            Optimizadores.Add(comision);
            Optimizadores.Add(poliza);
            Optimizadores.Add(mantenimiento);
            Optimizadores.Add(cuotaMensual);
            Optimizadores.Add(cuotaPoliza);
            Optimizadores.Add(ahorroAnual);
            Optimizadores.Add(ahorroMensual);

            financiamiento.Add(Optimizadores);



            //Costos del Centralizado
            montoCredito = 0;
            primaPct = 0;
            montoAsegurado = 0;
            primaDinero = 0;
            tasa = 0;
            plazo = 120;
            gracia = 0;
            cuotas = 12;
            comision = 0.01;
            poliza = 0;
            mantenimiento = 0;
            cuotaMensual = 0;
            cuotaPoliza = 0;
            ahorroAnual = 0;
            ahorroMensual = 0;

            if (costoUnitarioFijo == "Sí")
            {
                montoAsegurado = tamano * Convert.ToDouble(costoUnitarioFijoValor) * 1000;
            }
            else
            {
                if (tamano < costos[2].Pot1)
                {
                    montoAsegurado = costos[2].Precio1;
                }
                else if (tamano < costos[2].Pot2)
                {
                    montoAsegurado = costos[2].Precio2;
                }
                else if (tamano < costos[2].Pot3)
                {
                    montoAsegurado = costos[2].Precio3;
                }
                else if (tamano < costos[2].Pot4)
                {
                    montoAsegurado = costos[2].Precio4;
                }
                else if (tamano < costos[2].Pot5)
                {
                    montoAsegurado = costos[2].Precio5;
                }
                else if (tamano < costos[2].Pot6)
                {
                    montoAsegurado = costos[2].Precio6;
                }
                else
                {
                    montoAsegurado = 0;
                }
            }

            primaPct = 0.25;

            montoCredito = montoAsegurado * (1 - primaPct);

            primaDinero = montoAsegurado - montoCredito;

            tasa = 0.145;

            poliza = (montoAsegurado * 0.0012064) * 1.13;



            if (tamano < cMant.Pot1)
            {
                mantenimiento = cMant.Precio1;
            }
            else if (tamano < cMant.Pot2)
            {
                mantenimiento = cMant.Precio2;
            }
            else if (tamano < cMant.Pot3)
            {
                mantenimiento = cMant.Precio3;
            }
            else if (tamano < cMant.Pot4)
            {
                mantenimiento = cMant.Precio4;
            }

            mantenimiento = mantenimiento / 12;

            for (int i = 0; i < 11; i++)
            {
                ahorroAnual += calculo.calculos[i, 15];
            }

            ahorroAnual = ahorroAnualMicro * (0.85 / 0.9);
            ahorroAnualCent = ahorroAnual;

            ahorroMensual = ahorroAnual / 12;

            comodin1 = 0;

            if (cuotas >= plazo)
            {
                comodin1 = cuotas;
            }
            else
            {
                comodin1 = plazo;
            }

            cuotaMensual = -Financial.Pmt(tasa / 12, comodin1 - gracia, montoCredito);

            cuotaPoliza = poliza + mantenimiento + cuotaMensual;

            Centralizado.Add(montoCredito);
            Centralizado.Add(primaPct);
            Centralizado.Add(primaDinero);
            Centralizado.Add(montoAsegurado);
            Centralizado.Add(tasa);
            Centralizado.Add(plazo);
            Centralizado.Add(gracia);
            Centralizado.Add(cuotas);
            Centralizado.Add(comision);
            Centralizado.Add(poliza);
            Centralizado.Add(mantenimiento);
            Centralizado.Add(cuotaMensual);
            Centralizado.Add(cuotaPoliza);
            Centralizado.Add(ahorroAnual);
            Centralizado.Add(ahorroMensual);


            financiamiento.Add(Centralizado);

            //financiamiento.Clear();
            return financiamiento;
        }

    }
}
