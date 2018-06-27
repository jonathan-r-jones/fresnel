using System;
using System.Globalization;
using Xamarin.Forms;

namespace Fresnel.Views {
    public partial class Page10 : ContentPage {
        public Page10() {
            InitializeComponent();
        }
    }
    public class DatetimeToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return string.Empty;
            var datetime = (DateTime)value;
            //put your custom formatting here
            return datetime.ToLocalTime().ToString("g");
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
