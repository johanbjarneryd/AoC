using System.Data;

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
            map.Add('A', 14);
            map.Add('K', 13);
            map.Add('Q', 12);
            map.Add('J', 11);
            map.Add('T', 10);
            foreach (var inLine in input)
            {
                var vals = inLine.Split(' ');
                var hand = new Hand(map);
                hand.SetCards(vals[0]);
                hand.Bid = Convert.ToInt32(vals[1]);
                int handValue = 0;
                for (int i = 0; i < vals[0].Length; i++)
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
                hand.Groups = vals[0].GroupBy(x => x).ToList();
                hand.HandValue = handValue;
                hand.FirstCardValue = char.IsDigit(inLine[0]) ? inLine[0] : map[inLine[0]];
                hands.Add(hand);
            }
            //var fullHands = hands.Where(x => x.Groups.Count == 1).ToList();
            //var fourCards = hands.Where(x => x.Groups.Count == 2 && (x.Groups.Where(y => y.Count() == 4).Count() == 1)).ToList();
            //var fullHouse = hands.Where(x => x.Groups.Count == 2 && (x.Groups.Where(y => y.Count() == 3).Count() == 1 && x.Groups.Where(y => y.Count() == 2).Count() == 1)).ToList();
            //var three = hands.Where(x => x.Groups.Count == 3 && (x.Groups.Where(y => y.Count() == 3).Count() == 1 && x.Groups.Where(y => y.Count() == 1).Count() == 2)).ToList();
            //var twoPairs = hands.Where(x => x.Groups.Count == 3 && (x.Groups.Where(y => y.Count() == 2).Count() == 2)).ToList();
            //var pairs = hands.Where(x => x.Groups.Count == 4).ToList();
            //var distinctHighCard = hands.Where(x => x.Groups.Count == 5).ToList();

            //var orderedHands = new List<Hand>();
            //orderedHands.InsertRange(0, SortHands(distinctHighCard, map));
            //orderedHands.InsertRange(orderedHands.Count, SortHands(pairs, map));
            //orderedHands.InsertRange(orderedHands.Count, SortHands(twoPairs, map));
            //orderedHands.InsertRange(orderedHands.Count, SortHands(three, map));
            //orderedHands.InsertRange(orderedHands.Count, SortHands(fullHouse, map));
            //orderedHands.InsertRange(orderedHands.Count, SortHands(fourCards, map));
            //orderedHands.InsertRange(orderedHands.Count, SortHands(fullHands, map));

            var orderedHands = SortHands(hands, map);
            for (int i = 0; i < orderedHands.Count; i++)
            {
                Console.WriteLine(orderedHands[i].Cards.ToString());
                var rank = i + 1;
                total += orderedHands[i].Bid * rank;
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

        private static IList<Hand> SortHands(IList<Hand> hands, IDictionary<char, int> map)
        {
            return hands.OrderByDescending(x => x.FirstCardValue).ThenByDescending(x => x.SecondCardValue)
                        .ThenByDescending(x => x.ThirdCardValue).ThenByDescending(x => x.FourthCardValue)
                        .ThenByDescending(x => x.FiftCardValue).ToList();
            //if (hands.Count <= 1)
            //{
            //    return hands;
            //}

            //for (int i = 0; i < hands.Count; i++)
            //{
            //    for (int j = 0; j < hands.Count - 1; j++)
            //    {
            //        if (hands[j].Cards[0] == hands[j + 1].Cards[0])
            //        {
            //            for (int k = 0; k < hands[j].Cards[k]; k++)
            //            {
            //                if (hands[j].Cards[k] == hands[j + 1].Cards[k])
            //                {
            //                    continue;
            //                }
            //                int firstNum = char.IsDigit(hands[j].Cards[k]) ? Convert.ToInt32(hands[j].Cards[k]) : map[hands[j].Cards[k]];
            //                int secondNum = char.IsDigit(hands[j + 1].Cards[k]) ? Convert.ToInt32(hands[j + 1].Cards[k]) : map[hands[j + 1].Cards[k]];
            //                if (firstNum > secondNum)
            //                {
            //                    break;
            //                    var temp = hands[j];
            //                    hands[j] = hands[j + 1];
            //                    hands[j + 1] = temp;
            //                }
            //                else
            //                {
            //                    var temp = hands[j + 1];
            //                    hands[j + 1] = hands[j];
            //                    hands[j] = temp;
            //                    break;
            //                }
            //            }
            //        }
            //    }
            //}
            //return hands;
        }
    }
    public class Hand
    {
        private IDictionary<char, int> _map;
        public Hand(IDictionary<char, int> map)
        {
            _map = map;
        }
        public string Cards { get; private set; }
        public int Bid { get; set; }
        public int HandValue { get; set; }

        public int FirstCardValue { get; set; }
        public int SecondCardValue { get; set; }
        public int ThirdCardValue { get; set; }
        public int FourthCardValue { get; set; }
        public int FiftCardValue { get; set; }

        public void SetCards(string hand)
        {
            Cards = hand;
            FirstCardValue = char.IsDigit(hand[0]) ? Convert.ToInt32(hand[0]) : _map[hand[0]];
            SecondCardValue = char.IsDigit(hand[1]) ? Convert.ToInt32(hand[1]) : _map[hand[1]];
            ThirdCardValue = char.IsDigit(hand[2]) ? Convert.ToInt32(hand[2]) : _map[hand[2]];
            FourthCardValue = char.IsDigit(hand[3]) ? Convert.ToInt32(hand[3]) : _map[hand[3]];
            FiftCardValue = char.IsDigit(hand[4]) ? Convert.ToInt32(hand[4]) : _map[hand[4]];
        }

        public IList<IGrouping<char, char>> Groups { get; set; }
    }
}