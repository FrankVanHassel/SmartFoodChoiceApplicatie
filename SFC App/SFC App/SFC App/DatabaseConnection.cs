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
        private string connectionString = "Server=192.168.173.190;Database=SFCAppDatabase;Uid=ftpuser;Pwd=ftpuser";
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
                Console.WriteLine();
                Console.WriteLine(ex);
                Console.WriteLine();
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
                    string value = reader.GetString("Password");
                    productList.Add(value);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine(ex);
                Console.WriteLine();
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
    }
}
