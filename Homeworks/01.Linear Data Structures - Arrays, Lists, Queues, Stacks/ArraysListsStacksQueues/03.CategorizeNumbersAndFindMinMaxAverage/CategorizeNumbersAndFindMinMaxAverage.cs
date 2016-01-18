using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.CategorizeNumbersAndFindMinMaxAverage
{
    class CategorizeNumbersAndFindMinMaxAverage
    {
        static void Main(string[] args)
        {
            Console.Write("floating floating floating... : ");
            List<String> strList = Console.ReadLine().Split(' ').ToList(); //no one said that we have to use arrays here :p

            List<float> round = new List<float>();
            List<float> nonRound = new List<float>();

            foreach (String num in strList)
            {
                if (num.Contains("."))
                {
                    if (isRound(num.Substring(num.IndexOf(".") + 1)))
                    {
                        round = tryAdd(round, num);
                    }
                    else
                    {
                        nonRound = tryAdd(nonRound, num);
                    }
                }
                else
                {
                    round = tryAdd(round, num);
                }
            }

            printListMinMaxAvg(nonRound);
            printListMinMaxAvg(round);
        }

        private static Boolean isRound(String num)
        {
            if (num == "0" || num == "00")
            {
                return true;
            }
            return false;
        }

        private static List<float> tryAdd(List<float> list, string num) 
        {
            try 
            {
                list.Add(float.Parse(num));
            }
            catch (Exception)
            {
                Console.WriteLine(num + " is not a valid number. Will skip it");
            }

            return list;
        }

        private static void printListMinMaxAvg(List<float> list)
        {
            String strToPrint = "[";
            strToPrint = addNumsToString(strToPrint, list);
            strToPrint = addMin(strToPrint, list);
            strToPrint = addMax(strToPrint, list);
            strToPrint = addSum(strToPrint, list);
            strToPrint = addAvg(strToPrint, list);

            Console.WriteLine(strToPrint);
        }

        private static String addNumsToString(String str, List<float> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                str += list[i].ToString();
                if (i != list.Count - 1)
                {
                    str += ", ";
                }
                else
                {
                    str += "] -> ";
                }
            }

            return str;
        }

        private static String addMin(String str, List<float> list)
        {
            String min = list.Min().ToString();
            str += "min: " + min + ", ";

            return str;
        }

        private static String addMax(String str, List<float> list)
        {
            String max = list.Max().ToString();
            str += "max: " + max + ", ";

            return str;
        }

        private static String addSum(String str, List<float> list)
        {
            String sum = list.Sum().ToString();
            str += "sum: " + sum + ", ";

            return str;
        }

        private static String addAvg(String str, List<float> list)
        {
            String avg = ((float)Math.Round((float)list.Average(), 2)).ToString();
            str += "avg: " + avg;

            return str;
        }
    }
}
