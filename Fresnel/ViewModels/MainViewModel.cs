using System;
using System.Collections.ObjectModel;
using Fresnel.Models;

namespace Fresnel.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
		ObservableCollection<Open_Incident> _open_Incidents;
		public ObservableCollection<Open_Incident> Open_Incidents
		{
			get { return _open_Incidents; }
			set
			{
				_open_Incidents = value;
				OnPropertyChanged();
			}
		}

		public MainViewModel()
		{
            Open_Incidents = new ObservableCollection<Open_Incident>
            {
                new Open_Incident
                {
                    Title = "Washington Monument",
                    Notes = "Amazing!",
                    Rating = 3,
                    Date = new DateTime(2017, 2, 5),
                    Latitude = 38.8895,
                    Longitude = -77.0352
                },
                new Open_Incident
                {
                    Title = "Statue of Liberty",
                    Notes = "Inspiring!",
                    Rating = 4,
                    Date = new DateTime(2017, 4, 13),
                    Latitude = 40.6892,
                    Longitude = -74.0444
                },
                new Open_Incident
                {
                    Title = "Golden Gate Bridge",
                    Notes = "Foggy, but beautiful.",
                    Rating = 5,
                    Date = new DateTime(2017, 4, 26),
                    Latitude = 37.8268,
                    Longitude = -122.4798
                }
            };
        }
	}
}
