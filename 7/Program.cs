namespace _7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int total = 0;
            IList<string> input = ReadInput();
            IList<Hand> hands = new List<Hand>();
            IDictionary<char, int> map = new Dictionary<char, int>();
            map.Add('A',14);
            map.Add('K',13);
            map.Add('Q',12);
            map.Add('J',11);
            map.Add('T',10);
            foreach (var inLine in input)
            {
                var vals = inLine.Split(' ');
                var hand = new Hand();
                hand.Cards = vals[0];
                hand.Bid = Convert.ToInt32(vals[1]);
                int handValue = 0;
                for(int i = 0; i < vals[0].Length; i++)
                {
                    if (char.IsLetter(vals[0][i]))
                    {
                        handValue += map[vals[0][i]];
                    }
                    else
                    {
                        handValue += Convert.ToInt32(vals[0][1]);
                    }
                }
                hand.HandValue = handValue;
                hands.Add(hand);
            }

            hands = hands.OrderBy(x => x.HandValue).ToList();
            for(int i = 0; i< hands.Count;i++)
            {
                total += hands[i].Bid * i + 1;
            }

            Console.WriteLine(total);
        }
        private static IList<string> ReadInput()
        {
            var inData = new List<string>();
            using (StreamReader sr = new StreamReader(@"testdata0.txt"))
            {
                while (!sr.EndOfStream)
                {
                    inData.Add(sr.ReadLine());
                }
            }
            return inData;
        }


    }

    public class Hand
    {
        public string Cards { get; set; }
        public int Bid { get; set; }
        public int HandValue { get; set; }
    }
}