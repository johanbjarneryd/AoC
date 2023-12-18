using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15
{
    internal class Calculator
    {
        internal int Calculate(string input)
        {
            //Determine the ASCII code for the current character of the string.
            //Increase the current value by the ASCII code you just determined.
            //Set the current value to itself multiplied by 17.
            //Set the current value to the remainder of dividing itself by 256.

            int currentValue = 0;
            byte[] asciiBytes = Encoding.ASCII.GetBytes(input);
            foreach (var val in asciiBytes)
            {
                var d = Convert.ToInt32(val);
                currentValue += Convert.ToInt32(d);
                currentValue = currentValue * 17;
                int rem;
                Math.DivRem(currentValue, 256, out rem);
                currentValue = rem;
            }

            return currentValue;
        }
    }
}
