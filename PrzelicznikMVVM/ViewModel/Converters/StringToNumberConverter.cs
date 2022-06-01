using System;
using System.Globalization;
using System.Windows.Data;

namespace PrzelicznikMVVM.ViewModel.Converters
{
    class StringToNumberConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
          


            if (value is double doubleVal)
            {
                return doubleVal.ToString();
            }


            return Binding.DoNothing;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double returnVal;

            if (value is string strval)
            {
                if (double.TryParse(strval, out returnVal)) return returnVal;
                else return null;
            }

            return Binding.DoNothing;


        }

    }
}
