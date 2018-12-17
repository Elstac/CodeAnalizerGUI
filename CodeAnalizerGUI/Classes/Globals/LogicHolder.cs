using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeAnalizer.FileAnalizerModule.Interfaces;
using CodeAnalizer.FileAnalizerModule.Classes;
using CodeAnalizer.GitTrackerModule.Classes;
using CodeAnalizer;
using CodeAnalizerGUI.Models;
using CodeAnalizerGUI.Interfaces;
using System.Collections.ObjectModel;

namespace CodeAnalizerGUI
{
    class LogicHolder : ILogicHolder
    {
        private ProjectMiner projectminer;
        private IVMMediator mediator;
        public static ILogicHolder MainHolder;

        private List<ContributorModel> contributors;

        public LogicHolder(IVMMediator mediator)
        {
            this.mediator = mediator;
            MainHolder = this;
            projectminer = new ProjectMiner();
            contributors = new List<ContributorModel>();

            mediator.Register(MVVMMessage.NewContributorCreated, NewContributor);
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

        private void NewContributor(object contributor)
        {
            if (contributor is ContributorModel)
                contributors.Add(contributor as ContributorModel);
            if (contributor is IEnumerable<ContributorModel>)
                contributors.AddRange(contributor as IEnumerable<ContributorModel>);
        }

        public List<ContributorModel> GetContributorList()
        {
            return contributors;
        }

        public void ResetHolder()
        {
            throw new NotImplementedException();
        }
    }
}
