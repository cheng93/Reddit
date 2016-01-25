using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Reddit250.UnitTest.PartitionTests
{
    [TestClass]
    public class EqualsTest
    {
        [TestMethod]
        public void Null_False()
        {
            var partition = new Partition(new List<int> { 1 });
            object obj = null;
            Assert.IsFalse(partition.Equals(obj));
        }

        [TestMethod]
        public void String_False()
        {
            var partition = new Partition(new List<int> { 1 });
            var obj = "Hello World";
            Assert.IsFalse(partition.Equals(obj));
        }

        [TestMethod]
        public void BothEmpty_True()
        {
            var partition = new Partition(new List<int>());
            var obj = new Partition(new List<int>());
            Assert.IsTrue(partition.Equals(obj));
        }

        [TestMethod]
        public void OneEmpty_False()
        {
            var partition = new Partition(new List<int>() { 1 });
            var obj = new Partition(new List<int>());
            Assert.IsFalse(partition.Equals(obj));
        }

        [TestMethod]
        public void Simple_True()
        {
            var partition = new Partition(new List<int>() { 1 });
            var obj = new Partition(new List<int>() { 1 });
            Assert.IsTrue(partition.Equals(obj));
        }

        [TestMethod]
        public void Complex_True()
        {
            var partition = new Partition(new List<int>() { 1, 2, 2, 3, 4 });
            var obj = new Partition(new List<int>() { 1, 2, 2, 3, 4 });
            Assert.IsTrue(partition.Equals(obj));
        }

        [TestMethod]
        public void DifferentCount_False()
        {
            var partition = new Partition(new List<int>() { 1 });
            var obj = new Partition(new List<int>() { 1, 2 });
            Assert.IsFalse(partition.Equals(obj));
        }

        [TestMethod]
        public void Simple_SameElements_DifferentOrder_True()
        {
            var partition = new Partition(new List<int>() { 2, 1 });
            var obj = new Partition(new List<int>() { 1, 2 });
            Assert.IsTrue(partition.Equals(obj));
        }

        [TestMethod]
        public void Complex_SameElements_DifferentOrder_True()
        {
            var partition = new Partition(new List<int>() { 2, 1, 2, 4, 3 });
            var obj = new Partition(new List<int>() { 1, 2, 2, 3, 4 });
            Assert.IsTrue(partition.Equals(obj));
        }

        [TestMethod]
        public void Simple_SameCount_DifferentElements_False()
        {
            var partition = new Partition(new List<int>() { 1 });
            var obj = new Partition(new List<int>() { 2 });
            Assert.IsFalse(partition.Equals(obj));
        }

        [TestMethod]
        public void Complex_SameCount_DifferentElements_False()
        {
            var partition = new Partition(new List<int>() { 1, 2, 2, 3, 4 });
            var obj = new Partition(new List<int>() { 1, 2, 3, 4, 4 });
            Assert.IsFalse(partition.Equals(obj));
        }
    }
}
