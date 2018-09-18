using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using CodeAnalizer.GitTrackerModule.Classes;
using CodeAnalizerGUI.Classes.MinorClasses;
using CodeAnalizerGUI.UserControls.MainWindowControls.ViewModels;
using CodeAnalizer;
using CodeAnalizerGUI.UserControls.MainWindowControls.ViewModels;
namespace CodeAnalizerGUI.Interfaces
{
    public interface IControlsMediator
    {
        void LoadContent(UserControl control);
        void LoadContent(UserControl control, ViewModel child, ISubControlDataReciver owner);
        void LoadContent(UserControl control,ViewModel child);
        void SendData(object dataClass);
        void BreakOperation();
        void CloseControl(ViewModel toClose);
    }
}
