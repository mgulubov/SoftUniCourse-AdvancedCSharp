using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _04QueryMess
{
    class Program
    {
        private static List<Dictionary<String, List<String>>> _results;

        static void Main()
        {
            _results = new List<Dictionary<String, List<String>>>();

            while (true)
            {
                String input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }

                int index = input.LastIndexOf("?");
                if (index != -1)
                {
                    input = input.Substring(index + 1);
                }

                AddToResults(input);
            }

            PrintResults();
        }

        private static void PrintResults()
        {
            //Console.WriteLine(_results.Count);
            foreach (var dict in _results)
            {
                foreach (var item in dict)
                {
                    //Console.WriteLine(item);
                    Console.Write("{0}=[{1}]", item.Key, String.Join(", ", item.Value));
                }
                Console.WriteLine();
            }
        }

        private static void AddToResults(String input)
        {
            input = AdjustEmptySpaces(input);
            String[] arr = input.Split('&');
            var dict = new Dictionary<String, List<String>>();

            for (int i = 0; i < arr.Length; i++)
            {
                String[] keyValue = arr[i].Split('=');
                String key = keyValue[0].Trim();
                String value = keyValue[1].Trim();

                //Console.WriteLine(key + " " + value);
                if (!(dict.ContainsKey(key)))
                {
                    dict.Add(key, new List<String>());
                }

                dict[key].Add(value);
            }

            _results.Add(dict);
        }

        private static String AdjustEmptySpaces(String input)
        {
            StringBuilder bld = new StringBuilder(input);
            bld.Replace("+", " ");
            bld.Replace("%20", " ");

            return RemoveMultipleSpaces(bld.ToString());
        }

        private static String RemoveMultipleSpaces(String input)
        {
            //StringBuilder bld = new StringBuilder(input);
            String pattern = @"[ ]{2,}";
            Regex rex = new Regex(pattern);
            input = rex.Replace(input, @" ");

            return input;
        }
    }
}
