using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;
using System.Windows.Input;


namespace SFC_App.ViewModels
{
    public class OverviewViewModel : BaseViewModel
    {
        public OverviewViewModel()
        {
            Title = "Overview";


            try
            {
                ServerConnection connection = new ServerConnection();
                TcpClient client = connection.CreateClient();
                NetworkStream stream = connection.GetStream(client);

                connection.SendRequest(connection.getDemo, client, stream);
                Data = connection.ReceiveData(client, stream);
                connection.EndConnection(client, stream);
            }
            catch 
            {
                Data = "Not connected to server";
            }


        }
    }
}