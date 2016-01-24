using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Reddit250
{
    public class NewSolution : IReddit250
    {
        public bool IsSelfDescriptive(long number)
        {
            var numberAsString = number.ToString(CultureInfo.InvariantCulture);
            var upperBound = numberAsString.Length < 10 ? numberAsString.Length : 10;

            for (var i = 0; i < upperBound; i++)
            {
                if (numberAsString.Count(c => c == i.ToString()[0]) != int.Parse(numberAsString.Substring(i, 1)))
                {
                    return false;
                }
            }
            return true;
        }

        public IEnumerable<long> GetSelfDescriptiveNumberOfLength(int length)
        {
            throw new NotImplementedException();
        }
    }
}
