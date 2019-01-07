using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CodeAnalizerGUI.Models;
using System.Collections.ObjectModel;
namespace CodeAnalizerGUI.Classes
{
    public enum ListType
    {
        start,
        pCreation,
        pOpend,
        navigation
    }

    public abstract class ButtonsListFactory : IButtonsListFactory
    {
        protected List<string> names;
        protected List<ICommand> commands;

        protected IVMMediator mediator;

        public ButtonsListFactory(IVMMediator mediator)
        {
            names = new List<string>();
            commands = new List<ICommand>();
            this.mediator = mediator;
        }

        public ObservableCollection<ButtonModel> GenerateButtons()
        {
            var ret = new ObservableCollection<ButtonModel>();
            for (int i = 0; i < names.Count; i++)
                ret.Add(new ButtonModel(commands[i], names[i]));

            return ret;
        }
    }
}
