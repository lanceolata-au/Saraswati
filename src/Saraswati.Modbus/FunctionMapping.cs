using Saraswati.Modbus.Frame;
using Saraswati.Modbus.Function.Slave.DataAccess;

namespace Saraswati.Modbus
{
    public static class FunctionMapping
    {
        public static byte[] ProcessSlaveFunction(ModbusTCPFrame frame)
        {

            switch (frame.FunctionCode)
            {
                case FunctionCode.ReadCoils:
                    return BitAccess.ReadCoils(frame.Data);
                
                case FunctionCode.ReadDiscreteInputs:
                    return BitAccess.ReadDiscreteInputs(frame.Data);
                
                case FunctionCode.WriteSingleCoil:
                    return BitAccess.WriteSingleCoil(frame.Data);
                
                case FunctionCode.WriteMultipleCoils:
                    return BitAccess.WriteMultipleCoils(frame.Data);
            }
            
            return new byte[0];
        }
    }
}