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
        public ViewModel parent;
        public UserControl child;

        public ChainLink(ViewModel parent, UserControl child)
        {
            this.parent = parent;
            this.child = child;
        }
        public ChainLink()
        {

        }
    }
}
