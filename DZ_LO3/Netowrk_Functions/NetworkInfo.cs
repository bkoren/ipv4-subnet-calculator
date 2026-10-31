using System;

namespace DZ_LO3.Netowrk_Functions
{
    internal class NetworkInfo
    {
        const int binaryOverall = 32;
        const int octetLenght = 8;
        internal static void MainFunction(int value)
        {
            int expo = CalculateExpo(value);
            int Prefiks = CaluclationPrefiks(expo);
            int octetNumber = CalculationOctet(Prefiks, octetLenght);
            int bitsRemain = CalculationBits(Prefiks, octetLenght);

            string defaultNetworkAddress = SetNetworkClass(value);
            string subnetMask = SetSubnetAddress.MainFunction(octetNumber, bitsRemain);

            Console.WriteLine($"\nNetwork address: {defaultNetworkAddress}\nSubnet mask: {subnetMask}\n");
        }

        internal static string SetNetworkClass(int value)
        {
            string temp = string.Empty;

            if (value <= 254)
                temp = "192.168.0.0";
            else if (value > 254 || value <= 65.534)
                temp = "172.16.0.0";
            else if (value >= 65.534)
                temp = "10.0.0.0";

            return temp;
        }
        private static int CaluclationPrefiks(int expo) => binaryOverall - expo;
        private static int CalculationBits(int y, int x) => y % x;
        private static int CalculationOctet(int y, int x) => y / x;
        private static int CalculateExpo(int v) => (int)(Math.Ceiling((Math.Log10(v)) / (Math.Log10(2))));
    }
}
