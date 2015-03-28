using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Triplets.Tests
{
    [TestClass]
    public class BitTests
    {
        [TestMethod]
        public void Test()
        {
            var freq = new[] { 4, 2, 7, 5, 1, 3, 6, 4, 6, 6, 3, 3 };
            var bit = new Bit(freq.Length);
            for (var i = 0; i < freq.Length; i++)
                bit.Update(i + 1, freq[i]);

            var cumulFreq = new int[freq.Length];
            for (var i = 0; i < cumulFreq.Length; i++)
                cumulFreq[i] = bit.Read(i + 1);

            Console.WriteLine("Idx: {0}", string.Join(" ", Enumerable.Range(0, freq.Length)));
            Console.WriteLine("Frq: {0}", string.Join(" ", freq));
            Console.WriteLine("Sum: {0}", string.Join(" ", cumulFreq));

            Assert.IsTrue(new[] { 4, 6, 13, 18, 19, 22, 28, 32, 38, 44, 47, 50 }.SequenceEqual(cumulFreq));
        }
    }
}
