using Foundation;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using SFC_App.iOS;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLiteConnection))]

namespace SFC_App.iOS
{
    class sqliteIOS : ISqlConnection
    {
        public SQLiteAsyncConnection Connection()
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documentsPath, "MySQLite.sqldb");

            return new SQLiteAsyncConnection(path);
        }
    }
}