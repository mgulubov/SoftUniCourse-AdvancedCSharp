using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _02.ReplaceTag
{
    class ReplaceTag
    {
        static void Main(string[] args)
        {
            String htmlString = "<ul><li><a href=http://softuni.bg>SoftUni</a></li></ul>";

            htmlString = ReplaceATag(htmlString);

            Console.WriteLine(htmlString);
        }

        private static String ReplaceATag(String htmlString)
        {
            String pattern = @"(?<openTag><a href=)(?<url>http:\/\/\w+.\w+)(?<charToRemove>>)(?<name>\w+)(?<closeTag><\/a>)";
            String replacementPattern = @"[URL href=${url}]${name}[/URL]";

            return Regex.Replace(htmlString, pattern, replacementPattern);
        }
    }
}
