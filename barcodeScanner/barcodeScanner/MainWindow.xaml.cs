using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SQLite;
using System.Collections.ObjectModel;
using barcodeScanner.POCO;
using System.Text.RegularExpressions;

namespace barcodeScanner
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            TbUID.Focus();
        }


        public void Bnsubmit_Click(object sender, RoutedEventArgs e)
        {
            Lbstatus.Content = "";
            if (TbUID.Text.ToString() != "" || Tbquantity.Text.ToString() !="")
            {
                UID uid = new UID();
                uid.Uid = TbUID.Text;
                uid.Quantity = Tbquantity.Text.Replace(',', '.');
                
                uid.Source = "tekst";
                uid.Event_date_UMS = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString();
                Lbstatus.Content = SQLiteDBConnection.UpSert(uid);
                if (Lbstatus.Content.ToString() == "Row added")
                {
                    TbUID.Text = "";
                    Tbquantity.Text = "0";
                    TbUID.Focus();
                }
            }
            else
            {
                Lbstatus.Content = "UID is empty";
                TbUID.Focus();
            }
        }


        private void TbUID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Tbquantity.Focus();
                Tbquantity.SelectAll();
               
            }
        }

        private void Tbquantity_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                string q = Tbquantity.Text.ToString();
                double number;
                //bool result = double.TryParse(q);
                if (!double.TryParse(q, out number))
                {
                   
                    Lbstatus.Content = "Please enter only numbers";
                    Tbquantity.Focus();
                    Tbquantity.SelectAll();
                }
                else
                {
                    Bnsubmit.Focus();
                    Bnsubmit_Click(sender, e);
                }
            }
        }

    }

}

