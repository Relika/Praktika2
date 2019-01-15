using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace barcodeScanner
{
    class SQLiteConnect
    {

    public void getConnection()
        {
            string connectionString = System.Configuration.ConfigurationSettings.
            SQLiteConnection m_dbConnection;
            m_dbConnection = new SQLiteConnection();
            m_dbConnection.getConnection();
        }
    }
}
