using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeAnalizerGUI.UserControls.MainWindowControls.ViewModels;
using System.Windows.Controls;
namespace CodeAnalizerGUI.Classes
{
    class ChainLink
    {
        public UserControl parent;
        public object child;

        public ChainLink(UserControl parent, ViewModel child)
        {
            this.parent = parent;
            this.child = child;
        }public ChainLink(UserControl parent, UserControl child)
        {
            this.parent = parent;
            this.child = child;
        }

        public ChainLink()
        {

        }
    }
}
