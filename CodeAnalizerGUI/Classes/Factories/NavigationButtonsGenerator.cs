using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using CodeAnalizerGUI.UserControls.MainWindowControls.Models;
using CodeAnalizerGUI.UserControls.MainWindowControls.ViewModels;
using CodeAnalizerGUI.UserControls.MainWindowControls.Commands;
using CodeAnalizerGUI.UserControls.MainWindowControls.Views;
using CodeAnalizerGUI.Windows.Models;
using System.Windows.Input;
using System.Collections.ObjectModel;
namespace CodeAnalizerGUI.Classes
{
    class NavigationButtonsGenerator : Interfaces.IButtonsGenerator
    {
        private Interfaces.IControlsMediator mediator;
        private UserControl contribControl;

        public NavigationButtonsGenerator(Interfaces.IControlsMediator mediator, UserControl contrib)
        {
            this.mediator = mediator;
            contribControl = contrib;
        }

        public List<NavigationButtonModel> GenerateButtons()
        {
            ICommand[] commands = new ICommand[]
            {
                new SimpleCommand(OpenGlobalStatistics),
                new SimpleCommand(OpenContributorsControl)
            };

            string[] names = new string[]
            {
                "Global Statistics",
                "Contributors"
            };

            List<NavigationButtonModel> ret = new List<NavigationButtonModel>();
            NavigationButtonModel toAdd;
            for (int i = 0; i < commands.Length; i++)
            {
                toAdd = new NavigationButtonModel(names[i], commands[i]);
                ret.Add(toAdd);
            }

            return ret;
        }

        private void OpenContributorsControl()
        {
            mediator.LoadMainControl(contribControl);
            mediator.BreakOperation();
        }

        private void OpenGlobalStatistics()
        {
            GeneralStatisticsGenerator gen = new GeneralStatisticsGenerator();
            gen.SetMiner(LogicHolder.MainHolder.GetGlobalFileMiner());
            object[] dep = new object[] {gen.GenerateStatisticsDisplay() };
            UserControl view = mediator.CreateControl(typeof(StatisticsControl),mediator, dep);
            mediator.LoadMainControl(view);
            mediator.BreakOperation();
        }
    }
}
