using System;

namespace Typhon.Modbus.Exceptions
{
    public class DataTypeDoesNotMatchAddressException : Exception
    {
        public DataTypeDoesNotMatchAddressException(string address) 
            : base($"The address {address} does not match the type specified in data value. " +
                   $"This only happens when you are om the code directly.")
        {
        }
    }
}