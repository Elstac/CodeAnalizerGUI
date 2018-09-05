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
using CodeAnalizerGUI.Interfaces;
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
            nButton.Width = 64;
            nButton.Height = 64;
            buttonContent.Stretch = Stretch.Fill;
            nButton.Content = buttonContent;
            nButton.Click += clickEvent;

            InitializeTagBinding();

        }

        private void InitializeTagBinding()
        {
            Binding binding = new Binding
            {
                Source = this,
                Path = new PropertyPath("Tag"),
                Mode = BindingMode.TwoWay,
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
            };
            BindingOperations.SetBinding(nButton, TagProperty, binding);
        }
    }
}
