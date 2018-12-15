using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeAnalizerGUI.Abstractions;
using System.Collections.ObjectModel;
using CodeAnalizerGUI.Models;

namespace CodeAnalizerGUI.ViewModels
{
    class GlobalStatisticsViewModel:ViewModel
    {
        private ObservableCollection<Models.StatisticsModel> statistics;
        
        public GlobalStatisticsViewModel(ObservableCollection<Models.StatisticsModel> data)
        {
            statistics = data;
           
        }

        public ObservableCollection<StatisticsModel> Statistics { get => statistics; set => statistics = value; }
    }
}
