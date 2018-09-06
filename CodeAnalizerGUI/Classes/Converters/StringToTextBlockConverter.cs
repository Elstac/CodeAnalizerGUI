using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Controls;
namespace CodeAnalizerGUI.Classes.Converters
{
    public class StringToTextBlockConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is string))
                throw new ArgumentException("Given value isnt string");
            TextBlock ret = new TextBlock();
            ret.Text = value.ToString();
            return ret;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is TextBlock))
                throw new ArgumentException("Given value isnt TextBlock");
            TextBlock tmp = (TextBlock)value;
            return tmp.Text;
        }
    }
}
