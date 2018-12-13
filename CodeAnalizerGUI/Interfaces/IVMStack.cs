using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAnalizerGUI
{
    public interface IVMStack
    {
        void NewVM(Abstractions.ViewModel viewModel);
        Abstractions.ViewModel PreviousVM();
    }
}
