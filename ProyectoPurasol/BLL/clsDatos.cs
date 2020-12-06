using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;


namespace BLL
{
    public class clsDatos
    {
        

        //Datos fijos misc
        public double TasaCredCliente = 0.145;
        public double TasaCredPurasol = 0.095;
        public double impVentas = 0.13;
        public double incrementoTarifa = 0.05;
        public double TasaDesc = 0.08;
        public double TasaCO2 = 0.0824;
        public double areaPanel = 1.05 * 2.11;

        //Datos fijos Mantenimientos
        public double ViaticosPersona = 11300;
        public double HospedajePersona = 12000;
        public double Combustible = 30000;
        public double HorasTecnico = 25000;
        public double VisitaTecnica = 350; //Es en dólares americanos

        //Datos fijos degradación
        public double degradacionPInicial0 = 0.975;
        public double degradacionPMedia10 = 0.9;
        public double degradacionPFinal25 = 0.8;

        //Datos fijos horarios
        public double PuntaBloque1Inicio = 10;
        public double PuntaBloque1Final = 12.5;
        public double PuntaBloque2Inicio = 17.5;
        public double PuntaBloque2Final = 20;


        public double ValleBloque1Inicio = 6;
        public double ValleBloque1Final = 10;
        public double ValleBloque2Inicio = 12.5;
        public double ValleBloque2Final = 17.5;

        public double NocheBloque1Inicio = 20;
        public double NocheBloque1Final = 6;
        public double NocheBloque2Inicio = 0;

        public double diaLV = 5/7;
        public double diaS = 1/7;
        public double diaD = 1/7;

        public double diaNocheLV = (5/7)/2;
        public double diaNocheS = (1/7)/2;
        public double diaNocheD = (1/7)/2;

        public double NocheLV =0;
        public double NocheS =0;
        public double NocheD =0;

        //Datos fijos baterías
        public double degradacionBInicial0 = 0.975;
        public double degradacionFinal15 = 0.8;

        //Datos fijos baterías
        public double HB51CapDescarga = 0.8;
        public double HB51CapPV = 5.5;
        public string HB51Acople = "AC";
        public int HB51StrBaterias = 5;
        public int HB51Precio = 4125;

        public double H5001CapDescarga = 0.8;
        public double H5001CapPV = 6.5;
        public string H5001Acople = "DC";
        public int H5001StrBaterias = 3;
        public int H5001Precio = 4200;

        public double DarfonB7LFCap1 = 7*1*0.8;
        public double DarfonB7LFCap2 = 7 * 2 * 0.8;
        public double DarfonB7LFCap3 = 7 * 3 * 0.8;
        public double DarfonB7LFPrecio1 = 7896;
        public double DarfonB7LFPrecio2 = 2 * 7896;
        public double DarfonB7LFPrecio3 = 3 * 7896;

        public double DarfonB10LFCap1 = 9.7 * 1 * 0.8;
        public double DarfonB10LFCap3 = 9.7 * 3 * 0.8;
        public double DarfonB10LFPrecio1 = 12735;
        public double DarfonB10LFPrecio3 = 3 * 12735;


        public List<clsPaquetes> calculaPaquete(double PotenciaPanel)
        {


            List<clsPaquetes> Paquetes = new List<clsPaquetes>();

            for (int i = 0; i < 4; i++)
            {
                clsPaquetes paquetito = new clsPaquetes();
                switch (i)
                {
                    case 0:
                        paquetito.NumeroPaneles = 6;
                        paquetito.Precio = 6260;
                        break;
                    case 1:
                        paquetito.NumeroPaneles = 8;
                        paquetito.Precio = 8323;
                        break;
                    case 2:
                        paquetito.NumeroPaneles = 10;
                        paquetito.Precio = 10395;
                        break;
                    case 3:
                        paquetito.NumeroPaneles = 5/0.395;
                        paquetito.Precio = 5*2350;
                        break;
                }
                paquetito.Potencia=(paquetito.NumeroPaneles * PotenciaPanel) / 1000;
                paquetito.Extra1 = paquetito.Precio - 125 * 1.13 * paquetito.NumeroPaneles + 5000 * 1.13;
                paquetito.Extra2 = paquetito.Extra1 / paquetito.Precio;
                Paquetes.Add(paquetito);

            }
            return Paquetes;
        }

        public List<clsCostosUnitarios> calculaCostosUnitarios(double PotPanel, double AvgRecibo, double horasRespaldo, string TipoTarifa, double AlmacenamientoFijo, string microred,clsPreliminares dPrelim)
        {

            List<clsCostosUnitarios> CostosUnitarios = new List<clsCostosUnitarios>();

            List<clsPaquetes> Paquetes = calculaPaquete(PotPanel);
            clsCostosUnitarios Microinversor = new clsCostosUnitarios();
            Microinversor.nombre = "Microinversores";
            if (TipoTarifa=="T-RE")
            {
                Microinversor.CostoUnitarioMax1 = 2.8;
                Microinversor.CostoUnitarioMax2 = Paquetes[0].Precio / (1000 * Paquetes[0].Potencia);
                Microinversor.CostoUnitarioMax3 = Paquetes[1].Precio / (1000 * Paquetes[1].Potencia);
                Microinversor.CostoUnitarioMax4 = 2.6;
                Microinversor.CostoUnitarioMax5 = 2.35;
                Microinversor.CostoUnitarioMax6 = 2.1;
                Microinversor.CostoUnitarioMax7 = 1.65;
            }
            else
            {
                Microinversor.CostoUnitarioMax1 = 2.8;
                Microinversor.CostoUnitarioMax2 = 2.35;
                Microinversor.CostoUnitarioMax3 = 2.1;
                Microinversor.CostoUnitarioMax4 = 1.65;
                Microinversor.CostoUnitarioMax5 = 1.2;
                Microinversor.CostoUnitarioMax6 = 1.15;
                Microinversor.CostoUnitarioMax7 = 1.05;
            }
            Microinversor.minmaxPot(TipoTarifa);
            Microinversor.CostoUnitario1 = ((Microinversor.CostoUnitarioMax2 - Microinversor.CostoUnitarioMax1) / (Microinversor.Pot1 - Microinversor.Pot0)) * dPrelim.Tamano + (Microinversor.CostoUnitarioMax1-  (Microinversor.CostoUnitarioMax2 - Microinversor.CostoUnitarioMax1) / (Microinversor.Pot1 - Microinversor.Pot0) * Microinversor.Pot0);
            Microinversor.CostoUnitario2 = ((Microinversor.CostoUnitarioMax3 - Microinversor.CostoUnitarioMax2) / (Microinversor.Pot2 - Microinversor.Pot1)) * dPrelim.Tamano + (Microinversor.CostoUnitarioMax2 - (Microinversor.CostoUnitarioMax3 - Microinversor.CostoUnitarioMax2) / (Microinversor.Pot2 - Microinversor.Pot1) * Microinversor.Pot1);
            Microinversor.CostoUnitario3 = ((Microinversor.CostoUnitarioMax4 - Microinversor.CostoUnitarioMax3) / (Microinversor.Pot3 - Microinversor.Pot2)) * dPrelim.Tamano + (Microinversor.CostoUnitarioMax3 - (Microinversor.CostoUnitarioMax4 - Microinversor.CostoUnitarioMax3) / (Microinversor.Pot3 - Microinversor.Pot2) * Microinversor.Pot2);
            Microinversor.CostoUnitario4 = ((Microinversor.CostoUnitarioMax5 - Microinversor.CostoUnitarioMax4) / (Microinversor.Pot4 - Microinversor.Pot3)) * dPrelim.Tamano + (Microinversor.CostoUnitarioMax4 - (Microinversor.CostoUnitarioMax5 - Microinversor.CostoUnitarioMax4) / (Microinversor.Pot4 - Microinversor.Pot3) * Microinversor.Pot3);
            Microinversor.CostoUnitario5 = ((Microinversor.CostoUnitarioMax6 - Microinversor.CostoUnitarioMax5) / (Microinversor.Pot5 - Microinversor.Pot4)) * dPrelim.Tamano + (Microinversor.CostoUnitarioMax5 - (Microinversor.CostoUnitarioMax6 - Microinversor.CostoUnitarioMax5) / (Microinversor.Pot5 - Microinversor.Pot4) * Microinversor.Pot4);
            Microinversor.CostoUnitario6 = ((Microinversor.CostoUnitarioMax7 - Microinversor.CostoUnitarioMax6) / (Microinversor.Pot6 - Microinversor.Pot5)) * dPrelim.Tamano + (Microinversor.CostoUnitarioMax6 - (Microinversor.CostoUnitarioMax7 - Microinversor.CostoUnitarioMax6) / (Microinversor.Pot6 - Microinversor.Pot5) * Microinversor.Pot5);
            Microinversor.CostoUnitario7 = 0;
            Microinversor.Precio1 = Microinversor.CostoUnitario1 * 1000 * dPrelim.Tamano;
            Microinversor.Precio2 = Microinversor.CostoUnitario2 * 1000 * dPrelim.Tamano;
            Microinversor.Precio3 = Microinversor.CostoUnitario3 * 1000 * dPrelim.Tamano;
            Microinversor.Precio4 = Microinversor.CostoUnitario4 * 1000 * dPrelim.Tamano;
            Microinversor.Precio5 = Microinversor.CostoUnitario5 * 1000 * dPrelim.Tamano;
            Microinversor.Precio6 = Microinversor.CostoUnitario6 * 1000 * dPrelim.Tamano;
            Microinversor.Precio7 = 0;

            CostosUnitarios.Add(Microinversor);

            double FactorCosto = 0;


            for (int i = 0; i < 2; i++)
            {
                clsCostosUnitarios Costo = new clsCostosUnitarios();
                switch (i)
                {
                    case 0:
                        Costo.nombre = "Optimizadores";
                        FactorCosto = 0.96;
                        if (microred == "Sí")
                        {

                            Costo.CostoUnitario8 = ((Costo.CostoUnitarioMax9 - Costo.CostoUnitarioMax8) / (Costo.Pot7 - Costo.Pot0)) * AlmacenamientoFijo + (Costo.CostoUnitarioMax8 - (Costo.CostoUnitarioMax9 - Costo.CostoUnitarioMax8) / (Costo.Pot7 - Costo.Pot0) * Costo.Pot0);
                            Costo.CostoUnitario9 = ((Costo.CostoUnitarioMax10 - Costo.CostoUnitarioMax9) / (Costo.Pot8 - Costo.Pot7)) * AlmacenamientoFijo + (Costo.CostoUnitarioMax9 - (Costo.CostoUnitarioMax10 - Costo.CostoUnitarioMax9) / (Costo.Pot8 - Costo.Pot7) * Costo.Pot7);
                            Costo.Precio8 = Costo.CostoUnitario8 * AlmacenamientoFijo;
                            Costo.Precio9 = Costo.CostoUnitario6 * AlmacenamientoFijo;
                        }
                            Costo.minmaxPot(TipoTarifa);
                            Costo.CostoUnitarioMax1 = Microinversor.CostoUnitarioMax1 * FactorCosto;
                            Costo.CostoUnitarioMax2 = Microinversor.CostoUnitarioMax2 * FactorCosto;
                            Costo.CostoUnitarioMax3 = Microinversor.CostoUnitarioMax3 * FactorCosto;
                            Costo.CostoUnitarioMax4 = Microinversor.CostoUnitarioMax4 * FactorCosto;
                            Costo.CostoUnitarioMax5 = Microinversor.CostoUnitarioMax5 * FactorCosto;
                            Costo.CostoUnitarioMax6 = Microinversor.CostoUnitarioMax6 * FactorCosto;
                            Costo.CostoUnitarioMax7 = Microinversor.CostoUnitarioMax7 * FactorCosto;
                            Costo.CostoUnitario1 = ((Costo.CostoUnitarioMax2 - Costo.CostoUnitarioMax1) / (Costo.Pot1 - Costo.Pot0)) * dPrelim.Tamano + (Costo.CostoUnitarioMax1 - (Costo.CostoUnitarioMax2 - Costo.CostoUnitarioMax1) / (Costo.Pot1 - Costo.Pot0) * Costo.Pot0);
                            Costo.CostoUnitario2 = ((Costo.CostoUnitarioMax3 - Costo.CostoUnitarioMax2) / (Costo.Pot2 - Costo.Pot1)) * dPrelim.Tamano + (Costo.CostoUnitarioMax2 - (Costo.CostoUnitarioMax3 - Costo.CostoUnitarioMax2) / (Costo.Pot2 - Costo.Pot1) * Costo.Pot1);
                            Costo.CostoUnitario3 = ((Costo.CostoUnitarioMax4 - Costo.CostoUnitarioMax3) / (Costo.Pot3 - Costo.Pot2)) * dPrelim.Tamano + (Costo.CostoUnitarioMax3 - (Costo.CostoUnitarioMax4 - Costo.CostoUnitarioMax3) / (Costo.Pot3 - Costo.Pot2) * Costo.Pot2);
                            Costo.CostoUnitario4 = ((Costo.CostoUnitarioMax5 - Costo.CostoUnitarioMax4) / (Costo.Pot4 - Costo.Pot3)) * dPrelim.Tamano + (Costo.CostoUnitarioMax4 - (Costo.CostoUnitarioMax5 - Costo.CostoUnitarioMax4) / (Costo.Pot4 - Costo.Pot3) * Costo.Pot3);
                            Costo.CostoUnitario5 = ((Costo.CostoUnitarioMax6 - Costo.CostoUnitarioMax5) / (Costo.Pot5 - Costo.Pot4)) * dPrelim.Tamano + (Costo.CostoUnitarioMax5 - (Costo.CostoUnitarioMax6 - Costo.CostoUnitarioMax5) / (Costo.Pot5 - Costo.Pot4) * Costo.Pot4);
                            Costo.CostoUnitario6 = ((Costo.CostoUnitarioMax7 - Costo.CostoUnitarioMax6) / (Costo.Pot6 - Costo.Pot5)) * dPrelim.Tamano + (Costo.CostoUnitarioMax6 - (Costo.CostoUnitarioMax7 - Costo.CostoUnitarioMax6) / (Costo.Pot6 - Costo.Pot5) * Costo.Pot5);
                            Costo.CostoUnitario7 = 0;
                            Costo.Precio1 = Costo.CostoUnitario1 * 1000 * dPrelim.Tamano;
                            Costo.Precio2 = Costo.CostoUnitario2 * 1000 * dPrelim.Tamano;
                            Costo.Precio3 = Costo.CostoUnitario3 * 1000 * dPrelim.Tamano;
                            Costo.Precio4 = Costo.CostoUnitario4 * 1000 * dPrelim.Tamano;
                            Costo.Precio5 = Costo.CostoUnitario5 * 1000 * dPrelim.Tamano;
                            Costo.Precio6 = Costo.CostoUnitario6 * 1000 * dPrelim.Tamano;
                            Costo.Precio7 = 0;

                            CostosUnitarios.Add(Costo);
                        
                        break;
                    case 1:
                        Costo.nombre = "Centralizados";
                        FactorCosto = 0.9;
                        Costo.minmaxPot(TipoTarifa);
                        Costo.CostoUnitarioMax1 = Microinversor.CostoUnitarioMax1 * FactorCosto;
                        Costo.CostoUnitarioMax2 = Microinversor.CostoUnitarioMax2 * FactorCosto;
                        Costo.CostoUnitarioMax3 = Microinversor.CostoUnitarioMax3 * FactorCosto;
                        Costo.CostoUnitarioMax4 = Microinversor.CostoUnitarioMax4 * FactorCosto;
                        Costo.CostoUnitarioMax5 = Microinversor.CostoUnitarioMax5 * FactorCosto;
                        if (TipoTarifa == "T-RE")
                        {
                            Costo.CostoUnitarioMax6 = Microinversor.CostoUnitarioMax6 * FactorCosto;
                            Costo.CostoUnitarioMax7 = Microinversor.CostoUnitarioMax7 * FactorCosto;
                        }
                        else
                        {
                            Costo.CostoUnitarioMax6 = 0.9;
                            Costo.CostoUnitarioMax7 = 0.83;
                        }
                        Costo.CostoUnitario1 = ((Costo.CostoUnitarioMax2 - Costo.CostoUnitarioMax1) / (Costo.Pot1 - Costo.Pot0)) * dPrelim.Tamano + (Costo.CostoUnitarioMax1 - (Costo.CostoUnitarioMax2 - Costo.CostoUnitarioMax1) / (Costo.Pot1 - Costo.Pot0) * Costo.Pot0);
                        Costo.CostoUnitario2 = ((Costo.CostoUnitarioMax3 - Costo.CostoUnitarioMax2) / (Costo.Pot2 - Costo.Pot1)) * dPrelim.Tamano + (Costo.CostoUnitarioMax2 - (Costo.CostoUnitarioMax3 - Costo.CostoUnitarioMax2) / (Costo.Pot2 - Costo.Pot1) * Costo.Pot1);
                        Costo.CostoUnitario3 = ((Costo.CostoUnitarioMax4 - Costo.CostoUnitarioMax3) / (Costo.Pot3 - Costo.Pot2)) * dPrelim.Tamano + (Costo.CostoUnitarioMax3 - (Costo.CostoUnitarioMax4 - Costo.CostoUnitarioMax3) / (Costo.Pot3 - Costo.Pot2) * Costo.Pot2);
                        Costo.CostoUnitario4 = ((Costo.CostoUnitarioMax5 - Costo.CostoUnitarioMax4) / (Costo.Pot4 - Costo.Pot3)) * dPrelim.Tamano + (Costo.CostoUnitarioMax4 - (Costo.CostoUnitarioMax5 - Costo.CostoUnitarioMax4) / (Costo.Pot4 - Costo.Pot3) * Costo.Pot3);
                        Costo.CostoUnitario5 = ((Costo.CostoUnitarioMax6 - Costo.CostoUnitarioMax5) / (Costo.Pot5 - Costo.Pot4)) * dPrelim.Tamano + (Costo.CostoUnitarioMax5 - (Costo.CostoUnitarioMax6 - Costo.CostoUnitarioMax5) / (Costo.Pot5 - Costo.Pot4) * Costo.Pot4);
                        Costo.CostoUnitario6 = ((Costo.CostoUnitarioMax7 - Costo.CostoUnitarioMax6) / (Costo.Pot6 - Costo.Pot5)) * dPrelim.Tamano + (Costo.CostoUnitarioMax6 - (Costo.CostoUnitarioMax7 - Costo.CostoUnitarioMax6) / (Costo.Pot6 - Costo.Pot5) * Costo.Pot5);
                        Costo.CostoUnitario7 = 0;
                        Costo.Precio1 = Costo.CostoUnitario1 * 1000 * dPrelim.Tamano;
                        Costo.Precio2 = Costo.CostoUnitario2 * 1000 * dPrelim.Tamano;
                        Costo.Precio3 = Costo.CostoUnitario3 * 1000 * dPrelim.Tamano;
                        Costo.Precio4 = Costo.CostoUnitario4 * 1000 * dPrelim.Tamano;
                        Costo.Precio5 = Costo.CostoUnitario5 * 1000 * dPrelim.Tamano;
                        Costo.Precio6 = Costo.CostoUnitario6 * 1000 * dPrelim.Tamano;
                        Costo.Precio7 = 0;

                        CostosUnitarios.Add(Costo);
                        break;

                }
                
            }

            List<double> Almac = selecAlmacenamiento(AvgRecibo, horasRespaldo);


            clsCostosUnitarios Interactivo = new clsCostosUnitarios();
            Interactivo.nombre = "Interactivo";
            Interactivo.CostoUnitarioMax1 = 2.8 + 4200 / (1000 * 6.5);
            Interactivo.CostoUnitarioMax2 = 2.275 + 4200 / (1000 * 6.5);
            Interactivo.CostoUnitarioMax3 = 1.965 + 4200 / (1000 * 6.5);
            Interactivo.CostoUnitarioMax4 = 1.673 + 4200 / (1000 * 6.5);
            Interactivo.CostoUnitario1 = ((Interactivo.CostoUnitarioMax2 - Interactivo.CostoUnitarioMax1) / (Interactivo.PotI1 - Interactivo.Pot0)) * dPrelim.Tamano + (Interactivo.CostoUnitarioMax1 - (Interactivo.CostoUnitarioMax2 - Interactivo.CostoUnitarioMax1) / (Interactivo.PotI1 - Interactivo.Pot0) * Interactivo.Pot0);
            Interactivo.CostoUnitario2 = ((Interactivo.CostoUnitarioMax3 - Interactivo.CostoUnitarioMax2) / (Interactivo.PotI2 - Interactivo.PotI1)) * dPrelim.Tamano + (Interactivo.CostoUnitarioMax2 - (Interactivo.CostoUnitarioMax3 - Interactivo.CostoUnitarioMax2) / (Interactivo.PotI2 - Interactivo.PotI1) * Interactivo.PotI1);
            Interactivo.CostoUnitario3 = ((Interactivo.CostoUnitarioMax4 - Interactivo.CostoUnitarioMax3) / (Interactivo.PotI3 - Interactivo.PotI2)) * dPrelim.Tamano + (Interactivo.CostoUnitarioMax3 - (Interactivo.CostoUnitarioMax4 - Interactivo.CostoUnitarioMax3) / (Interactivo.PotI3 - Interactivo.PotI2) * Interactivo.PotI2);
            Interactivo.Precio1 = Interactivo.CostoUnitario1 * 1000 * dPrelim.Tamano+Almac[2]; //dólares
            Interactivo.Precio2 = Interactivo.CostoUnitario2 * 1000 * dPrelim.Tamano+Almac[2]; //dólares
            Interactivo.Precio3 = Interactivo.CostoUnitario3 * 1000 * dPrelim.Tamano+Almac[2]; //dólares

            CostosUnitarios.Add(Interactivo);

            return CostosUnitarios;
        }


        public clsCostosMant calculaCostosMant(string Tipo)
        {

            clsDatos datos = new clsDatos();
            clsCostosMant cMant = new clsCostosMant();
            clsPreliminares dPrelim = new clsPreliminares();

            cMant.CostoUnitarioMax1 = datos.VisitaTecnica * 2;
            cMant.CostoUnitarioMax2 = 2*((cMant.Pot2/cMant.Pot1)-(cMant.Pot1/cMant.Pot1))*(dPrelim.Tamano/(cMant.Pot2-cMant.Pot1))*datos.VisitaTecnica+2*datos.VisitaTecnica;
            cMant.CostoUnitarioMax3 = 2 * ((cMant.Pot3 / cMant.Pot1) - (cMant.Pot2 / cMant.Pot1)) * (dPrelim.Tamano / (cMant.Pot3 - cMant.Pot2)) * datos.VisitaTecnica + 2 * datos.VisitaTecnica;
            cMant.CostoUnitarioMax4 = 2 * ((cMant.Pot4 / cMant.Pot1) - (cMant.Pot3 / cMant.Pot1)) * (dPrelim.Tamano / (cMant.Pot4 - cMant.Pot3)) * datos.VisitaTecnica + 2 * datos.VisitaTecnica;
            switch (Tipo)
            {
                case "NO":
                    cMant.CostoPct1 = 0;
                    cMant.CostoPct2 = 0;
                    cMant.CostoPct3 = 0;
                    cMant.CostoPct4 = 0;
                    break;
                case "GAM":
                    cMant.CostoPct1 = 1;
                    cMant.CostoPct2 = 1;
                    cMant.CostoPct3 = 1;
                    cMant.CostoPct4 = 1;
                    break;
                case "GAM+100km":
                    cMant.CostoPct1 = 1.3;
                    cMant.CostoPct2 = 1.3;
                    cMant.CostoPct3 = 1.3;
                    cMant.CostoPct4 = 1.3;
                    break;
                case "GAM+250km":
                    cMant.CostoPct1 = 1.55;
                    cMant.CostoPct2 = 1.55;
                    cMant.CostoPct3 = 1.55;
                    cMant.CostoPct4 = 1.55;
                    break;
                case "GAM+350km":
                    cMant.CostoPct1 = 1.8;
                    cMant.CostoPct2 = 1.8;
                    cMant.CostoPct3 = 1.8;
                    cMant.CostoPct4 = 1.8;
                    break;
            }

            cMant.Precio1 = cMant.CostoUnitarioMax1 * cMant.CostoPct1;
            cMant.Precio2 = cMant.CostoUnitarioMax2 * cMant.CostoPct2;
            cMant.Precio3 = cMant.CostoUnitarioMax3 * cMant.CostoPct3;
            cMant.Precio4 = cMant.CostoUnitarioMax4 * cMant.CostoPct4;


            return cMant;
        }




        public List<double> selecAlmacenamiento(double AvgRecibo, double horasRespaldo)
        {
            List<double> Almac = new List<double>();
            clsPreliminares dPrelim = new clsPreliminares();
            double requerido = (AvgRecibo / (31 * 24)) * horasRespaldo * 1.2;
            double propuesto;
            double precio;
            double CantInversores;
            double AcopleACPrecio;

            if (requerido == 0)
                propuesto = 0;
            else if (requerido < DarfonB7LFCap1)
                propuesto = DarfonB7LFCap1;
            else if (requerido < DarfonB10LFCap1)
                propuesto = DarfonB10LFCap1;
            else if (requerido < DarfonB7LFCap2)
                propuesto = DarfonB7LFCap2;
            else if (requerido < DarfonB7LFCap3)
                propuesto = DarfonB7LFCap3;
            else if (requerido < DarfonB10LFCap3)
                propuesto = DarfonB10LFCap3;
            else
                propuesto = 0;


            if (requerido == 0)
                precio = 0;
            else if (requerido < DarfonB7LFCap1)
                precio = DarfonB7LFPrecio1;
            else if (requerido < DarfonB10LFCap1)
                precio = DarfonB10LFPrecio1;
            else if (requerido < DarfonB7LFCap2)
                precio = DarfonB7LFPrecio2;
            else if (requerido < DarfonB7LFCap3)
                precio = DarfonB7LFPrecio3;
            else if (requerido < DarfonB10LFCap3)
                precio = DarfonB10LFPrecio3;
            else
                precio = 0;

            CantInversores = Math.Ceiling(dPrelim.Tamano / HB51CapPV);

            AcopleACPrecio = CantInversores * HB51Precio;

            Almac.Add(requerido);
            Almac.Add(propuesto);
            Almac.Add(precio);
            Almac.Add(CantInversores);
            Almac.Add(AcopleACPrecio);

            return Almac;

        }

    }
}
