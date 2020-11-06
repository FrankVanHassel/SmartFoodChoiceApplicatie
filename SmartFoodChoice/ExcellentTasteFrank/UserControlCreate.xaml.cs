using MaterialDesignThemes.Wpf;
using SmartFoodChoiceApp;
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

namespace ExcellentTasteFrank
{
    /// <summary>
    /// Interaction logic for UserControlCreate.xaml
    /// </summary>
    public partial class UserControlCreate : UserControl
    {
        //Database connectie
        DataClasses1DataContext db = new DataClasses1DataContext();

        public UserControlCreate()
        {
            InitializeComponent();


        }

        private void btn_Burger_Click(object sender, RoutedEventArgs e)
        {
            Lijst.Items.Add("Burger - 30,7");
        }
        private void btn_VegaBurger_Click(object sender, RoutedEventArgs e)
        {
            Lijst.Items.Add("VegaBurger - 4,1");
        }
        private void btn_Kip_Click(object sender, RoutedEventArgs e)
        {
            Lijst.Items.Add("Kip: - 6,4 kilo");
        }
        private void btn_Biefstuk_Click(object sender, RoutedEventArgs e)
        {
            Lijst.Items.Add("Biefstuk: - 57,9 kilo");
        }
        private void btn_Friet_Click(object sender, RoutedEventArgs e)
        {
            Lijst.Items.Add("Friet: - 3,1 kilo CO-2");
        }
        private void btn_Donut_Click(object sender, RoutedEventArgs e)
        {
            Lijst.Items.Add("Donut");
        }
        private void btn_Brocolli_Click(object sender, RoutedEventArgs e)
        {
            Lijst.Items.Add("Brocolli: - 0,24 kilo CO-2");
        }
        private void btn_Salade_Click(object sender, RoutedEventArgs e)
        {
            Lijst.Items.Add("Salade: - kilo CO-2");
        }

        

        private void btn_ClearList_Click(object sender, RoutedEventArgs e)
        {
            Lijst.Items.Clear();
        }
        private void Button_Click_toevoegen(object sender, RoutedEventArgs e)
        {
            tbl_Overzicht Ovz = new tbl_Overzicht();
            Ovz.Productnaam = (string)burgerCheck.Content;
            db.tbl_Overzichts.InsertOnSubmit(Ovz);
            

            int i = 0, 
            result = 0;
            var sum = Lijst.Items
             .OfType<string>()
             .Select(s => Convert.ToDouble(s.Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries)[1]))     
             .Sum();

            MessageBox.Show( "Aantal kilo CO-2 uitstoot: " + sum.ToString());
            
        }

        private void btn_Remove_Click(object sender, RoutedEventArgs e)
        {
            Lijst.Items.Remove(Lijst.SelectedItem);
        }

        private void btn_Sushi_Click(object sender, RoutedEventArgs e)
        {
            Lijst.Items.Add("Sushi: - kilo CO-2");
        }

        private void btn_Pizza_Click(object sender, RoutedEventArgs e)
        {
            Lijst.Items.Add("Pizza: - kilo CO-2");
        }

        private void btn_Tomaat_Click(object sender, RoutedEventArgs e)
        {
            Lijst.Items.Add("Tomaat: - kilo CO-2");
        }

        private void btn_Banaan_Click(object sender, RoutedEventArgs e)
        {
            Lijst.Items.Add("Banaan: - kilo CO-2");
        }

        private void btn_Lasgne_Click(object sender, RoutedEventArgs e)
        {
            Lijst.Items.Add("Lasagne: - kilo CO-2");
        }

        private void btn_Twix_Click(object sender, RoutedEventArgs e)
        {
            Lijst.Items.Add("Twix: - kilo CO-2");
        }

        private void btn_Kiwi_Click(object sender, RoutedEventArgs e)
        {
            Lijst.Items.Add("Kiwi: - kilo CO-2");
        }

        private void btn_Paprika_Click(object sender, RoutedEventArgs e)
        {
            Lijst.Items.Add("Paprika: - kilo CO-2");
        }

        private void btn_Snickers_Click(object sender, RoutedEventArgs e)
        {
            Lijst.Items.Add("Snickers: - kilo CO-2");
        }

        private void btn_Garnalen_Click(object sender, RoutedEventArgs e)
        {
            Lijst.Items.Add("Garnalen: - kilo CO-2");
        }
    }
}
