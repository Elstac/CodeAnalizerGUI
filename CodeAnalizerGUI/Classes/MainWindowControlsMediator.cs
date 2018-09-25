using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using CodeAnalizer;
using CodeAnalizer.GitTrackerModule.Classes;
using CodeAnalizerGUI.Interfaces;
using CodeAnalizerGUI.Windows.ViewModels;
namespace CodeAnalizerGUI.Classes
{
    /// <summary>
    /// Manage comunication between MainWindow and all controls, can hold one layer of datalisnig operation
    /// </summary>
    public class MainWindowControlsMediator : ControlsMediator
    {
        private MainWindowViewModel mainWindow;
        public MainWindowControlsMediator(MainWindowViewModel mainWindow):base()
        {
            this.mainWindow = mainWindow;
        }

        public MainWindowViewModel MainWindow { get => mainWindow;}

        public override void LoadContent(UserControl control)
        {
            mainWindow.MainContent= control;
        }
        
                
    }
}
