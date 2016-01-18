using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace _08TextGravity
{
    class Program
    {
        private static int _rows;
        private static int _cols;
        private static char[,] _matrix;

        static void Main(string[] args)
        {
            _cols = int.Parse(Console.ReadLine());
            String str = Console.ReadLine();
            _rows = str.Length / _cols;
            if (str.Length % _cols != 0)
            {
                _rows++;
            }

            _matrix = new char[_rows, _cols];

            PopulateMatrix(str);
            //PrintResults();
            LetElementsFall();
            //PrintResults();
            PrintResultsInHtml();
        }

        private static void PrintResultsInHtml()
        {
            Console.Write("<table>");
            for (int row = 0; row < _rows; row++)
            {
                Console.Write("<tr>");
                for (int col = 0; col < _cols; col++)
                {
                    Console.Write("<td>{0}</td>", SecurityElement.Escape(_matrix[row, col].ToString()));
                }
                Console.Write("</tr>");
            }
            Console.Write("</table>");
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

        private static void LetElementsFall()
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
                            if (nextChar == ' ' || nextChar == '\0')
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

        private static void PopulateMatrix(String str)
        {
            int strIndex = 0;
            for (int row = 0; row < _rows; row++)
            {
                for (int col = 0; col < _cols; col++)
                {
                    if (strIndex >= str.Length)
                    {
                        _matrix[row, col] = ' ';
                        continue;
                    }

                    _matrix[row, col] = str[strIndex];
                    strIndex++;
                }
            }
        }
    }
}
