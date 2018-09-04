using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.IO;
namespace CodeAnalizerGUI.Classes.Converters
{
    public static class StringToImageConverter
    {
        public static Image Convert(string pathToImage)
        {
            Image ret = new Image();
            ret.Source = new BitmapImage(new Uri("file:///"+pathToImage));
            return ret;
        }
    }
}
