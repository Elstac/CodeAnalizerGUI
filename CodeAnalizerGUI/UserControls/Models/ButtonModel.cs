using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CodeAnalizerGUI.Abstractions;

namespace CodeAnalizerGUI.Models
{
    public class ButtonModel:Model
    {
        private ICommand command;
        private string name;

       
        public ButtonModel(ICommand command, string name)
        {
            this.command = command;
            this.name = name;
        }

        public ICommand Command { get => command; set => command = value; }
        public string Name { get => name; set => name = value; }
    }
}
