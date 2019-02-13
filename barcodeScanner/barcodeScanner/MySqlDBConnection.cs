using System;
using System.Data.SqlClient;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace barcodeScanner
{
    class MySqlDBConnection
    {
        public static string InsertData(POCO.UID uid)
        {
            string status;
            String connection = System.Configuration.ConfigurationManager.ConnectionStrings["MySql"].ConnectionString;
            string insterData = "Insert into UID_quantity_counter5 (UID, quantity, source, event_date_UMS) VALUES (@UID,@Quantity,@Source,@Event_date) ON DUBLICATE KEY UPDATE  quantity=@quantity, event_date_UMS=@Event_date";
            using (MySqlConnection mysqlconnection = new MySqlConnection(connection))
            {
                using (MySqlCommand insert = new MySqlCommand(insterData, mysqlconnection))
                {
                    mysqlconnection.Open();
                    insert.Parameters.AddWithValue("@UID", uid.Uid);
                    insert.Parameters.AddWithValue("@Quantity", uid.Quantity);
                    insert.Parameters.AddWithValue("@Source", uid.Source);
                    insert.Parameters.AddWithValue("@Event_date", uid.Event_date_UMS);
                    try
                    {
                        int insertStatus = insert.ExecuteNonQuery();
                        if (insertStatus == 1)
                        {
                            status = "Row added";
                        }
                        else
                        {
                            status = "";
                        }
                    } catch (Exception ex)
                    {
                        status = ex.Message;
                    }

                }
            }
            return status;

        }

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


