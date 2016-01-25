using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Reddit250.UnitTest.PartitionTests
{
    [TestClass]
    public class GetPartitionsTest
    {
        [TestMethod]
        public void One()
        {
            var expected = new List<Partition>
            {
                new Partition(new List<int> {1})
            };

            var actual = Partition.GetPartitions(1).ToList();
            CollectionAssert.AreEquivalent(expected, actual);
        }

        [TestMethod]
        public void Two()
        {
            var expected = new List<Partition>
            {
                new Partition(new List<int> {2}),
                new Partition(new List<int> {1,1})
            };
            var actual = Partition.GetPartitions(2).ToList();
            CollectionAssert.AreEquivalent(expected, actual);
        }

        [TestMethod]
        public void Three()
        {
            var expected = new List<Partition>
            {
                new Partition(new List<int> {3}),
                new Partition(new List<int> {2,1}),
                new Partition(new List<int> {1,1,1})
            };
            var actual = Partition.GetPartitions(3).ToList();
            CollectionAssert.AreEquivalent(expected, actual);
        }

        [TestMethod]
        public void Four()
        {
            var expected = new List<Partition>
            {
                new Partition(new List<int> {4}),
                new Partition(new List<int> {3,1}),
                new Partition(new List<int> {2,2}),
                new Partition(new List<int> {2,1,1}),
                new Partition(new List<int> {1,1,1,1})
            };
            var actual = Partition.GetPartitions(4).ToList();
            CollectionAssert.AreEquivalent(expected, actual);
        }
    }
}
