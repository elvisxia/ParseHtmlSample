using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Data.Xml.Dom;
using Windows.Storage;
using Windows.Storage.Streams;
using HtmlAgilityPack;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ParseHtmlSample
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void myBtn_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("ms-appx:///Assets/Html/default.html");
            StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(uri);
            String htmlStr=await FileIO.ReadTextAsync(file);
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(htmlStr);
            HtmlNode rootNode =htmlDoc.DocumentNode.SelectSingleNode("/html/body/div");
            //IEnumerable<HtmlNode> nodes = rootNode.Descendants("div");// The other way to get the child div nodes
            HtmlNodeCollection collection = rootNode.SelectNodes("/html/body/div/div");

        }
        
    }
}
