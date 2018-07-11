using Fresnel.Models;
using Fresnel.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace Fresnel.Views {
    public partial class AzureDataPage : ContentPage {

        readonly IList<Incident> incidents = new ObservableCollection<Incident>();
        readonly IncidentManager incidentManager = new IncidentManager();

        public AzureDataPage()
        {
            BindingContext = incidents;
            InitializeComponent();
            OnRefresh(null, null);
        }

        async void OnRefresh(object sender, EventArgs e)
        {
            // Turn on network indicator
            IsBusy = true;
            try
            {
                var incidentCollection = await incidentManager.GetAll();

                foreach (Incident incident in incidentCollection)
                {
                    if (incidents.All(b => b.Id != incident.Id))
                        incidents.Add(incident);
                }
            }
            finally
            {
                IsBusy = false;
            }
        }

        async void OnAddNewBook(object sender, EventArgs e)
        {
            //await Navigation.PushModalAsync(new AddEditBookPage(incidentManager, incidents));
        }

        async void OnEditBook(object sender, ItemTappedEventArgs e)
        {
            //await Navigation.PushModalAsync(new AddEditBookPage(incidentManager, incidents, (Book)e.Item));
        }

        async void OnDeleteBook(object sender, EventArgs e)
        {
            //MenuItem item = (MenuItem)sender;
            //Book book = item.CommandParameter as Book;
            //if (book != null)
            //{
            //    if (await DisplayAlert("Delete Book?",
            //        "Are you sure you want to delete the book '"
            //            + book.Title + "'?", "Yes", "Cancel") == true)
            //    {
            //        IsBusy = true;
            //        try
            //        {
            //            await incidentManager.Delete(book.ISBN);
            //            incidents.Remove(book);
            //        }
            //        finally
            //        {
            //            IsBusy = false;
            //        }

            //    }
            //}
        }

    }
}
