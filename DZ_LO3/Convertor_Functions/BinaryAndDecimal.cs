using System;
using System.Linq;

namespace DZ_LO3
{
    internal static class BinaryAndDecimal
    {
        public static string ConvertToDecimal(string input)
        {
            int counter = 1;
            int result = 0;

            for (int i = input.Length - 1; i >= 0; i--)
            {
                if (input[i] == '1') 
                {
                    result += counter;
                }

                counter *= 2;
            }

            return result.ToString();
        }
        public static string ConvertToBinary(string input) 
        {
            int number = int.Parse(input);

            if (number == 0)
                return "0";

            string binary = string.Empty;
            while (number >= 1) 
            {
                int temp = number % 2;
                number /= 2;

                binary += temp;
            }

            return new string (binary.Reverse().ToArray());
        }
    }
}
