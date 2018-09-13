using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeAnalizerGUI.Interfaces;
namespace CodeAnalizerGUI.Interfaces
{
    interface ISubControlOwner:ISubControlDataReciver
    {
        IControlsMediator GetMediator();
    }
}
