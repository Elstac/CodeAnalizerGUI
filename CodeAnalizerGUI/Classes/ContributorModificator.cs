using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeAnalizerGUI.Interfaces;
using CodeAnalizerGUI.Models;
using CodeAnalizerGUI.ViewModels;

namespace CodeAnalizerGUI.Classes
{
    class ContributorModificator : IContributorModificator
    {
        private Func<NewContributorViewModel> newContributorVMFactory;
        private IVMMediator mediator;
        private bool editMode = false;
        private ContributorModel edited;
        public ContributorModificator(Func<NewContributorViewModel> newContributorVMFactory, IVMMediator mediator)
        {
            this.newContributorVMFactory = newContributorVMFactory;
            this.mediator = mediator;

            mediator.Register(MVVMMessage.ContributorModificationEnd, ReciveContributorData);
        }

        public void Edit(ref ContributorModel toEdit)
        {
            editMode = true;
            var vm = newContributorVMFactory.Invoke();
            edited = toEdit;
            vm.Contributor = edited;

            mediator.NotifyColleagues(MVVMMessage.OpenNewControl,vm);
        }

        public void NewContributor()
        {
            var vm = newContributorVMFactory.Invoke();

            mediator.NotifyColleagues(MVVMMessage.OpenNewControl, vm);
        }

        private void ReciveContributorData(object args)
        {
            if (!(args is ContributorModel))
                return;

            if (!editMode)
                mediator.NotifyColleagues(MVVMMessage.NewContributorCreated, args);
            else
            {
                var contributor = args as ContributorModel;
                edited.Name=contributor.Name;
                edited.Email=contributor.Email;
                edited.PathToImage = contributor.PathToImage;
                edited.PathsToFiles=contributor.PathsToFiles;
            }
        }
    }
}
