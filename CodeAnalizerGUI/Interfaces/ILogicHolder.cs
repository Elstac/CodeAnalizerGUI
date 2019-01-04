using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeAnalizer.FileAnalizerModule.Interfaces;
using CodeAnalizerGUI.Models;
namespace CodeAnalizerGUI.Interfaces
{
    public interface ILogicHolder
    {
        IFileMiner GetFileMiner(string[] paths,bool addToProject);
        IFileMiner GetGlobalFileMiner();
        List<ContributorModel> GetContributorList();
        void ResetHolder();
        void LoadContributors(string path);
        void SaveContributors(string path);
    }
}
