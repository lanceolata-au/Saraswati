using System;
using System.Net.Sockets;
using System.Text;
using Saraswati.Modbus.CoreFunctions;
using Saraswati.Modbus.Frame;

namespace Saraswati.Modbus
{
    public class ModbusTCP
    {
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
                        
                        Console.WriteLine("Transaction identifier: {0}", frame.TransactionIdentifier);
                        
                        Console.WriteLine("Protocol identifier: {0}", frame.ProtocolIdentifier);
                        
                        Console.WriteLine("Length field: {0}", frame.LengthField);
                        
                        Console.WriteLine("Unit identifier: {0}", frame.UnitIdentifier);

                        Console.WriteLine("Function code: {0}", frame.FunctionCode.GetDescription());
                        
                        Console.WriteLine("Data: {0}", Formatter.ByteArrayToString(frame.Data));

                        byte[] msg = {0x00, 0x00, 0x00};

                        // Send back a response.
                        stream.Write(msg, 0, msg.Length);
                        Console.WriteLine("Sent: {0}", msg);
                    }

                    // Shutdown and end connection
                    client.Close();
                    
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                // Stop listening for new clients.
                _server.Stop();
                
                Console.WriteLine("\nHit enter to continue...");
                Console.Read();
            }
            
        }
        
    }
}