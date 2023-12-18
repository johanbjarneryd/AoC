// See https://aka.ms/new-console-template for more information
using _15;
using System.Runtime.CompilerServices;
using System.Text;

int total = 0;
string line;

using(StreamReader sr = new StreamReader("aoc15-1.txt"))
{
    line = sr.ReadToEnd();
}

Calculator calculator = new Calculator();
var input = line.Split(',');
SecondStar secondStar = new SecondStar(calculator, input);
secondStar.RunSecondStar();


//First star code
//foreach(var item in input)
//{
//    total += calculator.Calculate(item);
//}

//Console.WriteLine(total.ToString());


//Determine the ASCII code for the current character of the string.
//Increase the current value by the ASCII code you just determined.
//Set the current value to itself multiplied by 17.
//Set the current value to the remainder of dividing itself by 256.


//The current value starts at 0.
//The first character is H; its ASCII code is 72.
//The current value increases to 72.
//The current value is multiplied by 17 to become 1224.
//The current value becomes 200 (the remainder of 1224 divided by 256).
//The next character is A; its ASCII code is 65.
//The current value increases to 265.
//The current value is multiplied by 17 to become 4505.
//The current value becomes 153 (the remainder of 4505 divided by 256).
//The next character is S; its ASCII code is 83.
//The current value increases to 236.
//The current value is multiplied by 17 to become 4012.
//The current value becomes 172 (the remainder of 4012 divided by 256).
//The next character is H; its ASCII code is 72.
//The current value increases to 244.
//The current value is multiplied by 17 to become 4148.
//The current value becomes 52 (the remainder of 4148 divided by 256).
