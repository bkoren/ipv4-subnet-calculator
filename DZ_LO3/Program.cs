using System;

namespace DZ_LO3
{
    internal class Program
    {
        static void Main() => Menu();

        internal static void Menu()
        {
            ClearScreen();

            Console.WriteLine("MENU");
            Console.WriteLine("(1) Convert from decimal to binary.");
            Console.WriteLine("(2) Convert from binary to decimal.");
            Console.WriteLine("(3) Determine subnet Information.");
            Console.WriteLine("(4) Determine network information.");
            Console.Write("Enter option: ");

            if (int.TryParse(Console.ReadLine(), out int option))
                OptionProccess(option);
            else
                BackToMenu();
        }

        private static void OptionProccess(int option)
        {
            switch (option)
            {
                case 1:
                    InputMenu.DecimalToBinary();
                    break;
                case 2:
                    InputMenu.BinaryToDecimal();
                    break;
                case 3:
                    InputMenu.SubnetOption();
                    break;
                case 4:
                    InputMenu.NetworkOption();
                    break;
                default:
                    BackToMenu();
                    break;
            }
        }
        private static void BackToMenu()
        {
            ClearScreen();
            Console.WriteLine("Invalid option! Enter number in range [1 - 4]. \n");

            Console.WriteLine("Press enter for main menu.");
            Console.ReadKey();
            Menu();
        }

        public static void ClearScreen()
        {
            if (!Console.IsOutputRedirected)
                Console.Clear();
        }
    }
}