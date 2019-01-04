using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeAnalizerGUI.Interfaces;
using CodeAnalizerGUI.Models;
using CodeAnalizerGUI.Abstractions;
using CodeAnalizerGUI.Views;
using System.Windows.Input;
using Autofac;
using CodeAnalizerGUI.ViewModels;
using CodeAnalizerGUI.DataSavingModule;
using CodeAnalizerGUI.ProjectModule;
namespace CodeAnalizerGUI.Classes
{
    class StartingToolbarFactory : ButtonsListFactory
    {
        private FileExplorerViewModel.Factory explorer;
        private ILoadBehavior<ProjectConfig> loader;

        public StartingToolbarFactory(IVMMediator mediator,FileExplorerViewModel.Factory explorer,ILoadBehavior<ProjectConfig> loader):base(mediator)
        {
            this.loader = loader;
            this.explorer = explorer;
            this.mediator = mediator;
            names = new List<string> { "New Project", "Open Project" };
            commands = new List<ICommand> { new SimpleCommand(NewProject), new SimpleCommand(OpenProject) };

            mediator.Register(MVVMMessage.FileChosed, ReciveProjectPath);
        }

        private void NewProject()
        {
            var buttons = DIContainer.Container.Resolve<IButtonsListFactory>(new NamedParameter("listType", ListType.pCreation)).GenerateButtons();
            var view = DIContainer.Container.Resolve<ButtonPanelViewModel>();
            view.ButtonsList = buttons;

            mediator.NotifyColleagues(MVVMMessage.OpenNewControl, view);
        }

        private void OpenProject()
        {
            mediator.NotifyColleagues(MVVMMessage.OpenNewControl, explorer.Invoke(new string[] { ".xml" }));
        }

        private void ReciveProjectPath(object arg)
        {
            if (!arg.ToString().EndsWith(".xml"))
                return;

            var path = arg.ToString();

            var config = loader.Load(path);
            mediator.NotifyColleagues(MVVMMessage.ProjectCreated, config);
        }
    }
}
