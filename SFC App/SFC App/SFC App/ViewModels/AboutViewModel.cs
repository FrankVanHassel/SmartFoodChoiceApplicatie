using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SFC_App.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {

        private string databaseTest;
        public string DatabaseTest
        {
            get { return databaseTest; }
        }

        private string appDescription = "Welkom bij de Smart Food Choice app! \nKies je producten en kijk hoeveel CO2 je uitstoot.";
        public string AppDescription
        {
            get { return appDescription; }
        }


        public AboutViewModel()
        {
            Title = "Smart Food Choice";
        }
       

        protected async void OnAppearing()
        {
            DatabaseConnection DBC = new DatabaseConnection();
            string passwrd = DBC.GetUserPwd("admin@admin.admin");
            databaseTest = passwrd;
        }
        
        
        
    }
}