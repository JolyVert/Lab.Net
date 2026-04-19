using Microsoft.VisualStudio.TestTools.UnitTesting;
using Net_Lab1;

namespace Tests
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void ShouldReturnAtLeastOneItem()
        {
            Problem p = new Problem(5, 1);

            Result r = p.Solve(10);

            Assert.IsTrue(r.items.Count > 0);
        }

        [TestMethod]
        public void ShouldReturnEmptyWhenCapacityTooSmall()
        {
            Problem p = new Problem(5, 1);

            Result r = p.Solve(0);

            Assert.AreEqual(0, r.items.Count);
        }

        [TestMethod]
        public void ShouldCalculateCorrectValue()
        {
            Problem p = new Problem(3, 1);

            Result r = p.Solve(10);

            Assert.IsTrue(r.totalValue > 0);
            Assert.IsTrue(r.totalWeight <= 10);
        }

        [TestMethod]
        public void ShouldReturnCorrectResultForKnownInstance()
        {
            Problem p = new Problem(0, 1);

            p.items = new List<Item>()
            {
                new Item(10, 5),
                new Item(6, 2),
                new Item(4, 4)
            };

            p.n = 3;

            int capacity = 7;

            Result r = p.Solve(capacity);

            Assert.AreEqual(2, r.items.Count);

            Assert.AreEqual(16, r.totalValue);
            Assert.AreEqual(7, r.totalWeight);
        }

        [TestMethod]
        public void ShouldTakeAllItemsWhenTheyFit()
        {
            Problem p = new Problem(0, 1);

            p.items = new List<Item>()
            {
                new Item(5, 2),
                new Item(3, 1),
                new Item(7, 3)
            };

            p.n = 3;

            int capacity = 10;

            Result r = p.Solve(capacity);

            Assert.AreEqual(3, r.items.Count);
            Assert.AreEqual(15, r.totalValue);
            Assert.AreEqual(6, r.totalWeight);
        }
    }
}