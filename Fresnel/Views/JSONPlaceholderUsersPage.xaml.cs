using Fresnel.ViewModels;
using System;
using Xamarin.Forms;

namespace Fresnel.Views {
    public partial class JSONPlaceholderUsersPage : ContentPage {
        JSONPlaceholderUsersListViewModel jsonPlaceholderUsersListViewModel;
        public JSONPlaceholderUsersPage()
        {
            InitializeComponent();
            jsonPlaceholderUsersListViewModel = new JSONPlaceholderUsersListViewModel();
            try
            {
                jsonPlaceholderUsersListViewModel.GetMonkeysAsync();
            }
            catch (Exception exception)
            {
                DisplayAlert(title: "Oh no!", message: "Unable to get data: " + exception, cancel: "OK");
            }
            BindingContext = jsonPlaceholderUsersListViewModel;
        }
    }
}
