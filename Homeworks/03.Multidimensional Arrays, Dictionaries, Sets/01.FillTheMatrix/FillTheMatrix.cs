using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.FillTheMatrix
{
    class FillTheMatrix
    {
        private static int _n;
        private static int[,] _matrix;

        static void Main(string[] args)
        {
            Console.Write("_n: ");
            _n = int.Parse(Console.ReadLine());
            _matrix = new int[_n, _n];

            Console.WriteLine("Pattern A:");
            PopulateMatrixPatternA();
            PrintMatrix();

            _matrix = new int[_n, _n];

            Console.WriteLine("Pattern B:");
            PopulateMatrixPatternB();
            PrintMatrix();
        }

        private static void PopulateMatrixPatternA()
        {
            int num = 1;
            for (int col = 0; col < _n; col++)
            {
                for (int row = 0; row < _n; row++)
                {
                    _matrix[row, col] = num;
                    num++;
                }
            }
        }

        private static void PopulateMatrixPatternB()
        {
            int num = 1;
            int flag = 0;
            for (int col = 0; col < _n; col++)
            {
                if (flag == 0)
                {
                    num = PopulateRowTopDown(col, num);
                    flag = 1;
                }
                else
                {
                    num = PopulateRowDownUp(col, num);
                    flag = 0;
                }
            }
        }

        private static int PopulateRowDownUp(int col, int num)
        {
            for (int row = _n - 1; row >= 0; row--)
            {
                _matrix[row, col] = num;
                num++;
            }

            return num;
        }

        private static int PopulateRowTopDown(int col, int num)
        {
            for (int row = 0; row < _n; row++)
            {
                _matrix[row, col] = num;
                num++;
            }

            return num;
        }

        private static void PrintMatrix()
        {
            for (int row = 0; row < _n; row++)
            {
                for (int col = 0; col < _n; col++)
                {
                    Console.Write(_matrix[row, col]);
                    if (col != _n - 1)
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
