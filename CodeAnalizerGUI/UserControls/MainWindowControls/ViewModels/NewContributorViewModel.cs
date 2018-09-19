using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeAnalizerGUI.Interfaces;
using CodeAnalizerGUI.Exceptions;
using CodeAnalizerGUI.Classes;
using CodeAnalizerGUI.UserControls.MainWindowControls.Models;
using CodeAnalizerGUI.UserControls.CustomControls.ViewModels;
using CodeAnalizerGUI.UserControls.MainWindowControls.Views;
using CodeAnalizerGUI.UserControls.MainWindowControls.Commands;
using System.Windows.Input;
using System.IO;
using System.Windows.Controls;
namespace CodeAnalizerGUI.UserControls.MainWindowControls.ViewModels
{
    public class NewContributorViewModel:ViewModel,ISubControlOwner
    {
        private IControlsMediator subControlsMediator;
        private ContributorModel contributor;

        public UserControl FileList { get; set; }
        #region Commands
        public ICommand SendCommand { get; set; }
        public ICommand CloseCommand{ get; set; }
        public ICommand ChoseImageCommand{ get; set; }
        public ICommand GitBinderCommand{ get; set; }
        
        #endregion

        public NewContributorViewModel()
        {
            SendCommand = new SimpleCommand(Send);
            CloseCommand = new SimpleCommand(Cancel);
            ChoseImageCommand = new SimpleCommand(ChoseImage);
            GitBinderCommand = new SimpleCommand(OpenBinder);

            SubControlMediator med = new SubControlMediator();
            med.Parent = this;
            subControlsMediator = med;

            contributor = new ContributorModel();

            ManagableFileViewViewModel vm = new ManagableFileViewViewModel();
            vm.Mediator = subControlsMediator;
            ManageableFileView view = new ManageableFileView();
            view.DataContext = vm;
            FileList = view;
        }
        
        public ContributorModel Contributor { get => contributor; set => contributor = value; }

        public void Send()
        {
            contributor.PathsToFiles = (FileList.DataContext as ManagableFileViewViewModel).Files;
            if (contributor.PathsToFiles.Count == 0)
                throw new NoFileSelectedException("Contributor contains no file");

            mediator.SendData(contributor);
            mediator.CloseControl(this);
        }

        public void OpenBinder()
        {
            GitBinderViewModel tmpVM = new GitBinderViewModel(null);
            tmpVM.Mediator = subControlsMediator;
            GitBinderControl view = new GitBinderControl();
            view.DataContext = tmpVM;

            subControlsMediator.LoadContent(view,this);
        }

        public void Cancel()
        {
            mediator.CloseControl(this);
        }

        public void ChoseImage()
        {
            FileExplorerControl control = new FileExplorerControl();
            control.Formats = new string[] { ".jpg", ".png", ".bmp" };
            control.Mediator = subControlsMediator;
            control.TreeParent = View;
            subControlsMediator.LoadContent(control, this,this);
        }

        public IControlsMediator GetMediator()
        {
            return Mediator;
        }

        public void ReciveData(object dataClass)
        {
            if (dataClass is string)
                contributor.PathToImage = dataClass as string;
            else if(dataClass is GitAuthorModel)
            {
                GitAuthorModel tmp = dataClass as GitAuthorModel;
                contributor.Email = tmp.Email;
                contributor.Name = tmp.Name;
            }
            else
            {
                throw new InvalidOperationException("Recived data cannot be processed");
            }
        }
    }
}
