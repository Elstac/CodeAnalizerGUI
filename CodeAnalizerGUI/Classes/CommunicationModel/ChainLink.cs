using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeAnalizerGUI.ViewModels;
using System.Windows.Controls;
namespace CodeAnalizerGUI.Classes
{
    public class ChainLink
    {
        public ChainLink prev=null;
        public UserControl view;
        
        public ChainLink()
        {

        }

        public ChainLink( UserControl view)
        {
            this.view = view;
        }
    }
}
