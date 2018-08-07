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
						Content = new Image { Source = ImageSource.FromFile ("https://washington-org.s3.amazonaws.com/s3fs-public/metro-updated-map-2017.jpg") }
					}	
				}
			};
		}
	}
}
