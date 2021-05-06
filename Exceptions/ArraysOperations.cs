using System;
using System.Linq;

namespace Exceptions
{
    public class ArraysOperations
    {

        private readonly int[] restricted = new[] {13, 666, 1488};
        public ArraysOperations(int firstSize, int secondSize)
        {
            ValidateArgs(firstSize, secondSize);
            FirstArray = new int[firstSize];
            SecondArray = new int[secondSize];
        }

        public int[] FirstArray { get; set; }
        public int[] SecondArray { get; set; }

        public void Division()
        {
            try
            {
                FirstArray.Divide(SecondArray);
            }
            catch (InvalidOperationException ex) when (ex.Message.Contains("Arrays"))
            {
                Console.WriteLine(ex.Message);
            }
            catch (DivideByZeroException zeroEx)
            {
                Console.WriteLine(zeroEx.Message);
            }
        }

        private void ValidateArgs(int firstSize, int secondSize)
        {
            if (firstSize < 0)
                throw new ArgumentOutOfRangeException(nameof(firstSize),"Array size must be non-negative");
            if (secondSize < 0) 
                throw new ArgumentOutOfRangeException(nameof(secondSize),"Array size must be non-negative");
            if (restricted.Contains(firstSize))
                throw new ArgumentException("This array size is restricted", nameof(firstSize));
            if (restricted.Contains(secondSize))
                throw new ArgumentException("This array size is restricted", nameof(secondSize));
        }
    }
}