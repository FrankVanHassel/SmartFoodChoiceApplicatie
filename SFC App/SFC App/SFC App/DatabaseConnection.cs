using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Net;
using System.Net.Sockets;

namespace SFC_App
{
    class DatabaseConnection
    {
        private string connectionString = "Data Source=192.168.173.190,3306;Database=SFCAppDatabase;Uid=ftpuser;Pwd=ftpuser";
        public string ConnectionString
        {
            get { return connectionString; }
        }



        /// <summary>
        /// Gets the account password specified by the account email.
        /// </summary>
        /// <param name="email">account email</param>
        /// <returns>user password</returns>
        public string GetUserPwd(string email)
        {

            MySqlConnection DBConnection = new MySqlConnection(connectionString);
            DBConnection.Open();
            string passwordDB = "";

            try
            {
                string commandString = $"SELECT Password FROM Login WHERE Email='{email}'";
                MySqlCommand command = new MySqlCommand(commandString, DBConnection);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    passwordDB = reader.GetString("Password");
                }
            }
            catch (Exception ex)
            {
                // Replace console.writeline with message to user
                passwordDB = "no password received";
            }
            finally
            {
                if (DBConnection.State == System.Data.ConnectionState.Open)
                {
                    DBConnection.Close();
                }
            }

            return passwordDB;
        }


        /// <summary>
        /// Gets the data from all products
        /// </summary>
        /// <returns>list with all product data</returns>
        public List<string> GetAllProductData()
        {
            List<string> productList = new List<string>();
            MySqlConnection DBConnection = new MySqlConnection(connectionString);
            DBConnection.Open();

            try
            {
                string commandString = $"SELECT * FROM Products";
                MySqlCommand command = new MySqlCommand(commandString, DBConnection);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string value = "";
                    for (int i = 0; i < 17; i++)        // 17 is the number of coulmns in the database
                    {
                        value += reader.GetString(i);
                        value += " | ";
                    }
                    productList.Add(value);
                }
            }
            catch
            {
                productList.Add("nothing received");
            }
            finally
            {
                if (DBConnection.State == System.Data.ConnectionState.Open)
                {
                    DBConnection.Close();
                }
            }

            return productList;
        }


        /// <summary>
        /// Gets the data of a product
        /// </summary>
        /// <param name="productID">The ID of the requested product</param>
        /// <returns>string containing all data of the product</returns>
        public string GetProduct(int productID)
        {
            string product = "";
            MySqlConnection DBConnection = new MySqlConnection(connectionString);
            DBConnection.Open();

            try
            {
                string commandString = $"SELECT * FROM Products WHERE ProductID='{productID}'";
                MySqlCommand command = new MySqlCommand(commandString, DBConnection);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    for (int i = 0; i < 17; i++)
                    {
                        product += reader.GetString(i);
                        product += " | ";
                    }
                }
            }
            catch
            {
                product = "failed";
            }
            finally
            {
                if (DBConnection.State == System.Data.ConnectionState.Open)
                {
                    DBConnection.Close();
                }
            }

            return product;
        }
    }
}
