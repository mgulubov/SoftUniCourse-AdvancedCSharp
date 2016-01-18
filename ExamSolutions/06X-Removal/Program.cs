using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06X_Removal
{
    class Program
    {
        private static List<char[]> _list;
        private static List<String> _indexesToRemove;

        public static void Main()
        {
            _list = new List<char[]>();
            _indexesToRemove = new List<String>();

            String input;
            char[] charArray;

            while (true)
            {
                input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }

                charArray = input.ToCharArray();
                _list.Add(charArray);
            }

            GetIndexesToRemove();

            //if (_indexesToRemove.Count != 0)
            //{
            RemoveIndexes();
            //}

            PrintResults();
        }

        private static void PrintResults()
        {
            int printed;
            for (int i = 0; i < _list.Count; i++)
            {
                printed = 0;
                for (int j = 0; j < _list[i].Length; j++)
                {
                    if (_list[i][j] == ' ')
                    {
                        continue;
                    }
                    Console.Write(_list[i][j].ToString());
                    printed++;
                }
                if (printed != 0)
                {
                    Console.WriteLine();
                }
            }
        }

        private static void RemoveIndexes()
        {
            for (int i = 0; i < _indexesToRemove.Count; i++)
            {
                String[] arr = _indexesToRemove[i].Split('-');
                int row = int.Parse(arr[0]);
                int col = int.Parse(arr[1]);
                _list[row][col] = ' ';
            }
        }

        private static void GetIndexesToRemove()
        {
            for (int row = 1; row < _list.Count - 1; row++)
            {
                for (int col = 1; col < _list[row].Length; col++)
                {
                    if (XIsFormed(row, col))
                    {
                        _indexesToRemove.Add((row - 1) + "-" + (col - 1));
                        _indexesToRemove.Add((row - 1) + "-" + (col + 1));
                        _indexesToRemove.Add((row + 1) + "-" + (col - 1));
                        _indexesToRemove.Add((row + 1) + "-" + (col + 1));
                        _indexesToRemove.Add(row + "-" + col);
                    }
                }
            }
        }

        private static bool XIsFormed(int row, int col)
        {
            char current;
            char upLeft;
            char upRight;
            char downLeft;
            char downRight;

            try
            {
                current = _list[row][col];
                upLeft = _list[row - 1][col - 1];
                upRight = _list[row - 1][col + 1];
                downLeft = _list[row + 1][col - 1];
                downRight = _list[row + 1][col + 1];
            }
            catch (Exception)
            {
                return false;
            }

            return Char.ToLower(current).Equals(Char.ToLower(upLeft)) &&
                    Char.ToLower(current).Equals(Char.ToLower(upRight)) &&
                    Char.ToLower(current).Equals(Char.ToLower(downLeft)) &&
                    Char.ToLower(current).Equals(Char.ToLower(downRight));
        }
    }
}
