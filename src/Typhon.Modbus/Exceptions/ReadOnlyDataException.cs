using System;

namespace Typhon.Modbus.Exceptions
{
    public class ReadOnlyDataException : Exception
    {
        public ReadOnlyDataException(string address) 
            : base($"The data at address {address} is of the type read only and cannot be updated.")
        {
        }
    }
}