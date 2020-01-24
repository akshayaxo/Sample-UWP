using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.Web.Http;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWPApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        Frame rootFrame = Window.Current.Content as Frame;
        public BookItemsViewModel VM { get; set; }
        public BookItemsViewModel SearchResult { get; set; }

        public MainPage()
        {
            VM = new BookItemsViewModel();
            this.SearchResult = this.VM;
            this.InitializeComponent();
        }

        private void Clear(object sender, RoutedEventArgs e)
        {
            this.VM = this.SearchResult;
            SearchItem.Text = "";
        }
            private void Button_Click(object sender, RoutedEventArgs e)
        {
            var item=(sender as Button).DataContext as BookItem;
            rootFrame.Navigate(typeof(DetailsPage),item);
        }

        private void Search(object sender, RoutedEventArgs e)
        {
            var search = SearchItem.Text;
            VM = SearchResult;
            VM =VM.BookItems.Where(x => x.Name.Contains(search));
            //.Where(x => x.Name.Contains(search)) as ObservableCollection<BookItem>;
        }
    }
}
