using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.NightLife
{
    class NightLife
    {
        //I have a very cool, C-based, home-made, ultra-lightweight, database program, which will fit perfectly for this task.
        //But I supose that won't be allowed :P
        private static Dictionary<String, SortedDictionary<String, SortedSet<String>>> _program;

        static void Main(string[] args)
        {
            _program = new Dictionary<string, SortedDictionary<string, SortedSet<string>>>();

            PopulateProgram();
            PrintProgram();
        }

        private static void PopulateProgram()
        {
            String[] input;
            while (true)
            {
                input = Console.ReadLine().Trim().Split(';');
                if (input.Length != 3 && input[0] != "END")
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                if (input[0] == "END")
                {
                    break;
                }

                String city = input[0];
                String venue = input[1];
                String performer = input[2];

                AddRecord(city, venue, performer);
            }
        }

        private static void AddRecord(String city, String venue, String performer)
        {
            if (_program.ContainsKey(city))
            {
                if (_program[city].ContainsKey(venue))
                {
                    _program[city][venue].Add(performer);//If value is already present, add will be ignored. No need to check it explicitly
                }
                else
                {
                    var newPerfmerSet = new SortedSet<String>();                    
                    newPerfmerSet.Add(performer);

                    _program[city].Add(venue, newPerfmerSet);
                }
            }
            else
            {
                var newPerformerSet = new SortedSet<String>();
                var newVenueSortedDictionary = new SortedDictionary<String, SortedSet<String>>();

                newPerformerSet.Add(performer);
                newVenueSortedDictionary.Add(venue, newPerformerSet);

                _program.Add(city, newVenueSortedDictionary);
            }
        }

        private static void PrintProgram()
        {
            foreach (var city in _program)
            {
                Console.WriteLine(city.Key);
                foreach (var venue in city.Value)
                {
                    Console.WriteLine("->{0}: {1}", venue.Key, string.Join(", ", venue.Value));
                }
            }
        }
    }
}
