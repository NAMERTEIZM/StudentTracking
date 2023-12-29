using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentTracking.UI.Extensions
{
    public static class ConvertIntExtensions
    {
        public static List<int> ConvertStringToList(this string input)
        {
            string[] stringArray = input.Split(',');
            List<int> integerList = new List<int>();

            foreach (string str in stringArray)
            {
                if (int.TryParse(str, out int number))
                {
                    integerList.Add(number);
                }
                else
                {
                    Console.WriteLine($"Invalid number: {str}");
                }
            }

            return integerList;
        }
    }
}
