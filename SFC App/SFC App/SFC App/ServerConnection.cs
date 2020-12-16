using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace SFC_App
{
    public class ServerConnection
    {
        string serverIP = "192.168.174.189";    // The IP address from the ubuntu server
        int port = 8080;

        public void SendData(List<string> data)
        {
            // Convert the data from a list to a string
            DataHandler dataConvert = new DataHandler();
            string dataString = dataConvert.ListToData(data);

            // Create new tcp client, and get the amount of bytes in the message
            TcpClient client = new TcpClient(serverIP, port);
            int byteCount = Encoding.ASCII.GetByteCount(dataString);

            // Create the buffer to send via tcp
            byte[] buffer = new byte[byteCount];
            buffer = Encoding.ASCII.GetBytes(dataString);

            // Get the stream and use it to send the buffer to the server
            NetworkStream stream = client.GetStream();
            stream.Write(buffer, 0, buffer.Length);
        }
    }
}
