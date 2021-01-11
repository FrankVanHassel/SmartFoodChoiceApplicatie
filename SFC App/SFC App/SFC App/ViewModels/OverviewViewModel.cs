using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;
using System.Windows.Input;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Net.NetworkInformation;

namespace SFC_App.ViewModels
{
    public class OverviewViewModel : BaseViewModel
    {
        public OverviewViewModel()
        {
            var current = Connectivity.NetworkAccess;

            Title = "Overview";

            if (current == Xamarin.Essentials.NetworkAccess.Internet)
            {
                ServerConnection connection = new ServerConnection();
                TcpClient client = connection.CreateClient();
                // make the connection to the server
                NetworkStream stream = connection.GetStream(client);

                if (!client.Connected)
                {
                    connection.MakeConnection(client);
                }

                try
                {
                    connection.SendRequest(connection.getDemo, client, stream);
                    Data = connection.ReceiveData(client, stream);
                    connection.EndConnection(client, stream);
                }
                catch
                {
                    Data = "Fout: Kan geen data ophalen van server.";
                }
            }
            else
            {
                ErrorMessage();
            }
        }

        public void ErrorMessage()
        {
            Device.BeginInvokeOnMainThread(async () => await Application.Current.MainPage.DisplayAlert("Connectie error", "Er kan geen verbinding met de server worden vastgesteld", "OK"));
        }
    }
}