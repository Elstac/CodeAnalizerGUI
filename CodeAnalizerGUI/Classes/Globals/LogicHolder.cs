using System;
using System.Collections.Generic;
using CodeAnalizer.FileAnalizerModule.Interfaces;
using CodeAnalizer.FileAnalizerModule.Classes;
using CodeAnalizerGUI.Models;
using CodeAnalizerGUI.Interfaces;
using System.IO;
using CodeAnalizerGUI.Classes;
using Autofac;

namespace CodeAnalizerGUI
{
    class LogicHolder : ILogicHolder
    {
        private ProjectMiner projectminer;
        private IVMMediator mediator;
        private IFileCollector fileCollector;

        private List<ContributorModel> contributors;
        private IDataManager dataManager;

        public IFileCollector FileCollector {
            get 
            {
                if (fileCollector == null)
                    fileCollector = DIContainer.Container.Resolve<IFileCollector>();

                return fileCollector;
            }
            set => fileCollector = value; }

        public LogicHolder(IVMMediator mediator,IDataManager dataManager)
        {
            this.dataManager = dataManager;
            this.mediator = mediator;
            
            projectminer = new ProjectMiner();
            contributors = new List<ContributorModel>();

            mediator.Register(MVVMMessage.NewContributorCreated, NewContributor);
          
        }

        public IFileMiner GetFileMiner(string[] paths, bool addToProject)
        {
            var ret = new FileSetMiner(paths);
            if (addToProject)
                projectminer.Children.Add(ret);

            return ret;
        }

        public IFileMiner GetGlobalFileMiner()
        {
            return projectminer;
        }

        private void NewContributor(object contributor)
        {
            if (contributor is ContributorModel)
            {
                var tmp = contributor as ContributorModel;
                tmp.PathToImage = FileCollector.MoveToResources(tmp.PathToImage);
                contributors.Add(tmp);
                GetFileMiner(tmp.PathsToFiles.ToArray(), true);
            }
            if (contributor is IEnumerable<ContributorModel>)
                contributors.AddRange(contributor as IEnumerable<ContributorModel>);
        }

        public List<ContributorModel> GetContributorList()
        {
            return contributors;
        }

        public void ResetHolder()
        {
            projectminer.Children.Clear();
            contributors.Clear();
        }

        public void LoadContributors(string path)
        {
            ResetHolder();

            try
            {
                var contribs = dataManager.LoadContributors(path);
                foreach (var c in contribs)
                    NewContributor(c);
            }
            catch(FileNotFoundException)
            {
                dataManager.SaveContributors(contributors.ToArray(), path);
            }

            foreach(var contrib in contributors)
                GetFileMiner(contrib.PathsToFiles.ToArray(), true);
        }

        public void SaveContributors(string path)
        {
            dataManager.SaveContributors(contributors.ToArray(), path);
        }
    }

}
