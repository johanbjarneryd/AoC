using System;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Text.RegularExpressions;

namespace _1
{
    internal class Program
    {
        private static IDictionary<string, char> lookups;
        static void Main(string[] args)
        {
            IList<IList<Digit>> processedRows = new List<IList<Digit>>();
            IList<string> lines = new List<string>();
            var line = Console.ReadLine();
            lookups = SetupLookup();
            var numbers = new List<int>();

            while (!string.IsNullOrEmpty(line))
            {
                lines.Add(line);
                line = Console.ReadLine();
            }

            foreach (var lineToProcess in lines)
            {
                var digits = new List<Digit>();
                for (int i = 0; i < lineToProcess.Length; i++)
                {
                    if (IsDigit(lineToProcess[i]))
                    {
                        digits.Add(new Digit(i, lineToProcess[i]));
                    }
                }
                var fromStart = FindDigit(lineToProcess);
                if (!string.IsNullOrEmpty(fromStart))
                {
                    var index = lineToProcess.IndexOf(fromStart);
                    digits.Add(new Digit(index, lookups[fromStart]));
                }

                for (int i = lineToProcess.Length; i >= 0; i--)
                {
                    var sub = lineToProcess.Substring(i);
                    var fromBack = FindDigit(sub);
                    if (!string.IsNullOrEmpty(fromBack))
                    {
                        var index = lineToProcess.LastIndexOf(fromBack);
                        digits.Add(new Digit(index, lookups[fromBack]));
                    }
                }

                digits = digits.OrderBy(x => x.Column).ToList();
                var xNum = "" + digits.First().Value + digits.Last().Value;
                numbers.Add(Convert.ToInt32(xNum));

            }

            var sum = numbers.Sum();
            Console.WriteLine(sum);
        }

        private static string FindDigit(string s)
        {
            var match = Regex.Match(s.ToLower(), @"one|two|three|four|five|six|seven|eight|nine");
            if (match.Success)
            {
                return match.Value.ToString();
            }
            return null;
        }

        private static IDictionary<string, char> SetupLookup()
        {
            var dict = new Dictionary<string, char>();
            dict.Add("one", '1');
            dict.Add("two", '2');
            dict.Add("three", '3');
            dict.Add("four", '4');
            dict.Add("five", '5');
            dict.Add("six", '6');
            dict.Add("seven", '7');
            dict.Add("eight", '8');
            dict.Add("nine", '9');
            return dict;
        }

        private static bool IsDigit(char c)
        {
            return char.IsDigit(c);
        }

        private static void FirstStar(IList<string> lines)
        {
            var firstStarNumbers = new List<int>();
            //first star
            foreach (var lineToProcess in lines)
            {
                var number = $"{lineToProcess.First(x => char.IsDigit(x))}{lineToProcess.Last(x => char.IsDigit(x))}";
                firstStarNumbers.Add(Convert.ToInt32(number));
            }
            Console.WriteLine("First star result = " + firstStarNumbers.Sum());
        }
    }
}