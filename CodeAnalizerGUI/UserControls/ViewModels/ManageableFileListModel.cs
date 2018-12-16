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
        public ManageableFileListModel(string[] allowedFormats)
        {
            this.allowedFormats = allowedFormats;
            files = new List<string>();
            AddCommand = new SimpleCommand(OpenExplorer);
            DeleteCommand = new SimpleCommand(DeleteFile);

            VMMediator.Instance.Register(MVVMMessage.FileChosed, ReciveFile);
        }

        public object SelectedItem { get; set; }
        public List<string> Files { get => files; set => files = value; }
        public ICommand AddCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        private void OpenExplorer()
        {
            string[] formats = new string[] { ".cs" };

            var fac = DIContainer.Resolve<FileExplorerViewModel.Factory>();
            var explorer = fac.Invoke(formats);

            VMMediator.Instance.NotifyColleagues(MVVMMessage.OpenNewControl, explorer);
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
    }
}
