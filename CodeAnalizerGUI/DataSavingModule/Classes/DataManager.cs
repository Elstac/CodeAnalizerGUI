using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeAnalizerGUI.Models;
using CodeAnalizerGUI.Interfaces;
namespace CodeAnalizerGUI.DataSavingModule
{
    public class DataManager:IDataManager
    {
        private ISaveBehavior<ContributorModel[]> contributorSaver;
        private ILoadBehavior<ContributorModel[]> contributorLoader;

        public DataManager(ISaveBehavior<ContributorModel[]> contributorSaver, ILoadBehavior<ContributorModel[]> contributorLoader)
        {
            this.contributorSaver = contributorSaver;
            this.contributorLoader = contributorLoader;
        }

        public ContributorModel[] LoadContributors(string path)
        {
            return contributorLoader.Load(path);
        }

        public void SaveContributors(ContributorModel[] contributors, string path)
        {
            contributorSaver.Save(contributors, path);
        }
    }
}
