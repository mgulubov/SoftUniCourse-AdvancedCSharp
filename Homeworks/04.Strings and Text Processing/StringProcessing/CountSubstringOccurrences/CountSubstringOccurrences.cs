using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace CountSubstringOccurrences
{
    class CountSubstringOccurrences
    {
        static void Main(string[] args)
        {
            String input = Console.ReadLine();
            String pattern = Console.ReadLine();

            int occurrences = PatternMatchCount(input, pattern);

            Console.WriteLine(occurrences);
        }

        private static int PatternMatchCount(String input, String pattern)
        {
            Regex rex = new Regex(pattern, RegexOptions.IgnoreCase);
            int patternLength = pattern.Length;
            Match match;
            int count = 0;
            for (int i = 0; i < input.Length - (patternLength - 1); i++)
            {
                match = rex.Match(input, i, patternLength);
                if (match.Success)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
