using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace server
{
    public class ConnectionClass
    {
        public void sendData(TcpClient client, TcpListener server, string Data)
        {
            byte[] dataArr = Encoding.ASCII.GetBytes(Data);
           
            NetworkStream stream = client.GetStream();
            client = server.AcceptTcpClient();

            stream.Write(dataArr);
        }

        public string readData(TcpClient client, TcpListener server)
        {
            return "hoi";
        }
    }
}
