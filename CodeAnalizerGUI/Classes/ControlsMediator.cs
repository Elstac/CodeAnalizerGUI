using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using CodeAnalizer;
using CodeAnalizer.GitTrackerModule.Classes;
using CodeAnalizerGUI.Interfaces;
namespace CodeAnalizerGUI.Classes
{
    class ControlsMediator : IControlsMediator
    {
        MainWindow mainWindow;
        ISubControlDataReciver openedReciver = null;
        bool operationInProgres = false;
        public ControlsMediator(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
        }

        public void LoadContent(UserControl control)
        {
            mainWindow.LoadContent(control);
        }

        public void LoadContent(UserControl control, ISubControlDataReciver reciver)
        {
            if (operationInProgres)
                throw new NotImplementedException();
            
            mainWindow.LoadContent(control);
            openedReciver = reciver;
            operationInProgres = true;
        }

        public void SendContributorInfo(Contributor contributor)
        {
            if (openedReciver == null||!operationInProgres)
                throw new NotImplementedException();

            openedReciver.ReciveData(contributor);
            operationInProgres = false;
        }

        public void SendGitAuthorInfo(AuthorInfo info)
        {
            if (openedReciver == null || !operationInProgres)
                throw new NotImplementedException();

            openedReciver.ReciveData(info);
            operationInProgres = false;
        }
    }
}
