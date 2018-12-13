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
namespace CodeAnalizerGUI.ViewModels
{
    class ContributorDetailsViewModel:ViewModel
    {
        private UserControl statisticsView;
        private ContributorModel contributor;
        private IControlsMediator subControlsMediator;

        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ContributorDetailsViewModel()
        {

        }

        public UserControl StatisticsView { get => statisticsView; set => statisticsView = value; }
        public ContributorModel Contributor { get => contributor; set => contributor = value; }
        public IControlsMediator SubControlsMediator { get => subControlsMediator; set => subControlsMediator = value; }
    }
}
