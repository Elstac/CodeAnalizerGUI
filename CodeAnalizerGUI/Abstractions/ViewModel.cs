using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using CodeAnalizerGUI.Interfaces;
namespace CodeAnalizerGUI.Abstractions
{
    public abstract class ViewModel
    {
        public UserControl View { get; set; }
        protected IControlsMediator mediator;
        public IControlsMediator Mediator { get => mediator; set => mediator = value; }
    }
}
