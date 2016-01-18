using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.LegoBlocks
{
    class LegoBlocks
    {
        private static int _n;

        static void Main(string[] args)
        {
            _n = int.Parse(Console.ReadLine());

            int[][] leftJaggedArray = new int[_n][];
            int[][] rightJaggedArray = new int[_n][];
            int[][] joinedJaggedArray = new int[_n][];
            
            leftJaggedArray = PopulateJaggedArray(leftJaggedArray);
            rightJaggedArray = PopulateJaggedArray(rightJaggedArray);

            rightJaggedArray = ReverseArrayElementsIn(rightJaggedArray);

            joinedJaggedArray = JoinJaggedArrays(leftJaggedArray, rightJaggedArray);

            if (IsJagged(joinedJaggedArray))
            {
                Console.WriteLine("The total number of cells is: {0}", GetCellsCountOf(joinedJaggedArray));
            }
            else
            {
                foreach (var arr in joinedJaggedArray)
                {
                    Console.WriteLine("[{0}]", String.Join(", ", arr));
                }
            }
        }

        private static int GetCellsCountOf(int[][] jaggedArray)
        {
            int count = 0;
            for (int row = 0; row < _n; row++)
            {
                count += jaggedArray[row].Length;
            }

            return count;
        }

        private static bool IsJagged(int[][] jaggedArray)
        {
            int expectedLength = jaggedArray[0].Length;
            for (int row = 1; row < _n; row++)
            {
                if (jaggedArray[row].Length != expectedLength)
                {
                    return true;
                }
            }

            return false;
        }

        private static int[][] JoinJaggedArrays(int[][] leftJaggedArray, int[][] rightJaggedArray)
        {
            int[][] result = new int[_n][];
            for (int row = 0; row < _n; row++)
            {
                int combinedLength = leftJaggedArray[row].Length + rightJaggedArray[row].Length;
                int[] arr = new int[combinedLength];

                leftJaggedArray[row].CopyTo(arr, 0);
                rightJaggedArray[row].CopyTo(arr, leftJaggedArray[row].Length);

                result[row] = arr;
            }

            return result;
        }

        private static int[][] ReverseArrayElementsIn(int[][] jaggedArray)
        {
            for (int row = 0; row < _n; row++)
            {
                jaggedArray[row] = jaggedArray[row].Reverse().ToArray();
            }

            return jaggedArray;
        }

        private static int[][] PopulateJaggedArray(int[][] jaggedArray)
        {
            for (int row = 0; row < _n; row++)
            {
                List<String> input = Console.ReadLine().Trim().Split(' ').ToArray().ToList();
                input.RemoveAll(ElementIsEmpty);

                jaggedArray[row] = input.ToArray().Select(int.Parse).ToArray();
            }

            return jaggedArray;
        }

        //Predicate for RemoveAll in PopulateJaggedArray()
        private static bool ElementIsEmpty(String str)
        {
            return str.Equals("");
        }
    }
}
