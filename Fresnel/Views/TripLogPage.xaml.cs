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
                    Title = "Robert F. Kennedy Department of Justice Building",
                    Notes = "Headquarters of the United States Department of Justice. The building is located at 950 Pennsylvania Avenue NW, on a trapezoidal lot on the block bounded by Pennsylvania Avenue to the north, Constitution Avenue to the south, 9th Street to the east, and 10th Street NW to the west, in the Federal Triangle.[2] It is located west of the National Archives Building, east of the Internal Revenue Service Building, north of the National Mall, and south of the J. Edgar Hoover Building. The building is owned by the General Services Administration It comprises seven floors[4] and 1,200,000 sq ft (110,000 m2). It houses Department of Justice offices, including the office of the United States Attorney General. Completed in 1935, it was renamed after the 64th Attorney General of the United States, Robert F. Kennedy, in 2001.",
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
