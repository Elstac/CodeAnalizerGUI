using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using CodeAnalizerGUI.UserControls.MainWindowControls.Models;
using CodeAnalizerGUI.UserControls.MainWindowControls.ViewModels;
using CodeAnalizerGUI.UserControls.MainWindowControls.Commands;
using CodeAnalizerGUI.Windows.Models;
using System.Windows.Input;
namespace CodeAnalizerGUI.Classes
{
    class NavigationButtonsGenerator : Interfaces.IButtonsGenerator
    {
        private Interfaces.IControlsMediator mediator;
        public NavigationButtonsGenerator(Interfaces.IControlsMediator mediator)
        {
            this.mediator = mediator;
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
            UserControl view = mediator.CreateControl(typeof(ContributorsControl), mediator);
            mediator.LoadContent(view);
        }

        private void OpenGlobalStatistics()
        {
            throw new NotImplementedException();
        }
    }
}
