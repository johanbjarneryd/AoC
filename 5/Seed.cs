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

        private IList<InterVal> SeedToSoilMap { get; set; }
        private IList<InterVal> SoilToFertilizerMap { get; set; }
        private IList<InterVal> SertilizerToWaterMap { get; set; }
        private IList<InterVal> WaterToLightMap { get; set; }
        private IList<InterVal> LightToTemperatureMap { get; set; }
        private IList<InterVal> TemperatureToHumidityMap { get; set; }
        private IList<InterVal> HumidityToLocationMap { get; set; }

        public void Reset(long seedId)
        {
            SeedId = seedId;
            SoilId = 0;
            WaterId = 0;
            FertilizerId = 0;
            LocationId = 0;
            LightId = 0;
            TemperatureId = 0;
            HumidityId = 0;
        }

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

        public void SetMaps(IList<InterVal> seedToSoilMap, IList<InterVal> soilToFertilizerMap, IList<InterVal> fertilizerToWaterMap, IList<InterVal> waterToLightMap,
                IList<InterVal> lightToTemperatureMap, IList<InterVal> temperatureToHumidityMap, IList<InterVal> humidityToLocationMap)
        {
            SeedToSoilMap = seedToSoilMap;
            SoilToFertilizerMap = soilToFertilizerMap;
            SertilizerToWaterMap = fertilizerToWaterMap;
            WaterToLightMap = waterToLightMap;
            LightToTemperatureMap = lightToTemperatureMap;
            TemperatureToHumidityMap = temperatureToHumidityMap;
            HumidityToLocationMap = humidityToLocationMap;
        }

        public long GetLocation()
        {
            SoilId = GetValue(SeedToSoilMap, SeedId);
            FertilizerId = GetValue(SoilToFertilizerMap, SoilId);
            WaterId = GetValue(SertilizerToWaterMap, FertilizerId);
            LightId = GetValue(WaterToLightMap, WaterId);
            TemperatureId = GetValue(LightToTemperatureMap, LightId);
            HumidityId = GetValue(TemperatureToHumidityMap, TemperatureId);
            LocationId = GetValue(HumidityToLocationMap, HumidityId);
            return LocationId;
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
