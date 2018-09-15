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
using CodeAnalizer.GitTrackerModule.Classes;
namespace CodeAnalizerGUI.UserControls.MainWindowControls
{
    /// <summary>
    /// Interaction logic for GitBinderControl.xaml
    /// </summary>
    public partial class GitBinderControl : UserControl
    {
        private IControlsMediator mediator;
        private AuthorInfo[] authors;
        public GitBinderControl()
        {
            InitializeComponent();
            MainList.ItemsSource = Authors;
        }

        public AuthorInfo[] Authors { get => authors; set  => authors = value; }
        public IControlsMediator Mediator { get => mediator; set => mediator = value; }

        public void LoadButtons(string[] authorsList)
        {
            
        }

        private void CreateButton(string text)
        {

        }

        private void SelectButtonClick(object sender, RoutedEventArgs e)
        {
            int index = MainList.SelectedIndex;
            mediator.SendData(authors[index]);
        }
    }
}
