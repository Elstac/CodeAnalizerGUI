using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeAnalizerGUI.Interfaces;
using CodeAnalizerGUI.UserControls.MainWindowControls.Models;
using CodeAnalizerGUI.UserControls.MainWindowControls.Commands;
using CodeAnalizerGUI.UserControls.MainWindowControls.Views;
using System.Windows.Input;
using System.Windows.Controls;
using System.Collections.ObjectModel;
namespace CodeAnalizerGUI.UserControls.MainWindowControls.ViewModels
{
    class ContributorsViewModel : ViewModel,ISubControlDataReciver
    {
        private ObservableCollection<ContributorButtonModel> contributors;
        public ObservableCollection<ContributorButtonModel> Contributors { get => contributors; set => contributors = value; }

        public ContributorsViewModel()
        {
            contributors = new ObservableCollection<ContributorButtonModel>();
            ContributorModel des = new ContributorModel(); 
            contributors.Add(new ContributorButtonModel(des , new SimpleCommand(NewContributor)));
        }

        private void OpenDetailsControl(object parameter)
        {
            UserControl StatsView = mediator.CreateControl(typeof(StatisticsControl), mediator);
            (StatsView.DataContext as StatisticsViewModel).Statistics = new ObservableCollection<StatisticsModel>() { new StatisticsModel("Siurak", 50) };

            UserControl detailControl = mediator.CreateControl(typeof(ContributorDetailsControl),mediator);
            (detailControl.DataContext as ContributorDetailsViewModel).StatisticsView = StatsView;
            (detailControl.DataContext as ContributorDetailsViewModel).Contributor = parameter as ContributorModel;

            mediator.LoadContent(detailControl);
        }

        private void NewContributor()
        {
            //NewContributorControl view = new NewContributorControl();
            //NewContributorViewModel viewModel = new NewContributorViewModel();
            //viewModel.Mediator = mediator;
            //view.DataContext = viewModel;
            UserControl view = mediator.CreateControl(typeof(NewContributorControl), mediator);
            Mediator.LoadContent(view, this, this);
        }
        public void ReciveData(object dataClass)
        {
            ContributorButtonModel button = contributors.Last();
            contributors.Remove(contributors.Last());
            ContributorModel toAdd = dataClass as ContributorModel;
            contributors.Add(new ContributorButtonModel(toAdd,new IndexCommand( OpenDetailsControl)));
            contributors.Add(button);
        }
    }
}
