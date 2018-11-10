using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeAnalizer.FileAnalizerModule.Interfaces;
using CodeAnalizer.FileAnalizerModule.Classes;
using CodeAnalizer.GitTrackerModule.Classes;
using CodeAnalizer;
using CodeAnalizerGUI.Interfaces;

namespace CodeAnalizerGUI
{
    class LogicHolder : ILogicHolder
    {
        private ProjectMiner projectminer;
        public static ILogicHolder MainHolder;
        
        public LogicHolder()
        {
            MainHolder = this;
            projectminer = new ProjectMiner();
        }

        public LogicHolder(string[] paths)
        {
            MainHolder = this;
            projectminer = new ProjectMiner(paths);
        }

        public IFileMiner GetFileMiner(string[] paths, bool addToProject)
        {
            FileSetMiner ret = new FileSetMiner(paths);
            if (addToProject)
                projectminer.Children.Add(ret);

            return ret;
        }

        public IFileMiner GetGlobalFileMiner()
        {
            return projectminer;
        }
    }
}
