using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _03TextTransformer
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder bld = new StringBuilder();
            StringBuilder result = new StringBuilder();

            String str;
            while (true)
            {
                str = Console.ReadLine();
                if (str == "burp")
                {
                    break;
                }

                str = Regex.Replace(str, @"([ ]{2,})", " ");

                bld.Append(str);
            }

            str = bld.ToString();
            //Console.WriteLine(str);
            String pattern = @"(?<symbol>[$%&']{1})(?<text>[^$%&']+)(\k<symbol>)";

            Regex rex = new Regex(pattern);
            Match match = rex.Match(str);

            //Console.WriteLine(match.Success);
            while (match.Success)
            {
                String special = match.Groups["symbol"].Value;
                String text = match.Groups["text"].Value;
                // Console.WriteLine(special + " " + text);

                result.Append(GetResult(special, text) + " ");

                match = match.NextMatch();
            }

            Console.WriteLine(result.ToString());
        }

        private static String GetResult(String special, String text)
        {
            StringBuilder bld = new StringBuilder();
            int weight = GetWeight(special);
            int flag = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (flag == 0)
                {
                    bld.Append(char.ToString((char)(text[i] + weight)));
                    flag = 1;
                }
                else
                {
                    bld.Append(char.ToString((char)(text[i] - weight)));
                    flag = 0;
                }
            }

            return bld.ToString();
        }

        private static int GetWeight(String special)
        {
            switch (special)
            {
                case "$":
                    return 1;
                case "%":
                    return 2;
                case "&":
                    return 3;
                case "'":
                    return 4;
                default:
                    return 0;
            }
        }
    }
}
