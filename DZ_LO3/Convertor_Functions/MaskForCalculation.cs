using System;

namespace DZ_LO3.Convertor_Functions
{
    internal class MaskForCalculation
    {
        internal static string MainFunction(string input_Subnet)
        {
            string result = string.Empty;
            string octets = string.Empty;
            string bits = string.Empty;

            input_Subnet += '.';

            int counter = 0;
            for(int i = 0; i < input_Subnet.Length; i++)
            {
                if (input_Subnet[i] == '.')
                {
                    counter++;
                    octets += BinaryAndDecimal.ConvertToBinary(bits);

                    if (octets.Length < 8)
                        octets = FillRemain(octets, octets.Length);

                    result += octets;

                    if (counter < 4)
                        result += '.';                    

                    bits = string.Empty;
                    octets = string.Empty;
                }
                else
                    bits += input_Subnet[i];
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
