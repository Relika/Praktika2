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

        public static string Update(POCO.UID uid)
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
    }
}

//public void Create(Book book)
//{
//    SQLiteCommand insertSQL = new SQLiteCommand("INSERT INTO Book (Id, Title, Language, PublicationDate, Publisher, Edition, OfficialUrl, Description, EBookFormat) VALUES (?,?,?,?,?,?,?,?)", sql_con);
//    insertSQL.Parameters.Add(book.Id);
//    insertSQL.Parameters.Add(book.Title);
//    insertSQL.Parameters.Add(book.Language);
//    insertSQL.Parameters.Add(book.PublicationDate);
//    insertSQL.Parameters.Add(book.Publisher);
//    insertSQL.Parameters.Add(book.Edition);
//    insertSQL.Parameters.Add(book.OfficialUrl);
//    insertSQL.Parameters.Add(book.Description);
//    insertSQL.Parameters.Add(book.EBookFormat);
//    try
//    {
//        insertSQL.ExecuteNonQuery();
//    }
//    catch (Exception ex)
//    {
//        throw new Exception(ex.Message);
//    }
//}

//string dbConnectionString = @"Data Source=Sample.s3db;Version=3;";
//try
//{
//    SQLiteConnection sqlite_con = new SQLiteConnection(dbConnectionString);
//sqlite_con.Open();
//    string query = "select * from test;";
//SQLiteCommand sqlite_cmd = new SQLiteCommand(query, sqlite_con);
//SQLiteDataReader dr = sqlite_cmd.ExecuteReader();
//    while (dr.Read())
//    {
//        MessageBox.Show(dr.GetString(1));
//    }

//    sqlite_con.Close();
//}
//catch (Exception ex)
//{
//    MessageBox.Show(ex.ToString());
//}
