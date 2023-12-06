using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace _5
{
    internal class Seed
    {
        public Seed(long id)
        {
            SeedId = id;
        }

        public long SeedId { get; set; }
        public long SoilId { get; set; }
        public long WaterId { get; set; }
        public long FertilizerId { get; set; }
        public long LocationId { get; set; }
        public long LightId { get; set; }
        public long TemperatureId { get; set; }
        public long HumidityId { get; set; }

        public void Map(IList<InterVal> seedToSoilMap, IList<InterVal> soilToFertilizerMap, IList<InterVal> fertilizerToWaterMap, IList<InterVal> waterToLightMap,
                        IList<InterVal> lightToTemperatureMap, IList<InterVal> temperatureToHumidityMap, IList<InterVal> humidityToLocationMap)
        {
            SoilId = GetValue(seedToSoilMap, SeedId);
            FertilizerId = GetValue(soilToFertilizerMap, SoilId);
            WaterId = GetValue(fertilizerToWaterMap, FertilizerId);
            LightId = GetValue(waterToLightMap, WaterId);
            TemperatureId = GetValue(lightToTemperatureMap, LightId);
            HumidityId = GetValue(temperatureToHumidityMap, TemperatureId);
            LocationId = GetValue(humidityToLocationMap, HumidityId);            
        }

        private long GetValue(IList<InterVal> dict, long key)
        {
            var mapMatch = dict.Where(x => x.SourceStart <= key && key <= x.SourceStop).FirstOrDefault();
            if(mapMatch != null)
            {
                var i = key - mapMatch.SourceStart;
                return mapMatch.DestinationStart + i;
            }
            return key;
        }
    }
}
