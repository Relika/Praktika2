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


    }
}
