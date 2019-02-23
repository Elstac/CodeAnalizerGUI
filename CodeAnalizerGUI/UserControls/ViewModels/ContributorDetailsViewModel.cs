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
        private Func<NewContributorViewModel> editWindow;
        private ViewModel statisticsViewModel;
        private ContributorModel contributor;
        private IStatisticsGenerator generator;
        private IVMMediator mediator;

        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public ContributorDetailsViewModel(IStatisticsGenerator generator,IVMMediator mediator,ContributorModel contributor,Func<NewContributorViewModel> editWindow)
        {
            this.contributor = contributor;
            this.generator = generator;
            this.mediator = mediator;
            this.editWindow = editWindow;

            var stats = generator.GenerateStatisticsDisplay();
            var tmp = new GlobalStatisticsViewModel(stats);
            
            statisticsViewModel = tmp;;
        }

        public ViewModel StatisticsViewModel { get => statisticsViewModel; set => statisticsViewModel = value; }
        public ContributorModel Contributor { get => contributor; set => contributor = value; }
        
    }
}
