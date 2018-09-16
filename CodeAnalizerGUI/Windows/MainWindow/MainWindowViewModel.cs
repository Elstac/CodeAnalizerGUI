using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeAnalizerGUI.Windows;
using System.Windows.Controls;
using CodeAnalizerGUI.UserControls.MainWindowControls;
namespace CodeAnalizerGUI.Windows
{
    class MainWindowViewModel
    {
        private List<UserControl> mainWindowsControls;
        private string[] buttonsNames = new string[] { "Global statistics", "Contributors" };
        private List<Button> mainToolBarButtons;
        public MainWindowViewModel()
        {
            
        }
        
        public string[] ButtonsNames { get => buttonsNames; set => buttonsNames = value; }

        private void CreateButtons()
        {

        }

        private void NavigatePanelButtonClick()
        {
            
        }
    }
}
