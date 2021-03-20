using System.Linq;
using Typhon.Modbus.Data;
using Typhon.Modbus.Frame;
using Typhon.Modbus.Function.Slave.DataAccess;

namespace Typhon.Modbus
{
    public static class FunctionMapping
    {
        public static byte[] ProcessSlaveFunction(ModbusTCPFrame frame)
        {

            DataModel dataModel;

            if (ModbusTCP.Slaves.Any(s => s.Key == frame.UnitIdentifier))
            {
                dataModel = ModbusTCP.Slaves.FirstOrDefault(s => s.Key == frame.UnitIdentifier).Value;
            }
            else
            {
                dataModel = DataModel.Create(frame.UnitIdentifier);
                ModbusTCP.Slaves.Add(frame.UnitIdentifier,dataModel);
            }

            switch (frame.FunctionCode)
            {
                case FunctionCode.ReadCoils:
                    return dataModel.ReadCoils(frame.Data);
                
                case FunctionCode.ReadDiscreteInputs:
                    return dataModel.ReadDiscreteInputs(frame.Data);
                
                case FunctionCode.WriteSingleCoil:
                    return dataModel.WriteSingleCoil(frame.Data);
                
                case FunctionCode.WriteMultipleCoils:
                    return dataModel.WriteMultipleCoils(frame.Data);
            }
            
            return new byte[0];
        }
    }
}