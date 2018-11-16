using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using CodeAnalizer.GitTrackerModule.Classes;
using CodeAnalizerGUI.UserControls.MainWindowControls.ViewModels;
using CodeAnalizerGUI.UserControls.CustomControls;
using CodeAnalizer;
namespace CodeAnalizerGUI.Interfaces
{
    public interface IControlsMediator
    {
        void LoadSubControl(UserControl control);
        void LoadMainControl(UserControl control);
        void LoadMainControl(UserControl control,ISubControlDataReciver owner);
        void SendData(object dataClass);
        void BreakOperation();
        void CloseControl();
        UserControl CreateControl(Type viewType, IControlsMediator mediator,object[]properties);
        UserControl CreateControl(Type viewType, IControlsMediator mediator);
    }
}
