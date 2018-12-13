using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeAnalizerGUI.ViewModels;
using System.Windows.Controls;

namespace CodeAnalizerGUI.Interfaces
{
    public interface IControlFactory
    {
        UserControl Create(Type viewType,IControlsMediator mediator,object[] properties);
        UserControl Create(Type viewType,IControlsMediator mediator);
    }
}
