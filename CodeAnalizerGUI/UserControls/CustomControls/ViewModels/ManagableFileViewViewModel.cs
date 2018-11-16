using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeAnalizerGUI.Interfaces;
using CodeAnalizerGUI.Classes;
using CodeAnalizerGUI.UserControls.MainWindowControls.ViewModels;
using CodeAnalizerGUI.UserControls.MainWindowControls.Views;
using CodeAnalizerGUI.UserControls.MainWindowControls.Commands;
using CodeAnalizerGUI.UserControls.MainWindowControls;
using System.Windows.Input;
using System.Windows.Controls;
using CodeAnalizerGUI.Abstractions;
namespace CodeAnalizerGUI.UserControls.CustomControls.ViewModels
{
    class ManagableFileViewViewModel:SubViewModel,ISubControlDataReciver, ISubControlSender<List<string>>
    {
        private List<string> files;

        public ManagableFileViewViewModel()
        {
            files = new List<string>();
            AddCommand = new SimpleCommand(OpenExplorer);
            DeleteCommand = new SimpleCommand(DeleteFile);
        }

        public object SelectedItem { get; set; }
        public List<string> Files { get => files; set => files = value; }
        public ICommand AddCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        private void OpenExplorer()
        {
            string[] formats = new string[] { ".cs" };
            UserControl view = mediator.CreateControl(typeof(FileExplorerControl), mediator, new object[] { formats });
            mediator.LoadMainControl(view,this);
        }

        private void DeleteFile()
        {
            if (SelectedItem == null)
                throw new NullReferenceException("No file has been selected");

            files.Remove(SelectedItem.ToString());
        }

        public void ReciveData(object dataClass)
        {
            files.Add(dataClass as string);
        }

        public List<string> GetData()
        {
            return files;
        }
    }
}
