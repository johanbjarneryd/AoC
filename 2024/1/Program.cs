namespace _1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var left = new List<int>();
            var right = new List<int>();
            string line = null;
            int total = 0;
            using (var sr = new StreamReader("input1.txt"))
            {
                while (!sr.EndOfStream)
                {
                    line = sr.ReadLine();
                    var split = line.Split("   ");
                    left.Add(Convert.ToInt32(split[0]));
                    right.Add(Convert.ToInt32(split[1]));
                }
            }
            left = left.Select(x => x).Distinct().ToList();
            right = right.Select(x => x).Distinct().ToList();
            left.Sort();
            right.Sort();
            int itterations = left.Count;
            if (left.Count > right.Count)
            {
                itterations= right.Count;
            }

            for (int i = 0; i < itterations; i++)
            {
                if (left[i] > right[i])
                {
                    int x = left[i] - right[i];
                    total = total + x;
                }
                else if (left[i] < right[i])
                {
                    int x = right[i] - left[i];
                    total = total + x;
                }
                else
                {
                    total = total + 0;
                }
            }
            Console.WriteLine(total);
            Console.ReadLine();
        }
    }
}
