using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeAnalizerGUI.Windows;
using System.Windows.Controls;
using CodeAnalizerGUI.UserControls.MainWindowControls;
namespace CodeAnalizerGUI.Windows
{
    class MainWindowModel
    {
        private List<UserControl> mainWindowsControls;

        public MainWindowModel()
        {
            
        }

        public List<UserControl> MainWindowsControls { get => mainWindowsControls;}
    }
}
