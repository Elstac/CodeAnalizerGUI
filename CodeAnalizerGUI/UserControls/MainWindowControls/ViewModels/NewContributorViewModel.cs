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
        private ContributorModel contributor;
        private IControlFactory controlFactory;
        private IControlsMediator subControlMediator;
        private ISubControlSender<List<string>> fileList;
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
            
            contributor = new ContributorModel();
        }

        public ContributorModel Contributor { get => contributor; set => contributor = value; }
        internal IControlFactory ControlFactory { get => controlFactory; set => controlFactory = value; }
        public IControlsMediator SubControlMediator { get => subControlMediator; set => subControlMediator = value; }
        public ISubControlSender<List<string>> FileList { get=>fileList; set=> fileList = value; }

        public void Send()
        {
            contributor.PathsToFiles = FileList.GetData();
            if (contributor.PathsToFiles.Count == 0)
                throw new NoFileSelectedException("Contributor contains no file");

            mediator.SendData(contributor);
            mediator.CloseControl();
        }

        public void OpenBinder()
        {
            UserControl view = mediator.CreateControl(typeof(GitBinderControl), subControlMediator);
            subControlMediator.LoadMainControl(view,this);
        }

        public void Cancel()
        {
            mediator.BreakOperation();
            mediator.CloseControl();
        }

        public void ChoseImage()
        {
            string[] Formats = new string[] { ".jpg", ".png", ".bmp" };
            UserControl control = mediator.CreateControl(typeof(FileExplorerControl),subControlMediator,new object[] { Formats });

            subControlMediator.LoadMainControl(control,this);
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
