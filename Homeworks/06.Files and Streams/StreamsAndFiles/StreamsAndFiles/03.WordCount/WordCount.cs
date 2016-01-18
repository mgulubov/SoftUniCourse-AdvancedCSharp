using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace _03.WordCount
{
    class WordCount
    {
        private static Dictionary<String, int> _results;
        static void Main(string[] args)
        {
            String wordsFileName = "words.txt";
            String textFiltName = "text.txt";
            String resultsFileName = "results.txt";
            String path = Directory.GetCurrentDirectory() + "../../../../";

            _results = new Dictionary<String, int>(StringComparer.OrdinalIgnoreCase);

            SetResultsKeys(path + wordsFileName);
            GetResults(path + textFiltName);
            WriteResultsToFile(path + resultsFileName);
            PrintResults(path + resultsFileName);
            DeleteFile(path + resultsFileName);
        }

        private static void DeleteFile(String path)
        {
            if (File.Exists(path)) 
            {
                File.Delete(path);
            }
        }

        private static void PrintResults(String path)
        {
            StreamReader reader = new StreamReader(path);
            while (true)
            {
                String line = reader.ReadLine();
                if (line == null)
                {
                    break;
                }

                Console.WriteLine(line);
            }

            reader.Close();
        }

        private static void WriteResultsToFile(String path)
        {
            StreamWriter writer = new StreamWriter(path);
            var items = from pair in _results
                        orderby pair.Value descending
                        select pair;

            foreach (KeyValuePair<String, int> pair in items)
            {
                writer.WriteLine(pair.Key + " - " + pair.Value);
            }

            writer.Flush();
            writer.Close();
        }

        private static void GetResults(String path)
        {
            StreamReader reader = new StreamReader(path);
            String[] words = reader.ReadToEnd().Split(' ');
            String pattern = @"[^a-zA-Z]";
            for (int i = 0; i < words.Length; i++)
            {
                if (Regex.IsMatch(words[i], pattern, RegexOptions.IgnoreCase))
                {
                    words[i] = RemoveSymbolsFrom(words[i], pattern);
                }

                if (_results.ContainsKey(words[i]))
                {
                    _results[words[i]] = _results[words[i]] + 1;
                }
            }

            reader.Close();
        }

        private static String RemoveSymbolsFrom(String word, String pattern)
        {
            Regex rex = new Regex(pattern, RegexOptions.IgnoreCase);
            StringBuilder bld = new StringBuilder();
            for (int i = 0; i < word.Length; i++)
            {
                if (!rex.IsMatch(word[i].ToString()))
                {
                    bld.Append(word[i].ToString());
                }
            }

            return bld.ToString();
        }

        private static void SetResultsKeys(String path)
        {
            StreamReader reader = new StreamReader(path);
            while (true)
            {
                String line = reader.ReadLine();
                if (line == null)
                {
                    break;
                }

                _results.Add(line, 0);
            }

            reader.Close();
        }
    }
}
