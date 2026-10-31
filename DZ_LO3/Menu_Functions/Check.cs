using System;

namespace DZ_LO3
{
    internal class Check
    {
        internal static bool Binary(string input)
        {
            foreach(char number in input)
            {
                if (number != '0' && number != '1')
                {
                    return false;
                }
            }

            return true;
        }

        internal static bool Decimal(string input)
        {
            return int.TryParse(input, out int x) && int.Parse(input) >= 0;
        }

        internal static bool IP_Address(string pv4)
        {
            string temp = string.Empty;

            int counter = 0;
            for (int i = 0; i < pv4.Length; i++)
            {
                if (!char.IsDigit(pv4[i]) && pv4[i] != '.')
                    return false;

                if (pv4[i] != '.')
                    temp += pv4[i];

                if (pv4[i] == '.' || i == pv4.Length - 1)
                {
                    if (string.IsNullOrEmpty(temp))
                        return false;

                    if (temp.Length > 1 && temp[0] == '0') 
                        return false;

                    if (int.Parse(temp) > 255)
                        return false;

                    temp = string.Empty;
                    counter++;
                }
            }

            if (counter != 4)
                return false;

            return true;
        }

        internal static bool Number(int input)
        {
            return input > 0;
        }

        internal static bool Prefiks(string input)
        {
            bool result = true;
            foreach (char v in input)
            {
                if (!input.StartsWith("/"))
                    result = false;

                if (input.Length < 2 || input.Length > 3)
                    result = false;

                if (!char.IsDigit(v) && v != '/')
                    result = false;

                if (!CheckSum(input))
                    result = false; 
            }

            return result;
        }

        private static bool CheckSum(string input)
        {
            bool result = true;

            string temp = input.Substring(1, input.Length - 1);
            if (int.TryParse(temp, out int value))
            {
                if(value > 32)
                    result = false;
            }
            else
                result = false;

            return result;
        }

        internal static bool SubnetMask(string input)
        {
            string temp = string.Empty;

            int sum = 0;
            int counter = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (!char.IsDigit(input[i]) && input[i] != '.')
                    return false;

                if (input[i] != '.')
                    temp += input[i];

                if (input[i] == '.' || i == input.Length - 1)
                {
                    if (counter >= 1)
                    {
                        if (sum < int.Parse(temp))
                            return false;
                    }

                    if (string.IsNullOrEmpty(temp))
                        return false;

                    if (int.Parse(temp) > 255)
                        return false;

                    sum = int.Parse(temp);
                    temp = string.Empty;

                    counter++;
                }
            }

            if (counter != 4)
                return false;

            return true;
        }
    }
}
