using Fresnel.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace Fresnel.ViewModels
{
    public class CraigsListBikesViewModel : INotifyPropertyChanged
    {
        private bool _busy = false;
        public ObservableCollection<BikeItem> _bikeList { get; set; }
        public CraigsListBikesViewModel()
        {
            string methodName = "Entering method: CraigsListBikesViewModel";
            Microsoft.AppCenter.Analytics.Analytics.TrackEvent(methodName);
            Debug.WriteLine(methodName);
            _bikeList = new ObservableCollection<BikeItem>();
        }
        public bool IsBusy
        {
            get { return _busy; }
            set
            {
                if (_busy == value)
                    return;
                _busy = value;
                OnPropertyChanged("IsBusy");
            }
        }
        public async Task GetBikesAsync()
        {
            if (IsBusy)
                return;
            try
            {
                Microsoft.AppCenter.Analytics.Analytics.TrackEvent("Entering method: Get bikes async. - JRJ Jul-20-2018");
                IsBusy = true;
                var httpClient = new HttpClient();
                var jsonURL = await httpClient.GetStringAsync("https://washingtondc.craigslist.org/search/sss?format=rss&hasPic=1&max_price=100&query=bike&sort=date");
                var deserializedList = JsonConvert.DeserializeObject<List<BikeItem>>(jsonURL);
                foreach (var item in deserializedList)
                {
                    _bikeList.Add(item);
                    Debug.WriteLine("Jul-20-2018 - Text: " + item.Text);
                }
            }
            finally
            {
                IsBusy = false;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string name)
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;
            changed(this, new PropertyChangedEventArgs(name));
            //C# 6.0 - if this is changed then do this
            //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
