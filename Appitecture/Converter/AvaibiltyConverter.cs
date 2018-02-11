using System;
using System.Globalization;
using Xamarin.Forms;

namespace Appitecture.Converter
{
    public class AvaibiltyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                int avaiblity = (int)value;
                if (avaiblity == 1)
                    return "Yes";
                else
                    return "No";
            }catch
            {
                return "Yes";
            }
                
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
