using System;

namespace DZ_LO3.Convertor_Functions
{
    internal class IP_ForCalculations
    {
        internal static string MainFunction(string input_IP)
        {
            string result = string.Empty;
            string octet = string.Empty;
            string bits = string.Empty;

            input_IP += '.';

            int counter = 0;
            foreach (char c in input_IP) 
            {
                if (c != '.')
                    bits += c;
                
                else
                {
                    counter++;
                    octet += BinaryAndDecimal.ConvertToBinary(bits);

                    if (octet.Length < 8)
                        octet = FillRemain(octet, octet.Length);
                    
                    result += octet;

                    if (counter < 4)
                        result += '.';

                    octet = string.Empty;
                    bits = string.Empty;
                }
            }

            return result;
        }

        internal static string FillRemain(string v, int x)
        {
            const int overall_octet = 8;

            int remainBits = overall_octet - x;

            string value = string.Empty;
            for (int i = 0; i < remainBits; i++)
            {
                value += '0';
            }

            value += v;

            return value;
        }
    }
}
