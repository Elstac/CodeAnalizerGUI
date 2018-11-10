using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeAnalizerGUI.Interfaces;
using CodeAnalizerGUI.UserControls.MainWindowControls.Models;
using CodeAnalizerGUI.UserControls.CustomControls.ViewModels;
using CodeAnalizerGUI.UserControls.MainWindowControls.Commands;
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
        private IStatisticsGenerator generator;
        private ObservableCollection<ContributorButtonModel> contributors;
        private DataManager dataManager;

        public ObservableCollection<ContributorButtonModel> Contributors { get => contributors; set => contributors = value; }
        public IStatisticsGenerator Generator { get => generator; set => generator = value; }
        public DataManager DataManager { get => dataManager;
        set
            {
                dataManager = value;
                dataManager.SetPath(Properties.Settings.Default.savePath);
            }
        }

        public ContributorsViewModel()
        {
            contributors = new ObservableCollection<ContributorButtonModel>();
            ContributorModel des = new ContributorModel(); 
            contributors.Add(new ContributorButtonModel(null , new SimpleCommand(NewContributor)));
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

        private void NewContributor()
        {
            SubControlMediator subMed = new SubControlMediator();
            subMed.Parent = mediator;
            UserControl list = mediator.CreateControl(typeof(ManageableFileView), subMed);
            UserControl view = mediator.CreateControl(typeof(NewContributorControl), mediator,new object[] { subMed,list.DataContext});
            
            Mediator.LoadMainControl(view,this);
        }
        public void ReciveData(object dataClass)
        {
            ContributorButtonModel button = contributors.Last();
            contributors.Remove(contributors.Last());
            ContributorModel toAdd = dataClass as ContributorModel;
            contributors.Add(new ContributorButtonModel(toAdd,new IndexCommand( OpenDetailsControl)));
            contributors.Add(button);
            LogicHolder.MainHolder.GetFileMiner(toAdd.PathsToFiles.ToArray(),true);
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
            if (contributors.Count != 0)
                contributors.Clear();

            var tmp = from c in loaded
                      select new ContributorButtonModel(c, new IndexCommand(OpenDetailsControl));

            foreach (var button in tmp)
                contributors.Add(button);
        }
    }
}
