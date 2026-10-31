using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_LO3.Convertor_Functions
{
    internal class BinaryToAddress
    {
        internal static string MainFunction(string binaryVariable)
        {   
            string result = string.Empty;

            string temp = string.Empty;
            for (int i = 0; i < binaryVariable.Length; i++)
            {
                if (binaryVariable[i] == '.')
                {
                    result += BinaryAndDecimal.ConvertToDecimal(temp) + '.';

                    temp = string.Empty;
                }
                else
                    temp += binaryVariable[i];
            }

            result += BinaryAndDecimal.ConvertToDecimal(temp);

            return result;
        }
    }
}
