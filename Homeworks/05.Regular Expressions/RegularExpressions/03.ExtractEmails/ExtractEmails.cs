using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _03.ExtractEmails
{
    class ExtractEmails
    {
        static void Main(string[] args)
        {
            String text = Console.ReadLine();

            HashSet<String> emails = ExtractEmailsFrom(text);


            foreach (var item in emails)
            {
                Console.WriteLine(item);
            }
        }

        private static HashSet<String> ExtractEmailsFrom(String text)
        {
            var emails = new HashSet<String>();

            String pattern = @"(?<username>[a-zA-Z]+|[a-zA-Z]+\-[a-z]+|[a-zA-Z]+\.[a-z]+)@(?<host>[a-zA-Z]+(?:\-)?[a-zA-Z]+)(?<domainName>[.a-z+]+|[.a-z+\.a-z+]+)";
            Regex rex = new Regex(pattern);
            Match match = rex.Match(text);
            while (match.Success)
            {
                String email = match.ToString();
                if (email[email.Length - 1] == '.')
                {
                    email = email.Remove(email.Length - 1);
                }
                emails.Add(email);

                match = match.NextMatch();
            }

            return emails;
        }
    }
}
