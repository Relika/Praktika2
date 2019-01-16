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



namespace barcodeScanner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void Bnsubmit_Click(object sender, RoutedEventArgs e)
        {
            //string barCode = TbUID.Text.ToString();
            //string quantity = Tbquantity.Text.ToString();
            UID uid = new UID();
            uid.Uid = TbUID.Text;
            //float num = float.Parse(Tbquantity.Text);
            uid.Quantity = Tbquantity.Text.Replace(',', '.');
            //uid.Quantity = num.ToString().Replace(',', '.');
            //uid.Quantity = (float)Convert.ToDouble(Tbquantity.Text);
            uid.Source = "tekst";
            uid.Event_date_UMS = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString();
            bool UIDExist = SQLiteDBConnection.CompareUID(TbUID.Text);
            if (UIDExist == true){

            }
            else
            {
                Lbstatus.Content = SQLiteDBConnection.Insert(uid);
            }

            
        }


    }
}

//float num = float.Parse(textBox1.Text);
//string stringValue = num.ToString().Replace(',', '.');
