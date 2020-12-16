using System;
using System.Collections.Generic;
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

            ConnectionClass connection = new ConnectionClass();
            DataHandler dataHandler = new DataHandler();


            // Set the IP address
            IPAddress serverIP = IPAddress.Parse("192.168.174.189");    //IP from the ubuntu machine
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

                string clientMessage = connection.readData(client, server);
              
                //Console.WriteLine(clientMessage);

                List<string> dataList =  dataHandler.DataToList(clientMessage);

                connection.sendData(client, server, "message from server");

                foreach (string i in dataList)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
