using System;
using Plugin.TextToSpeech;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Fresnel.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MonkeyPage : ContentPage
	{
		public MonkeyPage ()
		{
			InitializeComponent ();
		}

        public void OnButtonClicked(object sender, EventArgs args)
        {
            ((Button) sender).Text = "Click to hear it again.";
            CrossTextToSpeech.Current.Speak("How are you? I am well thanks for asking.");
            CrossTextToSpeech.Current.Speak(Label1.Text);
        }
    }
}