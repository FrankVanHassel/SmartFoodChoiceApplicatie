using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;


namespace SmartFoodChoice
{
    /// <summary>
    /// Interaction logic for login.xaml
    /// </summary>
    /// 
    public partial class login : Window
    {
        DataClasses1DataContext db = new DataClasses1DataContext();

        public login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(Properties.Settings.Default.ConnectionString);
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                String query = "SELECT UserID FROM tbl_login WHERE Username=@Username AND Password=@Password";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                sqlCmd.Parameters.AddWithValue("@Password", txtPassword.Password);
                int userId = Convert.ToInt32(sqlCmd.ExecuteScalar());
                if (userId > 0)
                {
                    MessageBox.Show("Welkom Gebruiker");
                    Application.Current.Resources.Add("UserName", txtUsername.Text);
                    Application.Current.Resources.Add("UserId", userId);
                    MainWindow gebruiker = new MainWindow();
                    gebruiker.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Gebruikersnaam of wachtwoord is onjuist!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlCon.Close();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Wachtwoord of gebruikersnaam vergeten? Neem contact op met de manager L.Verhoeven.");
        }
    }
}


