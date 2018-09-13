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

namespace CodeAnalizerGUI.UserControls.MainWindowControls
{
    /// <summary>
    /// Interaction logic for GitBinderControl.xaml
    /// </summary>
    public partial class GitBinderControl : UserControl
    {
        public GitBinderControl()
        {
            InitializeComponent();
        }
        

       

        public void LoadButtons(string[] authorsList)
        {
            
        }

        private void CreateButton(string text)
        {
            Button btn = new Button();
            
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            NewContributorControl ncc=null;
            
        }
    }
}
