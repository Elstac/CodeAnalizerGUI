using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeAnalizerGUI.Interfaces;
using CodeAnalizerGUI.Models;
using CodeAnalizerGUI.Abstractions;
using CodeAnalizerGUI.Views;
using CodeAnalizerGUI.ViewModels;
using CodeAnalizerGUI.Classes;
using System.Windows.Input;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using CodeAnalizerGUI.DataSavingModule;
using Autofac;

namespace CodeAnalizerGUI.ViewModels
{
    public class ContributorsViewModel:ViewModel
    {
        private ObservableCollection<ContributorButtonModel> contributors;
        private IVMMediator mediator;
        private ILogicHolder logicHolder;
        private Func<NewContributorViewModel> newContributorVMFactory;
        private Func<ContributorModel, ContributorDetailsViewModel> detailsVMFactory;
        private string pathToContributors;

        public ObservableCollection<ContributorButtonModel> Contributors { get => contributors; set => contributors = value; }
        
        public ContributorsViewModel(IVMMediator mediator,ILogicHolder holder,Func<NewContributorViewModel> newContributorVMFactory, Func<ContributorModel, ContributorDetailsViewModel> detailsVMFactory,string path)
        {
            pathToContributors = path;
            this.detailsVMFactory = detailsVMFactory;
            this.newContributorVMFactory = newContributorVMFactory;
            this.mediator = mediator;
            logicHolder = holder;
            contributors = new ObservableCollection<ContributorButtonModel>();

            foreach (var contributor in logicHolder.GetContributorList())
                NewContributor(contributor);

            contributors.Add(new ContributorButtonModel(new ContributorModel {PathToImage = Properties.Settings.Default.AppData + "\\plus.png" } , new SimpleCommand(NewContributorClick)));

            mediator.Register(MVVMMessage.NewContributorCreated, ReciveNewContributor);
            mediator.Register(MVVMMessage.LoadContributors, LoadContributors);
            mediator.Register(MVVMMessage.SaveContributors, SaveContributors);
        }

        private void OpenDetailsControl(object parameter)
        {
            var selected = parameter as ContributorModel;
            
            mediator.NotifyColleagues(MVVMMessage.OpenNewControl, detailsVMFactory.Invoke(selected));
        }

        private void NewContributorClick()
        {
            var vm = newContributorVMFactory.Invoke();
            
            mediator.NotifyColleagues(MVVMMessage.OpenNewControl, vm);
        }

        public void ReciveNewContributor(object dataClass)
        {
            var button = contributors.Last();
            contributors.Remove(contributors.Last());

            ContributorModel toAdd = dataClass as ContributorModel;
            NewContributor(toAdd);
            contributors.Add(button);
        }

        private void NewContributor(ContributorModel toAdd)
        {
            if (toAdd == null)
                throw new NullReferenceException("Contributor to add cannot be null");

            contributors.Add(new ContributorButtonModel(toAdd, new IndexCommand(OpenDetailsControl)));
        }

        public void SaveContributors(object args)
        {
            logicHolder.SaveContributors(pathToContributors);
        }

        public void LoadContributors(object args)
        {
            logicHolder.LoadContributors(pathToContributors);

            contributors.Clear();
            var tmp = logicHolder.GetContributorList();
            foreach (var contrib in tmp)
                NewContributor(contrib);
        }
    }
}
