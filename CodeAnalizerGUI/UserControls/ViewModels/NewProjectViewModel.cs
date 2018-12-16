using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeAnalizerGUI.Abstractions;
using CodeAnalizerGUI.Interfaces;
namespace CodeAnalizerGUI.ViewModels
{
    class NewProjectViewModel:ViewModel
    {
        private string name;
        private string description;
        private string directory;

        private INewProjectConfigurationCreator confCreator;

        public NewProjectViewModel()
        {
        }
    }
}
