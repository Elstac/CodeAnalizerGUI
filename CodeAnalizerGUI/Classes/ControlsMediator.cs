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
using CodeAnalizerGUI.Exceptions;
using CodeAnalizerGUI.UserControls.MainWindowControls.ViewModels;

namespace CodeAnalizerGUI.Classes
{
    public abstract class ControlsMediator: IControlsMediator
    {
        private ISubControlDataReciver openedReciver = null;
        bool operationInProgres = false;

        List<ChainLink> controlsDependencies= new List<ChainLink>();
        private UserControl lastOpend;

        public void BreakOperation()
        {
            operationInProgres = false;
            openedReciver = null;
        }

        public void CloseControl(ViewModel toClose)
        {
            var result = from dependecy in controlsDependencies where dependecy.child == toClose select dependecy;

            if (result.Count() > 1)
                throw new DependencyMadnessException(toClose);
            ChainLink link = result.ElementAt(0);
            LoadContent(link.parent);
            link = null;


        }

        public abstract void LoadContent(UserControl control);
        

        public void LoadContent(UserControl control, ViewModel child, ISubControlDataReciver owner)
        {
            if (operationInProgres)
                throw new NotImplementedException();

            LoadContent(control,child);
            openedReciver = owner;
            operationInProgres = true;
        }

        public void LoadContent(UserControl control, ViewModel child)
        {
            ChainLink link = new ChainLink(control, child);
            controlsDependencies.Add(link);

            LoadContent(control);
        }
        public void LoadContent(UserControl control, UserControl child)
        {
            ChainLink link = new ChainLink(control, child);
            controlsDependencies.Add(link);
            LoadContent(control);
        }

        public virtual void SendData(object dataClass)
        {
            if (openedReciver == null || !operationInProgres)
                throw new NotImplementedException();

            openedReciver.ReciveData(dataClass);
            operationInProgres = false;
        }
    }
}
