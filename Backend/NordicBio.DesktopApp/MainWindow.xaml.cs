using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            try
            {
                Ping myPing = new Ping();
                PingReply reply = myPing.Send("google.com", 1000);

                if (reply != null)
                {
                    ctlBrowser.Navigate("http://localhost:8080");
                }
                else
                {
                    //todo handle network error
                }
            }
            catch (Exception e)
            {
                //ctlBrowser.Navigate("https://google.com");
                Console.WriteLine(e);
            }
        }
    }
}
