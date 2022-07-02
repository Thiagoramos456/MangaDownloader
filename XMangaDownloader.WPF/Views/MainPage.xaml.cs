using AngleSharp.Html.Parser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
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
            var chapterUrl = WebView.CoreWebView2.Source;
            
            await Vm.GetMangasAsync(chapterUrl);

            MessageBox.Show("Download finalizado");
        }

        public async void InitializeWebview()
        {
            await WebView.EnsureCoreWebView2Async();
            WebView.CoreWebView2.Navigate("https://mangaschan.com/");
        }

        private async void WebView_NavigationCompleted(object sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs e)
        {
            var parser = new HtmlParser();

            var html = await WebView.CoreWebView2.ExecuteScriptAsync("document.body.outerHTML");
            var htmlDecoded = JsonSerializer.Deserialize<string>(html);

            var document = await parser.ParseDocumentAsync(htmlDecoded);
            var readerArea = document.QuerySelector("#readerarea");

            Vm.CanFetchChapter = readerArea != null;
            await ToggleLoading();
        }

        private async Task ToggleLoading()
        {
            var script = File.ReadAllText(@"C:\Users\Thiago Ramos de Lima\source\repos\XMangaDownloader\XMangaDownloader.WPF\Scripts\loading.js");
            await WebView.CoreWebView2.ExecuteScriptAsync(script);
        }
    }
}
