﻿using System;
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
            uid.Quantity = 30;
            uid.Source = "source";
            uid.Event_date_UMS = 5765475;
            uid.Entry_date = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString();
            //SQLiteDBConnection.GetConnection();
            SQLiteDBConnection.Insert(uid);
        }
    }
}