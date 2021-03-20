using System;
using System.Linq;

namespace Typhon.Modbus.Frame
{
    public class ModbusTCPFrame
    {
        public ushort TransactionIdentifier { get; }
        public ushort ProtocolIdentifier { get; }
        public ushort LengthField{ get; }
        public byte UnitIdentifier{ get; }
        public FunctionCode FunctionCode { get; }
        public byte[] Data { get; }

        public ModbusTCPFrame(byte[] bytes)
        {

            TransactionIdentifier = BitConverter.ToUInt16(bytes.Skip(0).Take(2).Reverse().ToArray());
            ProtocolIdentifier = BitConverter.ToUInt16(bytes.Skip(2).Take(2).Reverse().ToArray());
            LengthField = BitConverter.ToUInt16(bytes.Skip(4).Take(2).Reverse().ToArray());
            UnitIdentifier = bytes.Skip(6).Take(1).ToArray()[0];
            FunctionCode = (FunctionCode) bytes.Skip(7).Take(1).ToArray()[0];
            Data = bytes.Skip(8).Take(LengthField - 2).ToArray();

        }
    }
}