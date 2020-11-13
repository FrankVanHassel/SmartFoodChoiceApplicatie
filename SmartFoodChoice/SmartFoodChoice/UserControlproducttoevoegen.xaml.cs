using Microsoft.Win32;
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

namespace SmartFoodChoice
{
    /// <summary>
    /// Interaction logic for UserControlproducttoevoegen.xaml
    /// </summary>
    public partial class UserControlproducttoevoegen : UserControl
    {
        // List<tbl_smiley> Smileylist = new List<tbl_smiley>();

        DataSet1 ds;
        string strName, imageName;

        //Database connectie
        DataClasses1DataContext db = new DataClasses1DataContext();
        public UserControlproducttoevoegen()
        {
            InitializeComponent();
            //    Employeedatalist.Add(new Employeedata { Smiley_Id = 1, Smileyimage = "Images/happy.png", Smileynaam = "Blije smiley" });
            //    Employeedatalist.Add(new Employeedata { Smiley_Id = 2, Smileyimage = "Images/sad.png", Smileynaam = "Neutrale smiley" });
            //    Employeedatalist.Add(new Employeedata { Smiley_Id = 3, Smileyimage = "Images/neutral.png", Smileynaam = "Verdrietige smiley" });
            //    lstwithimg.ItemsSource = Smileylist;
            //    lstwithimg.SelectedIndex = 0;
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            tbl_Overzicht Ovz = new tbl_Overzicht();
            Ovz.Productnaam = productnaam_tbx.Text;
            Ovz.CO_2_uitstoot = co2uitstoot_tbx.Text;

            db.tbl_Overzichts.InsertOnSubmit(Ovz);
            db.SubmitChanges();
            //update db

            //When you pressed the submit button you get this messagebox
            MessageBox.Show("Product ingevoerd met succes!");

            //After the messagebox the strings get empty
            productnaam_tbx.Text = string.Empty;
            co2uitstoot_tbx.Text = string.Empty;
        }

        private void Combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FileDialog fldlg = new OpenFileDialog();
                fldlg.InitialDirectory = Environment.SpecialFolder.MyPictures.ToString();
                fldlg.Filter = "Image File (*.jpg;*.bmp;*.gif)|*.jpg;*.bmp;*.gif";
                fldlg.ShowDialog();
                {
                    strName = fldlg.SafeFileName;
                    imageName = fldlg.FileName;
                    ImageSourceConverter isc = new ImageSourceConverter();
                    image1.SetValue(Image.SourceProperty, isc.ConvertFromString(imageName));
                }
                fldlg = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
