using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;

namespace UWPApp
{
    public class BookItemsViewModel : INotifyPropertyChanged
    {
        HttpClient httpClient = new HttpClient();
        HttpResponseMessage httpResponse = new HttpResponseMessage();

        public BookItemsViewModel() {
            MockData();
        }

        public ObservableCollection<BookItem> BookItems { get; private set; } = new ObservableCollection<BookItem>();

        public event PropertyChangedEventHandler PropertyChanged;

        private async void MockData()
        {
            Uri requestUri = new Uri("http://localhost:52312/api/Mockdata");
            httpResponse = await httpClient.GetAsync(requestUri);
            httpResponse.EnsureSuccessStatusCode();
            var bookItemString = await httpResponse.Content.ReadAsStringAsync();
            foreach (var bookItem in JsonConvert.DeserializeObject<ObservableCollection<BookItem>>(bookItemString))
            {
                BookItems.Add(bookItem);
            }
        }
    }
}
