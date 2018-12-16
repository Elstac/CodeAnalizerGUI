using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeAnalizerGUI.Abstractions;
namespace CodeAnalizerGUI
{
    public interface IVMStack
    {
        void NewVM(ViewModel viewModel);
        ViewModel PreviousVM();
        void RootVM(ViewModel viewModel);
    }
}
