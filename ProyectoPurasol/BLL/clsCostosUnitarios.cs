using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class clsCostosUnitarios
    {
        public string nombre = string.Empty;
        public string tarifa = string.Empty;
        public double Pot0;
        public double Pot1;
        public double Pot2;
        public double Pot3;
        public double Pot4;
        public double Pot5;
        public double Pot6;
        public double Pot7=1000;
        public double Pot8=1500;
        public double PotI1 = 6.5;
        public double PotI2 = 13;
        public double PotI3 = 019.5;
        public double CostoUnitarioMax1;
        public double CostoUnitarioMax2;
        public double CostoUnitarioMax3;
        public double CostoUnitarioMax4;
        public double CostoUnitarioMax5;
        public double CostoUnitarioMax6;
        public double CostoUnitarioMax7;
        public double CostoUnitarioMax8=800;
        public double CostoUnitarioMax9=800;
        public double CostoUnitarioMax10=800;
        public double CostoUnitario1;
        public double CostoUnitario2;
        public double CostoUnitario3;
        public double CostoUnitario4;
        public double CostoUnitario5;
        public double CostoUnitario6;
        public double CostoUnitario7;
        public double CostoUnitario8;
        public double CostoUnitario9;
        public double Precio1;
        public double Precio2;
        public double Precio3;
        public double Precio4;
        public double Precio5;
        public double Precio6;
        public double Precio7;
        public double Precio8;
        public double Precio9;

        public void minmaxPot(string tarifa)
        {
            if (tarifa == "T-RE")
            {
                    Pot0 = 0;
                    Pot1 = 2.37;
                    Pot2 = 3.16;
                    Pot3 = 3.95;
                    Pot4 = 5;
                    Pot5 = 10;
                    Pot6 = 20;
            }
            else
            {
                Pot0 = 0;
                Pot1 = 5;
                Pot2 = 10;
                Pot3 = 20;
                Pot4 = 50;
                Pot5 = 100;
                Pot6 = 200;

            }
        }

        


    }
}
