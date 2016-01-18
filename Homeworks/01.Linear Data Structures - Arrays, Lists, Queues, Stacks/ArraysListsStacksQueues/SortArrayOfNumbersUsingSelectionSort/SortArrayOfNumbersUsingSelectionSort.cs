using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.SortArrayOfNumbersUsingSelectionSort
{
    class SortArrayOfNumbersUsingSelectionSort
    {
        static void Main(string[] args)
        {
            Console.Write("Give me thy numbers, peasant: ");
            String[] strArray = Console.ReadLine().Split(' ');
            int[] intArray = new int[strArray.Length];
            try
            {
                intArray = SelectionSort(strArray.Select(int.Parse).ToArray());
            }
            catch (Exception)
            {
                Console.WriteLine("You dare defy me peasant?! I will cut your son's balls off, because of this!");
                Environment.Exit(1);
            }

            Console.WriteLine("Good, peasant, very good! Here's your reward:");
            for (int i = 0; i < intArray.Length; i++)
            {
                Console.Write(intArray[i]);
                if (i != intArray.Length - 1)
                {
                    Console.Write(" ");
                }
            }
            Console.WriteLine();
        }

        private static int[] SelectionSort(int[] array)
        {
            for (int round = 0; round < array.Length - 1; round++)
            {
                int smallestIntIndex = round;
                for (int startIndex = round; startIndex < array.Length - 1; startIndex++)
                {
                    if (array[smallestIntIndex] > array[startIndex + 1])
                    {
                        smallestIntIndex = startIndex + 1;
                    }
                }

                if (smallestIntIndex != round)
                {
                    array = Swap(smallestIntIndex, round, array);
                }
            }

            return array;
        }

        private static int[] Swap(int leftIndex, int rightIndex, int[] array)
        {
            int tmp = array[leftIndex];
            array[leftIndex] = array[rightIndex];
            array[rightIndex] = tmp;

            return array;
        }
    }
}
