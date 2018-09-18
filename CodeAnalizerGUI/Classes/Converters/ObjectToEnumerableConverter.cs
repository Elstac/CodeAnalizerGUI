using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
namespace CodeAnalizerGUI.Classes.Converters
{
    class ObjectToEnumerableConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            object[] ret = new object[] { value };
            return ret;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            object[] ret = value as object[];
            if (ret.Length > 1)
                throw new InvalidCastException("Cannot convert array to single value");

            return ret[0];
        }
    }
}
