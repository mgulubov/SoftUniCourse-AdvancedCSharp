using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Plus_Remove
{
    class Program
    {
        private static List<char[]> _input;
        private static List<int[]> _indexesToRemove;

        static void Main()
        {
            _input = new List<char[]>();
            _indexesToRemove = new List<int[]>();

            while (true)
            {
                char[] chA = Console.ReadLine().Trim().ToCharArray();
                if (chA[0] == 'E')
                {
                    break;
                }
                _input.Add(chA);
            }

            GetIndexesToRemove();
            RemoveIndexes();
            PrintResult();
        }

        private static void PrintResult()
        {
            for (int row = 0; row < _input.Count; row++)
            {
                for (int col = 0; col < _input[row].Length; col++)
                {
                    Console.Write(_input[row][col]);
                }
                Console.WriteLine();
            }
        }

        private static void RemoveIndexes()
        {
            for (int i = 0; i < _indexesToRemove.Count; i++)
            {
                int row = _indexesToRemove[i][0];
                int col = _indexesToRemove[i][1];
                _input[row][col] = '\0';
            }
        }

        private static void GetIndexesToRemove()
        {
            for (int row = 1; row < _input.Count - 1; row++)
            {
                char[] chA = _input[row];
                for (int col = 1; col < chA.Length; col++)
                {
                    if (FormsPlus(row, col))
                    {
                        AddToIndexesList(row, col);
                    }
                }
            }
        }

        private static void AddToIndexesList(int row, int col)
        {
            int[] center = new int[] { row, col };
            int[] up = new int[] { row - 1, col };
            int[] right = new int[] { row, col + 1 };
            int[] down = new int[] { row + 1, col };
            int[] left = new int[] { row, col - 1 };

            _indexesToRemove.Add(center);
            _indexesToRemove.Add(up);
            _indexesToRemove.Add(right);
            _indexesToRemove.Add(down);
            _indexesToRemove.Add(left);
        }

        private static bool FormsPlus(int row, int col)
        {
            char center;
            char up;
            char right;
            char down;
            char left;
            try
            {
                center = char.ToLower(_input[row][col]);
                up = char.ToLower(_input[row - 1][col]);
                right = char.ToLower(_input[row][col + 1]);
                down = char.ToLower(_input[row + 1][col]);
                left = char.ToLower(_input[row][col - 1]);

                if (center == '\0' || up == '\0' || right == '\0' || down == '\0' || left == '\0')
                {
                    return false;
                }

                if (center == up && center == right && center == down && center == left)
                {
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }

            return false;
        }
    }
}
