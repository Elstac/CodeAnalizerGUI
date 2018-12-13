using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeAnalizerGUI.Models;
namespace CodeAnalizerGUI.Interfaces
{
    interface IContributorHolder
    {
        ContributorModel GetContributor(int index);
        ContributorModel[] GetContributors();
        void AddContributor(ContributorModel contributor);
        void AddContributor(ContributorModel[] contributors);
        void RemoveContributor(int index);
        void RemoveContributor(ContributorModel toRemove);
    }
}
