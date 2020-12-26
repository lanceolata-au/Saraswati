using System;

namespace Saraswati.Modbus.Function.Slave.DataAccess
{
    public static class BitAccess
    {
        //Code: 0x01
        public static byte[] ReadCoils(byte[] data)
        {
            var startAddress = AddressHelper.GetAddress(data);
            var noToRead = AddressHelper.GetReadWriteNo(data);
#if DEBUG
            Console.WriteLine("Start Address: {0}", startAddress);
            Console.WriteLine("Reading For: {0}", noToRead);
#endif
            return new byte[0];
        }
        
        //Code: 0x02
        public static byte[] ReadDiscreteInputs(byte[] data)
        {
            var startAddress = AddressHelper.GetAddress(data);
            var noToRead = AddressHelper.GetReadWriteNo(data);
#if DEBUG
            Console.WriteLine("Start Address: {0}", startAddress);
            Console.WriteLine("Reading For: {0}", noToRead);
#endif
            return new byte[0];
        }
        
        //Code: 0x05
        public static byte[] WriteSingleCoil(byte[] data)
        {
            var startAddress = AddressHelper.GetAddress(data);
            var noToWrite = AddressHelper.GetReadWriteNo(data);
#if DEBUG
            Console.WriteLine("Start Address: {0}", startAddress);
            Console.WriteLine("Writing For: {0}", noToWrite);
#endif
            return new byte[0];
        }
        
        //Code: 0x15
        public static byte[] WriteMultipleCoils(byte[] data)
        {            
            var startAddress = AddressHelper.GetAddress(data);
            var noToWrite = AddressHelper.GetReadWriteNo(data);
#if DEBUG
            Console.WriteLine("Start Address: {0}", startAddress);
            Console.WriteLine("Writing For: {0}", noToWrite);
#endif
            return new byte[0];
        }
        
    }
}