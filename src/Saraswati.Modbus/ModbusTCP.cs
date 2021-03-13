using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Saraswati.Modbus.CoreFunctions;
using Saraswati.Modbus.Data;
using Saraswati.Modbus.Frame;

namespace Saraswati.Modbus
{
    public class ModbusTCP
    {
        internal static Dictionary<uint, DataModel> Slaves = new Dictionary<uint, DataModel>();
        
        private readonly Int32 _port = 502;
        private TcpListener _server;
        
        public ModbusTCP()
        {
            _server = TcpListener.Create(_port);
        }

        public void Start()
        {
            try
            {
                _server.Start();
                
                // Buffer for reading data
                var bytes = new byte[1024];
                string data = null;

                while (true)
                {    
                    Console.Write("Waiting for a connection... ");
                    var client = _server.AcceptTcpClient();
                    
                    Console.WriteLine("Connected!");

                    // Get a stream object for reading and writing
                    var stream = client.GetStream();

                    // Loop to receive all the data sent by the client.
                    while((stream.Read(bytes, 0, bytes.Length))!=0)
                    {
                        //Console.WriteLine("Received: {0}", Formatter.ByteArrayToString(bytes));
                        
                        var frame = new ModbusTCPFrame(bytes);

#if DEBUG
                        Console.WriteLine("Transaction identifier: {0}", frame.TransactionIdentifier);
                        Console.WriteLine("Protocol identifier: {0}", frame.ProtocolIdentifier);
                        Console.WriteLine("Length field: {0}", frame.LengthField);
                        Console.WriteLine("Unit identifier: {0}", frame.UnitIdentifier);
                        Console.WriteLine("Function code: {0}", frame.FunctionCode.GetDescription());
                        Console.WriteLine("Data: {0}", Formatter.ByteArrayToString(frame.Data));
#endif
                        
                        byte[] returnData = FunctionMapping.ProcessSlaveFunction(frame);

                        byte transActIdb0 = (byte)frame.TransactionIdentifier,
                            transActIdb1 = (byte)(frame.TransactionIdentifier>>8);

                        byte unitId = (byte) frame.UnitIdentifier;
                        
                        byte function = (byte) frame.FunctionCode;

                        byte dataLenth = (byte)(returnData.Length + 2);
                        
                        byte[] header = new byte[] {transActIdb1, transActIdb0, 0x00, 0x00, 0x00, dataLenth, unitId, function};

                        byte[] msg = _combine(header, returnData);

                        // Send back a response.
                        stream.Write(msg, 0, msg.Length);

#if DEBUG
                        Console.WriteLine("Sent: {0}", Formatter.ByteArrayToString(msg));
#endif
                        
                    }

                    // Shutdown and end connection
                    client.Close();
                    
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                // Stop listening for new clients.
                _server.Stop();
            }
            
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