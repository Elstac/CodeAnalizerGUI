using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeAnalizerGUI.Interfaces;
using CodeAnalizerGUI.Models;
using System.Windows.Input;
using CodeAnalizerGUI.Abstractions;
using CodeAnalizerGUI.ViewModels;
using CodeAnalizerGUI.Classes;
namespace CodeAnalizerGUI.Classes
{
    class ProjectCreationButtonsFactory : ButtonsListFactory
    {
        public ProjectCreationButtonsFactory(IVMMediator mediator):base(mediator)
        {
            this.mediator = mediator;
            names = new List<string> { "New project", "GIT", "Directory" };
            commands = new List<ICommand> {new SimpleCommand(NewProject),new SimpleCommand(ProjectFromGIT),new SimpleCommand(ProjectFromDirectory) };
        }

        private void NewProject()
        {
            var control = DIContainer.Resolve<NewProjectViewModel>();
            mediator.NotifyColleagues(MVVMMessage.OpenNewControl, control);
        }

        private void ProjectFromGIT()
        {

        }

        private void ProjectFromDirectory()
        {

        }
    }
}
