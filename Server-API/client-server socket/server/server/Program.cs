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

                string clientMessage = connection.readData(client, server);
              
                Console.WriteLine(clientMessage);

                //// Inside this if statement could be a message that contains data from the database
                //if (clientMessage == "response")
                //{                    
                //    connection.sendData(client, server, "response back");
                //}
                //else
                //{
                //    connection.sendData(client, server, "no response");
                //}

                List<string> dataList =  dataHandler.DataToList(clientMessage);

                foreach (string i in dataList)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
