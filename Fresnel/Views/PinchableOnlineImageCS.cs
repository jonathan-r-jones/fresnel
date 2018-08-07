using Xamarin.Forms;

namespace Fresnel.Views
{
	public class PinchableOnlineImageCS : ContentPage
	{
		public PinchableOnlineImageCS ()
		{
			Content = new Grid {
				Padding = new Thickness (20),
				Children = {
					new PinchToZoomContainer {
						Content = new Image { Source = ImageSource.FromFile ("https://raw.githubusercontent.com/jonathan-r-jones/For-Git-Testing/master/Art/dc_metro_map.jpg") }
					}	
				}
			};
		}
	}
}
