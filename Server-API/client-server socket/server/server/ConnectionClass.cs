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
            
            stream.Write(dataArr);
        }
        

        public string readData(TcpClient client, TcpListener server)
        {

            byte[] receivedBuffer = new byte[100];

            NetworkStream stream = client.GetStream();
            stream.Read(receivedBuffer, 0, receivedBuffer.Length);

            StringBuilder clientMessage = new StringBuilder();

            foreach (byte b in receivedBuffer)
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

            return clientMessage.ToString();
        }
    }
}
