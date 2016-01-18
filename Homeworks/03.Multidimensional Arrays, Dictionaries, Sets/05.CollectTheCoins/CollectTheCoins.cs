using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.CollectTheCoins
{
    class CollectTheCoins
    {
        private static char[][] _board;
        private static char[] _commands;
        private static int[] _currentPosition;
        private static int _rows;
        private static int _collectedCoins;
        private static int _hitWalls;

        static void Main(string[] args)
        {
            _rows = 4;
            _collectedCoins = 0;
            _hitWalls = 0;
            _currentPosition = new int[] { 0, 0 };
            PopulateBoard();
            GetCommand();

            ExecuteCommand();

            PrintResult();
        }

        private static void PopulateBoard()
        {
            _board = new char[_rows][];
            for (int row = 0; row < _rows; row++)
            {
                Console.Write("String " + (row + 1) + ": ");
                String cmd = Console.ReadLine().Trim().Replace(" ", String.Empty);
                _board[row] = cmd.ToArray();
            }
        }

        private static void GetCommand()
        {
            Console.Write("Command: ");
            _commands = Console.ReadLine().Trim().Replace(" ", String.Empty).ToArray();
        }

        private static void ExecuteCommand()
        {
            char command;
            for (int commandIndex = 0; commandIndex < _commands.Length; commandIndex++)
            {
                command = _commands[commandIndex];
                DoCommand(command);
            }
        }

        private static void DoCommand(char command)
        {
            int[] tmp = new int[2];
            tmp[0] = _currentPosition[0];
            tmp[1] = _currentPosition[1];
            switch (command)
            {
                case 'V':
                    tmp[0] += 1;
                    break;
                case '>':
                    tmp[1] += 1;
                    break;
                case '^':
                    tmp[0] -= 1;
                    break;
                case '<':
                    tmp[1] -= 1;
                    break;
                default:
                    Console.WriteLine("Invalid command.");
                    return;
            }

            if (PositionIsValid(tmp))
            {
                _currentPosition[0] = tmp[0];
                _currentPosition[1] = tmp[1];
                if (_board[_currentPosition[0]][_currentPosition[1]].Equals('$'))
                {
                    _collectedCoins++;
                }
            }
            else
            {
                _hitWalls++;
            }
        }

        private static bool PositionIsValid(int[] tmp)
        {
            try
            {
                char check = _board[tmp[0]][tmp[1]];
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        private static void PrintResult()
        {
            Console.WriteLine("Coins Collected: {0}\nWalls Hit: {1}", _collectedCoins, _hitWalls);
        }
    }
}
