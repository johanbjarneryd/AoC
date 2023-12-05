using System.ComponentModel.DataAnnotations;

namespace _2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SecondStar();
        }

        private static void FirstStar()
        {
            var line = Console.ReadLine();
            int games = 0;
            do
            {
                int semiIndex = line.IndexOf(':');
                var game = Convert.ToInt32(line.Substring(0, semiIndex).Split(' ')[1]);
                bool possible = true;
                var sets = line.Substring(semiIndex + 1).Trim().Split(';');
                foreach (var set in sets)
                {
                    var colorCubes = set.Split(',');
                    foreach (var cube in colorCubes)
                    {
                        var values = cube.Trim().Split(' ');
                        var refVal = 0;
                        switch (values[1])
                        {
                            case "green": refVal = 13; break;
                            case "red": refVal = 12; break;
                            case "blue": refVal = 14; break;
                        }
                        if (!ColorPossible(refVal, Convert.ToInt32(values[0])))
                        {
                            possible = false;
                            break;
                        }
                    }
                    if (!possible)
                    {
                        break;
                    }
                }
                if (possible)
                {
                    games += game;
                }
                line = Console.ReadLine();
            } while (!string.IsNullOrEmpty(line));
            Console.WriteLine(games);
        }

        private static void SecondStar()
        {
            var line = Console.ReadLine();
            int power = 0;
            do
            {
                int semiIndex = line.IndexOf(':');
                var game = Convert.ToInt32(line.Substring(0, semiIndex).Split(' ')[1]);
                bool possible = true;
                var sets = line.Substring(semiIndex + 1).Trim().Split(';');
                var dict = new Dictionary<string, int>();

                foreach (var set in sets)
                {
                    var colorCubes = set.Split(',');
                    foreach (var cube in colorCubes)
                    {
                        var values = cube.Trim().Split(' ');
                        if (dict.ContainsKey(values[1]))
                        {
                            var val = Convert.ToInt32(values[0]);
                            if (dict[values[1]] < val)
                            {
                                dict[values[1]] = val;
                            }
                        }
                        else
                        {
                            dict.Add(values[1], Convert.ToInt32(values[0]));
                        }
                    }
                }
                int total = 0;
                foreach (var val in dict.Values)
                {
                    if (total == 0)
                    {
                        total = val;
                    }
                    else
                    {
                        total = total * val;
                    }
                }
                power += total;
                line = Console.ReadLine();
            } while (!string.IsNullOrEmpty(line));
            Console.WriteLine(power);
        }

        private static bool ColorPossible(int refVal, int cubeCount)
        {
            if (cubeCount > refVal)
                return false;

            return true;
        }
    }
}