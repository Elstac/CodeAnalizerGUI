using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using CodeAnalizerGUI.Classes;
using CodeAnalizerGUI.Interfaces;
using CodeAnalizerGUI.Views;
using CodeAnalizerGUI.Models;
using CodeAnalizerGUI.ViewModels;

using CodeAnalizerGUI.Windows.ViewModels;
using CodeAnalizerGUI.DataSavingModule;
using Autofac;
namespace CodeAnalizerGUI.Windows
{
    /// <summary>
    /// Interaction logic for AppInitializer.xaml
    /// </summary>
    public partial class AppInitializer : Window
    {
        public AppInitializer()
        {

            InitializeData();
            InitializeComponent();
            InitializeFactory();
            LogicHolder holder = DIContainer.Container.Resolve<LogicHolder>();

            InitializeMainWindow();
        }

       
        private void InitializeData()
        {
            DIContainer.InitializeContainer();
        }

        private void InitializeMainWindow()
        {
            MainWindow win = new MainWindow();
            var toolbarFactory = DIContainer.Container.Resolve<IButtonsListFactory>(new NamedParameter("listType",ListType.start));
            var navigationFactory = DIContainer.Container.Resolve<IButtonsListFactory>(new NamedParameter("listType",ListType.navigation));
            var vm = DIContainer.Container.Resolve<MainWindowViewModel>(new NamedParameter("toolbarFactory",toolbarFactory), new NamedParameter("navigationFactory", navigationFactory));

            win.DataContext = vm;
            

            win.Show();
            Close();
        }

        private static void InitializeFactory()
        {
            ControlFactory fac = new ControlFactory();

            fac.RegisterViewType(typeof(GitBinderControl), typeof(GitBinderViewModel));
            fac.RegisterViewType(typeof(NewContributorControl), typeof(NewContributorViewModel));
            fac.RegisterViewType(typeof(ManageableFileView), typeof(ManageableFileListModel));
            fac.RegisterViewType(typeof(StatisticsControl), typeof(StatisticsViewModel));
            fac.RegisterViewType(typeof(ContributorDetailsControl), typeof(ContributorDetailsViewModel));
            fac.RegisterViewType(typeof(FileExplorerControl), typeof(FileExplorerViewModel));
            fac.RegisterViewType(typeof(ButtonPanelView), typeof(ButtonPanelViewModel));
        }
    }
}
