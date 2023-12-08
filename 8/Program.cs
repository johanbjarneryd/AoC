using System.Xml.Linq;

namespace _8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SecondStarNonBruteForce();
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

        private static void SecondStar()
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

            string[] mapNodes = map.Keys.Where(x => x.Last() == 'A').ToArray();

            int directionCursor = 0;
            long steps = 0;
            bool fullStop = false;
            Node currNode = null;
            while (!fullStop)
            {
                char direction = input[0][directionCursor];
                for (int i = 0; i < mapNodes.Length; i++)
                {
                    currNode = map[mapNodes[i]];
                    if (direction == 'L')
                    {
                        mapNodes[i] = map[currNode.Left].Key;
                    }
                    else
                    {
                        mapNodes[i] = map[currNode.Right].Key;
                    }
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
                if (mapNodes.Length == mapNodes.Where(x => x.Last() == 'Z').Count())
                {
                    fullStop = true;
                }

                if (steps % 40000 == 0)
                {
                    Console.WriteLine($"Step: {steps} - nodes ending with Z: {mapNodes.Where(x => x.Last() == 'Z').Count()}");
                }
            }
            Console.WriteLine(steps);
        }

        private static void SecondStarNonBruteForce()
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

            List<int> routesStep = new List<int>();
            string[] mapNodes = map.Keys.Where(x => x.Last() == 'A').ToArray();

            Node currNode = null;
            char direction;
            foreach (var node in mapNodes)
            {
                currNode = map[node];
                int directionCursor = 0;
                int steps = 0;

                while (currNode.Key.Last() != 'Z')
                {
                    direction = input[0][directionCursor];
                    if (direction == 'L')
                    {
                        currNode = map[currNode.Left];
                    }
                    else
                    {
                        currNode = map[currNode.Right];
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
                routesStep.Add(steps);
                Console.WriteLine($"Steps for {node} - {steps}");
            }

            var lcm = LcmOfArray(routesStep.ToArray(), 0);

            Console.WriteLine(lcm);

            //Find least common multiple
        }

        private static IList<string> ReadInput()
        {
            var inData = new List<string>();
            using (StreamReader sr = new StreamReader(@"testdata2.txt"))
            {
                while (!sr.EndOfStream)
                {
                    inData.Add(sr.ReadLine());
                }
            }
            return inData;
        }

        static int __gcd(int a, int b)
        {
            if (a == 0)
                return b;
            return __gcd(b % a, a);
        }

        static int LcmOfArray(int[] arr, int idx)
        {
            if (idx == arr.Length - 1)
            {
                return arr[idx];
            }
            int a = arr[idx];
            int b = LcmOfArray(arr, idx + 1);
            return (a * b / __gcd(a, b));
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