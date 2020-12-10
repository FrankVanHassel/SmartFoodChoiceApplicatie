using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace server
{
    public class ConnectionClass
    {
        public void sendData(string Data)
        {
            byte[] dataArr = Encoding.ASCII.GetBytes(Data);

            NetworkStream stream = client.GetStream();
        }
    }
}
