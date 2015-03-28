using System;
using System.Collections.Generic;

namespace Triplets
{
    public static class CubicComplexity
    {
        public static long Count(uint[] a)
        {
            var triplets = new HashSet<Tuple<uint, uint, uint>>();

            for (var i = 0; i < a.Length; i++)
            {
                for (var j = i + 1; j < a.Length; j++)
                {
                    if (a[j] <= a[i]) continue;
                    for (var k = j + 1; k < a.Length; k++)
                    {
                        if (a[k] <= a[j]) continue;
                        var triplet = new Tuple<uint, uint, uint>(a[i], a[j], a[k]);
                        if (triplets.Contains(triplet)) continue;
                        triplets.Add(triplet);
                    }
                }
            }

            return triplets.Count;
        }
    }
}
