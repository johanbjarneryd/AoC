using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3
{
    internal class Number
    {
        public Number(string numberInput, IList<int> columns, int row)
        {
            Value = Convert.ToInt32(numberInput);
            Columns = new List<int>();
            Columns = columns;
            Row = row;
        }
        public int Value { get; set; }
        public IList<int> Columns { get; set; }
        public int Row { get; set; }
    }
}
