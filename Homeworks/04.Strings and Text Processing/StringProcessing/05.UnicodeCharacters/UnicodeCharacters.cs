using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace _05.UnicodeCharacters
{
    class UnicodeCharacters
    {
        static void Main(string[] args)
        {
            String text = Console.ReadLine().Trim();

            text = ConvertCharsToUnicode(text);

            Console.WriteLine("Result: " + text);
        }

        private static String ConvertCharsToUnicode(String text)
        {
            StringBuilder bld = new StringBuilder(text.Length);
            for (int i = 0; i < text.Length; i++)
            {
                bld.Append(CharToUnicode(text[i]));
            }

            return bld.ToString();
        }

        private static String CharToUnicode(char ch)
        {
            return "\\u" + ((int)ch).ToString("X4");
        }
    }
}
