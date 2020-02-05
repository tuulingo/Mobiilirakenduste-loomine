using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Register_Login
{
    class ISQLiteDbInterface
    {
        public class GetSQLiteConnnection : ISQLiteInterface
        {
            public GetSQLiteConnnection()
            {
            }
            public SQLiteConnection GetSQLiteConnection()
            {
                var fileName = "UserDatabase.db3";
                var documentPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                var path = Path.Combine(documentPath, fileName);
                var connection = new SQLiteConnection(path);
                return connection;
            }
        }
    }
}
