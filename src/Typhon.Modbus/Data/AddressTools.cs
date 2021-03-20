using Typhon.Modbus.Exceptions;

namespace Typhon.Modbus.Data
{
    public static class AddressTools
    {
        public static int AddressNormalisation(int address)
        {
            if (address >= 00001 && address <= 09999)
            {
                //Coil
                return address;
            }
            else if (address >= 10001 && address <= 19999)
            {
                //Discrete Input
                return address - 10000;
            }
            else if (address >= 30001 && address <= 39999)
            {
                //Input Register
                return address - 30000;
            }
            else if (address >= 40001 && address <= 59999)
            {
                //Holding Register
                return address - 40000;
            }
            else
            {
                throw new AddressNotInSpecification(address.ToString());
            }
        }

        public static DataType AddressType(int address)
        {
            if (address >= 00001 && address <= 09999)
            {
                //Coil
                return DataType.Coil;
            }
            else if (address >= 10001 && address <= 19999)
            {
                //Discrete Input
                return DataType.DiscreteInput;
            }
            else if (address >= 30001 && address <= 39999)
            {
                //Input Register
                return DataType.InputRegister;
            }
            else if (address >= 40001 && address <= 59999)
            {
                //Holding Register
                return DataType.HoldingRegister;
            }
            else
            {
                throw new AddressNotInSpecification(address.ToString());
            }
        }
        
    }
}