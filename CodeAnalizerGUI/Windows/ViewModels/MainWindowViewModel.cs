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
        private List<NavigationButtonModel> navigationButtons;
        private IControlsMediator  mediator;
        private UserControl contributorsControl;
        private IButtonsGenerator buttonsGenerator;
        private IButtonsListFactory toolbarGenerator;
        private UserControl mainContent;
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<ButtonModel> toolBarButtons;

        public ICommand TestCommand;

        public List<NavigationButtonModel> NavigationButtons { get => navigationButtons; set => navigationButtons = value; }
        public ObservableCollection<ButtonModel> ToolbarButtons { get => toolBarButtons; set => toolBarButtons = value; }
        public IControlsMediator Mediator { get => mediator;
            set
            {
                mediator = value;
            } }
        public UserControl MainContent { get => mainContent; set { mainContent = value; RaisePropertyChange("MainContent"); } }
        public IButtonsGenerator ButtonsGenerator { get => buttonsGenerator; set { buttonsGenerator = value;LoadNavigationButtons(); } }

        public UserControl ContributorsControl { get => contributorsControl; set => contributorsControl = value; }
        public IButtonsListFactory ToolbarGenerator { get => toolbarGenerator; set { toolbarGenerator = value; LoadToolbarButtons(); } }

        private void LoadToolbarButtons()
        {
            toolBarButtons = toolbarGenerator.GenerateButtons();
            ToolbarButtons.Add(new ButtonModel(new SimpleCommand(RunTest), "TEST"));
        }

        public MainWindowViewModel()
        {
            TestCommand = new SimpleCommand(RunTest);
        }

        int pom = 0;
        public void RunTest()
        {
            var tmp = contributorsControl.DataContext as ContributorsViewModel;
            if (pom == 0)
            {
                try
                {
                    tmp.LoadContributors();
                }
                catch (System.IO.FileNotFoundException e)
                {
                    Console.WriteLine("Brak pliku: " + e.FileName);
                }
                mediator.LoadMainControl(contributorsControl);
                pom++;
            }
            else
            {
                tmp.SaveContributors();
            }

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
