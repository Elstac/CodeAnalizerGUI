using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using CodeAnalizerGUI;
using CodeAnalizerGUI.Classes.MinorClasses;
using CodeAnalizerGUI.Interfaces;
namespace CodeAnalizerGUI.Classes
{
    class SubControlMediator : ControlsMediator
    {
        private ISubControlOwner parent;
        public ISubControlOwner Parent { get => parent; set => parent = value; }

        public override void LoadContent(UserControl control)
        {
            parent.GetMediator().LoadContent(control);
        }
        
    }
}
