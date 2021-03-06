﻿using Fresnel.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace Fresnel.ViewModels
{
    public class JSONIncidentsViewModel : INotifyPropertyChanged
    {
        private bool _busy = false;
        public ObservableCollection<Incident> _jSONIncidents { get; set; }
        public JSONIncidentsViewModel()
        {
            string methodName = "Entering method: JSONIncidentsViewModel";
            Microsoft.AppCenter.Analytics.Analytics.TrackEvent(methodName);
            Debug.WriteLine(methodName);
            _jSONIncidents = new ObservableCollection<Incident>();
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
        public async Task GetJSONIncidentsAsync()
        {
            if (IsBusy)
                return;
            try
            {
                Microsoft.AppCenter.Analytics.Analytics.TrackEvent("Entering method: Getting JSON users. - JRJ Jul-20-2018");
                IsBusy = true;
                var httpClient = new HttpClient();
                var jsonURL = await httpClient.GetStringAsync("https://raw.githubusercontent.com/jonathan-r-jones/Fresnel/master/incidents.json");
                var deserializedList = JsonConvert.DeserializeObject<List<Incident>>(jsonURL);
                foreach (var item in deserializedList)
                {
                    _jSONIncidents.Add(item);
                    Debug.WriteLine("Jul-20-2018 - Name: " + item.Name);
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
