using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeAnalizerGUI.Interfaces;
using System.Windows.Controls;
namespace CodeAnalizerGUITests
{
    class TestMediator : IControlsMediator
    {
        public object recivedData;
        public void BreakOperation()
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

        public void SendData(object dataClass)
        {
            recivedData = dataClass;
        }
    }
}
