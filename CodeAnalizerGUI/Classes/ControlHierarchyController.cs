using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
namespace CodeAnalizerGUI.Classes
{
    public class ControlHierarchyController
    {
        
        private List<ContentControl> controlsStack;
        public ContentControl Top;

        public ControlHierarchyController()
        {
            controlsStack = new List<ContentControl>();
            Top = null;
        }

        public void AddToStack(ContentControl control)
        {
            controlsStack.Add(control);
            Top = control;
        }

        public void StepUp()
        {
            controlsStack.Remove(controlsStack.Last());
            Top = controlsStack.Last();
        }
    }
}
