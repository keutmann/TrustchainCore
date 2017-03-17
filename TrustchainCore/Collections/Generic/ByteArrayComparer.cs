using System;
using System.Collections.Generic;
using System.Linq;

namespace TrustchainCore.Collections.Generic
{
    public class ByteArrayComparer : IEqualityComparer<byte[]>
    {
        public bool Equals(byte[] left, byte[] right)
        {
            if (left == null || right == null)
                return left == right;

            if (ReferenceEquals(left, right))
                return true;

            if (left.Length != right.Length)
                return false;

            return left.SequenceEqual(right);
        }

        public int GetHashCode(byte[] key)
        {
            if (key == null)
                throw new ArgumentNullException("key");
            return key.Sum(b => b);
        }
    }

}
