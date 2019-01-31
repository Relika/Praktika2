using System;
using System.Data.SqlClient;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace barcodeScanner
{
    class MySqlDBConnection
    {
        public static string CreateTable()
        {
            String connection = System.Configuration.ConfigurationManager.ConnectionStrings["MySql"].ConnectionString;
            using (MySqlConnection  mysqlconnection= new MySqlConnection(connection))
            {
                mysqlconnection.Open();
                string status = mysqlconnection.State.ToString();
                return status;
            }
        }
    }
}


