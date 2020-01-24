using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWPApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DetailsPage : Page
    {
        Frame rootFrame = Window.Current.Content as Frame;

        public BookItem Item { get; set; }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            Item = e.Parameter as BookItem;
            //this.DataContext = Item;
        }
        public DetailsPage()
        {
            this.InitializeComponent();
        }
        public void Backbutton(object sender, RoutedEventArgs e)
        {
            rootFrame.Navigate(typeof(MainPage));
        }
    }
}
