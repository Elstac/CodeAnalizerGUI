using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
namespace CodeAnalizerGUI.UserControls.MainWindowControls.Commands
{
    class IndexCommand : ICommand
    {

        public event EventHandler CanExecuteChanged;
        Action<object> ExecuteCommandTarget;
        Func<bool> CanExecuteTarget;

        public IndexCommand(Action<object> executeCommandTarget, Func<bool> canExecuteTarget)
        {
            ExecuteCommandTarget = executeCommandTarget;
            CanExecuteTarget = canExecuteTarget;
        }

        public IndexCommand(Action<object> executeCommandTarget)
        {
            ExecuteCommandTarget = executeCommandTarget;
        }

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
            ExecuteCommandTarget(parameter);
        }
    }
}
