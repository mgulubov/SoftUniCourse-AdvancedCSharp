using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Palindromes
{
    class Palindromes
    {
        private static SortedSet<String> _sortedSet;

        static void Main(string[] args)
        {
            String text = Console.ReadLine().Trim();
            _sortedSet = new SortedSet<string>();

            FindPalindromesIn(text);

            Console.WriteLine("{0}", string.Join(", ", _sortedSet));
        }

        private static void FindPalindromesIn(String text)
        {
            String pattern = @"\w+";
            Regex rex = new Regex(pattern);
            Match match = rex.Match(text);

            while (match.Success) 
            {
                String word = match.Value;
                if (WordIsAPalindrome(word))
                {
                    _sortedSet.Add(word);
                }

                match = match.NextMatch();
            }
        }

        private static bool WordIsAPalindrome(String word)
        {
            if (word.Length == 1)
            {
                return true;
            }

            String reversedWord = Reverse(word);

            if (reversedWord.Equals(word))
            {
                return true;
            }

            return false;
        }

        private static String Reverse(String word)
        {
            StringBuilder strBuild = new StringBuilder();
            for (int i = word.Length - 1; i >= 0; i--)
            {
                strBuild.Append(word[i]);
            }

            return strBuild.ToString();
        }
    }
}
