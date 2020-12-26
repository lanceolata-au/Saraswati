using System;
using System.Text;

namespace Saraswati.Modbus.CoreFunctions
{
    public static class Formatter
    {
        public static string ByteArrayToString(Byte[] bytes)
        {

            var output = new StringBuilder();

            output.Append("0x");

            foreach (var b in bytes)
            {
                if (b < 0x10)
                {
                    output.Append("0");
                    output.Append(Convert.ToString(b, 16));
                }
                else
                {
                    output.Append(Convert.ToString(b, 16));
                }
                
                output.Append(".");
            }

            return output.ToString();

        }
        
    }
    
}