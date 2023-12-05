using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3
{
    internal class Symbol
    {
        public Symbol(char symbolChar, int row, int column) 
        { 
            SymbolChar = symbolChar;
            Row = row;
            Column = column;
        }

        public char SymbolChar { get;set; }
        public int Row { get; set; }
        public int Column { get; set; }
    }
}
