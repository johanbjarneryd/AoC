using System.ComponentModel;
using System.Security.Cryptography;

namespace _4
{
    internal class Program
    {
        private static int scratchCards = 0;
        static void Main(string[] args)
        {
            SecondStar();
        }

        private static void FirstStar()
        {
            var results = new List<int>();
            var line = Console.ReadLine();
            do
            {
                var card = line.Substring(9);
                var nums = card.Split('|');
                var winningNumbers = nums[0].Trim().Split(' ').Where(x => !string.IsNullOrEmpty(x)).Select(x => Convert.ToInt32(x)).ToArray<int>();
                var elfNumbers = nums[1].Split(' ').Where(x => !string.IsNullOrEmpty(x)).Select(x => Convert.ToInt32(x)).ToArray<int>();
                var winmatches = winningNumbers.Where(x => elfNumbers.Contains(x)).Select(x => x).ToArray<int>();
                int result = 0;
                for (int i = 0; i < winmatches.Length; i++)
                {
                    if (result == 0)
                    {
                        result = 1;
                    }
                    else
                    {
                        result = result * 2;
                    }
                }
                results.Add(result);
                line = Console.ReadLine();
            } while (!string.IsNullOrEmpty(line));
            Console.WriteLine(results.Sum());
        }

        private static void SecondStar()
        {
            var inputs = new List<Input>();
            var results = new List<int>();
            var line = Console.ReadLine();
            int rowId = 1;

            do
            {
                var card = line.Substring(9);
                var nums = card.Split('|');
                var winningNumbers = nums[0].Trim().Split(' ').Where(x => !string.IsNullOrEmpty(x)).Select(x => Convert.ToInt32(x)).ToArray<int>();
                var elfNumbers = nums[1].Split(' ').Where(x => !string.IsNullOrEmpty(x)).Select(x => Convert.ToInt32(x)).ToArray<int>();
                var winmatches = winningNumbers.Where(x => elfNumbers.Contains(x)).Select(x => x).Count();
                inputs.Add(new Input() { RowNumber = rowId, WinningNumbers = winningNumbers, ElfNumbers = elfNumbers, WinMatches = winmatches });
                line = Console.ReadLine();
                rowId++;
            } while (!string.IsNullOrEmpty(line));
            CalculateWinningCards(0, inputs.Count, inputs);
            Console.WriteLine(scratchCards);
        }

        private static void CalculateWinningCards(int listIndex, int loops, IList<Input> winners)
        {
            for (int i = listIndex; i < listIndex+loops; i++)
            {
                var winmatches = winners[i].WinningNumbers.Where(x => winners[i].ElfNumbers.Contains(x)).Select(x => x).Count();
                CalculateWinningCards(i+1, winners[i].WinMatches, winners);
                scratchCards++;
            }
        }
    }

    internal struct Input
    {
        internal int RowNumber { get; set; }
        internal int[] WinningNumbers { get; set; }
        internal int[] ElfNumbers { get; set; }
        internal int WinMatches { get; set; }
    }
}