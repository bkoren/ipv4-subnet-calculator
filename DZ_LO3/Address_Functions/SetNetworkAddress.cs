using System;

namespace DZ_LO3.Address_Functions
{
    internal class SetNetworkAddress
    {
        internal static string MainFunction(string ip_variable, string subnet_variable)
        {
            const int overall_binary = 35;

            int upBit, downBit;

            string value = string.Empty;
            for (int i = 0; i < overall_binary; i++)
            {
                if (ip_variable[i] == '.' || subnet_variable[i] == '.')
                    value += '.';

                else
                {
                    upBit = ip_variable[i] - '0';
                    downBit = subnet_variable[i] - '0';

                    value += (upBit & downBit).ToString();
                }
            }

            return value;
        }
    }
}
