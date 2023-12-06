using System.Net.Sockets;
using System.Windows.Markup;

namespace _5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SecondStar();
        }

        private static void FirstStar()
        {
            IList<Seed> seedList = new List<Seed>();
            var inData = ReadInput();

            var seeds = inData[0].Split(':')[1].Trim().Split(' ');
            foreach (var seed in seeds)
            {
                seedList.Add(new Seed(Convert.ToInt64(seed)));
            }
            var seedToSoilMap = GetMap(inData, "seed-to-soil map:");
            var soilToFertilizerMap = GetMap(inData, "soil-to-fertilizer map:");
            var fertilizerToWaterMap = GetMap(inData, "fertilizer-to-water map:");
            var waterToLightMap = GetMap(inData, "water-to-light map:");
            var lightToTemperatureMap = GetMap(inData, "light-to-temperature map:");
            var temperatureToHumidityMap = GetMap(inData, "temperature-to-humidity map:");
            var humidityToLocationMap = GetMap(inData, "humidity-to-location map:");

            foreach (var seed in seedList)
            {
                seed.Map(seedToSoilMap, soilToFertilizerMap, fertilizerToWaterMap, waterToLightMap, lightToTemperatureMap, temperatureToHumidityMap, humidityToLocationMap);
                //Console.WriteLine($"{seed.SeedId} - {seed.SoilId} -{seed.FertilizerId}  -  {seed.WaterId} - {seed.LightId} - {seed.TemperatureId} - {seed.HumidityId} -  {seed.LocationId}");
            }

            var item = seedList.OrderBy(x => x.LocationId).First();

            Console.WriteLine(item.LocationId);
        }

        private static void SecondStar()
        {
            //IList<Seed> seedList = new List<Seed>();
            Seed workSeed = new Seed(0);
            var inData = ReadInput();
            long location = long.MaxValue;

            var seeds = inData[0].Split(':')[1].Trim().Split(' ');

            var seedToSoilMap = GetMap(inData, "seed-to-soil map:");
            var soilToFertilizerMap = GetMap(inData, "soil-to-fertilizer map:");
            var fertilizerToWaterMap = GetMap(inData, "fertilizer-to-water map:");
            var waterToLightMap = GetMap(inData, "water-to-light map:");
            var lightToTemperatureMap = GetMap(inData, "light-to-temperature map:");
            var temperatureToHumidityMap = GetMap(inData, "temperature-to-humidity map:");
            var humidityToLocationMap = GetMap(inData, "humidity-to-location map:");
            workSeed.SetMaps(seedToSoilMap, soilToFertilizerMap, fertilizerToWaterMap, waterToLightMap, lightToTemperatureMap, temperatureToHumidityMap, humidityToLocationMap);

            for (long i = 0; i < seeds.Length; i++)
            {
                
                long start = Convert.ToInt64(seeds[i]);
                long stop = start + Convert.ToInt64(seeds[i + 1]);
                Console.WriteLine("Seedbatch # " + i);
                Console.WriteLine("Start # " + start);
                Console.WriteLine("Stop # " + stop);
                long seedIdAdd = 0;
                for (long j = start; j < stop; j++)
                {
                    workSeed.Reset(start + seedIdAdd);
                    var loc = workSeed.GetLocation();
                    location = Math.Min(loc, location);                 
                    seedIdAdd++;
                    if(j % 300000 ==0)
                    {
                        Console.WriteLine($"Row {j} and location = {location}");
                    }
                }
                i++;
            }

            Console.WriteLine(location);
        }

        private static IList<InterVal> GetMap(IList<string> input, string delimiter)
        {
            Console.WriteLine("Creating map for " + delimiter);
            var list = new List<InterVal>();
            var index = GetLineIndex(input, delimiter);
            for (int i = index + 1; i < input.Count; i++)
            {
                if (string.IsNullOrEmpty(input[i]))
                {
                    break;
                }
                var vals = input[i].Split(' ').Select(x => Convert.ToInt64(x.Trim())).ToList();
                list.Add(new InterVal(vals[0], vals[1], vals[2]));
            }

            return list;
        }


        //private static IList<string> ReadInput()
        //{
        //    var inData = new List<string>();
        //    var line = Console.ReadLine();
        //    while (!string.IsNullOrEmpty(line))
        //    {
        //        inData.Add(line);
        //        line = Console.ReadLine();
        //    }
        //    return inData;
        //}

        private static IList<string> ReadInput()
        {
            var inData = new List<string>();
            using (StreamReader sr = new StreamReader(@"testdata2.txt"))
            {
                while (!sr.EndOfStream)
                {
                    inData.Add(sr.ReadLine());
                }
            }
            return inData;
        }

        private static int GetLineIndex(IList<string> input, string stringToFind)
        {
            int index = 0;
            for (int i = 0; i < input.Count; i++)
            {
                if (input[i] == stringToFind)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }
    }
}