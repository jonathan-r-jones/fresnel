using System;
using System.Windows.Input;

using Xamarin.Forms;

namespace Fresnel.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";
            switch (Device.RuntimePlatform)
            {
                case Device.Android:
                    OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://tinyurl.com/fresnel-doj")));
                    break;
                case Device.iOS:
                    OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://tinyurl.com/fresnel-ios")));
                    break;
            }
            OpenWebCommandJMD = new Command(() => Device.OpenUri(new Uri("https://www.justice.gov/jmd")));
        }
        public ICommand OpenWebCommand { get; }
        public ICommand OpenWebCommandJMD { get; }
    }
}