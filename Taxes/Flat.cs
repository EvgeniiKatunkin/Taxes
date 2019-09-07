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
        int hotWater;
        int coldWater;
        double intercom;

        public Flat(double Heat, double YardCleaning, double Gas, double Trash, 
            double Electricity, int HotWater, int ColdWater, double Intercom)
        {
            heat = Heat;
            yardCleaning = YardCleaning;
            gas = Gas;
            trash = Trash;
            electricity = Electricity;
            hotWater = HotWater;
            coldWater = ColdWater;
            intercom = Intercom;
        }

        public double ColdWaterResult()
        {
            return (hotWater + coldWater) * coldWaterTarif;
        }

        public double WaterDisposalResult()
        {
            return (hotWater + coldWater) * waterDisposalTarif;
        }

        public double Result()
        {
            return heat + yardCleaning + gas + trash + electricity + 
                ColdWaterResult() + WaterDisposalResult() + intercom;
        }
    }
}
