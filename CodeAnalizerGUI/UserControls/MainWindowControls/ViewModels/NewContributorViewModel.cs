using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeAnalizerGUI.Interfaces;
using CodeAnalizerGUI.Exceptions;
using CodeAnalizerGUI.UserControls.MainWindowControls.Models;
using CodeAnalizerGUI.UserControls.MainWindowControls.Views;
using CodeAnalizerGUI.UserControls.MainWindowControls.Commands;
using System.Windows.Input;
namespace CodeAnalizerGUI.UserControls.MainWindowControls.ViewModels
{
    public class NewContributorViewModel:ViewModel,ISubControlOwner
    {
        private IControlsMediator mediator;
        private IControlsMediator subControlsMediators;
        private ContributorModel contributor;
        #region Commands
        public ICommand SendCommand;
        public ICommand CloseCommand;
        public ICommand ChoseImageCommand;
        public ICommand GitBinderCommand;
        #endregion

        public NewContributorViewModel()
        {
            SendCommand = new SimpleCommand(Send);
            CloseCommand = new SimpleCommand(Cancel);
            ChoseImageCommand = new SimpleCommand(ChoseImage);
            GitBinderCommand = new SimpleCommand(OpenBinder);

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
            tmpVM.Mediator = subControlsMediators;
            GitBinderControl view = new GitBinderControl();
            view.DataContext = tmpVM;

            mediator.LoadContent(view);
        }

        public void Cancel()
        {
            mediator.CloseControl(this);
        }

        public void ChoseImage()
        {
            FileExplorerControl control = new FileExplorerControl();
            control.Formats = new string[] {".jpg",".png",".bmp" };
            mediator.LoadContent(control, this);
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
