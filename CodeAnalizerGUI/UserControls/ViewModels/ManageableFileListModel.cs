using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeAnalizerGUI.Interfaces;
using CodeAnalizerGUI.Classes;
using CodeAnalizerGUI.ViewModels;
using CodeAnalizerGUI.Views;
using CodeAnalizerGUI.Abstractions;

using System.Windows.Input;
using System.Windows.Controls;
using System.IO;

namespace CodeAnalizerGUI.ViewModels
{
    class ManageableFileListModel:ViewModel,IManageableFileList
    {
        private List<string> files;
        private string[] allowedFormats;
        private FileExplorerViewModel.Factory explorer;
        private IVMMediator mediator;
        public ManageableFileListModel(string[] allowedFormats, FileExplorerViewModel.Factory explorer,IVMMediator mediator)
        {
            this.mediator = mediator;
            this.explorer = explorer;
            this.allowedFormats = allowedFormats;
            files = new List<string>();
            AddCommand = new SimpleCommand(OpenExplorer);
            DeleteCommand = new SimpleCommand(DeleteFile);

            mediator.Register(MVVMMessage.FileChosed, ReciveFile);
        }

        public object SelectedItem { get; set; }
        public List<string> Files { get => files; set => files = value; }
        public ICommand AddCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        private void OpenExplorer()
        {
            string[] formats = new string[] { ".cs" };
            
            mediator.NotifyColleagues(MVVMMessage.OpenNewControl, explorer.Invoke(formats));
        }

        private void ReciveFile(object path)
        {
            if(allowedFormats==null|| allowedFormats.Contains(Path.GetExtension(path.ToString())))
                files.Add(path.ToString());
        }

        private void DeleteFile()
        {
            if (SelectedItem == null)
                throw new NullReferenceException("No file has been selected");

            files.Remove(SelectedItem.ToString());
        }

        public List<string> getFilePaths()
        {
            return files;
        }

        public void SetAllowedFormats(string[] v)
        {
            allowedFormats = v;
        }

        public void SetFiles(string[] files)
        {
            this.Files = files.ToList();
        }
    }
}
