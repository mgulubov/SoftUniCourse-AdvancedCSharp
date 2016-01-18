using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.CountSymbols
{
    class CountSymbols
    {
        private static SortedDictionary<char, int> _dictionary;

        static void Main(string[] args)
        {
            Console.Write("Some text: ");
            String input = Console.ReadLine();
            _dictionary = new SortedDictionary<char, int>();

            PopulateDictionary(input);

            PrintResult();
        }

        private static void PopulateDictionary(String str)
        {
            char character;
            for (int i = 0; i < str.Length; i++)
            {
                character = str[i];
                if (_dictionary.ContainsKey(character))
                {
                    _dictionary[character] = _dictionary[character] + 1;
                }
                else
                {
                    _dictionary.Add(character, 1);
                }
            }
        }

        private static void PrintResult()
        {
            foreach (var i in _dictionary)
            {
                Console.WriteLine("{0}: {1} time/s", i.Key, i.Value);
            }
        }
    }
}
