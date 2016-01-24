using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Reddit250
{
    public class Solution : IReddit250
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

        private long GetLowerBound(int length)
        {
            return Multipler(1, length);
        }

        private long GetUpperBound(int length)
        {
            var start = length;
            return Multipler(start, length);
        }

        private long Multipler(long start, int length)
        {
            for (var i = 0; i < length - 1; i++)
            {
                start *= 10;
            }
            return start;
        }

        private long GetNextValue(long currentValue, long upperBound, int length)
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

        private int SumDigits(long number)
        {
            var sum = 0;
            while (number != 0)
            {
                sum += (int)(number % 10);
                number /= 10;
            }
            return sum;
        }

        private long GetInterval(int length)
        {
            var upperBound = length - 10 > 0 ? length - 10 : 0;
            return Multipler(10, upperBound);
        }
    }
}