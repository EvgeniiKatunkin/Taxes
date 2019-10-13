using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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
        double intercom;
        int water;

        public Flat(string Heat, string YardCleaning, string Gas, string Trash, 
            string Electricity, string Intercom, string HotWaterLastMonth, string HotWaterCurrently, 
            string ColdWaterLastMonth, string ColdWaterCurrently)
        {
            heat = Convert.ToDouble(Heat);
            yardCleaning = Convert.ToDouble(YardCleaning);
            gas = Convert.ToDouble(Gas);
            trash = Convert.ToDouble(Trash);
            electricity = Convert.ToDouble(Electricity);
            intercom = Convert.ToDouble(Intercom);
            water = (Convert.ToInt16(HotWaterCurrently) - Convert.ToInt16(HotWaterLastMonth)) + 
                (Convert.ToInt16(ColdWaterCurrently) - Convert.ToInt16(ColdWaterLastMonth));
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
            return heat + yardCleaning + gas + trash + electricity + intercom + 
                ColdWaterResult() + WaterDisposalResult();
        }
    }
}
