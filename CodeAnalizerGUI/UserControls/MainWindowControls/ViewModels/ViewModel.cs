using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
namespace CodeAnalizerGUI.UserControls.MainWindowControls.ViewModels
{
    public abstract class ViewModel
    {
        public UserControl View { get; set; }
    }
}
