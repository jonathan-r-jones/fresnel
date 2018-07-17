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
            try
            {
                bikesList.IsRefreshing = true;
                bikesList.ItemsSource = await CraigsHelper.SearchAsync("bike");
                bikesList.IsRefreshing = false;
                bikesList.EndRefresh();
            }
            catch (System.Exception exception)
            {
                await DisplayAlert("Cannot Connect to Craig's List", "The request timed out. You may be offline or the site may be down or slow. Exception: " + exception.Message, "Ok");
            }
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
