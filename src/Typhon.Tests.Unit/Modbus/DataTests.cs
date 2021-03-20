using NUnit.Framework;
using Typhon.Modbus.Data;
using Typhon.Modbus.Exceptions;

namespace Typhon.Tests.Unit.Modbus
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
            var tempDiscreteInput = Data.Create(10001, DataType.DiscreteInput);
            
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
            TestDiscreteInput = Data.Create(10001, DataType.DiscreteInput);

            Assert.Throws<ReadOnlyDataException>(() =>
            {
                TestDiscreteInput.Update(true);
            });
        }
        
        [Test]
        public void ReadOnlyDataExceptionDiscreteInputOverride()
        {
            TestDiscreteInput = Data.Create(10001, DataType.DiscreteInput);

            Assert.DoesNotThrow(() =>
            {
                TestDiscreteInput.Update(true, true);
            });
        }
        
        [Test]
        public void ReadOnlyDataExceptionInputRegister()
        {
            TestInputRegister = Data.Create(30001, DataType.InputRegister);

            Assert.Throws<ReadOnlyDataException>(() =>
            {
                TestInputRegister.Update(100);
            });
        }
        
        [Test]
        public void ReadOnlyDataExceptionDiscreteInputRegisterOverride()
        {
            TestInputRegister = Data.Create(30001, DataType.InputRegister);

            Assert.DoesNotThrow(() =>
            {
                TestInputRegister.Update(100, true);
            });
        }
    }
}