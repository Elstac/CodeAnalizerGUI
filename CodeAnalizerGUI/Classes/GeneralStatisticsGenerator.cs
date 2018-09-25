﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeAnalizerGUI.UserControls.MainWindowControls.Models;
using CodeAnalizer.FileAnalizerModule.Interfaces;
namespace CodeAnalizerGUI.Classes
{
    class GeneralStatisticsGenerator : Interfaces.IStatisticsGenerator
    {
        private IFileMiner fileMiner;

        public GeneralStatisticsGenerator(IFileMiner fileMiner)
        {
            this.fileMiner = fileMiner;
        }

        public ObservableCollection<StatisticsModel> GenerateStatisticsDisplay()
        {
            return new ObservableCollection<StatisticsModel>()
            {
                new StatisticsModel("Characters",fileMiner.GetCharactersCount()),
                new StatisticsModel("Lines",fileMiner.GetLinesCount()),
                new StatisticsModel("Usings",fileMiner.GetUsingsCount()),
                new StatisticsModel("Empty lines",fileMiner.GetEmptyLines()),
                new StatisticsModel("Methods",fileMiner.GetMethodsCount()),
                new StatisticsModel("Comments lines",fileMiner.GetCommentLines()),
                new StatisticsModel("Largest file",fileMiner.GetLargestFile()),
                new StatisticsModel("Smallest file",fileMiner.GetSmallestFile())
            };
        }
    }
}
