using System;

namespace Typhon.Modbus.Exceptions
{
    public class AddressNotInSpecification : Exception
    {
        public AddressNotInSpecification(string address) 
            : base($"The address {address} does not exist inside the implemented modbus specification.")
        {
        }
    }
}