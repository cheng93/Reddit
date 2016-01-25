using System.Collections.Generic;

namespace Reddit250
{
    public interface IReddit250
    {
        bool IsSelfDescriptive(ulong number);
        IEnumerable<ulong> GetSelfDescriptiveNumberOfLength(uint length);
    }
}