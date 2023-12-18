using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace _15
{
    internal class SecondStar
    {
        private List<Box> boxes = new List<Box>();
        private string[] input;
        private Calculator calculator;

        public SecondStar(Calculator calculator, string[] input)
        {
            for (int i = 0; i < 256; i++)
            {
                boxes.Add(new Box(i));
            }
            this.input = input;
            this.calculator = calculator;
        }

        public void RunSecondStar()
        {
            Console.WriteLine(calculator.Calculate("rn"));
            Console.WriteLine(calculator.Calculate("rn 1"));
            Console.WriteLine(calculator.Calculate("rn=1"));
            foreach (var inputSequence in input)
            {
                if (inputSequence.Contains('='))
                {
                    var splitVals = inputSequence.Split('=');
                    var lensId = inputSequence.Replace('=', ' ');//calculator.Calculate(splitVals[0]);
                    var box = GetBox(splitVals[0]);
                    box.AddLens(splitVals[0], Convert.ToInt32(splitVals[1]));
                }
                else
                {
                    var splitVals = inputSequence.Split('-');
                    var lensId = inputSequence.Replace('-', ' ');//calculator.Calculate(inputSequence.Substring(0, inputSequence.Length - 1));
                    var box = GetBox(splitVals[0]);
                    box.RemoveLens(splitVals[0]);
                }
            }
            int result = 0;
            //var calcBoxes = boxes.Where(x => x.Lenses.Count > 0).ToArray();
            for(int i =0;i<boxes.Count;i++)
            {
                result += boxes[i].CalculateResult();
            }
            Console.WriteLine("Result second star:");
            Console.WriteLine(result);

        }

        private Box GetBox(string input)
        {
            var boxLabel = calculator.Calculate(input);
            return boxes.Where(x => x.Index == boxLabel).First();
        }


    }

    internal class Box
    {
        private List<Lens> lenses = new List<Lens>();
        public Box(int index)
        {
            Index = index;
        }

        public int Index { get; set; }

        public List<Lens> Lenses { get { return lenses; } }

        internal void RemoveLens(string lensId)
        {
            var lens = lenses.Where(x => x.Label == lensId).FirstOrDefault();
            if(lens != null)
            {
                lenses.Remove(lens);
            }
        }

        internal void AddLens(string lensId, int focal)
        {
            var lens = lenses.Where(x => x.Label == lensId).FirstOrDefault();
            if (lens != null)
            {
                lens.Focal = focal;
            }
            else
            {
                lenses.Add(new Lens(lensId, focal));
            }
        }

        internal int CalculateResult()
        {
            int result = 0;
            int boxNr = Index + 1;
            for(int i = 0; i < lenses.Count; i++)
            {
                result += boxNr * (i + 1) * lenses[i].Focal;
            }
            return result;
        }
    }

    internal class Lens
    {
        public Lens(string label)
        {
            Label = label;
        }
        public Lens(string label, int focal)
        {
            Label = label;
            Focal = focal;
        }
        public string Label { get; set; }
        public int Focal { get; set; }
    }
}
