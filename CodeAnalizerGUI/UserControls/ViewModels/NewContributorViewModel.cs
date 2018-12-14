using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeAnalizerGUI.Interfaces;
using CodeAnalizerGUI.Exceptions;
using CodeAnalizerGUI.Classes;
using CodeAnalizerGUI.Models;
using CodeAnalizerGUI.Views;
using CodeAnalizerGUI.Abstractions;
using System.Windows.Input;
using System.IO;
using System.Windows.Controls;
namespace CodeAnalizerGUI.ViewModels
{
    public class NewContributorViewModel:ViewModel
    {
        private readonly string[] imageFormats= {".png",".jpg",".bmp" };

        private ContributorModel contributor;
        private IManageableFileList fileList;
        #region Commands
        public ICommand SendCommand { get; set; }
        public ICommand CloseCommand{ get; set; }
        public ICommand ChoseImageCommand{ get; set; }
        public ICommand GitBinderCommand{ get; set; }
        
        #endregion

        public NewContributorViewModel(IManageableFileList fileList)
        {
            this.fileList = fileList;

            SendCommand = new SimpleCommand(Send);
            CloseCommand = new SimpleCommand(Cancel);
            ChoseImageCommand = new SimpleCommand(ChoseImage);
            GitBinderCommand = new SimpleCommand(OpenBinder);
            
            contributor = new ContributorModel();

            VMMediator.Instance.Register(MVVMMessage.FileChosed, ReciveFilePath);
        }

        public ContributorModel Contributor { get => contributor; set => contributor = value; }
        public IManageableFileList FileList { get=>fileList; set=> fileList = value; }

        public void Send()
        {
            contributor.PathsToFiles = fileList.getFilePaths();
            if (contributor.PathsToFiles.Count == 0)
                throw new NoFileSelectedException("Contributor contains no file");

            VMMediator.Instance.NotifyColleagues(MVVMMessage.NewContributorCreated, contributor);
            VMMediator.Instance.NotifyColleagues(MVVMMessage.CloseControl, this);
        }

        public void OpenBinder()
        {
            
        }

        public void Cancel()
        {
            mediator.BreakOperation();
            mediator.CloseControl();
        }

        public void ChoseImage()
        {
            var fac = DIContainer.Resolve<FileExplorerViewModel.Factory>();
            VMMediator.Instance.NotifyColleagues(MVVMMessage.OpenNewControl, fac.Invoke(imageFormats));
        }
        
        public void ReciveFilePath(object path)
        {
            var extention = Path.GetExtension(path.ToString());
            if (imageFormats.Contains(extention))
            {
                Contributor.PathToImage = path.ToString();
            }
        }
    }
}
