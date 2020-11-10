using SmartFoodChoice.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace SmartFoodChoice
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
            List<Item> list = new List<Item>();
            list.Add(new Item { ProductId = 1, CO2Value = 30, Productnaam = "A", Smiley = "Sad", Image = "images/burger.png" });
            list.Add(new Item { ProductId = 2, CO2Value = 40, Productnaam = "B", Smiley = "Sad", Image = "images/burger.png" });
            list.Add(new Item { ProductId = 3, CO2Value = 50, Productnaam = "C", Smiley = "Sad", Image = "images/burger.png" });
            list.Add(new Item { ProductId = 4, CO2Value = 60.4, Productnaam = "D", Smiley = "Sad", Image = "images/burger.png" });
            this.overzichtList.ItemsSource = list;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var item = (Item)(sender as Button).DataContext;
            this.Lijst.Items.Add(item);
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }



        //private void btn_Burger_Click(object sender, RoutedEventArgs e)
        //{
        //    Lijst.Items.Add("Burger - 30,7");
        //}
        //private void btn_VegaBurger_Click(object sender, RoutedEventArgs e)
        //{
        //    Lijst.Items.Add("VegaBurger - 4,1");
        //}
        //private void btn_Kip_Click(object sender, RoutedEventArgs e)
        //{
        //    Lijst.Items.Add("Kip: - 6,4");
        //}
        //private void btn_Biefstuk_Click(object sender, RoutedEventArgs e)
        //{
        //    Lijst.Items.Add("Biefstuk: - 57,9");
        //}
        //private void btn_Friet_Click(object sender, RoutedEventArgs e)
        //{
        //    Lijst.Items.Add("Friet: - 3,1");
        //}
        //private void btn_Kaas_Click(object sender, RoutedEventArgs e)
        //{
        //    Lijst.Items.Add("Kaas - 13,1");
        //}
        //private void btn_Brocolli_Click(object sender, RoutedEventArgs e)
        //{
        //    Lijst.Items.Add("Brocolli: - 0,24");
        //}
        //private void btn_Salade_Click(object sender, RoutedEventArgs e)
        //{
        //    Lijst.Items.Add("Salade: - 3,9");
        //}

        //private void btn_Sushi_Click(object sender, RoutedEventArgs e)
        //{
        //    Lijst.Items.Add("Sushi: - 6,2");
        //}

        //private void btn_Pizza_Click(object sender, RoutedEventArgs e)
        //{
        //    Lijst.Items.Add("Pizza: - 8,1");
        //}

        //private void btn_Tomaat_Click(object sender, RoutedEventArgs e)
        //{
        //    Lijst.Items.Add("Tomaat: - 4,2");
        //}
        //private void btn_Banaan_Click(object sender, RoutedEventArgs e)
        //{
        //    Lijst.Items.Add("Banaan: - 0,9");
        //}

        //private void btn_Lasgne_Click(object sender, RoutedEventArgs e)
        //{
        //    Lijst.Items.Add("Lasagne: - 1,6");
        //}

        //private void btn_Twix_Click(object sender, RoutedEventArgs e)
        //{
        //    Lijst.Items.Add("Twix: - 5,6");
        //}

        //private void btn_Kiwi_Click(object sender, RoutedEventArgs e)
        //{
        //    Lijst.Items.Add("Kiwi: - 5,3");
        //}

        //private void btn_Paprika_Click(object sender, RoutedEventArgs e)
        //{
        //    Lijst.Items.Add("Paprika: - 1,23");
        //}

        //private void btn_Snickers_Click(object sender, RoutedEventArgs e)
        //{
        //    Lijst.Items.Add("Snickers: - 5,6");
        //}

        //private void btn_Garnalen_Click(object sender, RoutedEventArgs e)
        //{
        //    Lijst.Items.Add("Garnalen: - 15,4");
        //}


        private void btn_ClearList_Click(object sender, RoutedEventArgs e)
        {
            Lijst.Items.Clear();
        }

        private void Button_Click_toevoegen(object sender, RoutedEventArgs e)
        {
            var sum = Lijst.Items
             .OfType<string>()
             .Select(s => Convert.ToDouble(s.Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries)[1]))
             .Sum();

            int userId = Convert.ToInt32(Application.Current.Resources["UserId"]);

            using (SqlConnection sqlCon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\SmartFoodChoice.mdf;Integrated Security=True"))
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();

                foreach (Item item in Lijst.Items)
                {
                    string query = @"INSERT INTO tbl_Mapping (Product_ID, User_ID, [Datum en Tijd]) VALUES (@ProductId, @UserId, @Date)";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.CommandType = CommandType.Text;
                    sqlCmd.Parameters.AddWithValue("@ProductId", item.ProductId);
                    sqlCmd.Parameters.AddWithValue("@UserId", userId);
                    sqlCmd.Parameters.AddWithValue("@Date", DateTime.UtcNow);
                    sqlCmd.ExecuteNonQuery();
                }
                sqlCon.Close();
            }

            MessageBox.Show("Aantal kilo CO-2 uitstoot: " + sum.ToString());
        }

        private void btn_Remove_Click(object sender, RoutedEventArgs e)
        {
            Lijst.Items.Remove(Lijst.SelectedItem);
        }
    }
}
