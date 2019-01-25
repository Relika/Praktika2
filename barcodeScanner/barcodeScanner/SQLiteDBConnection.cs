using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SQLite;

namespace barcodeScanner
{
    public class SQLiteDBConnection
    {
        //string tableName = "UID_quantity_counter";


        //enne inserti tuleb kontrollida, kas selline uid on juba olemas, kui on, siis tuleb teha update!
        public static string Insert (POCO.UID uid)
        {
            string status;
            int insertStatus;
            string connection = System.Configuration.ConfigurationManager.ConnectionStrings["BarCodeScanner"].ConnectionString;
            using (SQLiteConnection sqliteconnection = new SQLiteConnection(connection))
            {
                sqliteconnection.Open();
                string insertData = "INSERT INTO UID_quantity_counter (UID, quantity, source, event_date_UMS) VALUES (@UID,@Quantity,@Source,@Event_date)";
                using (SQLiteCommand insert = new SQLiteCommand(sqliteconnection))
                {
                    insert.CommandText = insertData;
                    insert.Parameters.AddWithValue("@UID", uid.Uid);
                    insert.Parameters.AddWithValue("@Quantity", uid.Quantity);
                    insert.Parameters.AddWithValue("@Source", uid.Source);
                    insert.Parameters.AddWithValue("@Event_date", uid.Event_date_UMS);
                    //insert.Parameters.AddWithValue("@Entry_date", uid.Entry_date);
                    try
                    {
                        insertStatus = insert.ExecuteNonQuery();
                        if (insertStatus == 1)
                        {
                            status = "Row added";
                        }
                        else
                        {
                            status = "";
                        }
                    }
                    catch (Exception ex)
                    {
                        status = ex.Message;
                        throw new Exception(ex.Message);
                        
                    }
                }

            }
            return status;

        }

        public static bool CompareUID(string uid)
        {
            bool status;
            string connection = System.Configuration.ConfigurationManager.ConnectionStrings["BarCodeScanner"].ConnectionString;
            using (SQLiteConnection sqliteconnection = new SQLiteConnection(connection))
            {
                sqliteconnection.Open();
                string compareData = "SELECT * FROM UID_quantity_counter WHERE UID =="+uid;
                using (SQLiteCommand compare = new SQLiteCommand(sqliteconnection))
                {
                    compare.CommandText = compareData;
                    try
                    {
                        int compareStatus = compare.ExecuteNonQuery();
                        if (compareStatus == 1)
                        {
                            status = true;
                        }
                        else
                        {
                            status = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        //status = ex.Message;
                        throw new Exception(ex.Message);
                    }
                }
            }
            return status;
        }

        public static string UpSert(POCO.UID uid)
        {
            string status;
            int insertStatus;
            string connection = System.Configuration.ConfigurationManager.ConnectionStrings["BarCodeScanner"].ConnectionString;
            using (SQLiteConnection sqliteconnection = new SQLiteConnection(connection))
            {
                sqliteconnection.Open();
                string insertData = "INSERT INTO UID_quantity_counter (UID, quantity, source, event_date_UMS) VALUES (@UID,@Quantity,@Source,@Event_date) on conflict(UID) do update set quantity=excluded.quantity, event_date_UMS=excluded.event_date_UMS";
                using (SQLiteCommand insert = new SQLiteCommand(sqliteconnection))
                {
                    insert.CommandText = insertData;
                    insert.Parameters.AddWithValue("@UID", uid.Uid);
                    insert.Parameters.AddWithValue("@Quantity", uid.Quantity);
                    insert.Parameters.AddWithValue("@Source", uid.Source);
                    insert.Parameters.AddWithValue("@Event_date", uid.Event_date_UMS);
                    //insert.Parameters.AddWithValue("@Entry_date", uid.Entry_date);
                    try
                    {
                        insertStatus = insert.ExecuteNonQuery();
                        if (insertStatus == 1)
                        {
                            status = "Row added, UID: "+uid.Uid;
                            
                        }
                        else
                        {
                            status = "";
                        }
                    }
                    catch (Exception ex)
                    {
                        status = ex.Message;
                        throw new Exception(ex.Message);
                    }
                }
            }
            return status;
        }

        public static string StartTrigger()
        {
            string status;
            int triggerStatus;
            string connection = System.Configuration.ConfigurationManager.ConnectionStrings["BarCodeScanner"].ConnectionString;
            using (SQLiteConnection sqliteconnection = new SQLiteConnection(connection))
            {
                sqliteconnection.Open();
                string startTrigger = "CREATE TRIGGER [UpdateLastTime]  AFTER UPDATE ON UID_quantity_counter FOR EACH ROW WHEN NEW.event_date_UMS >= OLD.event_date_UMS BEGIN update UID_quantity_counter set entry_date = CURRENT_TIMESTAMP where UID = OLD.UID; END; ";
                using (SQLiteCommand trigger = new SQLiteCommand(startTrigger))
                {
                    trigger.CommandText = startTrigger;
                    try{
                        triggerStatus = trigger.ExecuteNonQuery();
                        if (triggerStatus == 1)
                        {
                            status = "Entry date updated";

                        }
                        else
                        {
                            status = "";
                        }
                    }
                    catch (Exception ex)
                    {
                        status = ex.Message;
                        throw new Exception(ex.Message);
                    }
                }
            }
            return status;
        }
    }
}
