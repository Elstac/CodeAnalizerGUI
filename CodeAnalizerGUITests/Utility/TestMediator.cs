using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeAnalizerGUI.Interfaces;
using System.Windows.Controls;
using CodeAnalizerGUI.Abstractions;
using CodeAnalizerGUI.ViewModels;

namespace CodeAnalizerGUITests
{
    class TestMediator : IControlsMediator
    {
        public object recivedData=null;
        public void BreakOperation()
        {
        }



        public void CloseControl()
        {
        }

        public UserControl CreateControl(Type viewType, IControlsMediator mediator, object[] properties)
        {
            return null;
        }

        public UserControl CreateControl(Type viewType, IControlsMediator mediator)
        {
            return null;
        }

        public void LoadContent(System.Windows.Controls.UserControl control)
        {
        }

        public void LoadContent(System.Windows.Controls.UserControl control, ISubControlDataReciver owner)
        {
        }

        public void LoadContent(UserControl control, ViewModel child, ISubControlDataReciver owner)
        {
        }

        public void LoadContent(UserControl control, ViewModel child)
        {
        }

        public void LoadMainControl(UserControl control)
        {
        }

        public void LoadMainControl(UserControl control, ISubControlDataReciver owner)
        {
        }

        public void LoadSubControl(UserControl control)
        {
        }

        public void SendData(object dataClass)
        {
            recivedData = dataClass;
        }
    }
}
