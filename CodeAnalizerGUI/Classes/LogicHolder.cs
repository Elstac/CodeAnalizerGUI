using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeAnalizer.FileAnalizerModule.Interfaces;
using CodeAnalizer.FileAnalizerModule.Classes;
using CodeAnalizer.GitTrackerModule.Classes;
using CodeAnalizer;
namespace CodeAnalizerGUI
{
    class LogicHolder
    {
        private RepoTracker repoTracker;
        private ProjectMiner projectMiner;
        private static LogicHolder mainHolder;
        public static LogicHolder MainHolder{
            get
            {
                if (mainHolder == null)
                    throw new NullReferenceException("No logic has been loaded");
                return mainHolder;
            }
        }
        
        public LogicHolder()
        {
            mainHolder = this;
        }
        public void LoadFileMiner(string[] paths)
        {
            projectMiner = new ProjectMiner(paths);
        }
        public void LoadGitTracker(string pathToRepo)
        {
            repoTracker = new RepoTracker(pathToRepo);            
        }
        public IGitChangesTracker GetGitChangesTracker()
        {
            return repoTracker;
        }

        public IFileMiner GetFileMiner()
        {
            return projectMiner;
        }
    }
}
