using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.ComponentModel;
using CodeAnalizerGUI.Abstractions;
namespace CodeAnalizerGUI.Models
{
    public class ContributorButtonModel:Model
    {
        private ContributorModel contributor = new ContributorModel();
        private ICommand buttonCommand;
        private ICommand editCommand;

        public ContributorButtonModel(ContributorModel contributor, ICommand buttonCommand, ICommand editCommand)
        {
            if(contributor!=null)
                this.contributor = contributor;
            this.buttonCommand = buttonCommand;
            this.editCommand = editCommand;
        }

        public ContributorModel Contributor { get => contributor; set { contributor = value; RaisePropertyChanged("Contributor"); } }
        public ICommand ButtonCommand { get => buttonCommand; set { buttonCommand = value; RaisePropertyChanged("ButtonCommand"); } }
        public ICommand EditCommand { get => editCommand; set { editCommand = value; RaisePropertyChanged("EditCommand"); } }
    }
}
