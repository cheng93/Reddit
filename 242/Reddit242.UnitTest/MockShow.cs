using System;

namespace Reddit242.UnitTest
{
    internal class MockShow : IShow
    {
        public DateTime Start { get; private set; }
        public DateTime End { get; private set; }
        
        public MockShow(DateTime start, DateTime end)
        {
            Start = start;
            End = end;
        }
    }
}
