using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
//using MySql.Data.MySqlClient;

namespace server
{
    public class Program
    {
        

        static void Main(string[] args)
        {
            //demo list
            List<string> demoList = new List<string> { "tomaat", "Nutri: A", "23", "11" };

            Console.WriteLine("Enter port to use: ");
            string portStr = Console.ReadLine();           
            int port = Int32.Parse(portStr);

            ClientConnection connection = new ClientConnection();
            DataHandler dataHandler = new DataHandler();


            // Set the IP address
            IPAddress serverIP = IPAddress.Parse("192.168.1.113");    // The IP address from the ubuntu server: 192.168.173.190
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

                if (clientMessage == "demotijd")
                {
                    connection.sendData(client, server, dataHandler.ListToData(demoList));
                }
                else
                {
                    connection.sendData(client, server, "request unclear");
                }

                
                foreach (string i in dataList)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
