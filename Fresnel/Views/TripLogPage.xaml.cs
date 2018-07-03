using System;
using System.Collections.Generic;
using Fresnel.Models;
using Xamarin.Forms;

namespace Fresnel.Views
{
    public partial class TripLogPage : ContentPage
    {
        public TripLogPage()
        {
            InitializeComponent();

            var items = new List<TripLogEntry>
            {
                new TripLogEntry
                {
                    Title = "2Con",
                    Notes = "Inspiring!",
                    Rating = 4,
                    Date = new DateTime(2017, 4, 13),
                    Latitude = 38.906916,
                    Longitude = -77.004138
                },
                new TripLogEntry
                {
                    Title = "Main Justice",
                    Notes = "Shooter false alarm.",
                    Rating = 5,
                    Date = new DateTime(2017, 4, 26),
                    Latitude = 38.892927,
                    Longitude = -77.024888
                },
                new TripLogEntry
                {
                    Title = "Washington Monument",
                    Notes = "Amazing!",
                    Rating = 3,
                    Date = new DateTime(2017, 2, 5),
                    Latitude = 38.8895,
                    Longitude = -77.0352
                }
            };

            trips.ItemsSource = items;
        }

        void New_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NewEntryPage());
        }

        async void Trips_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var trip = (TripLogEntry)e.Item;
            await Navigation.PushAsync(new DetailPage(trip));

            // Clear selection
            trips.SelectedItem = null;
        }
    }
}
