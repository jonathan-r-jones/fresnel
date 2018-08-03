using Xamarin.Forms;

namespace Fresnel
{
	public class HomePageCS : ContentPage
	{
		public HomePageCS ()
		{
			Content = new Grid {
				Padding = new Thickness (20),
				Children = {
					new PinchToZoomContainer {
						Content = new Image { Source = ImageSource.FromFile ("shark_finning_infographic.jpg") }
					}	
				}
			};
		}
	}
}
