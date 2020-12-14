using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace SFC_App
{
    public interface ISqlConnection
    {
        SQLiteAsyncConnection Connection();
    }
}
