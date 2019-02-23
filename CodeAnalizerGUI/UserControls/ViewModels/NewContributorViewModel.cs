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
        private FileExplorerViewModel.Factory explorerFactory;
        private IVMMediator mediator;

        private ContributorModel contributor;
        private IManageableFileList fileList;
        #region Commands
        public ICommand SendCommand { get; set; }
        public ICommand CloseCommand{ get; set; }
        public ICommand ChoseImageCommand{ get; set; }
        public ICommand GitBinderCommand{ get; set; }

        #endregion

        public delegate NewContributorViewModel Factory(IManageableFileList fileList);

        public NewContributorViewModel(IManageableFileList fileList, FileExplorerViewModel.Factory explorerFactory, IVMMediator mediator)
        {
            Initialize(fileList,explorerFactory,mediator);
        }

        public NewContributorViewModel(IManageableFileList fileList, FileExplorerViewModel.Factory explorerFactory,ContributorModel contributor, IVMMediator mediator)
        {
            this.contributor = contributor;
            Initialize(fileList, explorerFactory,mediator);
        }

        private void Initialize(IManageableFileList fileList, FileExplorerViewModel.Factory explorerFactory,IVMMediator mediator)
        {
            this.fileList = fileList;
            this.mediator = mediator;
            this.explorerFactory = explorerFactory;

            SendCommand = new SimpleCommand(Send);
            CloseCommand = new SimpleCommand(Cancel);
            ChoseImageCommand = new SimpleCommand(ChoseImage);
            GitBinderCommand = new SimpleCommand(OpenBinder);

            contributor = new ContributorModel();

            mediator.Register(MVVMMessage.FileChosed, ReciveFilePath);
        }

        public ContributorModel Contributor { get => contributor;
            set
            {
                contributor.Name = value.Name;
                contributor.Email = value.Email;
                contributor.PathToImage = value.PathToImage;

                fileList.SetFiles(value.PathsToFiles.ToArray());
            }
        }
        public IManageableFileList FileList { get=>fileList; set=> fileList = value; }

        public void Send()
        {
            contributor.PathsToFiles = fileList.getFilePaths();
            if (contributor.PathsToFiles.Count == 0)
                throw new NoFileSelectedException("Contributor contains no file");

            mediator.NotifyColleagues(MVVMMessage.ContributorModificationEnd, contributor);
            mediator.NotifyColleagues(MVVMMessage.CloseControl, this);
        }

        public void OpenBinder()
        {
            
        }

        public void Cancel()
        {
            mediator.NotifyColleagues(MVVMMessage.CloseControl,this);
        }

        public void ChoseImage()
        {
            mediator.NotifyColleagues(MVVMMessage.OpenNewControl, explorerFactory.Invoke(imageFormats));
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
