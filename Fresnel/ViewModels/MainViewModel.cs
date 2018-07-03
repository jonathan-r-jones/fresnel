using System;
using System.Collections.ObjectModel;
using Fresnel.Models;
using Fresnel.Services;

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
                    Title = "Peter Medawar",
                    Notes = "Sir Peter Brian Medawar OM CBE FRS (/ˈmɛdəwər/; 28 February 1915 – 2 October 1987)[1] was a British biologist born in Brazil, whose work on graft rejection and the discovery of acquired immune tolerance was fundamental to the practice of tissue and organ transplants. For his works in immunology he is regarded as the 'father of transplantation'. He is remembered for his wit in real life and popular writings. Famous zoologists such as Richard Dawkins referred to him as 'the wittiest of all scientific writers', and Stephen Jay Gould as 'the cleverest man I have ever known'.",
                    Rating = 3,
                    Date = new DateTime(2017, 2, 5),
                    Latitude = 38.8895,
                    Longitude = -77.0352
                },
                new Open_Incident
                {
                    Title = "George Washington",
                    Notes = "(February 22, 1732[b][c] - December 14, 1799) was an American statesman and soldier who served as the first President of the United States from 1789 to 1797. As one of the new nation's leading patriots, he was among the Founding Fathers of the United States, and served as commander-in-chief of the Continental Army during the American Revolutionary War. He presided over the 1787 convention. He also came to be known as the 'Father of His Country.'",
                    Rating = 4,
                    Date = new DateTime(2017, 4, 13),
                    Latitude = 40.6892,
                    Longitude = -74.0444
                },
                new Open_Incident
                {
                    Title = "Voltaire",
                    Notes = "François-Marie Arouet (French: [f??~.swa ma.?i a?.w?]; 21 November 1694 - 30May 1778), known by his nom de plume Voltaire (/vo?l't??r/; French: [v?l.t???]), was a French Enlightenment writer, historian and philosopher famous for his wit, his attacks on Christianity as a whole, especially the established Catholic  Church,and his advocacy of freedom of religion, freedom of speech and separation of church and state.",
                    Rating = 5,
                    Date = new DateTime(2017, 4, 26),
                    Latitude = 37.8268,
                    Longitude = -122.4798
                },
                new Open_Incident
                {
                    Title = "Wrapping",
                    Notes = "Notice that there is a wrapping problem.",
                    Rating = 5,
                    Date = new DateTime(2017, 4, 26),
                    Latitude = 37.8268,
                    Longitude = -122.4798
                }
            };
        }
	}
}
