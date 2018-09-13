using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using CodeAnalizer.GitTrackerModule.Classes;
using CodeAnalizerGUI.Classes.MinorClasses;
using CodeAnalizer;
namespace CodeAnalizerGUI.Interfaces
{
    interface IControlsMediator
    {
        void LoadContent(UserControl control);
        void LoadContent(UserControl control,ISubControlDataReciver owner);
        void SendData(object dataClass);

    }
}
