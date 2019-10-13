using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Taxes
{
    [Serializable]
    class Flat
    {
        const double coldWaterTarif = 25.14;
        const double waterDisposalTarif = 17.95;
        public string heat { get; private set; }
        public string yardCleaning { get; private set; }
        public string gas { get; private set; }
        public string trash { get; private set; }
        public string electricity { get; private set; }
        public string intercom { get; private set; }
        public string hotWaterLastMonth { get; private set; }
        public string hotWaterCurrently { get; private set; }
        public string coldWaterLastMonth { get; private set; }
        public string coldWaterCurrently { get; private set; }


        public Flat(string Heat, string YardCleaning, string Gas, string Trash, 
            string Electricity, string Intercom, string HotWaterLastMonth, string HotWaterCurrently, 
            string ColdWaterLastMonth, string ColdWaterCurrently)
        {
            heat = Heat;
            yardCleaning = YardCleaning;
            gas = Gas;
            trash = Trash;
            electricity = Electricity;
            intercom = Intercom;
            hotWaterLastMonth = HotWaterLastMonth;
            hotWaterCurrently = HotWaterCurrently;
            coldWaterLastMonth = ColdWaterLastMonth;
            coldWaterCurrently = ColdWaterCurrently;
        }

        private int amountOfWater()
        {
            return (Convert.ToInt16(hotWaterCurrently) - Convert.ToInt16(hotWaterLastMonth)) +
                (Convert.ToInt16(coldWaterCurrently) - Convert.ToInt16(coldWaterLastMonth));
        }

        public double ColdWaterResult()
        {
            return amountOfWater() * coldWaterTarif;
        }

        public double WaterDisposalResult()
        {
            return amountOfWater() * waterDisposalTarif;
        }

        public double Result()
        {
            return Convert.ToDouble(heat) + Convert.ToDouble(yardCleaning) + Convert.ToDouble(gas)
                + Convert.ToDouble(trash) + Convert.ToDouble(electricity) + Convert.ToDouble(intercom)
                + ColdWaterResult() + WaterDisposalResult();
        }
    }
}
