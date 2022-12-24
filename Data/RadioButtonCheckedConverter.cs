using System;
using System.Globalization;
using System.Windows.Data;

namespace ClimateControlSystemNamespace
{
    public class RadioButtonCheckedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            if (value is bool)
            {
                return !(bool)value;
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, 
            System.Globalization.CultureInfo culture)
        {
            if (value is bool)
            {
                return !(bool)value;
            }
            return value;
        } 
        /*public object Convert(object value, Type targetType, object parameter,
            CultureInfo cultureInfo)
        {
            return value.Equals(parameter);
        }

        public object ConvertBack(object value, Type targetType, object parameter,
            CultureInfo cultureInfo)
        {
            return value.Equals(true) ? parameter : Binding.DoNothing;
        }*/
    }
}