using SFC_App.Models;
using SFC_App.ViewModels;
using SFC_App.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using System.Collections.ObjectModel;


namespace SFC_App.Views
{
    public partial class ItemsPage : ContentPage
    {
        //ItemsViewModel _viewModel;

        public ObservableCollection<Items> ListItems { get; set; } 
        public ItemsPage()
        {
            InitializeComponent();
            ListItems = new ObservableCollection<Items> 
            {
                new Items{ Name="ItemList"}
            };
            BindingContext = this;
            //BindingContext = _viewModel = new ItemsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            //  _viewModel.OnAppearing();
        }
    }

    
    public class Items
    {
        public string ImgIcon { get; set; }

        public string Name { get; set; }
    }
}