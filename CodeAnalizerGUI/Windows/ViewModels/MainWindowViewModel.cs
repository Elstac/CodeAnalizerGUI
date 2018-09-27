using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeAnalizerGUI.Windows;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Input;
using CodeAnalizerGUI.UserControls.MainWindowControls.ViewModels;
using CodeAnalizerGUI.UserControls.MainWindowControls.Views;
using CodeAnalizerGUI.UserControls.MainWindowControls.Commands;
using CodeAnalizerGUI.Interfaces;
using CodeAnalizerGUI.Classes;
using CodeAnalizerGUI.Windows.Models;
using System.Collections.ObjectModel;
using CodeAnalizerGUI.UserControls.MainWindowControls.Models;
using System.Reflection;
namespace CodeAnalizerGUI.Windows.ViewModels
{
    public class MainWindowViewModel : ViewModel,INotifyPropertyChanged
    {
        private List<Models.NavigationButtonModel> navigationButtons;
        private IControlsMediator mediator;
        private UserControl contributorsControl;
        private IButtonsGenerator buttonsGenerator;
        private UserControl mainContent;
        public event PropertyChangedEventHandler PropertyChanged;

        #region Commands
        public ICommand OptionsCommand { get; set; }
        public ICommand ExitCommand { get; set; }
        public ICommand TestCommand { get; set; }
        public ICommand DailyStatsCommand { get; set; }
        #endregion

        public List<NavigationButtonModel> NavigationButtons { get => navigationButtons; set => navigationButtons = value; }
        public IControlsMediator Mediator { get => mediator;
            set
            {
                mediator = value;
            } }
        public UserControl MainContent { get => mainContent; set { mainContent = value; RaisePropertyChange("MainContent"); } }
        public IButtonsGenerator ButtonsGenerator { get => buttonsGenerator; set { buttonsGenerator = value;LoadNavigationButtons(); } }

        public UserControl ContributorsControl { get => contributorsControl; set => contributorsControl = value; }

        public MainWindowViewModel()
        {
            TestCommand = new SimpleCommand(RunTest);
        }
        

        public void RunTest()
        {
            mediator.LoadContent(contributorsControl);

        }

        public void DailyStats()
        {

        }

        private void LoadNavigationButtons()
        {
            navigationButtons = ButtonsGenerator.GenerateButtons();
        }

        private void RaisePropertyChange(string property)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(property));
        }

        
    }
}
