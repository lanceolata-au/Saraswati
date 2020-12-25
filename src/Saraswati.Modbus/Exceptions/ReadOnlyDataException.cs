using System;

namespace Saraswati.Modbus.Exceptions
{
    public class ReadOnlyDataException : Exception
    {
        public ReadOnlyDataException() 
            : base("The data is of the type read only and cannot be updated")
        {
        }
    }
}