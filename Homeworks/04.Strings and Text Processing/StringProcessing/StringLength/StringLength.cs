using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringLength
{
    class StringLength
    {
        static void Main(string[] args)
        {
            String input = Console.ReadLine();
            if (input.Length >= 20)
            {
                input = input.Substring(0, 20);
            }
            else
            {
                StringBuilder strBuild = new StringBuilder();
                for (int i = 0; i < 20; i++)
                {
                    if (i < input.Length)
                    {
                        strBuild.Append(input[i]);
                    }
                    else
                    {
                        strBuild.Append("*");
                    }
                }
                input = strBuild.ToString();
            }

            Console.WriteLine(input);
        }
    }
}
