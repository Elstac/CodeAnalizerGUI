using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeAnalizerGUI.Interfaces;
using CodeAnalizerGUI.UserControls.MainWindowControls.Models;
using CodeAnalizerGUI.UserControls.MainWindowControls.Commands;
using System.Windows.Input;
namespace CodeAnalizerGUI.Classes
{
    class StartingToolbarFactory : ButtonsListFactory
    {
        public StartingToolbarFactory()
        {
            names = new string[] { "New Project", "Open Project" };
            commands = new ICommand[] { new SimpleCommand(NewProject), new SimpleCommand(OpenProject) };
        }
        private void NewProject()
        {

        }

        private void OpenProject()
        {

        }
    }
}
