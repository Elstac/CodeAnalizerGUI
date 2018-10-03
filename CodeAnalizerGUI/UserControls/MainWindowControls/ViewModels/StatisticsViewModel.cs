using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeAnalizerGUI.UserControls.MainWindowControls.Models;
using System.Collections.ObjectModel;
namespace CodeAnalizerGUI.UserControls.MainWindowControls.ViewModels
{
    class StatisticsViewModel:ViewModel
    {
        ObservableCollection<Models.StatisticsModel> statistics;

        public StatisticsViewModel()
        {
            //statistics = new ObservableCollection<StatisticsModel>(); 
        }

        public ObservableCollection<Models.StatisticsModel> Statistics { get => statistics; set => statistics = value; }
    }
}
