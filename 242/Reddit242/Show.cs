using System;

namespace Reddit242
{
    public class Show
    {
        public DateTime Start { get; private set; }

        public DateTime End { get; private set; }

        public Show(DateTime start, DateTime end)
        {
            Start = start;
            End = end;
        }
    }
}