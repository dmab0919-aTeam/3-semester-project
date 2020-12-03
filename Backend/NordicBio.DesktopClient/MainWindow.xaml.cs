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

namespace NordicBio.DesktopClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            /*string sTest = "<html>hallo this is a html-String</html>";

            ctlBrowser.NavigateToString(sTest);*/
            
            //string applicationDirectory = Path.GetDirectoryName(Application.ExecutablePath);
            //string myFile = Path.Combine(applicationDirectory, "Sample.html");
            //ctlBrowser.Source("http://localhost:8080/");
            //ctlBrowser.Url = new Uri("file:///" + myFile);

            ctlBrowser.Navigate("http://localhost:8080");
        }
    }
}