﻿using Fresnel.ViewModels;
using Xamarin.Forms;

namespace Fresnel.Views {
    public partial class Page7 : ContentPage {
        public Page7() {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }
    }
}
