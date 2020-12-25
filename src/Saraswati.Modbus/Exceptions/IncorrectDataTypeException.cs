using System;

namespace Saraswati.Modbus.Exceptions
{
    public class IncorrectDataTypeException : Exception
    {
        public IncorrectDataTypeException() 
            : base("That data type cannot be updated with the supplied type of value")
        {
        }
    }
}