using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
namespace CodeAnalizerGUI.UserControls.MainWindowControls.Models
{
    class ContributorButtonModel
    {
        private ContributorModel contributor;
        private ICommand buttonCommand;

        public ContributorButtonModel(ContributorModel contributor, ICommand buttonCommand)
        {
            this.contributor = contributor;
            this.buttonCommand = buttonCommand;
        }

        public ContributorModel Contributor { get => contributor; set => contributor = value; }
        public ICommand ButtonCommand { get => buttonCommand; set => buttonCommand = value; }
    }
}
