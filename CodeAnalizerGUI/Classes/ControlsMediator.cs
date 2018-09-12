using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using CodeAnalizer;
using CodeAnalizer.GitTrackerModule.Classes;
using CodeAnalizerGUI.Interfaces;
using CodeAnalizerGUI.Classes.MinorClasses;
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

        public void SendContributorInfo(ContributorDisplay contributor)
        {
            SendData(contributor);
        }

        public void SendData(object dataClass)
        {
            if(openedReciver == null || !operationInProgres)
                throw new NotImplementedException();

            openedReciver.ReciveData(dataClass);
            operationInProgres = false;
        }
        
    }
}
