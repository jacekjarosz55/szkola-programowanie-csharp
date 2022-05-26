using System;
using System.Globalization;
using System.Windows.Data;

namespace PrzelicznikMVVM.ViewModel.Converters
{
    class StringToNumberConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int intval)
            {
                return intval.ToString();
            }

            return Binding.DoNothing;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int returnVal;

            if (value is string strval)
            {
                if (int.TryParse(strval, out returnVal)) return returnVal;
                else return null;
            }

            return Binding.DoNothing;


        }

    }
}
