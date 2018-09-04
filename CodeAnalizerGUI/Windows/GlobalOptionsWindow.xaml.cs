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
using System.Windows.Shapes;
using System.Windows.Controls;
namespace CodeAnalizerGUI
{
    /// <summary>
    /// Interaction logic for GlobalOptionsWindow.xaml
    /// </summary>
    public partial class GlobalOptionsWindow : Window
    {
        private List<UserControl> content;
        private string[] buttonsContent = new string[] {"Language", "cccccccs" };
        public GlobalOptionsWindow(Window owner)
        {
            InitializeComponent();
            Owner = owner;
            LoadButtons();
        }

        private void LoadButtons()
        { 

            int index = 0;
            Button newButton;
            foreach (var text in buttonsContent)
            {
                newButton = new Button();
                newButton.Content = text;
                newButton.Tag = index++;
                newButton.Click += new RoutedEventHandler(NavigationButtonClick);
                NavigationBar.Items.Add(newButton); 
            }
        }

        private void NavigationButtonClick(object sender, RoutedEventArgs e)
        {
            
        }

        protected override void OnClosed(EventArgs e)
        {
            Owner.Show();
            Owner.Focus();
            base.OnClosed(e);
        }
    }
}
