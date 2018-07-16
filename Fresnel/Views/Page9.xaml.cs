using Fresnel.Data;
using Microsoft.AppCenter.Analytics;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace Fresnel.Views {
    public partial class Page9 : ContentPage {

        readonly IList<Book> books = new ObservableCollection<Book>();
        readonly BookManager manager = new BookManager();

        public Page9() {
            Analytics.TrackEvent("Entering method: " + System.Reflection.MethodBase.GetCurrentMethod().Name.ToString());
            BindingContext = books;
            InitializeComponent();
            OnRefresh(null, null);
        }

        async void OnRefresh(object sender, EventArgs e)
        {
            // Turn on network indicator
            IsBusy = true;
            try
            {
                var bookCollection = await manager.GetAll();

                foreach (Book book in bookCollection)
                {
                    if (books.All(b => b.ISBN != book.ISBN))
                        books.Add(book);
                }
            }
            catch
            {
                await DisplayAlert("Cannot Connect", "Either you are offline or the site is down.", "Ok");
            }
            finally
            {
                IsBusy = false;
            }
        }

        async void OnAddNewBook(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(
                new AddEditBookPage(manager, books));
        }

        async void OnEditBook(object sender, ItemTappedEventArgs e)
        {
            await Navigation.PushModalAsync(
                new AddEditBookPage(manager, books, (Book)e.Item));
        }

        async void OnDeleteBook(object sender, EventArgs e)
        {
            MenuItem item = (MenuItem)sender;
            Book book = item.CommandParameter as Book;
            if (book != null)
            {
                if (await DisplayAlert("Delete Book?",
                    "Are you sure you want to delete the book '"
                        + book.Title + "'?", "Yes", "Cancel") == true)
                {
                    IsBusy = true;
                    try
                    {
                        await manager.Delete(book.ISBN);
                        books.Remove(book);
                    }
                    finally
                    {
                        IsBusy = false;
                    }

                }
            }
        }

    }
}
