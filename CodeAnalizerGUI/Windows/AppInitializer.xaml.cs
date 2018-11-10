﻿using System;
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
using CodeAnalizerGUI.UserControls.MainWindowControls.Models;
using CodeAnalizerGUI.UserControls.MainWindowControls.ViewModels;
using CodeAnalizerGUI.UserControls.CustomControls.ViewModels;
using CodeAnalizerGUI.UserControls.CustomControls;
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

            InitializeComponent();
            InitializeFactory();
            InitializeMainWindow();
            InitializeData();
            LogicHolder holder = new LogicHolder();
        }

       
        private void InitializeData()
        {
            DIContainer.InitializeContainer();

            DataManager dm = DIContainer.Container.Resolve<DataManager>();
        }

        private void InitializeMainWindow()
        {
            MainWindow win = new MainWindow();
            MainWindowViewModel vm = new MainWindowViewModel();
            MainWindowControlsMediator mainWindowControlsMediator = new MainWindowControlsMediator(vm);
            
            SubControlMediator subMed = new SubControlMediator();
            subMed.Parent = mainWindowControlsMediator;

            UserControl list = mainWindowControlsMediator.CreateControl(typeof(ManageableFileView),subMed, new object[] { });

            object[] par = new object[] { new GeneralStatisticsGenerator(),new DataSaver(null) };
            UserControl contributorsControl = mainWindowControlsMediator.CreateControl(typeof(ContributorsControl), mainWindowControlsMediator, par);


            vm.Mediator = mainWindowControlsMediator;
            vm.ButtonsGenerator = new NavigationButtonsGenerator(mainWindowControlsMediator,contributorsControl);
            vm.ContributorsControl = contributorsControl;
            
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
            fac.RegisterViewType(typeof(FileExplorerControl), typeof(FileExplorerViewModel));
        }
    }
}
