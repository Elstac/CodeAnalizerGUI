using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.ObjectModel;
using CodeAnalizerGUI.Models;
using CodeAnalizerGUI.Abstractions;
namespace CodeAnalizerGUI.ViewModels
{
    class ButtonPanelViewModel:ViewModel
    {
        public ObservableCollection<ButtonModel> ButtonsList { get; set; }
    }
}
