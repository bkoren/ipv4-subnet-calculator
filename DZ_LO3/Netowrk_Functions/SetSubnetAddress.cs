using System;
using System.Collections.Generic;

namespace DZ_LO3.Netowrk_Functions
{
    internal class SetSubnetAddress
    {
        const int logBase = 2;
        const int expoBase = 7;
        internal static string MainFunction(int octetNumber, int bitsRemain)
        {
            string value = string.Empty;

            switch (octetNumber)
            {
                case 0:
                    value = AddOctet(bitsRemain, 3);
                    break;
                case 1:
                    value = FullOctect(1) + AddOctet(bitsRemain, 2);
                    break;
                case 2:
                    value = FullOctect(2) + AddOctet(bitsRemain, 1);
                    break;
                case 3:
                    value = FullOctect(3) + AddOctet(bitsRemain, 0);
                    break;
                case 4:
                    value = FullOctect(4);
                    break;
            }

            return value;
        }

        private static string FullOctect(int v)
        {
            string value = string.Empty;

            for (int i = 0; i < v; i++)
            {
                if (i < v - 1)
                    value += "255.";
                else
                    value += "255";
            }

            return value;
        }

        internal static string AddOctet(int bitsRemain, int octectRemain)
        {
            string value = ".";

            int tempSum = 0;
            for (int i = expoBase; i > expoBase - bitsRemain; i--)
            {
                tempSum += (int)(Math.Pow(logBase, i));
            }

            value += (tempSum.ToString() + FillRemain(octectRemain));

            return value;
        }

        private static string FillRemain(int v)
        {
            string value = string.Empty;

            for (int i = v; i > 0; i--)
                value += ".0";

            return value;
        }

    }
}
