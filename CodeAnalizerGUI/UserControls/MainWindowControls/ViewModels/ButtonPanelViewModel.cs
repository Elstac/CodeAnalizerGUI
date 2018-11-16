using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.ObjectModel;
using CodeAnalizerGUI.UserControls.MainWindowControls.Models;
namespace CodeAnalizerGUI.UserControls.MainWindowControls.ViewModels
{
    class ButtonPanelViewModel:ViewModel
    {
        public ObservableCollection<ButtonModel> ButtonsList { get; set; }
    }
}
