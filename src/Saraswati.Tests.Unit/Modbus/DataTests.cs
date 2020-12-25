using NUnit.Framework;
using Saraswati.Modbus.Data;
using Saraswati.Modbus.Exceptions;

namespace Saraswati.Tests.Unit.Modbus
{
    public class DataTests
    {
        private DataModel TestDataModel01;

        private Data TestCoil;
        private Data TestDiscreteInput;
        private Data TestInputRegister;
        private Data TestHoldingRegister;
        
        [SetUp]
        public void Setup()
        {
            TestDataModel01 = DataModel.Create(1);

            var tempCoil = Data.Create(1, DataType.Coil);
            var tempDiscreteInput = Data.Create(1, DataType.DiscreteInput);
            
            TestDataModel01.UpdateValue(tempCoil);
            TestDataModel01.UpdateValue(tempDiscreteInput);
        }

        [Test]
        public void AddressNotInSpecification()
        {
            Assert.Throws<AddressNotInSpecification>(() =>
            {
                TestDataModel01.ValueExists(20020);
            });
        }

        [Test]
        public void ReadOnlyDataExceptionDiscreteInput()
        {
            TestDiscreteInput = Data.Create(1, DataType.DiscreteInput);

            Assert.Throws<ReadOnlyDataException>(() =>
            {
                TestDiscreteInput.Update(true);
            });
        }
        
        [Test]
        public void ReadOnlyDataExceptionDiscreteInputOverride()
        {
            TestDiscreteInput = Data.Create(1, DataType.DiscreteInput);

            Assert.DoesNotThrow(() =>
            {
                TestDiscreteInput.Update(true, true);
            });
        }
    }
}