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
using CodeAnalizer;
namespace CodeAnalizerGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        UIBus mainBus;
        public MainWindow()
        {
            InitializeComponent();
            TEstPage tmp = new TEstPage();
            mainBus = new UIBus(this);
        }

        public void OpenProject()
        {
            //All shit happend here!!!
        }

        private void Exit_Button_Click(object sender, RoutedEventArgs e)
        {
            CloseWindow();
        }

        private void Open_Button_Click(object sender, RoutedEventArgs e)
        {
            mainBus.ExploreFiles();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
        public void LoadNumberPanel(List<string> numbersList)
        {
            TextBlock block;

            foreach (var item in numbersList)
            {
                block = new TextBlock();
                block.Text = item;
                block.Tag = item.Substring(0, item.IndexOf(":") - 1);
                block.Margin = new Thickness(0, 10, 0, 10);
                block.FontSize = 14;
                block.TextWrapping = TextWrapping.WrapWithOverflow;
                NumberPanel.Children.Add(block);

            }
        }
        private void CloseWindow()
        {
            Close();
        }

        private void OpenSubWindow(Window win)
        {
            win.Owner = this;
            win.Show();
            this.Hide();
            win.Focus();
        }
    }
}
