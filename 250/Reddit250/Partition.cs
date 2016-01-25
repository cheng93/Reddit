using System.Collections.Generic;
using System.Linq;

namespace Reddit250
{
    public class Partition
    {
        public ICollection<uint> Values { get; private set; }

        public Partition(ICollection<uint> values)
        {
            Values = values;
        }

        public static IEnumerable<Partition> GetPartitions(uint number)
        {
            var output = new List<Partition>();
            for (var i = number; i > 0; i--)
            {
                var list = new List<uint> {i};
                bool yielded = false;
                var partitions = GetPartitions(number - i);
                foreach (var partition in partitions)
                {
                    var partitionedList = new List<uint>(list);
                    partitionedList.AddRange(partition.Values);
                    yielded = true;
                    output.Add(new Partition(partitionedList));
                }
                if (!yielded)
                {
                    output.Add(new Partition(list));
                }
            }
            return output.Distinct();
        }

        public override bool Equals(object obj)
        {
            var partition = obj as Partition;
            if (partition == null)
            {
                return false;
            }
            return Equals(partition);
        }

        public bool Equals(Partition partition)
        {
            if (partition == null)
            {
                return false;
            }

            if (Values.Count != partition.Values.Count)
            {
                return false;
            }

            return Values.Distinct().All(value => Values.Count(v => v == value) == partition.Values.Count(p => p == value));
        }

        public override int GetHashCode()
        {
            return (Values != null ? Values.Sum(v => v).GetHashCode() : 0);
        }
    }
}
