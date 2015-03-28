using System;

namespace Triplets
{
    /// <summary>
    /// Binary Indexed Tree implementation
    /// See. https://comeoncodeon.wordpress.com/2009/09/17/binary-indexed-tree-bit/
    /// See. https://theoryofprogramming.wordpress.com/2014/12/24/binary-indexed-tree-or-fenwick-tree/
    /// </summary>
    public class Bit
    {
        private readonly int[] _tree;

        public Bit(int length)
        {
            _tree = new int[length + 1];
        }

        public void Update(int idx, int value)
        {
#if DEBUG
            var idxCopy = idx;
#endif
            if (idx < 1) throw new IndexOutOfRangeException("Idx must be greather or equal to 1");

            while (idx < _tree.Length)
            {
                _tree[idx] += value;
                idx += idx & -idx;
            }
#if DEBUG
            Console.WriteLine("BIT Update (Index={0}, Value={1}) : {2}", idxCopy, value, string.Join(" ", _tree));
#endif
        }

        public int Read(int idx)
        {
            int sum = 0;
            while (idx > 0)
            {
                sum += _tree[idx];
                idx -= (idx & -idx);
            }
            return sum;
        }
    }
}
