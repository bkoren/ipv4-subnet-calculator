using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_LO3.Address_Functions
{
    internal class SetBradcastAddress
    {
        internal static string MainFunction(string ip_variable, string subnet_variable)
        {
            const int overall_binary = 35;

            string subnet_fliped = FlipSubnet(subnet_variable);

            int upBit, downBit;

            string value = string.Empty;
            for (int i = 0; i < overall_binary; i++)
            {
                if (ip_variable[i] == '.' || subnet_fliped[i] == '.')
                    value += '.';

                else
                {
                    upBit = ip_variable[i] - '0';
                    downBit = subnet_fliped[i] - '0';

                    value += (upBit | downBit).ToString();
                }
            }

            return value;
        }

        private static string FlipSubnet(string subnet_variable)
        {
            string value = string.Empty;
            for (int i = 0; i < subnet_variable.Length; i++)
            {
                if (subnet_variable[i] == '.')
                    value += ".";

                if (subnet_variable[i] == '1')
                    value += '0';
                else if (subnet_variable[i] == '0')
                    value += '1';
            }

            return value;
        }
    }
}
