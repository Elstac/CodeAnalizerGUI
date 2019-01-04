using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAnalizerGUI.DataSavingModule
{
    public interface ILoadBehavior<T>
    {
        T Load(string path);
    }
}
