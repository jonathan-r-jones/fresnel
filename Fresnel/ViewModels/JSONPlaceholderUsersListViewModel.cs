using Fresnel.Models;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Diagnostics;

namespace Fresnel.ViewModels
{
    public class JSONPlaceholderUsersListViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<JSONPlaceholderUser> JSONPlaceholderUsersList { get; set; }

        public JSONPlaceholderUsersListViewModel()
        {
            JSONPlaceholderUsersList = new ObservableCollection<JSONPlaceholderUser>();
        }

        private bool busy = false;

        public bool IsBusy
        {
            get { return busy; }
            set
            {
                if (busy == value)
                    return;
                busy = value;
                OnPropertyChanged("IsBusy");
            }
        }

        public async Task GetMonkeysAsync()
        {
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;
                var client = new HttpClient();
                var json = await client.GetStringAsync("http://jsonplaceholder.typicode.com/users");
                var list = JsonConvert.DeserializeObject<List<JSONPlaceholderUser>>(json);
                foreach (var item in list)
                {
                    JSONPlaceholderUsersList.Add(item);
                    Debug.WriteLine("Name: " + item.Name);
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
