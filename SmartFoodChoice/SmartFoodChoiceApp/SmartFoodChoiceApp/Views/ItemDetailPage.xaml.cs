using SmartFoodChoiceApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace SmartFoodChoiceApp.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}