using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database_and_wpf.Model
{
    public class DataBaseConnection
    {
        DataBaseConnection() { }

        private static DataBaseConnection connection;
        public static DataBaseConnection GetDataBaseConnection()
        {
            if(connection == null)
            {
                connection = new DataBaseConnection();
            }
            return connection;
        }

        public SqliteConnection connect()
        {
            string connection = "Data Source = DataFile.db";
            return new(connection);
        }

    }
}
