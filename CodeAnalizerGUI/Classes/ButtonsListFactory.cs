using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CodeAnalizerGUI.UserControls.MainWindowControls.Models;
using System.Collections.ObjectModel;
namespace CodeAnalizerGUI.Classes
{
    public enum ListType
    {
        start,
        pCreation
    }
    public abstract class ButtonsListFactory : IButtonsListFactory
    {
        protected string[] names;
        protected ICommand[] commands;

        public ObservableCollection<ButtonModel> GenerateButtons()
        {
            var ret = new ObservableCollection<ButtonModel>();
            for (int i = 0; i < names.Length; i++)
                ret.Add(new ButtonModel(commands[i], names[i]));

            return ret;
        }
    }
}
