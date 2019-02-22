using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeAnalizerGUI.Abstractions;
using CodeAnalizerGUI.DataSavingModule;
using CodeAnalizerGUI.ProjectModule;
using CodeAnalizerGUI.ViewModels;

namespace CodeAnalizerGUI.Classes
{
    class OpenedProjecToolbarFactory : StartingToolbarFactory
    {
        public OpenedProjecToolbarFactory(IVMMediator mediator, FileExplorerViewModel.Factory explorer,IProjectOpener projectOpener) : base(mediator, explorer,projectOpener)
        {
            names.Add("Save");
            names.Add("Load");

            commands.Add(new SimpleCommand(SaveButtonClick));
            commands.Add(new SimpleCommand(LoadButtonClick));
        }

        public void LoadButtonClick()
        {
            mediator.NotifyColleagues(MVVMMessage.LoadContributors, null);
        }

        public void SaveButtonClick()
        {
            mediator.NotifyColleagues(MVVMMessage.SaveContributors, null);
        }
    }
}
