using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_LO3.Address_Functions
{
    internal class LastValid
    {
        internal static int passingPointFromLeft = 3;
        internal static int passingPointFromRight = 0;

        const int octetMinValue = 0;

        internal static string MainFunction(string mainAddress)
        {
            string result = string.Empty;

            string changingOctet = DetectOctet(mainAddress);
            string processedOctet = MinusOneFromOctet(changingOctet);
            string remainAddress = SetRestOfAddress(mainAddress);

            switch (passingPointFromRight)
            {
                case 0:
                    result = remainAddress + processedOctet;
                    break;
                case 1:
                    result = remainAddress + processedOctet + FillMaxValue(1);
                    break;
                case 2:
                    result = remainAddress + processedOctet + FillMaxValue(2);
                    break;
                case 3:
                    result = processedOctet + FillMaxValue(3);
                    break;
                default:

                    throw new Exception("Error! Class -> \"LastValid\"");
            }

            passingPointFromLeft = 3;
            passingPointFromRight = 0;

            return result;
        }

        internal static string DetectOctet(string address)
        {
            string temp = string.Empty;

            for (int i = address.Length - 1; i >= 0; i--)
            {
                if (address[i] == '.')
                {
                    if (Compare(temp) == octetMinValue)
                    {
                        temp = string.Empty;
                        passingPointFromRight++;
                    }
                    else
                        break;
                }
                else
                    temp += address[i];
            }

            return new string(temp.Reverse().ToArray());
        }

        internal static string SetRestOfAddress(string mainAddress)
        {
            string result = string.Empty;

            for (int i = 0; i < mainAddress.Length; i++)
            {
                result += mainAddress[i];
                if (mainAddress[i] == '.')
                {
                    passingPointFromLeft--;

                    if (passingPointFromLeft == passingPointFromRight)
                        break;
                }
            }

            return result;
        }

        private static string FillMaxValue(int v)
        {
            string result = string.Empty;

            for (int i = 0; i < v; i++)
                result += ".255";

            return result;
        }
        private static string MinusOneFromOctet(string changingOctet) => (int.Parse(changingOctet) - 1).ToString();
        private static int Compare(string value) => int.Parse(new string(value.Reverse().ToArray()));
    }
}
