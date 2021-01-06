using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net;
using System.Net.Sockets;


namespace client
{
    public partial class clientForm : Form
    {
        //string serverIP = "145.93.144.80";
        string serverIP = "192.168.1.113";//"192.168.174.189";
        int port = 8081;

        public clientForm()
        {
            InitializeComponent();
        }

        private void sendBtn_Click(object sender, EventArgs e)
        {
            TcpClient client = new TcpClient(serverIP, port);
            int byteCount = Encoding.ASCII.GetByteCount(messageTb.Text);

            byte[] sendData = new byte[byteCount];
            sendData = Encoding.ASCII.GetBytes(messageTb.Text);

            NetworkStream stream = client.GetStream();
            stream.Write(sendData, 0, sendData.Length);

            


            

            // The part below are for receiving a message from the server, and then convert it to a string
            // The client must receive a message, otherwise the application will freeze :(      (fixed this?)
            byte[] serverMessage = new byte[100];

            do
            {
                stream.Read(serverMessage, 0, serverMessage.Length);
                string serverMessageString = Encoding.ASCII.GetString(serverMessage);
                MessageBox.Show(serverMessageString);
            }
            while (stream.DataAvailable);

            // Stop the connection
            stream.Close();
            client.Close();

        }
    }
}
