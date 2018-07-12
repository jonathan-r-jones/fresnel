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
            #if __ANDROID__
                // Android-specific code
                OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://tinyurl.com/fresnel-doj")));
            #endif
            #if __IOS__
                // iOS-specific code
                OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://tinyurl.com/fresnel-ios")));
            #endif
            OpenWebCommandJMD = new Command(() => Device.OpenUri(new Uri("https://www.justice.gov/jmd")));
        }
        public ICommand OpenWebCommand { get; }
        public ICommand OpenWebCommandJMD { get; }
    }
}