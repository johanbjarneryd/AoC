namespace _7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IList<string> input = ReadInput();
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
}