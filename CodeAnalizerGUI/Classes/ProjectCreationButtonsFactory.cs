using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeAnalizerGUI.Interfaces;
using CodeAnalizerGUI.UserControls.MainWindowControls.Models;
using System.Windows.Input;
using CodeAnalizerGUI.UserControls.MainWindowControls.Commands;
namespace CodeAnalizerGUI.Classes
{
    class ProjectCreationButtonsFactory : ButtonsListFactory
    {
        public ProjectCreationButtonsFactory()
        {
            names = new string[] { "New project", "GIT", "Directory" };
            commands = new ICommand[] {new SimpleCommand(NewProject),new SimpleCommand(ProjectFromGIT),new SimpleCommand(ProjectFromDirectory) };
        }

        private void NewProject()
        {
            
        }

        private void ProjectFromGIT()
        {

        }

        private void ProjectFromDirectory()
        {

        }
    }
}
