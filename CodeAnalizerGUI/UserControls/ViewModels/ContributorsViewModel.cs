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
    class ContributorsViewModel:ViewModel
    {
        private ObservableCollection<ContributorButtonModel> contributors;
        private IFileCollector collector;
        private DataManager dataManager;

        public ObservableCollection<ContributorButtonModel> Contributors { get => contributors; set => contributors = value; }
        

        public ContributorsViewModel(IFileCollector collector,DataManager manager)
        {
            this.collector = collector;
            dataManager = manager;
            manager.SetPath(Properties.Settings.Default.ProjectPath);

            contributors = new ObservableCollection<ContributorButtonModel>();
            contributors.Add(new ContributorButtonModel(new ContributorModel {PathToImage = Properties.Settings.Default.AppData + "\\plus.png" } , new SimpleCommand(NewContributorClick)));

            VMMediator.Instance.Register(MVVMMessage.NewContributorCreated, ReciveNewContributor);
        }

        private void OpenDetailsControl(object parameter)
        {
            var selected = parameter as ContributorModel;

            var detView = DIContainer.Container.Resolve<ContributorDetailsViewModel>(
                new NamedParameter("miner", LogicHolder.MainHolder.GetFileMiner(selected.PathsToFiles.ToArray(), false)),
                new NamedParameter("contributor",selected));

            VMMediator.Instance.NotifyColleagues(MVVMMessage.OpenNewControl, detView);
        }

        private void NewContributorClick()
        {
            var vm = DIContainer.Resolve<NewContributorViewModel>();
            var list = DIContainer.Resolve<ManageableFileListModel>();
            list.AllowedFormats = new string[] { ".cs", ".xaml.cs"};
            vm.FileList = list;
            
            VMMediator.Instance.NotifyColleagues(MVVMMessage.OpenNewControl, vm);
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
            toAdd.PathToImage = collector.MoveToResources(toAdd.PathToImage);
            contributors.Add(new ContributorButtonModel(toAdd, new IndexCommand(OpenDetailsControl)));

            LogicHolder.MainHolder.GetFileMiner(toAdd.PathsToFiles.ToArray(), true);
        }

        public void SaveContributors()
        {
            var toSave = from x in contributors
                         where x.Contributor!=null
                         select x.Contributor;

            dataManager.ContributorSaver.Save(toSave.ToArray());
        }

        public void LoadContributors()
        {
            var loaded = dataManager.ContributorLoader.Load();
            var plus = contributors.Last();

            if (contributors.Count != 0)
                contributors.Clear();

            foreach (var contributor in loaded)
                NewContributor(contributor);

            contributors.Add(plus);
        }
    }
}
