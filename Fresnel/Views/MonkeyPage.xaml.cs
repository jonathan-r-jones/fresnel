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

            ((Button) sender).Text = "You clicked the button.";
            //Refractored.Xam.TTS.CrossTextToSpeech.Current.Speak("Hello Gabriella and Jacob");
            CrossTextToSpeech.Current.Speak("Hello");
            CrossTextToSpeech.Current.Speak(Label1.Text);
        }
    }
}