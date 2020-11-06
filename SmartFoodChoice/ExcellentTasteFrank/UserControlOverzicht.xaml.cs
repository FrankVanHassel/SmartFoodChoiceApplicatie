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


namespace SmartFoodChoiceApp
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
           
     List<tbl_Overzicht> test = new List<tbl_Overzicht>(db.tbl_Overzichts.ToList());
            //The items are comming up in the db
            this.dgOverzicht.ItemsSource = test;

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
