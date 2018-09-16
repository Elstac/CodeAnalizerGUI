using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
namespace CodeAnalizerGUI.MinorClasses
{
    class TagCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        Action ExecuteCommandTarget;
        Func<bool> CanExecuteTarget;

        public bool CanExecute(object parameter)
        {
            if (CanExecuteTarget != null)
                return CanExecuteTarget();

            if (ExecuteCommandTarget != null)
                return true;

            return false;
        }

        public void Execute(object parameter)
        {
            ExecuteCommandTarget();
        }
    }
}
