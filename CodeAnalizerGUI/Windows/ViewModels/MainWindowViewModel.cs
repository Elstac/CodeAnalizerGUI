using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeAnalizerGUI.Windows;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Input;
using CodeAnalizerGUI.ViewModels;
using CodeAnalizerGUI.Abstractions;
using CodeAnalizerGUI.Interfaces;
using CodeAnalizerGUI.Classes;
using CodeAnalizerGUI.Windows.Models;
using System.Collections.ObjectModel;
using CodeAnalizerGUI.Models;
using CodeAnalizerGUI.ProjectModule;
using System.Reflection;
using Autofac;

namespace CodeAnalizerGUI.Windows.ViewModels
{
    public class MainWindowViewModel : ViewModel,INotifyPropertyChanged
    {
        #region Fields
        private List<NavigationButtonModel> navigationButtons;
        private IButtonsGenerator navigationFactory;
        private IButtonsListFactory toolbarFactory;
        private IVMStack commStack;
        private IVMMediator mediator;
        private object mainContent;
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<ButtonModel> toolBarButtons;

        public ICommand TestCommand;
        #endregion

        #region Properties
        public List<NavigationButtonModel> NavigationButtons { get => navigationButtons; set => navigationButtons = value; }
        public ObservableCollection<ButtonModel> ToolbarButtons { get => toolBarButtons; set => toolBarButtons = value; }
        public object MainContent { get => mainContent; set { mainContent = value; RaisePropertyChange("MainContent"); } }
        
        #endregion


        public MainWindowViewModel(IButtonsGenerator navigationFactory,IButtonsListFactory toolbarFactory, IVMStack commStack,IVMMediator mediator)
        {
            this.mediator = mediator;
            this.navigationFactory = navigationFactory;
            this.toolbarFactory = toolbarFactory;
            this.commStack = commStack;

            LoadNavigationButtons();
            LoadToolbarButtons();

            TestCommand = new SimpleCommand(RunTest);
            mediator.Register(MVVMMessage.OpenNewControl, LoadContent);
            mediator.Register(MVVMMessage.CloseControl, RevertContent);
            mediator.Register(MVVMMessage.OpenNewRootControl, LoadRoot);
            mediator.Register(MVVMMessage.ProjectCreated, OpenNewProject);
        }

        private void LoadToolbarButtons()
        {
            toolBarButtons = toolbarFactory.GenerateButtons();
            ToolbarButtons.Add(new ButtonModel(new SimpleCommand(RunTest), "TEST"));
        }
        
        public void RunTest()
        {
        }

        private void LoadNavigationButtons()
        {
            navigationButtons = navigationFactory.GenerateButtons();
        }

        private void RaisePropertyChange(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
        
        private void LoadContent(object viewModel)
        {
            MainContent = viewModel;
            commStack.NewVM(viewModel as ViewModel);
        }

        private void LoadRoot(object viewModel)
        {
            MainContent = viewModel;
            commStack.RootVM(viewModel as ViewModel);
        }

        private void RevertContent(object viewModel)
        {
            MainContent = commStack.PreviousVM();
        }

        private void OpenNewProject(object args)
        {
            var config = args as ProjectConfig;

            Properties.Settings.Default.ProjectPath = config.Directory;

            var lh = DIContainer.Resolve<ILogicHolder>();
            lh.LoadContributors(config.Directory + Properties.Settings.Default.contibFile);

            MainContent = DIContainer.Container.Resolve<ContributorsViewModel>(new NamedParameter("path",config.Directory+"Contributors.xml"));
            commStack.RootVM(mainContent as ViewModel);
        }
    }
}
