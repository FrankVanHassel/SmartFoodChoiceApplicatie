using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace SFC_App
{
    public class ServerConnection
    {
        private string serverIP = "192.168.174.189";    // The IP address from the ubuntu server: 192.168.174.189
        private int port = 8080;
        public string getDemo = "demotijd";


        public TcpClient CreateClient()
        {
            TcpClient client = new TcpClient(serverIP, port);
            return client;
        }

        public NetworkStream GetStream(TcpClient client)
        {
            NetworkStream stream = client.GetStream();
            return stream;
        }

        public void EndConnection(TcpClient client, NetworkStream stream)
        {
            stream.Close();
            client.Close();
        }


        /// <summary>
        /// Used to send data to the server. This function does not close the client or stream!
        /// </summary>
        /// <param name="data"></param>
        public void SendData(List<string> data, TcpClient client, NetworkStream stream)
        {
            // Convert the data from a list to a string
            DataHandler dataConvert = new DataHandler();
            string dataString = dataConvert.ListToData(data);

            // Create new tcp client, and get the amount of bytes in the message
            //TcpClient client = new TcpClient(serverIP, port);
            int byteCount = Encoding.ASCII.GetByteCount(dataString);

            // Create the buffer to send via tcp
            byte[] buffer = new byte[byteCount];
            buffer = Encoding.ASCII.GetBytes(dataString);

            // Get the stream and use it to send the buffer to the server
            //NetworkStream stream = client.GetStream();
            stream.Write(buffer, 0, buffer.Length);
        }


        /// <summary>
        /// Used to receive data from the server. This function will close the client and the stream. 
        /// </summary>
        /// <returns>The data received form the server.</returns>
        public string ReceiveData(TcpClient client, NetworkStream stream)
        {
            byte[] serverMessage = new byte[256];
            string serverMessageString;

            //TcpClient client = new TcpClient(serverIP, port);
            //NetworkStream stream = client.GetStream();


            do
            {
                stream.Read(serverMessage, 0, serverMessage.Length);
                serverMessageString = Encoding.ASCII.GetString(serverMessage);
                //MessageBox.Show(serverMessageString);
            }
            while (stream.DataAvailable);

            return serverMessageString;
        }


        public void SendRequest(string request, TcpClient client, NetworkStream stream)
        {
            //TcpClient client = new TcpClient(serverIP, port);
            //int byteCount = Encoding.ASCII.GetByteCount(request);
            byte[] buffer = Encoding.ASCII.GetBytes(request);

            //NetworkStream stream = client.GetStream();
            stream.Write(buffer, 0, buffer.Length);
        }

    }
}
