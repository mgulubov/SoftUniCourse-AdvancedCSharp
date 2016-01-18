using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.LargerThanNeighbours
{
    class LargerThanNeighbours
    {
        static void Main(string[] args)
        {
            Console.Write("Num Array: ");
            int[] intArray = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();

            for (int i = 0; i < intArray.Length; i++)
            {
                Console.WriteLine(IsLargerThanItsNeighbours(intArray, i));
            }
        }

        private static bool IsLargerThanItsNeighbours(int[] array, int index)
        {
            return IsLargerThan(array, index, index - 1) && IsLargerThan(array, index, index + 1);
        }

        private static bool IsLargerThan(int[] array, int index, int indexToCheck)
        {
            if (indexToCheck < 0 || indexToCheck >= array.Length)
            {
                return true;
            }

            return array[index] > array[indexToCheck];
        }
    }
}
