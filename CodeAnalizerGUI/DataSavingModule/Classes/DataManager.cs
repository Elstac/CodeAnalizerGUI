using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeAnalizerGUI.UserControls.MainWindowControls.Models;
namespace CodeAnalizerGUI.DataSavingModule
{
    class DataManager
    {
        private ISaveBehavior<ContributorModel[]> contributorSaver;
        private ILoadBehavior<ContributorModel[]> contributorLoader;

        public DataManager()
        {

        }

        public ISaveBehavior<ContributorModel[]> ContributorSaver { get => contributorSaver; set => contributorSaver = value; }
        public ILoadBehavior<ContributorModel[]> ContributorLoader { get => contributorLoader; set => contributorLoader = value; }
    }
}
