using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
namespace CodeAnalizerGUI.UserControls.MainWindowControls.Commands
{
    public class SimpleCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        Action ExecuteCommandTarget;
        Func<bool> CanExecuteTarget;

        public SimpleCommand(Action executeCommandTarget, Func<bool> canExecuteTarget)
        {
            ExecuteCommandTarget = executeCommandTarget;
            CanExecuteTarget = canExecuteTarget;
        }

        public SimpleCommand(Action executeCommandTarget)
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
            ExecuteCommandTarget();
        }
    }
}
