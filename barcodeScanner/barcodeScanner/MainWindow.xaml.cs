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
using System.Windows.Documents;


namespace barcodeScanner
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            TbUID.Focus();
            //CbQuantityOff.IsChecked == false;
            //CbQuantityOff_Unchecked(sender,e);
        }


        public void Bnsubmit_Click(object sender, RoutedEventArgs e)
        {
            Lbstatus.Content = "";
            if (TbUID.Text.ToString() != "" || Tbquantity.Text.ToString() !="")
            {
                UID uid = new UID();
                uid.Uid = TbUID.Text;
                uid.Quantity = Tbquantity.Text.Replace(',', '.');
                
                uid.Source = System.Configuration.ConfigurationManager.AppSettings["Source"];
                uid.Event_date_UMS = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString();
                Lbstatus.Content = SQLiteDBConnection.UpSert(uid);
                if (Lbstatus.Content.ToString().StartsWith("Row added, UID: "))
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
            if (e.Key == Key.Enter && !String.IsNullOrWhiteSpace(TbUID.Text))
            {
                if (CbQuantityOff.IsChecked == true){
                    Bnsubmit_Click(sender, e);
                }
                else{
                    Tbquantity.Focus();
                    Tbquantity.SelectAll();
                }  
            }
            else { TbUID.Text = ""; TbUID.Focus(); }
            
        }

        //private void Tbquantity_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if(e.Key == Key.RightShift)
        //    {
        //        string q = Tbquantity.Text.ToString();
        //        double number;
        //        //bool result = double.TryParse(q);
        //        if (!double.TryParse(q, out number))
        //        {
                   
        //            Lbstatus.Content = "Please enter only numbers";
        //            Tbquantity.Focus();
        //            Tbquantity.SelectAll();
        //        }
        //        else
        //        {
        //            Bnsubmit.Focus();
        //            Bnsubmit_Click(sender, e);
        //        }
        //    }
        //}

        private void CbQuantityOff_Checked(object sender, RoutedEventArgs e)
        {
            LbQuantityOff.Content = "Scan without quantity";
            LbQuantityOff.Foreground = Brushes.Black;
            TbUID.Focus();
        }

        private void CbQuantityOff_Unchecked(object sender, RoutedEventArgs e)
        {
            LbQuantityOff.Foreground = Brushes.Gray;
            TbUID.Focus();
        }


        private void Tbquantity_PreviewKeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
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

