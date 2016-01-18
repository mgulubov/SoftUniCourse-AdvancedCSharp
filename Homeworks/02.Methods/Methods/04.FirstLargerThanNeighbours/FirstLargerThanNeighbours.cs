using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.FirstLargerThanNeighbours
{
    class FirstLargerThanNeighbours
    {
        static void Main(string[] args)
        {
            var firstIntArray = new int[] 
                                        {
                                            1, 3, 4, 5, 1, 0, 5
                                        };
            var secondIntArray = new int[] 
                                        { 
                                            1, 2, 3, 4, 5, 6, 6 
                                        };
            var thirdIntArray = new int[]
                                        {
                                            1, 1, 1
                                        };

            Console.WriteLine(GetIndexOfFirstElementLargerThanItsNeighbours(firstIntArray));
            Console.WriteLine(GetIndexOfFirstElementLargerThanItsNeighbours(secondIntArray));
            Console.WriteLine(GetIndexOfFirstElementLargerThanItsNeighbours(thirdIntArray));
        }

        private static int GetIndexOfFirstElementLargerThanItsNeighbours(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (IsLargerThanNeighbours(array, i))
                {
                    return i;
                }
            }

            return -1;
        }

        private static bool IsLargerThanNeighbours(int[] array, int index)
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
