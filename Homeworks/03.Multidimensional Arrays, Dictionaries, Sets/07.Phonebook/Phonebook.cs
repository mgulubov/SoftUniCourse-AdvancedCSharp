using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Phonebook
{
    class Phonebook
    {
        private static Dictionary<String, List<String>> _phoneBook;

        static void Main(string[] args)
        {
            Console.WriteLine("Commands list:\nADD - switch from search mode to add mode\n" +
                              "search - switch from add mode to search mode");
            _phoneBook = new Dictionary<string, List<string>>();
            
            PopulatePhoneBook();
        }

        private static void PopulatePhoneBook()
        {
            String[] input;

            while (true)
            {
                Console.Write("Provide a name and a phone separated by a '-': ");
                input = Console.ReadLine().Trim().Replace(" ", "|").Split('-').ToArray();
                if (input.Length != 2 && input[0] != "search") //ugly-fixed bug here. input.Length is always >= 1
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                if (input[0] == "search")
                {
                    break;
                }

                String name = input[0].Replace("|", " ").Trim();
                String phone = input[1].Replace("|", " ").Trim();

                AddRecord(name, phone);
            }

            SearchPhoneBook();
        }

        private static void AddRecord(String name, String phone)
        {
            if (_phoneBook.ContainsKey(name))
            {
                _phoneBook[name].Add(phone);
                Console.WriteLine(phone + " successfully added to contact " + name);
            }
            else
            {
                _phoneBook[name] = new List<String>();
                _phoneBook[name].Add(phone);
                Console.WriteLine("Created new contact " + name);
            }
        }

        private static void SearchPhoneBook()
        {
            String input;
            while (true)
            {
                Console.Write("Type the name of the contact that we should search for: ");
                input = Console.ReadLine();
                if (input == "ADD")
                {
                    break;
                }

                SearchRecord(input);
            }

            PopulatePhoneBook();
        }

        private static void SearchRecord(String name)
        {
            if (_phoneBook.ContainsKey(name))
            {
                PrintRecord(name);
            }
            else
            {
                Console.WriteLine("Contact {0} does not exist.\nUse the 'ADD' command to add a new record.", name);
            }
        }

        private static void PrintRecord(String name)
        {
            foreach (var phone in _phoneBook[name])
            {
                Console.WriteLine("{0} -> {1}", name, phone);
            }
        }
    }
}
