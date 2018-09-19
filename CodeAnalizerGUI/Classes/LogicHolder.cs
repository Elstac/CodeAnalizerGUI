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
        private ContributorManager manager;
        private bool managerChanged;
        public static LogicHolder MainHolder{
            get
            {
                if (mainHolder == null)
                    throw new NullReferenceException("No logic has been loaded");
                return mainHolder;
            }
        }

        public ContributorManager Manager { get { managerChanged = true; return manager; } set { manager = value;managerChanged = true; }  }

        public LogicHolder()
        {
            mainHolder = this;
        }
        public void LoadGitTracker(string pathToRepo)
        {
            repoTracker = new RepoTracker(pathToRepo);            
        }
        public void LoadFileMiner(string[] paths)
        {
            projectMiner = new ProjectMiner(paths);          
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
