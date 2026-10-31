using System;
using System.Linq;
using DZ_LO3.Address_Functions;

namespace DZ_LO3.Convertor_Functions
{
    internal class PrefiksForCalculations
    {
        internal static string MainFunction(string input_Subnet)
        {
            const int overall_binary = 32;

            string value = string.Empty;

            string[] separete = input_Subnet.Split('/');
            string separated = string.Join("", separete);

            int maskLenght = int.Parse(separated);
            for (int i = overall_binary; i > overall_binary - maskLenght; i--)
            {
                if (i % 8 == 0 && i < 32)
                    value += ".";

                value += "1";
            }

            for (int i = overall_binary - maskLenght; i > 0; i--)
            {
                if (i % 8 == 0 && i < overall_binary)
                    value += ".";

                value += "0";
            }

            return value;
        }
    }
}
