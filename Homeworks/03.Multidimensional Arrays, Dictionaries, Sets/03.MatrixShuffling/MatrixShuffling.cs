using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.MatrixShuffling
{
    class MatrixShuffling
    {
        private static String[,] _matrix;
        private static int _rows;
        private static int _cols;

        static void Main(string[] args)
        {
            //ACHTUNG!
            //Input format, in the problem description, is wrong
            //Provide the input AS SHOWN IN THE PROBLEM EXAMPLES
            _rows = int.Parse(Console.ReadLine());
            _cols = int.Parse(Console.ReadLine());
            _matrix = new String[_rows, _cols];

            PopulateMatrix();

            ShuffleMatrix();
        }

        private static void PopulateMatrix()
        {
            for (int row = 0; row < _rows; row++)
            {
                //String[] inputArray = Console.ReadLine().Split(' ');

                //int inputArrayIndex = 0;
                for (int col = 0; col < _cols; col++)
                {
                    _matrix[row, col] = Console.ReadLine();
                }
            }
        }

        private static void ShuffleMatrix()
        {
            String[] input = new string[]{"BEGIN"};
            while (input[0] != "END")
            {
                input = Console.ReadLine().Split(' ');
                if (input[0] == "END")
                {
                    break;
                }

                if (InputIsValid(input))
                {
                    int row1 = int.Parse(input[1].ToString());
                    int col1 = int.Parse(input[2].ToString());
                    int row2 = int.Parse(input[3].ToString());
                    int col2 = int.Parse(input[4].ToString());
                    SwapElements(row1, col1, row2, col2);
                    PrintMatrix();
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
        }

        private static bool InputIsValid(String[] array)
        {
            if (array.Length != 5)
            {
                return false;
            }

            return CommandIsCorrect(array) && ParametersAreInBounds(array);
        }

        private static bool CommandIsCorrect(String[] array)
        {
            return array[0] == "swap";
        }

        private static bool ParametersAreInBounds(String[] array)
        {
            return RowsAreValid(array[1], array[3]) && ColsAreValid(array[2], array[4]);
        }

        private static bool RowsAreValid(String str1, String str2)
        {
            int row1;
            int row2;
            try
            {
                row1 = int.Parse(str1);
                row2 = int.Parse(str2);
            }
            catch (Exception)
            {
                return false;
            }

            return (row1 >= 0 && row1 < _rows) && (row2 >= 0 && row2 < _rows);
        }

        private static bool ColsAreValid(String str1, String str2)
        {
            int col1;
            int col2;
            try
            {
                col1 = int.Parse(str1);
                col2 = int.Parse(str2);
            }
            catch (Exception)
            {
                return false;
            }

            return (col1 >= 0 && col1 < _cols) && (col2 >= 0 && col2 < _cols);
        }

        private static void SwapElements(int row1, int col1, int row2, int col2)
        {
            String tmp = _matrix[row1, col1];
            _matrix[row1, col1] = _matrix[row2, col2];
            _matrix[row2, col2] = tmp;
        }

        private static void PrintMatrix()
        {
            for (int row = 0; row < _rows; row++)
            {
                for (int col = 0; col < _cols; col++)
                {
                    Console.Write(_matrix[row, col]);
                    if (col != _cols - 1)
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
