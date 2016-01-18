using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.MaximalSum
{
    class MaximalSum
    {
        private static int _rows;
        private static int _cols;
        private static int[,] _matrix;

        static void Main(string[] args)
        {
            int[] rowsCols = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            _rows = rowsCols[0];
            _cols = rowsCols[1];
            _matrix = new int[_rows, _cols];

            PopulateMatrix();

            int[,] maximumSumMatrix = GetSubMatrixWithMaximumSum();

            Console.WriteLine("Sum: {0}", GetMatrixSum(maximumSumMatrix, 3));
            PrintMatrix(maximumSumMatrix, 3);
        }

        private static void PopulateMatrix()
        {
            for (int row = 0; row < _rows; row++)
            {
                int[] inputArray = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                int i = 0;
                for (int col = 0; col < _cols; col++)
                {
                    _matrix[row, col] = inputArray[i];
                    i++;
                }
            }
        }

        private static int[,] PopulateMatrix(int startRow, int endRow, int startCol, int endCol)
        {
            int[,] result = new int[3, 3];
            int resultRow = 0;
            int resultCol = 0;
            for (int row = startRow; row <= endRow; row++)
            {
                resultCol = 0;
                for (int col = startCol; col <= endCol; col++)
                {
                    result[resultRow, resultCol] = _matrix[row, col];
                    resultCol++;
                }
                resultRow++;
            }

            return result;
        }

        private static int[,] GetSubMatrixWithMaximumSum()
        {
            int[,] resultMatrix = new int[3, 3];
            int[,] tmpMatrix = new int[3, 3];
            int maxSum = 0;
            int startRow;
            int endRow;
            int startCol;
            int endCol;
            for (int row = 0; row < _rows - 2; row++)
            {
                startRow = row;
                endRow = row + 2;
                for (int col = 0; col < _cols - 2; col++)
                {
                    startCol = col;
                    endCol = col + 2;

                    tmpMatrix = PopulateMatrix(startRow, endRow, startCol, endCol);
                    int sum = GetMatrixSum(tmpMatrix, 3);

                    if (sum > maxSum)
                    {
                        resultMatrix = tmpMatrix;
                        maxSum = sum;
                    }
                }
            }

            return resultMatrix;
        }

        private static int GetMatrixSum(int[,] matrix, int rows)
        {
            int sum = 0;
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    sum += matrix[row, col];
                }
            }

            return sum;
        }

        private static void PrintMatrix(int[,] matrix, int rows)
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    Console.Write(matrix[row, col]);
                    if (col != 2)
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
