using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using CodeAnalizerGUI.Models;
using CodeAnalizerGUI.ViewModels;
using CodeAnalizerGUI.Abstractions;
using CodeAnalizerGUI.Classes;
using CodeAnalizerGUI.Views;
using CodeAnalizerGUI.Windows.Models;
using System.Windows.Input;
using System.Collections.ObjectModel;
using Autofac;
using CodeAnalizerGUI.Interfaces;

namespace CodeAnalizerGUI.Classes
{
    class NavigationButtonsGenerator : ButtonsListFactory
    {
        private ILogicHolder holder;

        public NavigationButtonsGenerator(IVMMediator mediator,ILogicHolder holder) : base(mediator)
        {
            this.holder = holder;

            commands = new List<ICommand>()
            {
                new SimpleCommand(OpenGlobalStatistics),
                new SimpleCommand(OpenContributorsControl)
            };

            names = new List<string>()
            {
                "Global Statistics",
                "Contributors"
            };
        }

        private void OpenContributorsControl()
        {
            mediator.NotifyColleagues(MVVMMessage.OpenNewRootControl,DIContainer.Container.Resolve<ContributorsViewModel>(
                new NamedParameter("path",Properties.Settings.Default.ProjectPath + "Contributors.xml")));
        }

        private void OpenGlobalStatistics()
        {
            var gen = DIContainer.Container.Resolve<IStatisticsGenerator>(new NamedParameter("miner",holder.GetGlobalFileMiner()));
            var vm = DIContainer.Container.Resolve<GlobalStatisticsViewModel>(new NamedParameter("data", gen.GenerateStatisticsDisplay()));
            mediator.NotifyColleagues(MVVMMessage.OpenNewRootControl, vm);
        }
    }
}
