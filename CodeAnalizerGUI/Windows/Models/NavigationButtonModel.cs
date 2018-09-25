using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
namespace CodeAnalizerGUI.Windows.Models
{
    public class NavigationButtonModel
    {
        private string text;
        private ICommand command;

        public NavigationButtonModel()
        {

        }

        public NavigationButtonModel(string text, ICommand command)
        {
            this.text = text;
            this.command = command;
        } 

        public string Text { get => text; set => text = value; }
        public ICommand Command { get => command; set => command = value; }
    }
}
