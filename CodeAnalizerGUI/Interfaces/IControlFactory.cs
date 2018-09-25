using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeAnalizerGUI.UserControls.MainWindowControls.ViewModels;
using System.Windows.Controls;

namespace CodeAnalizerGUI.Interfaces
{
    interface IControlFactory
    {
        UserControl Create(Type viewType,IControlsMediator mediator);
    }
}
