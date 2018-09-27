using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeAnalizerGUI.Interfaces;
using System.Windows.Controls;
using CodeAnalizerGUI.UserControls.MainWindowControls.ViewModels;

namespace CodeAnalizerGUITests
{
    class TestMediator : IControlsMediator
    {
        public object recivedData=null;
        public void BreakOperation()
        {
            throw new NotImplementedException();
        }

        public void CloseControl(ViewModel toClose)
        {
            
        }

        public UserControl CreateControl(Type viewType, IControlsMediator mediator, object[] properties)
        {
            throw new NotImplementedException();
        }

        public UserControl CreateControl(Type viewType, IControlsMediator mediator)
        {
            throw new NotImplementedException();
        }

        public void LoadContent(System.Windows.Controls.UserControl control)
        {
            throw new NotImplementedException();
        }

        public void LoadContent(System.Windows.Controls.UserControl control, ISubControlDataReciver owner)
        {
            throw new NotImplementedException();
        }

        public void LoadContent(UserControl control, ViewModel child, ISubControlDataReciver owner)
        {
            throw new NotImplementedException();
        }

        public void LoadContent(UserControl control, ViewModel child)
        {
            throw new NotImplementedException();
        }

        public void SendData(object dataClass)
        {
            recivedData = dataClass;
        }
    }
}
