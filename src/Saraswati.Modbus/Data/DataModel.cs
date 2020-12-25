using System.Collections.Generic;

namespace Saraswati.Modbus.Data
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
        
        
        
    }
}