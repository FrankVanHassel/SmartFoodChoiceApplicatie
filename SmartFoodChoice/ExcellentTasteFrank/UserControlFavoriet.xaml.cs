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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SmartFoodChoiceApp
{
    /// <summary>
    /// Interaction logic for UserControlFavoriet.xaml
    /// </summary>
    public partial class UserControlFavoriet : UserControl
    {
        public UserControlFavoriet()
        {
            InitializeComponent();
        }

        private void btn_Burger_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Dit product heeft een CO-2 uitstoot van 30,7 kilo.");
        }

        private void btn_Friet_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Dit product heeft een CO-2 uitstoot van 3,1 kilo.");
        }

        private void btn_Twix_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Dit product heeft een CO-2 uitstoot van 5,6 kilo.");
        }

        private void btn_Banaan_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Dit product heeft een CO-2 uitstoot van 0,9 kilo.");
        }

        private void btn_Salade_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Dit product heeft een CO-2 uitstoot van 3,9 kilo.");
        }

        private void btn_Garnalen_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Dit product heeft een CO-2 uitstoot van 15,4 kilo.");
        }

        private void btn_Kaas_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Dit product heeft een CO-2 uitstoot van 13,1 kilo.");
        }

        private void btn_VegaBurger_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Dit product heeft een CO-2 uitstoot van 4,1 kilo.");
        }

        private void btn_Brocolli_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Dit product heeft een CO-2 uitstoot van 0,24 kilo.");
        }

        private void btn_Kiwi_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Dit product heeft een CO-2 uitstoot van 5,3 kilo.");
        }
    }
}
