using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeAnalizerGUI.Models;
using System.Collections.ObjectModel;
using CodeAnalizerGUI.Abstractions;
using CodeAnalizerGUI.Interfaces;

namespace CodeAnalizerGUI.ViewModels
{
    class StatisticsViewModel:ViewModel
    {
        ObservableCollection<Models.StatisticsModel> statistics;

        public StatisticsViewModel()
        {

        }

        public ObservableCollection<Models.StatisticsModel> Statistics { get => statistics; set => statistics = value; }
    }
}
