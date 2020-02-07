using Register_Login.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;
using static Register_Login.ISQLiteDbInterface;

[assembly: Dependency(typeof(GetSQLiteConnnection))]
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
                var documentPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                var path = Path.Combine(documentPath, fileName);
                var connection = new SQLiteConnection(path);
                return connection;
            }
        }
    }
}
