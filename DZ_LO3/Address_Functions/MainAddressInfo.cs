using System;
using DZ_LO3.Convertor_Functions;
using DZ_LO3.Address_Functions;

namespace DZ_LO3
{
    internal class MainAddressInfo
    {
        internal static void MainFunction(string input_IP, string input_Subnet)
        {
            string subnet_variable = string.Empty;

            if (Check.SubnetMask(input_Subnet))
                subnet_variable = MaskForCalculation.MainFunction(input_Subnet);

            else 
                subnet_variable = PrefiksForCalculations.MainFunction(input_Subnet);
            
             
            string ip_variable = IP_ForCalculations.MainFunction(input_IP);
            string network_variable = SetNetworkAddress.MainFunction(ip_variable, subnet_variable);
            string broadcast_variable = SetBradcastAddress.MainFunction(ip_variable, subnet_variable);

            string networkAddress = BinaryToAddress.MainFunction(network_variable);
            string firstVaildAddress = FirstValid.MainFunction(networkAddress);
            string broadcastAddress = BinaryToAddress.MainFunction(broadcast_variable);
            string lastVaildAddress = LastValid.MainFunction(broadcastAddress);

            Console.WriteLine($"\nNetwork address: {networkAddress}\nFirst valid address: {firstVaildAddress}\nLast valid address: {lastVaildAddress}\nBroadcast: {broadcastAddress}\n");
        }
    }
}
