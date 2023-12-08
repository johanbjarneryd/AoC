namespace _8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FirstStar();
        }

        private static void FirstStar()
        {
            IList<string> input = ReadInput();

            IDictionary<string, Node> map = new Dictionary<string, Node>();
            for (int i = 2; i < input.Count; i++)
            {
                var key = input[i].Substring(0, 3);
                var left = input[i].Substring(7, 3);
                var right = input[i].Substring(12, 3);
                map.Add(key, new Node(key, left, right));
            }

            var node = map["AAA"];
            int directionCursor = 0;
            int steps = 0;

            while (node.Key != "ZZZ")
            {
                char direction = input[0][directionCursor];
                if (direction == 'L')
                {
                    node = map[node.Left];
                }
                else
                {
                    node = map[node.Right];
                }
                steps++;
                if (directionCursor == input[0].Length - 1)
                {
                    directionCursor = 0;
                }
                else
                {
                    directionCursor++;
                }
            }
            Console.WriteLine(steps);
        }

        private static IList<string> ReadInput()
        {
            var inData = new List<string>();
            using (StreamReader sr = new StreamReader(@"testdata1.txt"))
            {
                while (!sr.EndOfStream)
                {
                    inData.Add(sr.ReadLine());
                }
            }
            return inData;
        }
    }

    public class Node
    {
        public Node(string key, string left, string right)
        {
            Key = key;
            Left = left;
            Right = right;
        }

        public string Key { get; set; }
        public string Left { get; set; }
        public string Right { get; set; }
    }
}