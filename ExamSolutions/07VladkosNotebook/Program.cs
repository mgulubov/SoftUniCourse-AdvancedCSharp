using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07VladkosNotebook
{
    class Program
    {
        private static SortedDictionary<String, Player> _players;
        public static void Main()
        {
            _players = new SortedDictionary<String, Player>();

            String line;
            while (true)
            {
                line = Console.ReadLine();

                if (line == "END")
                {
                    break;
                }

                ManageInputLine(line);
            }

            PrintResult();
        }

        private static void PrintResult()
        {
            int printed = 0;
            foreach (var color in _players)
            {
                Player player = color.Value;
                if (player.GetName() == "No data recovered." || player.GetAge() == "No data recovered.")
                {
                    continue;
                }
                Console.WriteLine("Color: {0}\n" +
                                    "-age: {1}\n" +
                                    "-name: {2}\n" +
                                    "-opponents: {3}\n" +
                                    "-rank: {4}",
                                    player.GetColor(),
                                    player.GetAge(),
                                    player.GetName(),
                                    player.GetOponents(),
                                    string.Format("{0:0.00}", player.GetRank()));
                printed++;
            }

            if (printed == 0)
            {
                Console.WriteLine("No data recovered.");
            }
        }

        private static void ManageInputLine(String line)
        {
            String[] arr = line.Split('|');

            String color = arr[0];
            String command = arr[1];
            String param = arr[2];

            CreatePlayerIfDoesNotExist(color);

            Player player = _players[color];

            switch (command)
            {
                case "win":
                    player.AddOponent(param);
                    player.AddWin();
                    break;
                case "loss":
                    player.AddOponent(param);
                    player.AddLoss();
                    break;
                case "name":
                    player.SetName(param);
                    break;
                case "age":
                    player.SetAge(param);
                    break;
                default:
                    throw new ArgumentException("command not supported");
            }
        }

        private static void CreatePlayerIfDoesNotExist(String color)
        {
            if (!(_players.ContainsKey(color)))
            {
                _players.Add(color, new Player(color));
            }
        }

        private class Player
        {
            private String _name;
            private String _color;
            private String _age;
            private List<String> _oponents;
            private double _rank;
            private int _winsCount;
            private int _lossesCount;

            public Player(String color)
            {
                SetColor(color);
                _oponents = new List<String>();
                _winsCount = 0;
                _lossesCount = 0;
                _rank = 0d;
            }

            private void SetColor(String color)
            {
                _color = color;
            }

            public String GetColor()
            {
                return _color;
            }

            public void SetName(String name)
            {
                _name = name;
            }

            public String GetName()
            {
                if (_name == null)
                {
                    return "No data recovered.";
                }
                return _name;
            }

            public void SetAge(String age)
            {
                _age = age;
            }

            public String GetAge()
            {
                if (_age == null)
                {
                    return "No data recovered.";
                }
                return _age;
            }

            public void AddOponent(String name)
            {
                _oponents.Add(name);
            }

            public String GetOponents()
            {
                if (_oponents.Count == 0)
                {
                    return "(empty)";
                }

                _oponents.Sort(StringComparer.Ordinal);
                StringBuilder bld = new StringBuilder();
                for (int i = 0; i < _oponents.Count; i++)
                {
                    bld.Append(_oponents[i]);

                    if (i != _oponents.Count - 1)
                    {
                        bld.Append(", ");
                    }
                }

                return bld.ToString();
            }

            public void AddWin()
            {
                _winsCount++;
            }

            public void AddLoss()
            {
                _lossesCount++;
            }

            private int GetWins()
            {
                return _winsCount;
            }

            private int GetLosses()
            {
                return _lossesCount;
            }

            private void CalcRank()
            {
                //_rank = Math.Round((double)(GetWins() + 1) / (double)(GetLosses() + 1), 2);
                _rank = (double)(GetWins() + 1.00d) / (double)(GetLosses() + 1.00d);
            }

            public double GetRank()
            {
                CalcRank();
                return _rank;
            }
        }
    }
}
