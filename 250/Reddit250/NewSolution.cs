using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Reddit250
{
    public class NewSolution : IReddit250
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
            var partitions = Partition.GetPartitions(length);
            foreach (var partition in partitions)
            {
                var number = ConstructNumber(partition, length);
                var descriptiveNumber = GetDescriptiveNumber(number);
                if (IsSelfDescriptive(descriptiveNumber))
                {
                    yield return descriptiveNumber;
                }
            }

        }

        private ulong ConstructNumber(Partition partition, uint length)
        {
            var multiplier = Multiplier(1, length);
            ulong sum = 0;
            foreach (var value in partition.Values)
            {
                sum += value * multiplier;
                multiplier /= 10;
            }
            return sum;
        }

        private ulong Multiplier(ulong index, uint length)
        {
            for (var i = 1; i < length; i++)
            {
                index *= 10;
            }
            return index;
        }

        private ulong GetDescriptiveNumber(ulong number)
        {
            var numberAsString = number.ToString();
            var outputString = new StringBuilder();
            for (var i = 0; i < numberAsString.Length; i++)
            {
                outputString.Append(numberAsString.Count(c => int.Parse(c.ToString()) == i));
            }
            return ulong.Parse(outputString.ToString());
        }
    }
}
