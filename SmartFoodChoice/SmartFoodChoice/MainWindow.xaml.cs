using System.Windows;
using System.Windows.Controls;

namespace SmartFoodChoice
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            var userName = Application.Current.Resources["UserName"];
            if (userName != null)
            {
                this.txtUsername.Text = userName.ToString();
            }
        }
       
        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UserControl usc = null;
            GridMain.Children.Clear();

            switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            {
                case "ItemHome":
                    MainWindow mypage = new MainWindow();
                    mypage.Show();
                    break;
                case "ItemCreate":
                    usc = new UserControlCreate();
                    GridMain.Children.Add(usc);
                    break;
                case "Overzicht":
                    usc = new UserControlOverzicht();
                    GridMain.Children.Add(usc);
                    break;
                case "Favoriet":
                    usc = new UserControlFavoriet();
                    GridMain.Children.Add(usc);
                    break;

            }
        }

        private void Logoutclick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("U bent nu uitgelogd.", "SmartFoodChoice", MessageBoxButton.OK, MessageBoxImage.Stop);
            this.Close();
        }
    }
}


// hallo