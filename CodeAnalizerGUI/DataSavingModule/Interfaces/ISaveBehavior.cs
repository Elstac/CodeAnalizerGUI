using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAnalizerGUI.DataSavingModule
{
    interface ISaveBehavior<T>
    {
        void Save(T dataObject);
    }
}
