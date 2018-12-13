using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeAnalizerGUI.Abstractions;

namespace CodeAnalizerGUI
{
    class VMStack : IVMStack
    {
        private Stack<ViewModel> stack;
        public VMStack()
        {
            stack = new Stack<ViewModel>();
        }
        public void NewVM(ViewModel viewModel)
        {
            stack.Push(viewModel);
        }

        public ViewModel PreviousVM()
        {
            if (stack.Count ==0)
                return null;

            stack.Pop();
            return stack.Peek();
        }
    }
}
