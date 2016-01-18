using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace SeriesOfLetters
{
    class SeriesOfLetters
    {
        static void Main(string[] args)
        {
            String text = Console.ReadLine().Trim();

            text = RemoveDuplicateCharactersFrom(text);

            Console.WriteLine(text);
        }

        private static String RemoveDuplicateCharactersFrom(String text)
        {
            String pattern = @"(\w)\1";
            Regex rex = new Regex(pattern);
            Match match = rex.Match(text);

            while (match.Success)
            {
                text = text.Replace(match.ToString(), match.ToString()[0].ToString());
                match = rex.Match(text);
            }

            return text;
        }
    }
}
