using Fresnel.ViewModels;
using System;
using Xamarin.Forms;

namespace Fresnel.Views {
    public partial class JSONPlaceholderUsersPage : ContentPage {
        JSONPlaceholderUsersListViewModel _jsonPlaceholderUsersListViewModel;
        public JSONPlaceholderUsersPage()
        {
            InitializeComponent();
            _jsonPlaceholderUsersListViewModel = new JSONPlaceholderUsersListViewModel();
            try
            {
                _jsonPlaceholderUsersListViewModel.GetJSONUsersAsync();
            }
            catch (Exception exception)
            {
                DisplayAlert(title: "Oh no!", message: "Unable to get data: " + exception, cancel: "OK");
            }
            BindingContext = _jsonPlaceholderUsersListViewModel;
        }
    }
}
