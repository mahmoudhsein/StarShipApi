using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Helpers
{
    public  class Utilities
    {
        public static int CalculateStops(StarShipModel starship, int distance)
        {
            var consumables = starship.Properties.consumables;
            var MGLT = string.Empty;
            var stops = 0;
            if (starship.Properties.MGLT != null)
                MGLT = starship.Properties.MGLT;
            var consumablesSplit = consumables.Split(" ");
            if (consumablesSplit.Count() == 2 && !string.IsNullOrEmpty(MGLT))
            {
                var number = int.Parse(consumablesSplit[0]);
                var strTime = consumablesSplit[1];
                var consumablesDays = getDays(number, strTime);
                var hours = distance / int.Parse(MGLT);
                var days = hours / 24;
                stops = days / consumablesDays;
            }
            return stops;
        }
        private static int getDays(int number,string strtime)
        {
            var list = new List<KeyValuePair<string, int>>() {
                        new KeyValuePair<string, int>("years", 365),
                        new KeyValuePair<string, int>("months", 30),
                        new KeyValuePair<string, int>("weeks", 7),
                        new KeyValuePair<string, int>("days", 1),
                        new KeyValuePair<string, int>("year", 365),
                        new KeyValuePair<string, int>("month", 30),
                        new KeyValuePair<string, int>("week", 7),
                        new KeyValuePair<string, int>("day", 1)
            };

            var result = from val in list where val.Key.Equals(strtime) select val.Value * number;
            return result.FirstOrDefault();
        }
    }
}
