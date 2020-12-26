using System.ComponentModel;

namespace Saraswati.Modbus.Frame
{
    public enum FunctionCode : byte
    {
        [Description("[0x00] Not Known")]
        NONE = 0x00,
        [Description("[0x01] Internal Bits or Physical Coils Read Coils")]
        ReadCoils = 0x01,
        [Description("[0x02] Read Discrete Inputs")]
        ReadDiscreteInputs = 0x02,
        [Description("[0x03] Read Multiple Holding Registers")]
        ReadMultipleHoldingRegisters = 0x03,
        [Description("[0x04] Read Input Registers")]
        ReadInputRegisters = 0x04,
        [Description("[0x05] Write Single Coil")]
        WriteSingleCoil = 0x05,
        [Description("[0x06] Write Single Holding Register")]
        WriteSingleHoldingRegister = 0x06,
        [Description("[0x07] Read Exception Status")]
        ReadExceptionStatus = 0x07,
        [Description("[0x08] Diagnostic")]
        Diagnostic = 0x08,
        [Description("[0x10] Write Multiple Holding Registers")]
        WriteMultipleHoldingRegisters = 0x10,
        [Description("[0x0B] Get Com Event Counter")]
        GetComEventCounter = 0x0B,
        [Description("[0x0C] Get Com Event Log")]
        GetComEventLog = 0x0C,
        [Description("[0x0F] Write Multiple Coils")]
        WriteMultipleCoils = 0x0F,
        [Description("[0x11] Report Slave ID")]
        ReportSlaveID = 0x11,
        [Description("[0x14] Read File Record")]
        ReadFileRecord = 0x14,
        [Description("[0x15] Read Discrete Inputs")]
        WriteFileRecord = 0x15,
        [Description("[0x16] Mask Write Register")]
        MaskWriteRegister = 0x16,
        [Description("[0x17] Read Write Multiple Registers")]
        ReadWriteMultipleRegisters = 0x17,
        [Description("[0x18] Read FIFO Queue")]
        ReadFIFOQueue = 0x18,
        [Description("[0x43] Read Device Identification")]
        ReadDeviceIdentification = 0x43
    }
}