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

namespace CodeAnalizerGUI.Classes
{
    class StartingToolbarFactory : ButtonsListFactory
    {
        private IVMMediator mediator;
        private FileExplorerViewModel.Factory explorer;
        
        public StartingToolbarFactory(IVMMediator mediator,FileExplorerViewModel.Factory explorer)
        {
            this.explorer = explorer;
            this.mediator = mediator;
            mediator.Register(MVVMMessage.FileChosed)
            names = new string[] { "New Project", "Open Project" };
            commands = new ICommand[] { new SimpleCommand(NewProject), new SimpleCommand(OpenProject) };
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
    }
}
