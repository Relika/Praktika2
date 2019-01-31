using System;

namespace barcodeScanner
{
    public class MySqlConnection
    {
	    public static void CreateTable()
	    {
            String connection = System.Configuration.ConfigurationManager.ConnectionStrings["MySql"].ConnectionString;
            using (MySqlConnection mysqlconnection = new MySqlConnection(connection))
            {
                mysqlconnection.o
            }
        }
    }
}


