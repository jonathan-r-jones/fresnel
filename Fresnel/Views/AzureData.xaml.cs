using Fresnel.ViewModels;
using Xamarin.Forms;

namespace Fresnel.Views {
    public partial class AzureDataPage : ContentPage {
        public AzureDataPage() {
            InitializeComponent();
            BindingContext = new OpenIncidentsViewModel();
        }
    }
}
