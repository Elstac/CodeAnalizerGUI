using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.ComponentModel;
using CodeAnalizerGUI.Abstractions;
namespace CodeAnalizerGUI.UserControls.MainWindowControls.Models
{
    class ContributorButtonModel:Model
    {
        private ContributorModel contributor = new ContributorModel();
        private ICommand buttonCommand;

        public ContributorButtonModel(ContributorModel contributor, ICommand buttonCommand)
        {
            if(contributor!=null)
                this.contributor = contributor;
            this.buttonCommand = buttonCommand;
        }

        public ContributorModel Contributor { get => contributor; set { contributor = value; RaisePropertyChanged("Contributor"); } }
        public ICommand ButtonCommand { get => buttonCommand; set { buttonCommand = value; RaisePropertyChanged("ButtonCommand"); } }
    }
}
