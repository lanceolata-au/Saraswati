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
            var obj = new Data
            {
                Address = address, 
                Type = type, 
                Value = 0x0
            };

            return obj;
        }

        public void Update(ushort value, bool readOnlyOverride = false)
        {
            if (Type == DataType.Coil || Type == DataType.DiscreteInput)
            {
                throw new IncorrectDataTypeException((Address + (int)Type*10000).ToString());
            }

            if (Type == DataType.InputRegister && !readOnlyOverride)
            {
                throw new ReadOnlyDataException((Address + (int)Type*10000).ToString());
            }

            Value = value;

        }

        public void Update(bool value, bool readOnlyOverride = false)
        {
            if (Type == DataType.HoldingRegister || Type == DataType.InputRegister)
            {
                throw new IncorrectDataTypeException((Address + (int)Type*10000).ToString());
            }

            if (Type == DataType.DiscreteInput && !readOnlyOverride)
            {
                throw new ReadOnlyDataException((Address + (int)Type*10000).ToString());
            }
            
            Value = value ? (ushort) 0x1 : (ushort) 0x0;
            
        }
        
    }
    
}    