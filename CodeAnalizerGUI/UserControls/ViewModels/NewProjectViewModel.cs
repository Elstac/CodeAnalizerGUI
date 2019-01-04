using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeAnalizerGUI.Abstractions;
using CodeAnalizerGUI.Interfaces;
using System.Windows.Input;
namespace CodeAnalizerGUI.ViewModels
{
    public class NewProjectViewModel:ViewModel
    {
        private string name;
        private string description;
        private string directory;

        private IProjectInitializer initializer;
        private IVMMediator mediator;
        private FileExplorerViewModel.Factory explorerFactory;

        public ICommand ConfirmCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        public ICommand ChoseFileCommand { get; set; }

        public NewProjectViewModel(IProjectInitializer initializer, IVMMediator mediator, FileExplorerViewModel.Factory explorerFactory)
        {
            this.explorerFactory = explorerFactory;
            this.mediator = mediator;
            this.initializer = initializer;

            ConfirmCommand = new SimpleCommand(CreateProject);
            CancelCommand = new SimpleCommand(Cancel);
            ChoseFileCommand = new SimpleCommand(OpenFileExplorer);

            mediator.Register(MVVMMessage.FileChosed, ReciveDirectory);
        }

        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public string Directory { get => directory; set => directory = value; }

        private void CreateProject()
        {
            mediator.NotifyColleagues(MVVMMessage.CloseControl, this);
           
            initializer.Initialize(name, description, directory);
        }

        private void Cancel()
        {
            mediator.NotifyColleagues(MVVMMessage.CloseControl, this);
        }

        private void OpenFileExplorer()
        {
            mediator.NotifyColleagues(MVVMMessage.OpenNewControl, explorerFactory.Invoke(new string[] { }));
        }

        private void ReciveDirectory(object dir)
        {
            directory = dir.ToString();
        }
    }
}
