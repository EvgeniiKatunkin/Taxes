using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxes
{
    class Flat
    {
        const double coldWaterTarif = 25.14;
        const double waterDisposalTarif = 17.95;
        double heat;
        double yardCleaning;
        double gas;
        double trash;
        double electricity;
        int water;
        double intercom;

        public Flat(double Heat, double YardCleaning, double Gas, double Trash, 
            double Electricity, int HotWater, int ColdWater, double Intercom)
        {
            heat = Heat;
            yardCleaning = YardCleaning;
            gas = Gas;
            trash = Trash;
            electricity = Electricity;
            water = HotWater + ColdWater;
            intercom = Intercom;
        }

        public double ColdWaterResult()
        {
            return water * coldWaterTarif;
        }

        public double WaterDisposalResult()
        {
            return water * waterDisposalTarif;
        }

        public double Result()
        {
            return heat + yardCleaning + gas + trash + electricity + 
                ColdWaterResult() + WaterDisposalResult() + intercom;
        }
    }
}
