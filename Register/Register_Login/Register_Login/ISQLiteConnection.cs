using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Register_Login
{
    public interface ISQLiteInterface
    {
        SQLiteConnection GetSQLiteConnection();
    }
}
