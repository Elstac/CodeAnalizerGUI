using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using CodeAnalizer;
using CodeAnalizer.GitTrackerModule.Classes;
using CodeAnalizerGUI.Interfaces;
using CodeAnalizerGUI.Exceptions;
using CodeAnalizerGUI.UserControls.MainWindowControls.ViewModels;

namespace CodeAnalizerGUI.Classes
{
    public abstract class ControlsMediator: IControlsMediator
    {
        private ISubControlDataReciver openedReciver = null;
        private IControlFactory factory;
        bool operationInProgres = false;

        List<ChainLink> controlsDependencies= new List<ChainLink>();
        public ControlsMediator()
        {
            factory = ControlFactory.Factory;
        }
        public void BreakOperation()
        {
            operationInProgres = false;
            openedReciver = null;
        }

        public void CloseControl(ViewModel toClose)
        {
            var result = from dependecy in controlsDependencies where dependecy.child == toClose.View select dependecy;

            if (result.Count() > 1)
                throw new DependencyMadnessException(toClose);
            ChainLink link = result.ElementAt(0);
            LoadContent(link.parent.View);
            link = null;


        }

        public UserControl CreateControl(Type viewType, IControlsMediator mediator,object[] properties)
        {
            return factory.Create(viewType, mediator,properties);
        }

        public UserControl CreateControl(Type viewType, IControlsMediator mediator)
        {
            return factory.Create(viewType, mediator);
        }

        public abstract void LoadContent(UserControl control);
        

        public void LoadContent(UserControl control, ViewModel parent, ISubControlDataReciver owner)
        {
            if (operationInProgres)
                throw new NotImplementedException();

            LoadContent(control, parent);
            openedReciver = owner;
            operationInProgres = true;
        }

        public void LoadContent(UserControl control, ViewModel parent)
        {
            ChainLink link = new ChainLink(parent, control);
            controlsDependencies.Add(link);

            LoadContent(control);
        }

        public virtual void SendData(object dataClass)
        {
            if (openedReciver == null || !operationInProgres)
                throw new NotImplementedException();

            openedReciver.ReciveData(dataClass);
            operationInProgres = false;
            openedReciver = null;
        }

        
    }
}
