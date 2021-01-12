using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using MySql.Data;


namespace server
{
    class DatabaseConnection
    {
        private string connectionString = "Server=localhost;Databse=SFCAppDatabase;Uid=ftpuser;Pwd=ftpuser";
        public string ConnectionString
        {
            get { return connectionString; }
        }


        public string GetUserPwd(string email)
        {
            MySqlConnection DBConnection = new MySqlConnection(connectionString);
            DBConnection.Open();
            string passwordDB = "";

            try
            {
                MySqlCommand cmd = DBConnection.CreateCommand();
                cmd.CommandText = $"SELECT Password FROM Login WHERE Email={email}";
                MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
                passwordDB = adap.ToString();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
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
    }
}
