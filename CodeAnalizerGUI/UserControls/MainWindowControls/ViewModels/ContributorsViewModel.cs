using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeAnalizerGUI.Interfaces;
using CodeAnalizerGUI.UserControls.MainWindowControls.Models;
using CodeAnalizerGUI.UserControls.CustomControls;
using CodeAnalizerGUI.Abstractions;
using CodeAnalizerGUI.UserControls.MainWindowControls.Views;
using CodeAnalizerGUI.Classes;
using System.Windows.Input;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using CodeAnalizerGUI.DataSavingModule;

namespace CodeAnalizerGUI.UserControls.MainWindowControls.ViewModels
{
    class ContributorsViewModel : ViewModel,ISubControlDataReciver
    {
        private IFileCollector collector;
        private IStatisticsGenerator generator;
        private ObservableCollection<ContributorButtonModel> contributors;
        private DataManager dataManager;

        public ObservableCollection<ContributorButtonModel> Contributors { get => contributors; set => contributors = value; }
        public IStatisticsGenerator Generator { get => generator; set => generator = value; }
        public DataManager DataManager { get => dataManager;
        set
            {
                dataManager = value;
                dataManager.SetPath(Properties.Settings.Default.ProjectPath);
            }
        }

        public IFileCollector Collector { get => collector; set => collector = value; }

        public ContributorsViewModel()
        {
            contributors = new ObservableCollection<ContributorButtonModel>();
            ContributorModel des = new ContributorModel(); 
            contributors.Add(new ContributorButtonModel(null , new SimpleCommand(NewContributorClick)));
        }

        private void OpenDetailsControl(object parameter)
        {
            ContributorModel recived = parameter as ContributorModel;
            object[] tp = new object[1];

            generator.SetMiner(LogicHolder.MainHolder.GetFileMiner(recived.PathsToFiles.ToArray(), true));
            tp[0] = generator.GenerateStatisticsDisplay();
            UserControl StatsView = mediator.CreateControl(typeof(StatisticsControl), mediator,tp);

            SubControlMediator subMed =new SubControlMediator();
            subMed.Parent = mediator;

            object[] properties = new object[] {StatsView,parameter as ContributorModel,subMed };
            UserControl detailControl = mediator.CreateControl(typeof(ContributorDetailsControl),mediator,properties);

            mediator.LoadMainControl(detailControl);
        }

        private void NewContributorClick()
        {
            SubControlMediator subMed = new SubControlMediator();
            subMed.Parent = mediator;
            UserControl list = mediator.CreateControl(typeof(ManageableFileView), subMed);
            UserControl view = mediator.CreateControl(typeof(NewContributorControl), mediator,new object[] { subMed,list.DataContext});
            
            Mediator.LoadMainControl(view,this);
        }
        public void ReciveData(object dataClass)
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
