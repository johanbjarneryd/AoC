namespace _5
{
    internal class InterVal
    {
        public InterVal(long destination, long source, long range)
        {
            DestinationStart = destination;
            DestinationStop = destination + range;
            SourceStart = source;
            SourceStop = source + range;
            Range = range;
        }

        public long DestinationStart { get; set; }
        public long SourceStart { get; set; }
        public long DestinationStop { get; set; }
        public long SourceStop { get; set; }
        public long Range { get; set; }
    }
}
