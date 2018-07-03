using Fresnel.ViewModels;
using Xamarin.Forms;

namespace Fresnel.Views {
    public partial class OpenIncidentsPage : ContentPage {
        public OpenIncidentsPage() {
            InitializeComponent();
            BindingContext = new OpenIncidentsViewModel();
        }
    }
}
