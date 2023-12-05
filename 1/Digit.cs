using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
{
    internal class Digit
    {
        public Digit(int column, char value)
        {
            Column = column;
            Value = value;
        }

        public int Column { get; set; }
        public char Value { get; set; }
    }
}
