using System;

namespace Typhon.Modbus.Exceptions
{
    public class IncorrectDataTypeException : Exception
    {
        public IncorrectDataTypeException(string address) 
            : base($"The data type at address {address} cannot be updated with the supplied type of value.")
        {
        }
    }
}