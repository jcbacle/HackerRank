using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Triplets.Tests
{
    /// <summary>
    /// Summary description for LinearithmicComplexityTests
    /// </summary>
    [TestClass]
    public class LinearithmicComplexityTests
    {
        [TestMethod]
        public void RankTest()
        {
            var testCase = new uint[] { 1, 1, 2, 2, 3, 4 };
            var ranks = LinearithmicComplexity.Rank(testCase);
            Console.WriteLine("array: {0}", string.Join(" ", testCase));
            Console.WriteLine("rank: {0}", string.Join(" ", ranks));            
        }

        [TestMethod]
        public void TestCase_0()
        {
            var a = new uint[] {1, 1, 2, 2, 3, 4};
            var res = LinearithmicComplexity.Count(a);
            Assert.AreEqual(4, res);
        }

        [TestMethod]
        public void TestCase_1()
        {
            var a = new uint[] {1, 1, 5, 4, 3, 6, 6, 5, 9, 10};
            var res = LinearithmicComplexity.Count(a);
            Assert.AreEqual(28, res);
        }

        [TestMethod]
        public void TestCase_2()
        {
            var a = new uint[] {1, 5, 6, 5, 9};
            var res = LinearithmicComplexity.Count(a);
            Assert.AreEqual(4, res);
        }
    }
}
