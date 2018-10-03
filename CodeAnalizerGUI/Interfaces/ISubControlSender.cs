using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAnalizerGUI.Interfaces
{
    public interface ISubControlSender<T>
    {
        T GetData();
    }
}
