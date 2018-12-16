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
using System.Reflection;
namespace CodeAnalizerGUI.Windows.ViewModels
{
    public class MainWindowViewModel : ViewModel,INotifyPropertyChanged
    {
        #region Fields
        private List<NavigationButtonModel> navigationButtons;
        private IButtonsGenerator navigationFactory;
        private IButtonsListFactory toolbarFactory;
        private IVMStack commStack;
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


        public MainWindowViewModel(IButtonsGenerator navigationFactory,IButtonsListFactory toolbarFactory, IVMStack commStack)
        {
            this.navigationFactory = navigationFactory;
            this.toolbarFactory = toolbarFactory;
            this.commStack = commStack;

            LoadNavigationButtons();
            LoadToolbarButtons();

            TestCommand = new SimpleCommand(RunTest);
            VMMediator.Instance.Register(MVVMMessage.OpenNewControl, LoadContent);
            VMMediator.Instance.Register(MVVMMessage.CloseControl, RevertContent);
            VMMediator.Instance.Register(MVVMMessage.OpenNewRootControl, LoadRoot);
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
    }
}
