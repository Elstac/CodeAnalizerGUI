using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CodeAnalizerGUI
{
    /// <summary>
    /// Interaction logic for ContributorsButon.xaml
    /// </summary>
    public partial class ButtonWithDescription : UserControl
    {
        public ButtonWithDescription(Image buttonContent, string description,RoutedEventHandler clickEvent)
        {
            InitializeComponent();
            DescriptionBlock.Text = description;
            Button.Width = 64;
            Button.Height = 64;
            buttonContent.Stretch = Stretch.Fill;
            Button.Content = buttonContent;
            Button.Click += clickEvent;
        }
    }
}
