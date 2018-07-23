﻿using Fresnel.ViewModels;
using System;
using Xamarin.Forms;

namespace Fresnel.Views {
    public partial class JSONIncidentsPage : ContentPage {
        JSONPlaceholderUsersListViewModel _jsonPlaceholderUsersListViewModel;
        public JSONIncidentsPage()
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
