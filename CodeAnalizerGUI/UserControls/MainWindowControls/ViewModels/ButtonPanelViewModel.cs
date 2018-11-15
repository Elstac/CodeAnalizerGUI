using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CodeAnalizerGUI.UserControls.MainWindowControls.Models;
namespace CodeAnalizerGUI.UserControls.MainWindowControls.ViewModels
{
    class ButtonPanelViewModel:ViewModel
    {
        private List<ButtonModel> buttonsList;

        public List<ButtonModel> ButtonsList { get => buttonsList; set => buttonsList = value; }
    }
}
