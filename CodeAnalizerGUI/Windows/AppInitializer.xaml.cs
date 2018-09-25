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
using CodeAnalizerGUI.Classes;
using CodeAnalizerGUI.UserControls.MainWindowControls.Views;
using CodeAnalizerGUI.UserControls.MainWindowControls.ViewModels;
using CodeAnalizerGUI.UserControls.CustomControls.ViewModels;
using CodeAnalizerGUI.Windows.ViewModels;
namespace CodeAnalizerGUI.Windows
{
    /// <summary>
    /// Interaction logic for AppInitializer.xaml
    /// </summary>
    public partial class AppInitializer : Window
    {
        public AppInitializer()
        {
            InitializeComponent();
            InitializeFactory();
            InitializeMainWindow();
        }

        private void InitializeMainWindow()
        {
            MainWindow win = new MainWindow();
            MainWindowViewModel vm = new MainWindowViewModel();

            MainWindowControlsMediator mainWindowControlsMediator = new MainWindowControlsMediator(vm);
            vm.Mediator = mainWindowControlsMediator;
            vm.ButtonsGenerator = new NavigationButtonsGenerator(mainWindowControlsMediator);

            win.DataContext = vm;

            win.Show();
            Close();
        }

        private static void InitializeFactory()
        {
            ControlFactory fac = new ControlFactory();
            fac.RegisterViewType(typeof(ContributorsControl), typeof(ContributorsViewModel));
            fac.RegisterViewType(typeof(GitBinderControl), typeof(GitBinderViewModel));
            fac.RegisterViewType(typeof(NewContributorControl), typeof(NewContributorViewModel));
            fac.RegisterViewType(typeof(ManageableFileView), typeof(ManagableFileViewViewModel));
            fac.RegisterViewType(typeof(StatisticsControl), typeof(StatisticsViewModel));
            fac.RegisterViewType(typeof(ContributorDetailsControl), typeof(ContributorDetailsViewModel));
        }
    }
}
