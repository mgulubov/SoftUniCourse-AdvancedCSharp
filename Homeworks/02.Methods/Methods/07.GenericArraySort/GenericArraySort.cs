using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.GenericArraySort
{
    class GenericArraySort
    {
        static void Main(string[] args)
        {
            var intArray = new int[] 
                                    {1, 3, 4, 5, 1, 0, 5};
            
            var stringArray = new String[] { "zaz", "cba", "baa", "azis" }; //zaz, cba && azis?! Couldn't have gotten more random than that :D

            var dateArray = new DateTime[] 
                                        {
                                            new DateTime(2002, 3, 1),
                                            new DateTime(2015, 5, 6),
                                            new DateTime(2014, 1, 1)
                                        };

            PrintArray(SortArray(intArray));
            PrintArray(SortArray(stringArray));
            PrintArray(SortArray(dateArray));
        }

        private static void PrintArray<T>(T[] array)
        {
            Console.WriteLine("{0}", String.Join(", ", array));
        }

        private static T[] SortArray<T>(T[] array)
        {
            return SelectionSort(array);
        }

        private static T[] SelectionSort<T>(T[] array)
        {
            int smallestIntIndex;
            int check;
            for (int round = 0; round < array.Length - 1; round++)
            {
                smallestIntIndex = round;
                for (int startIndex = round; startIndex < array.Length - 1; startIndex++)
                {
                    check = ((IComparable)array[smallestIntIndex]).CompareTo(array[startIndex + 1]);
                    if (check > 0)
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

        private static T[] Swap<T>(int left, int right, T[] array)
        {
            T tmp = array[left];
            array[left] = array[right];
            array[right] = tmp;

            return array;
        }
    }
}
