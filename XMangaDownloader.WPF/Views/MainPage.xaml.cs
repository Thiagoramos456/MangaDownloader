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

namespace XMangaDownloader.WPF.Views
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            InitializeWebview();
        }

        private async void DownloadManga_Click(object sender, RoutedEventArgs e)
        {
            await Vm.GetMangasAsync();

            MessageBox.Show("Download finalizado");
        }

        public async void InitializeWebview()
        {
            await WebView.EnsureCoreWebView2Async();
            WebView.CoreWebView2.Navigate("https://mangaschan.com/");
        }

        private void WebView_NavigationStarting(object sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationStartingEventArgs e)
        {
        }
    }
}
