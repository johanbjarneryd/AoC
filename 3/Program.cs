using System.Text;
using System.Text.RegularExpressions;

namespace _3
{
    internal class Program
    {
        private static IList<string> lines = new List<string>();

        static void Main(string[] args)
        {
            int total = 0;
            var line = Console.ReadLine();
            int llength = line.Length;
            lines.Add(GetFillerRow(line.Length + 2));
            do
            {
                lines.Add("." + line + ".");
                line = Console.ReadLine();
            } while (!string.IsNullOrEmpty(line));
            lines.Add(GetFillerRow(llength + 2));

            total = SecondStar(total);
            Console.WriteLine(total);
        }

        private static int FirstStar(int total)
        {
            //loop lines
            for (int i = 0; i < lines.Count; i++)
            {
                var curLine = lines[i];
                //run line
                for (int j = 0; j < lines[i].Length; j++)
                {
                    var curChar = lines[i][j];
                    if (IsNumber(lines[i][j].ToString()))
                    {
                        int length = 1;
                        int number = 0;
                        int startIndex = j;
                        for (int l = j + 1; l < lines[i].Length; l++)
                        {
                            if (IsNumber(lines[i][l].ToString()))
                            {
                                length++;
                            }
                            else
                            {
                                j = l;
                                break;
                            }
                        }

                        var aSub = lines[i - 1].Substring(startIndex - 1, length + 2);
                        var bSub = lines[i + 1].Substring(startIndex - 1, length + 2);
                        var cSub = lines[i].Substring(startIndex - 1, length + 2);
                        var above = HasSymbol(aSub);
                        var current = HasSymbol(cSub);
                        var below = HasSymbol(bSub);
                        if (above || current || below)
                        {
                            number = Convert.ToInt32(lines[i].Substring(startIndex, length));
                            total += Convert.ToInt32(number);
                        }
                    }
                }
            }

            return total;
        }

        private static int SecondStar(int total)
        {
            IList<Symbol> symbols = new List<Symbol>();
            IList<Number> numbers = new List<Number>();
            //find all symbols & numbers
            for (int i = 0; i < lines.Count; i++)
            {
                //run line
                for (int j = 0; j < lines[i].Length; j++)
                {
                    if (IsSymbol(lines[i][j]))
                    {
                        symbols.Add(new Symbol(lines[i][j], i, j));
                    }
                    else if (IsDigit(lines[i][j]))
                    {
                        var number = FindNumberAfter(i, j, lines[i]);
                        j += number.Columns.Count - 1;
                        numbers.Add(number);
                    }
                }
            }

            foreach (var symbol in symbols)
            {
                var nums = numbers.Where(x => (x.Row == symbol.Row || x.Row == symbol.Row + 1 || x.Row == symbol.Row - 1) && 
                                        (x.Columns.Contains(symbol.Column) || x.Columns.Contains(symbol.Column + 1) || x.Columns.Contains(symbol.Column - 1)))
                                        .ToList();
                if(nums.Count == 2)
                {
                    total += (nums[0].Value * nums[1].Value);
                }
            }
            return total;
        }

        private static Number FindNumberAfter(int row, int i, string line)
        {
            int length = 0;
            IList<int> columns = new List<int>();
            string numberString = "";
            for (int l = i; l < line.Length; l++)
            {
                if (IsNumber(line[l].ToString()))
                {
                    columns.Add(l);
                    numberString += line[l].ToString();
                    length++;
                }
                else
                {
                    if (length == 0)
                        length = 1;
                    break;
                }
            }
            return new Number(numberString, columns, row);
        }

        private static bool HasSymbol(string row)
        {
            var matches = Regex.Matches(row, @"\W").Where(x => x.Value != ".").Count();
            if (matches > 0)
                return true;
            return false;
        }

        private static bool IsSymbol(char c)
        {
            if (c != '.' && IsDigit(c) == false)
                return true;
            return false;
        }

        private static bool IsNumber(string c)
        {
            int num;
            return int.TryParse(c, out num);
        }

        private static bool IsDigit(char c)
        {
            return char.IsDigit(c);
        }

        private static string GetFillerRow(int length)
        {
            var builder = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                builder.Append(".");
            }
            return builder.ToString();
        }
    }
}