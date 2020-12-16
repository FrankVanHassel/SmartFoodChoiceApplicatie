using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace SFC_App
{
    public class ServerConnection
    {
        string serverIP = "145.93.144.80";
        int port = 8080;


        public void SendData(List<string> data)
        {
            TcpClient client = new TcpClient(serverIP, port);
            int byteCount = Encoding.ASCII.GetByteCount("banaan/33/22/B/fruit");

            byte[] sendData = new byte[byteCount];
            sendData = Encoding.ASCII.GetBytes("banaan/33/22/B/fruit");

            NetworkStream stream = client.GetStream();
            stream.Write(sendData, 0, sendData.Length);

            stream.Close();
            client.Close();
        }


        public string ReceiveData()
        {
            TcpClient client = new TcpClient(serverIP, port);
            NetworkStream stream = client.GetStream();
            byte[] serverMessage = new byte[100];
            string serverMessageString;

            do
            {
                stream.Read(serverMessage, 0, serverMessage.Length);
                serverMessageString = Encoding.ASCII.GetString(serverMessage);               
            }
            while (stream.DataAvailable);

            // Stop the connection
            stream.Close();
            client.Close();

            return serverMessageString;
        }
    }
}
