using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace _3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Second();
        }

        static void First()
        {
            string input = null;
            using (var sr = new StreamReader("input.txt"))
            {
                input = sr.ReadToEnd();
            }
            Regex regex = new Regex(@"mul\((\d+),(\d+)\)");
            var matches = regex.Matches(input);
            int total = 0;
            foreach (var match in matches)
            {
                var itemString = match.ToString().Trim();
                var item = itemString.Replace("mul(", "");
                item = item.Replace(")", "");
                var vals = item.Split(',');
                total += (Convert.ToInt32(vals[0]) * Convert.ToInt32(vals[1]));
            }
            Console.WriteLine(total.ToString());
            Console.ReadLine();
        }

        static void Second()
        {
            string input = null;
            using (var sr = new StreamReader("input.txt"))
            {
                input = sr.ReadToEnd();
            }

            int index = 0;
            bool isDo = true;
            Regex reg;
            IList<string> values = new List<string>();
            do
            {
                if(isDo)
                {
                    reg = new Regex(@"\bdon't\(\)");
                }
                else
                {
                    reg = new Regex(@"do\(\)");
                }

                if (reg.IsMatch(input))
                {
                    index = reg.Match(input).Index;

                    if (isDo)
                    {
                        values.Add(input.Substring(0, index));
                    }
                    input = input.Substring(index);
                    isDo = !isDo;
                }
                else
                {
                    if(input.StartsWith("do()"))
                    {
                        values.Add(input);
                    }
                    index = -1;
                    break;
                }

            } while (index != -1);
            

            Regex regex = new Regex(@"mul\((\d+),(\d+)\)");
            int total = 0;

            foreach (var subString in values)
            {
                var matches = regex.Matches(subString);
                foreach (var match in matches)
                {
                    var itemString = match.ToString().Trim();
                    var item = itemString.Replace("mul(", "");
                    item = item.Replace(")", "");
                    var vals = item.Split(',');
                    total += (Convert.ToInt32(vals[0]) * Convert.ToInt32(vals[1]));
                }
            }
            Console.WriteLine(total.ToString());
            Console.ReadLine();
        }
    }
}
