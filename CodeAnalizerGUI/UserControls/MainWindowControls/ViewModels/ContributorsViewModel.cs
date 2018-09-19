using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeAnalizerGUI.Interfaces;
using CodeAnalizerGUI.UserControls.MainWindowControls.Models;
using CodeAnalizerGUI.UserControls.MainWindowControls.Commands;
using System.Windows.Input;
namespace CodeAnalizerGUI.UserControls.MainWindowControls.ViewModels
{
    class ContributorsViewModel : ViewModel,ISubControlDataReciver
    {
        private List<ContributorButtonModel> contributors;
        public List<ContributorButtonModel> Contributors { get => contributors; set => contributors = value; }

        public ContributorsViewModel()
        {
            contributors = new List<ContributorButtonModel>();
            ContributorModel des = new ContributorModel(); 
            contributors.Add(new ContributorButtonModel(des , new SimpleCommand(NewContributor)));
        }

        private void OpenDetailsControl()
        {
            throw new NotImplementedException();
        }

        private void NewContributor()
        {
            throw new NotImplementedException();
        }
        public void ReciveData(object dataClass)
        {
            ContributorModel toAdd = dataClass as ContributorModel;
            contributors.Add(new ContributorButtonModel(toAdd,new SimpleCommand( OpenDetailsControl)));
        }
    }
}
