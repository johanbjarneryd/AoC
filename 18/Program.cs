using System.Runtime.CompilerServices;
using System.Text;

namespace _18
{
    internal class Program
    {
        //83750 too high

        private static int rowIndex = 250;
        private static int colIndex = 250;
        private static List<List<char>> world;
        private static int worldDimension = 650;

        static void Main(string[] args)
        {
            var indata = ReadInput();
            world = GetWorld();

            world[rowIndex][colIndex] = '#';
            foreach (var item in indata)
            {
                var split = item.Split(' ');
                var steps = Convert.ToInt32(split[1]);
                switch (split[0])
                {
                    case "R": GoRight(steps); break;
                    case "D": GoDown(steps); break;
                    case "L": GoLeft(steps); break;
                    case "U": GoUp(steps); break;
                }
            }

            //for(int i = 0; i < worldDimension; i++)
            //{
            //    int? firstIndex = null;
            //    for (int j= 0; j< worldDimension; j++)
            //    {
            //        if (world[j][i] =='#')
            //        {
            //            if (firstIndex == null && world[j + 1][i] == '#')
            //            {
            //                continue;
            //            }
            //            if (firstIndex == null)
            //            {
            //                firstIndex = j;
            //            }
            //            else
            //            {
            //                for (int k = firstIndex.Value; k < j; k++)
            //                {
            //                    world[k][i] = '#';
            //                }
            //                firstIndex = null;
            //            }
            //        }
            //    }
            //}

            foreach (var row in world)
            {
                FillTrench(row);
            }

            using (var writer = new StreamWriter("output3.txt"))
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < worldDimension; i++)
                {
                    for (int j = 0; j < worldDimension; j++)
                    {
                        sb.Append(world[i][j]);
                    }
                    sb.AppendLine();
                }
                writer.WriteLine(sb.ToString());
            }

            int total = 0;
            foreach (var item in world)
            {
                total += item.Where(x => x == '#').Count();
            }
            Console.WriteLine(total);

        }

        private static void FillTrench(List<char> row)
        {

            int? firstIndex = null;
            for (int i = 0; i < row.Count; i++)
            {
                if (row[i] == '#')
                {
                    if (firstIndex == null && row[i + 1] == '#')
                    {
                        continue;
                    }
                    if(firstIndex == null)
                    {
                        firstIndex = i;
                    }
                    else
                    {
                        for(int j = firstIndex.Value;j<i;j++)
                        {
                            row[j] = '#';
                        }
                        i++;
                        firstIndex = null;
                    }
                }
            }
        }

        private static void GoRight(int steps)
        {
            int limit = colIndex + steps;
            for (int i = colIndex; i < limit; i++)
            {
                world[rowIndex][colIndex] = '#';
                colIndex++;
            }
        }

        private static void GoLeft(int steps)
        {
            int limit = colIndex - steps;
            for (int i = colIndex; i > limit; i--)
            {
                world[rowIndex][colIndex] = '#';
                colIndex--;
            }
        }

        private static void GoUp(int steps)
        {
            int limit = rowIndex - steps;
            for (int i = rowIndex; i > limit; i--)
            {
                world[rowIndex][colIndex] = '#';
                rowIndex--;
            }
        }

        private static void GoDown(int steps)
        {
            int limit = rowIndex + steps;
            for (int i = rowIndex; i < limit; i++)
            {
                world[rowIndex][colIndex] = '#';
                rowIndex++;
            }
        }

        private static IList<string> ReadInput()
        {
            var inData = new List<string>();
            using (StreamReader sr = new StreamReader(@"aoc18-1.txt"))
            {
                while (!sr.EndOfStream)
                {
                    inData.Add(sr.ReadLine());
                }
            }
            return inData;
        }

        private static List<List<char>> GetWorld()
        {
            int worldSize = worldDimension;
            var cols = new List<List<char>>();
            for (int i = 0; i < worldSize; i++)
            {
                var list = new List<char>();
                for (int j = 0; j < worldSize; j++)
                {
                    list.Add('.');
                }
                cols.Add(list);
            }
            return cols;
        }
    }

    public class Trench
    {

    }
}
