using System;
using System.Globalization;
using Xamarin.Forms;

namespace Appitecture.Converter
{
    public class ImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string avaiblity = (string)value;
            if (avaiblity == null)
                return "images.jpeg";
            else
                return avaiblity;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
