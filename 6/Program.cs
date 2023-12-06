namespace _6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SecondStar();
        }

        public static void FirstStar()
        {
            var timeInput = Console.ReadLine().Split(' ');
            var times = timeInput.Where(x => !string.IsNullOrEmpty(x)).ToList();
            var recordInput = Console.ReadLine().Split(' ');
            var records = recordInput.Where(x => !string.IsNullOrEmpty(x)).ToList();

            var combinations = new List<int>();

            for (int i = 1; i < times.Count; i++)
            {
                var record = Convert.ToInt32(records[i]);
                int timeLimit = Convert.ToInt32(times[i]);
                int options = 0;
                for (int j = 0; j < timeLimit; j++)
                {
                    var timeLeft = timeLimit - j;
                    var raceLength = timeLeft * j;
                    if (raceLength > record)
                    {
                        options++;
                    }
                }
                combinations.Add(options);
            }

            int total = 1;
            for (int i = 0; i < combinations.Count; i++)
            {
                total = total * combinations[i];
            }
            Console.WriteLine(total.ToString());
        }

        private static void SecondStar()
        {
            var timeInput = Console.ReadLine().Split(' ');
            var time = Convert.ToInt64(timeInput[1]);
            var recordInput = Console.ReadLine().Split(' ');
            var record = Convert.ToInt64(recordInput[1]);

            long options = 0;
            for (long j = 0; j < time; j++)
            {
                var timeLeft = time - j;
                var raceLength = timeLeft * j;
                if (raceLength > record)
                {
                    options++;
                }
            }

            Console.WriteLine(options.ToString());
        }
    }
}