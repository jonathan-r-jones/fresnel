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
            //Refractored.Xam.TTS.CrossTextToSpeech.Current.Speak("Hello Gabriella and Jacob");
            CrossTextToSpeech.Current.Speak("How are you?");
            CrossTextToSpeech.Current.Speak(Label1.Text);
        }
    }
}