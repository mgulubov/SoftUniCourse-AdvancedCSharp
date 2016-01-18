using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace TextFilter
{
    class TextFilter
    {
        static void Main(string[] args)
        {
            List<String> bannedWords = Console.ReadLine().Replace(" ", String.Empty).Split(',').ToArray().ToList();
            String text = Console.ReadLine();

            text = FilterText(text, bannedWords);

            Console.WriteLine("Filtered Text:");
            Console.WriteLine(text);
        }

        private static String FilterText(String text, List<String> bannedWords)
        {
            for (int i = 0; i < bannedWords.Count; i++)
            {
                String bannedWord = bannedWords[i];
                text = text.Replace(bannedWord, new String('*', bannedWord.Length));
            }

            return text;
        }
    }
}
