using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeAnalizerGUI.Interfaces;
using CodeAnalizerGUI.Exceptions;
using CodeAnalizerGUI.Classes;
using CodeAnalizerGUI.UserControls.MainWindowControls.Models;
using CodeAnalizerGUI.UserControls.MainWindowControls.Views;
using CodeAnalizerGUI.UserControls.MainWindowControls.Commands;
using System.Windows.Input;
using System.IO;
using System.Windows.Controls;
namespace CodeAnalizerGUI.UserControls.MainWindowControls.ViewModels
{
    public class NewContributorViewModel:ViewModel,ISubControlOwner
    {
        private IControlsMediator mediator;
        private IControlsMediator subControlsMediator;
        private ContributorModel contributor;
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
            subControlsMediator = new SubControlMediator();
            contributor = new ContributorModel();
        }

        public IControlsMediator Mediator { get => mediator; set => mediator = value; }
        public ContributorModel Contributor { get => contributor; set => contributor = value; }

        public void Send()
        {
            if (contributor.PathsToFiles.Count == 0)
                throw new NoFileSelectedException("Contributor contains no file");

            mediator.SendData(contributor);
        }

        public void OpenBinder()
        {
            GitBinderViewModel tmpVM = new GitBinderViewModel(null);
            tmpVM.Mediator = subControlsMediator;
            GitBinderControl view = new GitBinderControl();
            view.DataContext = tmpVM;

            mediator.LoadContent(view,this);
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
            mediator.LoadContent(control, null,this);
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
