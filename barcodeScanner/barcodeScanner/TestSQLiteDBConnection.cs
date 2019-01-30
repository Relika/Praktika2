using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using barcodeScanner.POCO;

namespace barcodeScanner
{
    [TestClass]
    public class TestSQLiteDBConnection
    {

        [TestMethod]
        public void TestInsert()
        {
            UID uid = new UID();
            uid.Uid = "68563427";
            uid.Quantity = "5";
            uid.Source = "source";
            uid.Event_date_UMS = "5765475";
            uid.Entry_date = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString();
            //SQLiteDBConnection.GetConnection();
            SQLiteDBConnection.Insert(uid);
        }

        [TestMethod]
        public void TestUpsert()
        {
            UID uid = new UID();
            uid.Uid = "79879";
            uid.Quantity = "10";
            uid.Source = "source";
            uid.Event_date_UMS = "576540000";
            string status =SQLiteDBConnection.UpSert(uid);
            string status2 = SQLiteDBConnection.StartTrigger();
            Assert.AreEqual("Row added", status);
            Assert.AreEqual("Entry date updated", status2);
        }

        [TestMethod]
        public void TestRandomUID()
        {
            int i = 0;
            String[] names = {"UID", "RMA" };
            Random rand = new Random();
            while (i < 800000)
            {
                UID uid = new UID();
                String result = names[rand.Next(names.Length)];
                int randomNumber = rand.Next(10000000, 99999999);
                uid.Uid = result + randomNumber;
                uid.Quantity = "4";
                uid.Source = "random";
                uid.Event_date_UMS = GetRandomTime();
                SQLiteDBConnection.Insert(uid);
                //string status2 = SQLiteDBConnection.StartTrigger();
                //Assert.IsNotNull(status);
                //Assert.AreEqual("Entry date updated", status2);
                i ++;
            }
        }

        public static string GetRandomTime()
        {
            Random r = new Random();
            DateTime rDate = new DateTime(r.Next(1900, 2018), r.Next(1, 12), r.Next(1, 28));
            string datetime = rDate.ToString();
            DateTimeOffset.TryParse(datetime, out DateTimeOffset result);
            string timemilliseconds = result.ToUnixTimeMilliseconds().ToString();
            return timemilliseconds;
        }


    }
}
