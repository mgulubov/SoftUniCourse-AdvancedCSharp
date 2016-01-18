using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02TargetPractice
{
    class Program
    {
        private static int _rows;
        private static int _cols;
        private static char[,] _matrix;

        static void Main(string[] args)
        {
            String[] p = Console.ReadLine().Trim().Split(' ');

            _rows = int.Parse(p[0]);
            _cols = int.Parse(p[1]);

            String snake = Console.ReadLine();
            _matrix = new char[_rows, _cols];
            PopulateMatrix(snake);

            String[] shot = Console.ReadLine().Split(' ');

            int shotRow = int.Parse(shot[0]);
            int shotCol = int.Parse(shot[1]);
            int shotRadius = int.Parse(shot[2]);

            MakeShot(shotRow, shotCol, shotRadius);
            ObjectsFall();

            PrintResults();
        }

        private static void PrintResults()
        {
            for (int row = 0; row < _rows; row++)
            {
                for (int col = 0; col < _cols; col++)
                {
                    Console.Write(_matrix[row, col].ToString());
                }
                Console.WriteLine();
            }
        }

        private static void ObjectsFall()
        {
            for (int row = _rows - 2; row >= 0; row--)
            {
                for (int col = 0; col < _cols; col++)
                {
                    int nextRow = row + 1;
                    char current = _matrix[row, col];
                    while (true)
                    {
                        char nextChar;
                        try
                        {
                            nextChar = _matrix[nextRow, col];
                            if (nextChar == ' ')
                            {
                                _matrix[nextRow, col] = current;
                                _matrix[nextRow - 1, col] = ' ';
                                current = _matrix[nextRow, col];
                                nextRow++;
                                continue;
                            }
                            break;
                        }
                        catch (Exception)
                        {
                            break;
                        }
                    }
                }
            }
        }

        private static void MakeShot(int shotRow, int shotCol, int shotRadius)
        {
            for (int row = 0; row < _rows; row++)
            {
                for (int col = 0; col < _cols; col++)
                {
                    if (IsInCircle(shotRow, shotCol, row, col, shotRadius))
                    {
                        _matrix[row, col] = ' ';
                    }
                }
            }
        }

        private static bool IsInCircle(int startX, int startY, int x, int y, int r)
        {
            return ((x - startX) * (x - startX) + (y - startY) * (y - startY)) <= r * r;
        }

        private static void PopulateMatrix(String snake)
        {
            int snakeIndex = 0;
            int startRow = _rows - 1;
            int startCol = _cols - 1;

            int flag = 0;
            for (int row = _rows - 1; row >= 0; row--)
            {
                if (flag == 0)
                {
                    for (int col = _cols - 1; col >= 0; col--)
                    {
                        if (snakeIndex >= snake.Length)
                        {
                            snakeIndex = 0;
                        }
                        _matrix[row, col] = snake[snakeIndex];
                        snakeIndex++;
                    }
                    flag = 1;
                }
                else
                {
                    for (int col = 0; col < _cols; col++)
                    {
                        if (snakeIndex >= snake.Length)
                        {
                            snakeIndex = 0;
                        }
                        _matrix[row, col] = snake[snakeIndex];
                        snakeIndex++;
                    }
                    flag = 0;
                }
            }
        }
    }
}
