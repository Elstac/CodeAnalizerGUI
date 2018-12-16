using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeAnalizerGUI.Abstractions;
using System.Windows.Input;
using System.IO;
using CodeAnalizerGUI.ProjectModule;
using CodeAnalizerGUI.Interfaces;
namespace CodeAnalizerGUI.Windows
{
    public class NDNewProjectViewModel:ViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }
        public INewProjectConfigurationCreator Creator { get; set; }

        public ICommand Cancel;
        public ICommand Confirm;

        public delegate void endOperation();
        public event endOperation EndOperation;

        public NDNewProjectViewModel()
        {
            Confirm = new SimpleCommand(ConfirmClick);
        }

        private void ConfirmClick()
        {
            if (Name == "")
                throw new InvalidOperationException("No name given");
            if (Path == "")
                throw new InvalidOperationException("No path selected");

            Creator.CreateConfiguration(Name, Description, Path);
            EndOperation();
        }

        private void CancelClick()
        {
            EndOperation();
        }
    }
}
