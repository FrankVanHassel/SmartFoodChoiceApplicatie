using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace server
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter port to use: ");
            string portStr = Console.ReadLine();           
            int port = Int32.Parse(portStr);


            // Set the IP address
            IPAddress serverIP = IPAddress.Parse("192.168.1.113");
            TcpListener server = new TcpListener(serverIP, port);
            TcpClient client = default(TcpClient);

            try
            {
                server.Start();
                Console.WriteLine("server started");
                Console.WriteLine("--------------");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.Read();     // Wait for the user to press a button
            }


            while (true)
            {
                client = server.AcceptTcpClient();

                byte[] receivedBuffer = new byte[100];
                NetworkStream stream = client.GetStream();

                // Read the received data from the client and store it in receivedBuffer.
                stream.Read(receivedBuffer, 0, receivedBuffer.Length);

                // Create a empty stringbuilder to build the message
                StringBuilder clientMessage = new StringBuilder();

                foreach(byte b in receivedBuffer)
                {
                    // 00 equals null, this is impossible for the user to put in their message. 
                    if (b.Equals(00))   
                    {
                        break;
                    }
                    else
                    {
                        // First complete the byte to a character, then to a string. Then append it in the message.
                        clientMessage.Append(Convert.ToChar(b).ToString());     
                    }
                }

                Console.WriteLine(clientMessage.ToString());


                // Inside this if statement could be a message that contains data from the database
                if (clientMessage.ToString() == "response")
                {
                    byte[] serverMessage = Encoding.ASCII.GetBytes("hello");

                    stream.Write(serverMessage);
                }
            }
        }
    }
}
