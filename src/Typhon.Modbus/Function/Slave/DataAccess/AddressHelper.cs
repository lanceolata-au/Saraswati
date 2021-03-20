using System;
using System.Linq;

namespace Typhon.Modbus.Function.Slave.DataAccess
{
    internal static class AddressHelper
    {
        public static int GetAddress(byte[] data)
        {
            //To conform to the standard in all places we offset the count by one
            return BitConverter.ToUInt16(data.Skip(0).Take(2).Reverse().ToArray()) + 1;
        }
        
        public static int GetReadWriteNo(byte[] data)
        {
            return BitConverter.ToUInt16(data.Skip(2).Take(2).Reverse().ToArray());
        }
    }
}