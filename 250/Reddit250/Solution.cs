using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Reddit250
{
    public class Solution : IReddit250
    {
        public bool IsSelfDescriptive(ulong number)
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

        public IEnumerable<ulong> GetSelfDescriptiveNumberOfLength(uint length)
        {
            var start = GetLowerBound(length);
            var end = GetUpperBound(length);
            for (var i = start; i < end; i = GetNextValue(i, end, length))
            {
                if (IsSelfDescriptive(i))
                {
                    yield return i;
                }
            }
        }

        private ulong GetLowerBound(uint length)
        {
            return Multipler(1, length);
        }

        private ulong GetUpperBound(uint length)
        {
            var start = length;
            return Multipler(start, length);
        }

        private ulong Multipler(ulong start, uint length)
        {
            for (var i = 0; i < length - 1; i++)
            {
                start *= 10;
            }
            return start;
        }

        private ulong GetNextValue(ulong currentValue, ulong upperBound, uint length)
        {
            var interval = GetInterval(length);
            for (var i = currentValue + interval; i < upperBound; i = i + interval)
            {
                if (SumDigits(i) == length)
                {
                    return i;
                }
            }
            return upperBound;
        }

        private uint SumDigits(ulong number)
        {
            uint sum = 0;
            while (number != 0)
            {
                sum += (uint)(number % 10);
                number /= 10;
            }
            return sum;
        }

        private ulong GetInterval(uint length)
        {
            var upperBound = length - 10 > 0 ? length - 10 : 0;
            return Multipler(10, upperBound);
        }
    }
}