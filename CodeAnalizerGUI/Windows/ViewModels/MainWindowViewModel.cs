using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeAnalizerGUI.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using CodeAnalizerGUI.UserControls.MainWindowControls.ViewModels;
using CodeAnalizerGUI.Interfaces;
using CodeAnalizerGUI.Windows.Models;

namespace CodeAnalizerGUI.Windows.ViewModels
{
    class MainWindowViewModel : ViewModel
    {
        private List<Models.NavigationButtonModel> navigationButtons;
        private IControlsMediator mediator;
        private IButtonsGenerator buttonsGenerator;
        private object mainContent;

        #region Commands
        public ICommand OptionsCommand { get; set; }
        public ICommand ExitCommand { get; set; }
        public ICommand TestCommand { get; set; }
        public ICommand DailyStatsCommand { get; set; }
        #endregion

        public List<NavigationButtonModel> NavigationButtons { get => navigationButtons; set => navigationButtons = value; }
        public IControlsMediator Mediator { get => mediator; set => mediator = value; }
        public object MainContent { get => mainContent; set => mainContent = value; }
        public IButtonsGenerator ButtonsGenerator { get => buttonsGenerator; set { buttonsGenerator = value;LoadNavigationButtons(); } }

        public MainWindowViewModel()
        {

        }

        public void RunTest()
        {
            //ContributorsControl tmp = new ContributorsControl();
            //mainBus.PathToProject = "D:\\Documents\\Projekty\\CodeAnalizerGUI";
            //mainBus.OpenProject();

            //TestControl tc = new TestControl();
            //mediator.LoadContent(tc);

            //ViewModel vm = new ContributorsViewModel();
            //UserControl view = new ContributorsControl();

            //vm.Mediator = mediator;
            //view.DataContext = vm;

            UserControl view = mediator.CreateControl(typeof(ContributorsControl), mediator);
            mediator.LoadContent(view);

            //ContributorDetailsControl cdc = new ContributorDetailsControl();
            //mainBus.ContributorManager.AddContributor("Judasz Iskariota",new string[] {"D:\\AnalizerTest\\Kuba"});
            //cdc.Contributor = mainBus.ContributorManager.Contributors[0];
            //cdc.LoadContent();
            //LoadContent(cdc);
        }

        public void DailyStats()
        {

        }

        private void LoadNavigationButtons()
        {
            navigationButtons = ButtonsGenerator.GenerateButtons();
        }
    }
}
