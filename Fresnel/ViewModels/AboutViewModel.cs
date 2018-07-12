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

            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://tinyurl.com/fresnel-doj")));
            OpenWebCommandJMD = new Command(() => Device.OpenUri(new Uri("https://www.justice.gov/jmd")));
        }

        public ICommand OpenWebCommand { get; }
        public ICommand OpenWebCommandJMD { get; }
    }
}