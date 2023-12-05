using System;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Text.RegularExpressions;

namespace _1
{
    internal class Program
    {
        private static IDictionary<string, int> lookups;
        static void Main(string[] args)
        {
            var line = Console.ReadLine();
            lookups = SetupLookup();
            var numbers = new List<int>();

            while (!string.IsNullOrEmpty(line))
            {
                string firstDigit = null, lastDigit = null;
                int? fd = null, ld = null;
                int? firstIndex = null, lastIndex = null;
                
                for(int i=0;i<line.Length; i++)
                {
                    var sub = line.Substring(0, i+1);
                    var res = FindDigit(sub);
                    if (!string.IsNullOrEmpty(res))
                    {
                        firstIndex = line.IndexOf(res);
                        fd = lookups[res];
                        break;
                    }
                }

                for (int i = line.Length; i >= 0; i--)
                {
                    var sub = line.Substring(i);
                    var res = FindDigit(sub);
                    if (!string.IsNullOrEmpty(res))
                    {
                        lastIndex = line.LastIndexOf(res);
                        ld = lookups[res];
                        break;
                    }
                }
        
                for (int i = 0; i < line.Length; i++)
                {
                    if(fd == null && IsNumber(line[i].ToString()))
                    {
                        firstDigit = line[i].ToString();
                        break;
                    }
                    else if(fd != null && IsNumber(line[i].ToString()))
                    {
                        if (firstIndex > i)
                        {
                            firstDigit = line[i].ToString();
                        }
                        else
                        {
                            firstDigit = fd.ToString();
                        }
                        break;
                    }
                }

                for (int i = line.Length; i > 0; i--)
                {
                    if (ld == null && IsNumber(line[i-1].ToString()))
                    {
                        lastDigit = line[i-1].ToString();
                        break;
                    }
                    else if (ld != null && IsNumber(line[i-1].ToString()))
                    {
                        if (lastIndex < i-1)
                        {
                            lastDigit = line[i-1].ToString();
                        }
                        else
                        {
                            lastDigit = ld.ToString();
                        }
                        break;
                    }
                }

                numbers.Add(Convert.ToInt32("" + firstDigit + lastDigit));
                line = Console.ReadLine();
            }

            var sum = numbers.Sum();
             Console.WriteLine(sum);
        }

        private static bool IsNumber(string c)
        {
            int num;
            return int.TryParse(c, out num);
        }

        private static string FindDigit(string s)
        {
            var match = Regex.Match(s.ToLower(), @"zero|one|two|three|four|five|six|seven|eight|nine");
            if(match.Success)
            {
                return match.Value.ToString();
            }
            return null;
        }

        private static IDictionary<string,int> SetupLookup()
        {
            var dict = new Dictionary<string, int>();
            dict.Add("zero", 0);
            dict.Add("0", 0);
            dict.Add("one", 1);
            dict.Add("1", 1);
            dict.Add("two", 2);
            dict.Add("2", 2);
            dict.Add("three", 3);
            dict.Add("3", 3);
            dict.Add("four", 4);
            dict.Add("4", 4);
            dict.Add("five", 5);
            dict.Add("5", 5);
            dict.Add("six", 6);
            dict.Add("6", 6);
            dict.Add("seven", 7);
            dict.Add("7", 7);
            dict.Add("eight", 8);
            dict.Add("8", 8);
            dict.Add("nine", 9);
            dict.Add("9", 9);
            return dict;
        }
    }
}