using System;
using System.Collections.Generic;
using DZ_LO3.Netowrk_Functions;

namespace DZ_LO3
{
    internal class InputMenu
    {
        internal static void SubnetOption()
        {
            CallStack.Push(SubnetOption);

            Console.Clear();
            Console.Write("Enter IPv4 address: ");
            string inputValue_IP = Console.ReadLine();

            Console.Write("Enter subnet mask: ");
            string inputValue_Subnet = Console.ReadLine();

            if (!Check.IP_Address(inputValue_IP))
            {
                Console.Clear();
                Console.WriteLine("Error! invaild IPv4 address!");

                Back();
            }

            else if (Check.SubnetMask(inputValue_Subnet) || Check.Prefiks(inputValue_Subnet))
            {
                MainAddressInfo.MainFunction(inputValue_IP, inputValue_Subnet);
                BacktoMainMenu_options();
            }

            else 
            {
                Console.Clear();
                Console.WriteLine("Error! invaild subnet mask or prefiks!");

                Back();
            }
        }
                
        internal static void NetworkOption()
        {
            CallStack.Push(NetworkOption);

            Console.Clear();
            Console.Write("Enter number of devices: ");

            int.TryParse(Console.ReadLine(), out int value);

            if (Check.Number(value))
            {
                NetworkInfo.MainFunction(value);

                BacktoMainMenu_options();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Error! Input value must be a positve number!");

                Back();
            }    
        }

        internal static void BinaryToDecimal()
        {
            CallStack.Push(BinaryToDecimal);

            Console.Clear();
            Console.Write("Enter binary number: ");
            string input = Console.ReadLine();

            string result = string.Empty;
            if (Check.Binary(input))
                result = BinaryAndDecimal.ConvertToDecimal(input);
            
            else
            {
                Console.Clear();
                Console.WriteLine("Error! Entered number is not binary!");

                Back();
            }

            Console.WriteLine($"Decimal: {result}");

            BacktoMainMenu_options();
        }

        internal static void DecimalToBinary()
        {
            CallStack.Push(DecimalToBinary);

            Console.Clear();
            Console.Write("Enter Decimal number: ");
            string input = Console.ReadLine();

            string result = string.Empty;
            if (Check.Decimal(input))
                result = BinaryAndDecimal.ConvertToBinary(input);
            
            else
            {
                Console.Clear();
                Console.WriteLine("Erorr! Input must be number!");

                Back();
            }

            Console.WriteLine($"Binary: {result}");

            BacktoMainMenu_options();
        }

        internal static Stack<Action> CallStack = new Stack<Action>();

        internal static void BacktoMainMenu_options()
        {
            Console.WriteLine("\nBack to main menu? (yes/no).");
            string temp = Console.ReadLine();

            if (temp.ToLower() == "yes")
                Program.Menu();

            else if (temp.ToLower() == "no")
            {
                Action Function = CallStack.Pop();
                Function();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Error! inccorrect input. Enter (yes) or (no) options!");
                BacktoMainMenu_options();
            }
        }

        internal static void Back()
        {
            Console.Write("\nPress enter to continue. ");
            Console.ReadKey();

            Action Function = CallStack.Pop();
            Function();
        }
    }
}
