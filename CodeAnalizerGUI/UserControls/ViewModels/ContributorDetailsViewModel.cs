using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using CodeAnalizerGUI.Interfaces;
using CodeAnalizerGUI.Models;
using CodeAnalizerGUI.Abstractions;
using CodeAnalizer.FileAnalizerModule.Interfaces;
using CodeAnalizerGUI.Classes;
using Autofac;

namespace CodeAnalizerGUI.ViewModels
{
    public class ContributorDetailsViewModel:ViewModel
    {
        private ViewModel statisticsViewModel;
        private ContributorModel contributor;
        private IControlsMediator subControlsMediator;
        private IFileMiner dataMiner;
        private IStatisticsGenerator generator;

        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public ContributorDetailsViewModel(IStatisticsGenerator generator,IFileMiner miner,ContributorModel contributor)
        {
            this.contributor = contributor;
            this.generator = generator;
            dataMiner = miner;
            generator.SetMiner(dataMiner);
            this.generator = generator;
            var stats = generator.GenerateStatisticsDisplay();

            statisticsViewModel = DIContainer.Container.Resolve<GlobalStatisticsViewModel>(new NamedParameter("data", stats));
            VMMediator.Instance.NotifyColleagues(MVVMMessage.OpenNewControl, statisticsViewModel);
        }

        public ViewModel StatisticsViewModel { get => statisticsViewModel; set => statisticsViewModel = value; }
        public ContributorModel Contributor { get => contributor; set => contributor = value; }
        public IControlsMediator SubControlsMediator { get => subControlsMediator; set => subControlsMediator = value; }
    }
}
