using System;
using System.Collections.Generic;
using System.Linq;

namespace Program
{
    public class StringCalc
    {

        public static int Add(String numbers)
        {
            int result;

            if (string.IsNullOrEmpty(numbers))
            {
                Console.WriteLine(0);
                return 0;
            }

            if (numbers.StartsWith("//"))
            {
                result = CalculateWithSpecifiedDelimiter(numbers);
            }
            else
            {
                result = Calculate(numbers);
            }
            Console.WriteLine(result);
            return result;
        }

        private static int CalculateWithSpecifiedDelimiter(string input)
        {
            var delimiter = GetDelimiter(input);
            input = input.Substring(input.IndexOf("\n"));
            return Calculate(input, delimiter);
        }

        private static int Calculate(string input)
        {
            return Calculate(input, GetDelimiter(input));
        }

        private static int Calculate(String input, string[] delimiter)
        {
            var values = input.Split(delimiter, StringSplitOptions.None);
            var intValues = values.Select(x => int.Parse(x)).Where(x => x < 1001);

            CheckForNegativeNumbers(intValues);


            return intValues.Sum();
        }

        private static void CheckForNegativeNumbers(IEnumerable<int> intValues)
        {
            var negatives = intValues.Where(x => x < 0).ToList();
            var errorMessage = "negatives not allowed: ";

            if (negatives.Count() > 0)
            {
                negatives.ForEach(x => errorMessage += x);
                throw new Exception(errorMessage);
            }
        }

        private static string[] GetDelimiter(String input)
        {
            string[] defaultDelimiter = new string[] { ",", "\n" };
            if (input.StartsWith("//["))
            {
                return GetMultipleDelimiters(input);
            }
            if (input.StartsWith("//"))
            {
                return new string[] { input[2].ToString() };
            }

            return defaultDelimiter;
        }

        public static string[] GetMultipleDelimiters(String input)
        {

            input = input.TrimStart("/[".ToCharArray());
            input = input.Split(new[] { "]\n" }, StringSplitOptions.None).First();
            return input.Split(new[] { "][" }, StringSplitOptions.None);

        }
    }

}

