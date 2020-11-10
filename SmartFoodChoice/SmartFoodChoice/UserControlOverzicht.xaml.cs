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
            list.Add(new Item { ProductId = 1, CO2Value = 30, Productnaam = "A", Smiley = "Sad", Image = "images/burger.png" });
            list.Add(new Item { ProductId = 2, CO2Value = 40, Productnaam = "B", Smiley = "Sad", Image = "images/burger.png" });
            list.Add(new Item { ProductId = 3, CO2Value = 50, Productnaam = "C", Smiley = "Sad", Image = "images/burger.png" });
            list.Add(new Item { ProductId = 4, CO2Value = 60.4, Productnaam = "D", Smiley = "Sad", Image = "images/burger.png" });

            this.datagrid.ItemsSource = list;
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
