using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SFC_App.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "Smart Food Choice";
        }

        private string appDescription = "Welkom bij de Smart Food Choice app! \nKies je producten en kijk hoeveel CO2 je uitstoot.";
        public string AppDescription
        {
            get { return appDescription; }
        }
    }
}