using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _09UppercaseWords
{
    class Program
    {
        static void Main(string[] args)
        {
            String pattern = @"(\b[A-Z]+)(?:[0-9]?\b)";
            StringBuilder bld = new StringBuilder();

            String str;
            while (true)
            {
                str = Console.ReadLine();
                if (str == "END")
                {
                    break;
                }

                Regex rex = new Regex(pattern);
                Match match = rex.Match(str);

                while (match.Success)
                {
                    int index = match.Index;
                    String current = match.Groups[1].Value;
                    String reverse = ReverseString(current);

                    if (current == reverse)
                    {
                        current = DoubleChars(current);
                    }
                    else
                    {
                        current = reverse;
                    }

                    str = str.Remove(index, match.Groups[1].Value.Length);
                    //Console.WriteLine(str);
                    str = str.Insert(index, current);
                    //Console.WriteLine(str);
                    if (index + current.Length + 1 >= str.Length)
                    {
                        break;
                    }

                    match = rex.Match(str, index + current.Length + 1);
                }

                bld.Append(str);
                bld.Append("\n");
            }

            Console.WriteLine(SecurityElement.Escape(bld.ToString()));
        }

        private static String DoubleChars(String str)
        {
            StringBuilder bld = new StringBuilder();
            for (int i = 0; i < str.Length; i++)
            {
                bld.Append(str[i].ToString());
                bld.Append(str[i].ToString());
            }

            return bld.ToString();
        }

        private static String ReverseString(String str)
        {
            StringBuilder bld = new StringBuilder();
            for (int i = str.Length - 1; i >= 0; i--)
            {
                bld.Append(str[i].ToString());
            }

            return bld.ToString();
        }
    }
}
