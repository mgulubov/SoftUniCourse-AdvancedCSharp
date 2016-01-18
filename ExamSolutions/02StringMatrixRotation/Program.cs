using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02StringMatrixRotation
{
    class Program
    {
        private static List<char[]> _input;
        private static int[] _flag;
        private static int _maxLength;

        static void Main()
        {
            _input = new List<char[]>();
            _flag = new int[] { 1, 2, 3, 4 };
            _maxLength = -1;

            String command = Console.ReadLine();

            List<String> tmp = new List<String>();
            while (true)
            {
                String str = Console.ReadLine();
                if (str == "END")
                {
                    break;
                }

                if (_maxLength < str.Length)
                {
                    _maxLength = str.Length;
                }

                tmp.Add(str);
            }

            MakeStringsEqual(tmp);

            //Console.WriteLine(command.Substring(command.IndexOf('(') + 1, (command.IndexOf(')') - 1) - command.IndexOf('(')));
            int rotations = int.Parse(command.Substring(command.IndexOf('(') + 1, (command.IndexOf(')') - 1) - command.IndexOf('('))) / 90;
            int position = GetPosition(rotations);

            PrintResult(position);
        }

        private static void MakeStringsEqual(List<String> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                _input.Add(list[i].PadRight(_maxLength).ToCharArray());
            }
        }

        private static void PrintResult(int position)
        {
            switch (position)
            {
                case 0:
                    PrintLeftRight();
                    break;
                case 1:
                    PrintUpDown();
                    break;
                case 2:
                    PrintRightLeft();
                    break;
                case 3:
                    PrintDownUp();
                    break;
                default:
                    throw new Exception();
            }
        }

        private static void PrintDownUp()
        {
            for (int col = _maxLength - 1; col >= 0; col--)
            {
                for (int row = 0; row < _input.Count; row++)
                {
                    Console.Write(_input[row][col]);
                }
                Console.WriteLine();
            }
        }

        private static void PrintRightLeft()
        {
            for (int row = _input.Count - 1; row >= 0; row--)
            {
                for (int col = _maxLength - 1; col >= 0; col--)
                {
                    Console.Write(_input[row][col]);
                }
                Console.WriteLine();
            }
        }

        private static void PrintUpDown()
        {
            for (int col = 0; col < _maxLength; col++)
            {
                for (int row = _input.Count - 1; row >= 0; row--)
                {
                    Console.Write(_input[row][col]);
                }
                Console.WriteLine();
            }
        }

        private static void PrintLeftRight()
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

        private static int GetPosition(int rotations)
        {
            int flagIndex = 0;
            for (int i = 0; i < rotations; i++)
            {
                flagIndex++;
                if (flagIndex >= _flag.Length)
                {
                    flagIndex = 0;
                }
            }

            return flagIndex;
        }
    }
}
