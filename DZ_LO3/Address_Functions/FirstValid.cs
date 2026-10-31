using System;
using System.Collections.Generic;
using System.Linq;


namespace DZ_LO3.Address_Functions
{ 
    internal class FirstValid
    {
        internal static int passingPointFromLeft = 3;
        internal static int passingPointFromRight = 0;

        const int octetMaxValue = 255;
        internal static string MainFunction(string mainAddress)
        {
            string result = string.Empty;

            string changingOctet = DetectOctet(mainAddress);
            string processedOctet = AddOneToOctet(changingOctet);
            string remainAddress = SetRestOfAddress(mainAddress);

            switch (passingPointFromRight)
            {
                case 0:
                    result = remainAddress + processedOctet;
                    break;
                case 1:
                    result = remainAddress + processedOctet + FillZeros(1);
                    break;
                case 2:
                    result = remainAddress + processedOctet + FillZeros(2);
                    break;
                case 3:
                    result = processedOctet + FillZeros(3);
                    break;
                default:
                
                throw new Exception("Error! Class -> \"FirstValid\".");
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
                    if (Compare(temp) >= octetMaxValue)
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


        internal static string FillZeros(int v)
        {
            string result = string.Empty;

            for (int i = 0; i < v; i++)
                result += ".0";

            return result;
        }
        private static int Compare(string value) => int.Parse(new string(value.Reverse().ToArray()));

        private static string AddOneToOctet(string changingOctet) => (int.Parse(changingOctet) + 1).ToString();
    }
}
