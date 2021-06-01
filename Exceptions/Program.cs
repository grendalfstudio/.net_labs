using System;

namespace Exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            var arrays = new ArraysOperations(8, 10);
            var secondArrays = new ArraysOperations(10, 10);
            arrays.Division();
            secondArrays.Division();

            Console.WriteLine(arrays.FirstArray[7]);
            try
            {
                Console.WriteLine(arrays.FirstArray[8]);
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }

            ArraysOperations thirdArrays = null;
            try
            {
                thirdArrays.Division();
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                var testArrays = new ArraysOperations(13, 10);
            }
            catch (ArgumentException argumentException)
            {
                Console.WriteLine(argumentException.Message);
            }

            try
            {
                var testArrays = new ArraysOperations(-3, 10);
            }
            catch (ArgumentOutOfRangeException argumentException)
            {
                Console.WriteLine(argumentException.Message);
            }
        }
    }
}
