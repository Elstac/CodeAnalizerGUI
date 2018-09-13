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
    abstract class AbstractControlsMediator: IControlsMediator
    {
        private ISubControlDataReciver openedReciver = null;
        bool operationInProgres = false;
        public abstract void LoadContent(UserControl control);

        public void LoadContent(UserControl control, ISubControlDataReciver reciver)
        {
            if (operationInProgres)
                throw new NotImplementedException();

            LoadContent(control);
            openedReciver = reciver;
            operationInProgres = true;
        }
        

        public void SendData(object dataClass)
        {
            if (openedReciver == null || !operationInProgres)
                throw new NotImplementedException();

            openedReciver.ReciveData(dataClass);
            operationInProgres = false;
        }
    }
}
