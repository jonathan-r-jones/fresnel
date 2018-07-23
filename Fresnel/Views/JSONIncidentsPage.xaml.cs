using Fresnel.ViewModels;
using System;
using Xamarin.Forms;

namespace Fresnel.Views {
    public partial class JSONIncidentsPage : ContentPage {
        JSONIncidentsViewModel _jsonIncidentsViewModel;
        public JSONIncidentsPage()
        {
            InitializeComponent();
            _jsonIncidentsViewModel = new JSONIncidentsViewModel();
            try
            {
                _jsonIncidentsViewModel.GetJSONUsersAsync();
            }
            catch (Exception exception)
            {
                DisplayAlert(title: "Oh no!", message: "Unable to get data: " + exception, cancel: "OK");
            }
            BindingContext = _jsonIncidentsViewModel;
        }
    }
}
