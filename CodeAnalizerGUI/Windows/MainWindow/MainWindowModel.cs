using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeAnalizerGUI.Windows;
using System.Windows.Controls;
namespace CodeAnalizerGUI.Windows
{
    class MainWindowModel
    {
        private string[] buttonsNames = new string[] { "Global statistics", "Contributors" };

        public string[] ButtonsNames { get => buttonsNames;  }
        private MainWindow mainWindow;
        
        public void MainWindowLoadContent(UserControl control)
        {
            mainWindow.LoadContent(control);
        }

        //public void ReloadMainWindowContent(int index)
        //{
        //    if (index >= statisitcsViews.Count || index < 0)
        //        if (pathToProject == null)
        //        {
        //            ShowErrorMessage("No project have been loaded");
        //            return;
        //        }
        //        else
        //        {
        //            ShowErrorMessage("Invalid index");
        //            return;
        //        }
        //    mainWindow.LoadContent(statisitcsViews[index]);
        //}
    }
}
