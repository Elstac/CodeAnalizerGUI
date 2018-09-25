using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeAnalizerGUI.UserControls.MainWindowControls.Models;
using CodeAnalizerGUI.Windows.Models;
namespace CodeAnalizerGUI.Interfaces
{
    public interface IButtonsGenerator
    {
        List<NavigationButtonModel> GenerateButtons();
    }
}
