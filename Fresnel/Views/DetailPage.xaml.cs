using Fresnel.Models;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace Fresnel.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailPage : ContentPage
    {
        public DetailPage(TripLogEntry entry)
        {
            InitializeComponent();

            try
            {
                map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(entry.Latitude, entry.Longitude), Distance.FromMiles(.5)));

                map.Pins.Add(new Pin
                {
                    Type = PinType.Place,
                    Label = entry.Title,
                    Position = new Position(entry.Latitude, entry.Longitude)
                });

                title.Text = entry.Title;
                date.Text = entry.Date.ToString("M");
                rating.Text = $"{entry.Rating} star rating";
                notes.Text = entry.Notes;
            }
            catch
            {
                DisplayAlert("Cannot Connect", "I noticed that at the moment it works on iOS but not Android.", "Ok");
            }
        }
    }
}