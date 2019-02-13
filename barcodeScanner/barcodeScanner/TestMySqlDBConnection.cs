using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barcodeScanner
{
    [TestClass]
    public class TestMySqlDBConnection
    {

        [TestMethod]
        public void TestCreateTable()
        {
            string status = MySqlDBConnection.CreateTable();
        }

        [TestMethod]
        public void TestInsertData()
        {
            POCO.UID uid = new POCO.UID();
            uid.Uid = "79879";
            uid.Quantity = "10";
            uid.Source = "source";
            uid.Event_date_UMS = "576540000";
            string status = MySqlDBConnection.InsertData(uid);
            Assert.AreEqual("Row added", status);
        }


    }
}
