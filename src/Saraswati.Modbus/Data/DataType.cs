namespace Saraswati.Modbus.Data
{
    
/*
Object type	     |  Access	    |   Size	 |  Address Space
-------------------------------------------------------------
Coil	         |  Read-write  |   1 bit	 |  00001 - 09999
Discrete input	 |  Read-only	|   1 bit	 |  10001 - 19999
Input register	 |  Read-only	|  16 bits   |  30001 - 39999
Holding register |	Read-write	|  16 bits   |  40001 - 49999
*/
    
    public enum DataType : byte
    {
        Coil = 0,
        DiscreteInput = 1,
        InputRegister = 3,
        HoldingRegister = 4
    }
}