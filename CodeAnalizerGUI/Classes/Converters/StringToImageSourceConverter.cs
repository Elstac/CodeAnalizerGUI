using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using System.IO;
namespace CodeAnalizerGUI.Classes.Converters
{
    class StringToImageSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string path = value as string;
            if (value == null)
                path = Directory.GetCurrentDirectory() + "\\nofile.png";
            ImageSource src = StringToImageConverter.Convert(path).Source;
            return src;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ImageSource src = value as ImageSource;
            return "strdupa";
        }
    }
}
