using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SmartFoodChoice
{
    /// <summary>
    /// Interaction logic for Adminwindow.xaml
    /// </summary>
    public partial class Adminwindow : Window
    {
        public Adminwindow()
        {
            InitializeComponent();
            var userName = Application.Current.Resources["UserName"];
            if (userName != null)
            {
                this.txtUsername.Text = userName.ToString();
            }
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UserControl usc = null;
            GridMain.Children.Clear();

            switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            {
                case "ItemHome":
                    Adminwindow mypage = new Adminwindow();
                    mypage.Show();
                    break;
                case "ItemCreate":
                    usc = new UserControlproducttoevoegen();
                    GridMain.Children.Add(usc);
                    break;
            }
        }

        private void Logoutclick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("U bent nu uitgelogd.", "SmartFoodChoice", MessageBoxButton.OK, MessageBoxImage.Stop);
            this.Close();
        }

        private void Logoutclick(object sender, RoutedEventArgs e)
        {

        }
    }
}