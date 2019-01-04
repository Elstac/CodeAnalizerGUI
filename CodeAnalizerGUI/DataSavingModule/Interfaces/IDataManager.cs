using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeAnalizerGUI.Models;
namespace CodeAnalizerGUI.Interfaces
{
    public interface IDataManager
    {
        void SaveContributors(ContributorModel[] contributors,string path);
        ContributorModel[] LoadContributors(string path);
    }
}
