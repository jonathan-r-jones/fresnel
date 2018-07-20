using Fresnel.ViewModels;
using System;
using Xamarin.Forms;

namespace Fresnel.Views {
    public partial class CraigsListBikesPage : ContentPage {
        CraigsListBikesViewModel _craigsListBikesViewModel;
        public CraigsListBikesPage()
        {
            InitializeComponent();
            _craigsListBikesViewModel = new CraigsListBikesViewModel();
            try
            {
                _craigsListBikesViewModel.GetBikesAsync();
            }
            catch (Exception exception)
            {
                DisplayAlert(title: "Oh no!", message: "Unable to get data: " + exception, cancel: "OK");
            }
            BindingContext = _craigsListBikesViewModel;
        }
    }
}
