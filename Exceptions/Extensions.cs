using System;

namespace Exceptions
{
    public static class Extensions
    {
        public static int[] Divide(this int[] first, int[] second)
        {
            if (first.Length != second.Length)
                throw new InvalidOperationException("Arrays must be same length");

            var result = new int[first.Length];
            for (var i = 0; i < first.Length; i++)
            {
                if (second[i] is 0) throw new DivideByZeroException($"Element {i} of second array is 0");
                result[i] = first[i] / second[i];
            }
            return result;
        }
    }
}