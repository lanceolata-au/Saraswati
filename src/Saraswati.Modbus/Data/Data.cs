using System.Data;
using Saraswati.Modbus.Exceptions;

namespace Saraswati.Modbus.Data
{
    public class Data
    {
        public int Address { get; private set; }
        public DataType Type { get; private set; }
        
        public ushort Value { get; private set; }
        
        public static Data Create(int address, DataType type)
        {
            var obj = new Data();
            
            obj.Address = address;
            obj.Type = type;
            obj.Value = 0x0;
            
            return obj;
        }

        public void Update(ushort value, bool readOnlyOverride = false)
        {
            if (Type == DataType.Coil || Type == DataType.DiscreteInput)
            {
                throw new IncorrectDataTypeException();
            }

            if (Type == DataType.InputRegister && !readOnlyOverride)
            {
                throw new ReadOnlyDataException();
            }

            Value = value;

        }

        public void Update(bool value, bool readOnlyOverride = false)
        {
            if (Type == DataType.HoldingRegister || Type == DataType.InputRegister)
            {
                throw new IncorrectDataTypeException();
            }

            if (Type == DataType.DiscreteInput && !readOnlyOverride)
            {
                throw new ReadOnlyDataException();
            }
            
            Value = value ? (ushort) 0x1 : (ushort) 0x0;
            
        }
        
    }
    
}    