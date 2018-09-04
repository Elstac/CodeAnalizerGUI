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
using CodeAnalizerGUI.Classes.Converters;
using CodeAnalizerGUI.Interfaces;
using System.IO;
namespace CodeAnalizerGUI
{
    /// <summary>
    /// Interaction logic for ContributorsControl.xaml
    /// </summary>
    public partial class ContributorsControl : UserControl,IFamilyMember
    {
        private Button AddButton;
        private int buttonCounter = 0;
        public ContributorsControl()
        {
            InitializeComponent();
            LoadAddButton();
            MainPanel.Children.Add(AddButton);
        }

        private void LoadAddButton()
        {
            AddButton = new Button();
            Image plus = StringToImageConverter.Convert(Directory.GetCurrentDirectory() + "\\plus.png");
            plus.Stretch = Stretch.Fill;
            AddButton.Width = 64;
            AddButton.Height = 64;
            AddButton.Content = plus;
            AddButton.Click += new RoutedEventHandler(AddButtonClick);
            
        }

        public void AddNewButton(string name,Image image)
        {
            UIElementCollection children = MainPanel.Children;
            ButtonWithDescription newButton = new ButtonWithDescription(image, name, new RoutedEventHandler(ContributoButtonClick));
            children.RemoveAt(children.Count - 1);
            children.Add(newButton);
            children.Add(AddButton);
        }

        private void ContributoButtonClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
        private void AddButtonClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void GetParent<T>(ref T ret) where T : class
        {
            if (Parent is T)
            {
                ret = Parent as T;
                return;
            }
            IFamilyMember par = Parent as IFamilyMember;
            par.GetParent<T>(ref ret);
        }

        public void GetChildren<T>(ref T ret) where T : class
        {
            throw new InvalidOperationException("Operation not suported");
        }
    }
}
