using System;
using System.Net.NetworkInformation;

namespace NordicBio.DesktopClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
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