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
using CodeAnalizerGUI.UserControls.CustomControls.ViewModels;

namespace CodeAnalizerGUI.Classes
{
    public abstract class ControlsMediator: IControlsMediator
    {
        private ISubControlDataReciver openedReciver = null;
        private IControlFactory factory;
        bool operationInProgres = false;
        ControlsChain chain;
        public ControlsMediator()
        {
            factory = ControlFactory.Factory;  
            chain = new ControlsChain();
        }

        public void BreakOperation()
        {
            operationInProgres = false;
            openedReciver = null;
        }

        public virtual void CloseControl()
        {
           ChainLink tmp = chain.GetNextLink();

           LoadContent(tmp.view);
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

        public void LoadMainControl(UserControl control, ISubControlDataReciver owner)
        {
            if (operationInProgres)
                throw new NotImplementedException();

            LoadMainControl(control);
            openedReciver = owner;
            operationInProgres = true;
        }
        
        public void LoadSubControl(UserControl control)
        {
            LoadContent(control);
        }

        public void LoadMainControl(UserControl control)
        {
            chain.AddNewLink(new ChainLink(control));
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
