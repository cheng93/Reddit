using System.Collections.Generic;

namespace Reddit250
{
    public interface IReddit250
    {
        bool IsSelfDescriptive(long number);
        IEnumerable<long> GetSelfDescriptiveNumberOfLength(int length);
    }
}