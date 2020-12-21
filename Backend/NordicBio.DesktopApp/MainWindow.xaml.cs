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
using Microsoft.Web.WebView2.Core;
using static System.Net.WebRequestMethods;

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
                PingReply reply = myPing.Send("164.68.106.245", 1000);
                if (reply.Status == IPStatus.Success)
                {
                    webView.EnsureCoreWebView2Async();
                } else
                {
                    webView.Visibility = Visibility.Hidden;
                    webView.IsEnabled = false;
                    Label.IsEnabled = true;
                    Label.Visibility = Visibility.Visible;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
