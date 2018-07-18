using Fresnel.ViewModels;
using System;
using Xamarin.Forms;

namespace Fresnel.Views {
    public partial class MonkeyListPage : ContentPage {
        MonkeyListViewModel monkeyListViewModel;
        public MonkeyListPage()
        {
            InitializeComponent();
            monkeyListViewModel = new MonkeyListViewModel();
            ButtonGet.Clicked += async (sender, e) =>
            {
                try
                {
                    ButtonGet.IsEnabled = false;
                    await monkeyListViewModel.GetMonkeysAsync();
                    ButtonGet.IsEnabled = true;
                }
                catch (Exception exception)
                {
                    await DisplayAlert(title: "Oh no!", message: "Unable to get monkeys: " + exception, cancel: "OK");
                }
            };
            List.ItemTapped += async (sender, e) =>
            {
                var monkey = e.Item;
                var details = new MonkeyPage();
                details.BindingContext = monkey;
                await Navigation.PushAsync(details);
                List.SelectedItem = null; // Deselects the item.
            };
            BindingContext = monkeyListViewModel;
        }
    }
}
