using Fresnel.Models;
using Microsoft.AppCenter.Analytics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Fresnel.Views {
    public partial class BikeSearchPage : ContentPage {
        public BikeSearchPage() {
            InitializeComponent();
            LoadItemsAsync();
        }

        private async Task LoadItemsAsync()
        {
            bikesList.IsRefreshing = true;
            bikesList.ItemsSource = await CraigsHelper.SearchAsync("bike");
            bikesList.IsRefreshing = false;
            bikesList.EndRefresh();
        }

        void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                var item = (BikeItem)e.SelectedItem;
                this.bikesList.SelectedItem = null;
                Analytics.TrackEvent("ViewPosting");
                Device.OpenUri(new System.Uri(item.Link));
            }
        }
    }
}
