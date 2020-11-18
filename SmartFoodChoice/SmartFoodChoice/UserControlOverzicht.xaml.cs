using SmartFoodChoice.Model;
using System.Collections.Generic;
using System.Windows.Controls;


namespace SmartFoodChoice
{
    /// <summary>
    /// Interaction logic for UserControlOverzicht.xaml
    /// </summary>
    public partial class UserControlOverzicht : UserControl
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        public UserControlOverzicht()
        {
            InitializeComponent();
            List<Item> list = new List<Item>();
            list.Add(new Item { ProductId = 1, CO2Value = 30, Productnaam = "Friet", Smiley = "Sad", Image = "images/burger.png" });
            list.Add(new Item { ProductId = 2, CO2Value = 40, Productnaam = "Sushi", Smiley = "Sad", Image = "images/burger.png" });
            list.Add(new Item { ProductId = 3, CO2Value = 50, Productnaam = "Kiwi", Smiley = "Happy", Image = "images/burger.png" });
            list.Add(new Item { ProductId = 4, CO2Value = 60, Productnaam = "Kip", Smiley = "Sad", Image = "images/burger.png" });
            list.Add(new Item { ProductId = 5, CO2Value = 70, Productnaam = "Lasagne", Smiley = "Sad", Image = "images/burger.png" });
            list.Add(new Item { ProductId = 6, CO2Value = 10, Productnaam = "Aardappel", Smiley = "Happy", Image = "images/burger.png" });
            list.Add(new Item { ProductId = 7, CO2Value = 30, Productnaam = "Kaas", Smiley = "Sad", Image = "images/burger.png" });
            list.Add(new Item { ProductId = 8, CO2Value = 40, Productnaam = "Snicker", Smiley = "Sad", Image = "images/burger.png" });
            list.Add(new Item { ProductId = 9, CO2Value = 110, Productnaam = "Banaan", Smiley = "Sad", Image = "images/burger.png" });

            this.datagrid.ItemsSource = list;
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
