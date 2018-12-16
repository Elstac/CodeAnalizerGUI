using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using CodeAnalizerGUI.Models;
using CodeAnalizer.FileAnalizerModule.Interfaces;
namespace CodeAnalizerGUI.Interfaces
{
    public interface IStatisticsGenerator
    {
        ObservableCollection<StatisticsModel> GenerateStatisticsDisplay();
        void SetMiner(IFileMiner fileMiner);
    }
}
