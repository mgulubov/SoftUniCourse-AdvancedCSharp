using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _04OlympicsAreComing
{
    class Program
    {
        private static Dictionary<String, Country> _dict;
        static void Main(string[] args)
        {
            _dict = new System.Collections.Generic.Dictionary<string, Country>();
            while (true)
            {

                String input = Console.ReadLine().Trim();
                if (input == "report")
                {
                    break;
                }

                input = Regex.Replace(input, @"([\s]{2,})", " ");

                String[] arr = input.Split('|');
                String countryName = arr[1].Trim();
                String playerName = arr[0].Trim();
                // Console.WriteLine(arr[0]);
                // Console.WriteLine(arr[1]);
                if (_dict.ContainsKey(countryName))
                {
                    _dict[countryName].AddPlayer(playerName);
                }
                else
                {
                    _dict.Add(countryName, new Country(countryName));
                    _dict[countryName].AddPlayer(playerName);
                }
            }

            var ord = from pair in _dict
                      orderby pair.Value.GetWins() descending
                      select pair;

            foreach (var o in ord)
            {
                Console.WriteLine("{0} ({1} participants): {2} wins", o.Key, o.Value.GetNumberOfPlayers(), o.Value.GetWins());
            }
        }

        public class Country
        {
            private String _name;
            private HashSet<String> _players;
            private int _wins;

            public Country(String name)
            {
                _players = new System.Collections.Generic.HashSet<string>();
                SetName(name);
                _wins = 0;
            }

            public void SetName(String name)
            {
                this._name = name;
            }

            public String GetName()
            {
                return this._name;
            }

            public void AddPlayer(String name)
            {
                if (_players.Contains(name))
                {
                    this._wins++;
                }
                else
                {
                    _players.Add(name);
                    this._wins++;
                }
            }

            public int GetWins()
            {
                return this._wins;
            }

            public int GetNumberOfPlayers()
            {
                return this._players.Count();
            }
        }
    }
}
