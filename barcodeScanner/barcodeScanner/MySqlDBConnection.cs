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
            int createStatus;
            string status;
            String connection = System.Configuration.ConfigurationManager.ConnectionStrings["MySql"].ConnectionString;
            //using (MySqlConnection  mysqlconnection= new MySqlConnection(connection))
            //{
                //mysqlconnection.Open();
            string createUIDtable = "CREATE TABLE UID_quantity_counter (`UID' TEXT NOT NULL, `quantity` text NOT NULL, `source` TEXT NOT NULL, `event_date_UMS` INTEGER NOT NULL, `entry_date` round(UNIX_TIMESTAMP(CURTIME(4))*1000))";
            using (MySqlConnection mysqlconnection = new MySqlConnection(connection))
            {

                using (MySqlCommand create = new MySqlCommand(createUIDtable, mysqlconnection))
                {
                    mysqlconnection.Open();
                    create.CommandText = createUIDtable;                       
                        try
                        {
                            createStatus = create.ExecuteNonQuery();

                            if (createStatus == 1)
                            {
                                status = "Table added";
                            }
                            else
                            {
                                status = "";
                            }
                        }
                        catch (Exception ex)
                        {
                            status = ex.Message;
                            //throw new Exception(ex.Message);                        
                        }
                    }
                }
                //string status = mysqlconnection.State.ToString();
                return status;
            //}
        }
    }
}


