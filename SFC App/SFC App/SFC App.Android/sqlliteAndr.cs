using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFC_App.Droid;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLiteConnection))]

namespace SFC_App.Droid
{
    class sqlliteAndr : ISqlConnection
    {
        public SQLiteAsyncConnection Connection()
        {
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documentsPath, "MySQLite.sqldb");

            return new SQLiteAsyncConnection(path);
        }
    }
}