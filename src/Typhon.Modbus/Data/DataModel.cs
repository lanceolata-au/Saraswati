using System.Collections.Generic;
using Typhon.Modbus.Exceptions;

namespace Typhon.Modbus.Data
{
    public class DataModel
    {
        public uint StationNo { get; private set; }
        
        public List<Data> Coils { get; private set; }
        public List<Data> DiscreteInputs { get; private set; }
        public List<Data> InputRegisters { get; private set; }
        public List<Data> HoldingRegisters { get; private set; }
        
        public static DataModel Create(uint stationNo)
        {
            var obj = new DataModel
            {
                StationNo = stationNo,
                Coils = new List<Data>(),
                DiscreteInputs = new List<Data>(),
                InputRegisters = new List<Data>(),
                HoldingRegisters = new List<Data>()
            };
            
            return obj;
        }

        public bool ValueExists(int address)
        {
            var normalisedAddress = AddressTools.AddressNormalisation(address);
            var addressType = AddressTools.AddressType(address);

            switch (addressType)
            {
                case DataType.Coil:
                    return Coils.Exists(c => c.Address == normalisedAddress);

                case DataType.DiscreteInput:
                    return DiscreteInputs.Exists(c => c.Address == normalisedAddress);
                
                case DataType.InputRegister:
                    return InputRegisters.Exists(c => c.Address == normalisedAddress);
                
                case DataType.HoldingRegister:
                    return HoldingRegisters.Exists(c => c.Address == normalisedAddress);
            }

            return false;

        }
        
        public void UpdateValue(Data data, bool readOnlyOverride = false)
        {
            var normalisedAddress = AddressTools.AddressNormalisation(data.Address);
            var addressType = AddressTools.AddressType(data.Address);

            if (addressType != data.Type)
            {
                throw new DataTypeDoesNotMatchAddressException(data.Address.ToString());
            }
            
            if (ValueExists(data.Address))
            {
                switch (addressType)
                {
                    case DataType.Coil:
                        Coils.Find(c => c.Address == normalisedAddress).Update(data.Value, readOnlyOverride);
                        break;

                    case DataType.DiscreteInput:
                        DiscreteInputs.Find(c => c.Address == normalisedAddress).Update(data.Value, readOnlyOverride);
                        break;
                
                    case DataType.InputRegister:
                        InputRegisters.Find(c => c.Address == normalisedAddress).Update(data.Value, readOnlyOverride);
                        break;
                
                    case DataType.HoldingRegister:
                        HoldingRegisters.Find(c => c.Address == normalisedAddress).Update(data.Value, readOnlyOverride);
                        break;
                }

            }                
            else
            {
                var normalisedData = Data.Create(normalisedAddress, data.Type);
                
                switch (addressType)
                {
                    case DataType.Coil:
                        Coils.Add(normalisedData);
                        break;

                    case DataType.DiscreteInput:
                        DiscreteInputs.Add(normalisedData);
                        break;
                
                    case DataType.InputRegister:
                        InputRegisters.Add(normalisedData);
                        break;
                
                    case DataType.HoldingRegister:
                        HoldingRegisters.Add(normalisedData);
                        break;
                }
            }
        }

        public void UpdateValue(List<Data> bulkData)
        {
            foreach (var data in bulkData)
            {
                UpdateValue(data);
            }
        }
        
    }
}