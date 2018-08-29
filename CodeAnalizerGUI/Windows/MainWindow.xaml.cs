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
        string[] buttonsNames = new string[] { "Global statistics","Git statistics" };
        public MainWindow()
        {
            InitializeComponent();
            mainBus = new UIBus(this);
            Button tmp;
            
            for (int i = 0; i < buttonsNames.Length; i++)
            {
                tmp = new Button();
                tmp.Content = buttonsNames[i];
                
                tmp.Tag = i;
                tmp.Click += new RoutedEventHandler(NavigatePanelButtonClick);
                tmp.Margin = new Thickness(0, 5, 0, 5);
                NavigationBar.Items.Add(tmp);
            }
            
        }

        public void LoadContent(UserControl contentView)
        {
            MainControl.Content = contentView;
        }
        
        private void Exit_Button_Click(object sender, RoutedEventArgs e)
        {
            CloseWindow();
        }

        private void Open_Button_Click(object sender, RoutedEventArgs e)
        {
            mainBus.ExploreFiles();
        }

        private void NavigatePanelButtonClick(object sender, RoutedEventArgs e)
        {
            Button butt = sender as Button;
            mainBus.ReloadMainWindowContent(int.Parse(butt.Tag.ToString()));
        }

        private void OptionsButtonClick(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

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
