using System;
using System.Collections.Generic;

namespace Triplets
{
    public static class LinearithmicComplexity
    {
        // Count in O(n.log n)
        public static long Count(uint[] a)
        {
            var r = Rank(a);    // O(n.log n)

            var smallerBit = new Bit(r.Length);
            var smallerSet = new Dictionary<int, int>();
            var smallers = new int[r.Length];
            for (var i = 0; i < r.Length; i++)  // O(n.log n)
            {
                int smaller;
                if (smallerSet.TryGetValue(r[i], out smaller))
                {
                    smallers[i] = smallerBit.Read(r[i] - 1) - smaller;
                }
                else
                {
                    smallers[i] = smallerBit.Read(r[i] - 1);
                    smallerSet[r[i]] = smallers[i];
                    smallerBit.Update(r[i], 1);   // O(log n)
                }
            }

            var largerBit = new Bit(r.Length);
            var largerSet = new Dictionary<int, int>();
            var largers = new int[r.Length];
            for (var i = r.Length - 1; i >= 0; i--)  // O(n.log n)            
            {
                if (largerSet.ContainsKey(r[i]))
                {
                    largers[i] = largerBit.Read(r.Length - r[i]); // O(log n)
                }
                else
                {
                    largers[i] = largerBit.Read(r.Length - r[i]); // O(log n)
                    largerSet[r[i]] = largers[i];
                    largerBit.Update(r.Length - r[i] + 1, 1);   // O(log n)
                }
            }

#if DEBUG
            Console.WriteLine("a = {0}", string.Join(" ", a));
            Console.WriteLine("r = {0}", string.Join(" ", r));
            Console.WriteLine("Smaller = {0}", string.Join(" ", smallers));
            Console.WriteLine("Larger = {0}", string.Join(" ", largers));
#endif

            long count = 0;
            for (var i = 0; i < r.Length; i++)
            {
                count += smallers[i] * largers[i];
            }
            return count;
        }

        // Rank array from 0 to Length-1 in O(n.log n)
        public static int[] Rank<T>(T[] a)
        {
            var s = (T[])a.Clone();
            Array.Sort(s);  // O(n.log n)

            var indexByValue = new Dictionary<T, int>();
            int rank = 1;
            for (var i = 0; i < s.Length; i++)  // O(n)
            {
                var key = s[i];
                if (!indexByValue.ContainsKey(key)) indexByValue[key] = rank;   // O(1)
                rank++;
            }

            var ranks = new int[a.Length];
            for (var i = 0; i < a.Length; i++)  // O(n)
                ranks[i] = indexByValue[a[i]];
            return ranks;
        }
    }
}
