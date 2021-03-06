using System;
using System.Collections;
using System.Linq;
using Typhon.Modbus.Data;

namespace Typhon.Modbus.Function.Slave.DataAccess
{
    public static class BitAccess
    {
        //Code: 0x01
        public static byte[] ReadCoils(this DataModel model, byte[] data)
        {
            var startAddress = AddressHelper.GetAddress(data);
            var noToRead = AddressHelper.GetReadWriteNo(data);

            var bytesNeeded = (int) Math.Ceiling( (double)noToRead / 8);

            var dataReturn = new byte[bytesNeeded];
            var bitArray = new BitArray(dataReturn);

            for (int i = startAddress; i < startAddress + noToRead; i++)
            {
                bool value = false;
                if (model.Coils.Exists(d => d.Address.Equals(i)))
                {
                    // ReSharper disable once PossibleNullReferenceException
                    if (model.Coils.FirstOrDefault(d => d.Address.Equals(i)).Value == 1) value = true;
                }
                else
                {
                    var addedData = Data.Data.Create(i, DataType.Coil);
                    model.Coils.Add(addedData);
                }
                
                bitArray.Set(i - startAddress, value);
            }
            
            bitArray.CopyTo(dataReturn, 0);
            
#if DEBUG
            Console.WriteLine("Start Address: {0}", startAddress);
            Console.WriteLine("Reading For: {0}", noToRead);
#endif

            byte byteCount = (byte) bytesNeeded;
            byte[] pdu = new byte[] {byteCount};

            pdu = _combine(pdu, dataReturn);

            return pdu;
        }
        
        //Code: 0x02
        public static byte[] ReadDiscreteInputs(this DataModel model, byte[] data)
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
        public static byte[] WriteSingleCoil(this DataModel model, byte[] data)
        {
            var address = AddressHelper.GetAddress(data);
            var readVal = BitConverter.ToUInt16(data.Skip(2).Take(2).Reverse().ToArray());

            bool value = readVal > 0;

            if (model.Coils.Exists(d => d.Address.Equals(address)))
            {
                // ReSharper disable once PossibleNullReferenceException
                var coil = model.Coils.FirstOrDefault(d => d.Address.Equals(address));
                // ReSharper disable once PossibleNullReferenceException
                coil.Update(value);
            }
            else
            {
                var coil = Data.Data.Create(address, DataType.Coil);
                coil.Update(value);
                model.Coils.Add(coil);
            }
            
#if DEBUG
            Console.WriteLine("Write Address: {0}", address);
            Console.WriteLine("Write Value: {0}", value);
#endif
            return data;
        }
        
        //Code: 0x15
        public static byte[] WriteMultipleCoils(this DataModel model, byte[] data)
        {            
            var startAddress = AddressHelper.GetAddress(data);
            var noToWrite = AddressHelper.GetReadWriteNo(data);
#if DEBUG
            Console.WriteLine("Start Address: {0}", startAddress);
            Console.WriteLine("Writing For: {0}", noToWrite);
#endif
            return new byte[0];
        }

        private static byte[] _combine(byte[] first, byte[] second)
        {
            byte[] ret = new byte[first.Length + second.Length];
            Buffer.BlockCopy(first, 0, ret, 0, first.Length);
            Buffer.BlockCopy(second, 0, ret, first.Length, second.Length);
            return ret;
        }
        
    }
}