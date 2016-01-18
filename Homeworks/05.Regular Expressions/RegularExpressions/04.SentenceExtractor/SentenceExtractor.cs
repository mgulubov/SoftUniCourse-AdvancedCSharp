using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _04.SentenceExtractor
{
    class SentenceExtractor
    {
        static void Main(string[] args)
        {
            String wordToMatch = " " + Console.ReadLine() + " ";
            String text = Console.ReadLine();

            var results = ExtractSentences(text, wordToMatch);

            PrintResults(results);
        }

        private static List<String> ExtractSentences(String text, String wordToMatch)
        {
            var results = new List<String>();
            String pattern = @"(\S.+?[.!?])(?=\s+|$)";
            Regex rex = new Regex(pattern);
            Match match = rex.Match(text);
            while (match.Success)
            {
                String sentence = match.ToString();
                if (sentence.Contains(wordToMatch))
                {
                    results.Add(sentence);
                }
                match = match.NextMatch();
            }

            return results;
        }

        private static void PrintResults(List<String> results)
        {
            Console.WriteLine("{0}", String.Join("\n", results));
        }
    }
}
