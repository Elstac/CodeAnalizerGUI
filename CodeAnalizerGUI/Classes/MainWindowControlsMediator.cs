using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using CodeAnalizer;
using CodeAnalizer.GitTrackerModule.Classes;
using CodeAnalizerGUI.Interfaces;
using CodeAnalizerGUI.Classes.MinorClasses;
namespace CodeAnalizerGUI.Classes
{
    class MainWindowControlsMediator : ControlsMediator
    {
        private MainWindow mainWindow;
        public MainWindowControlsMediator(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
        }

        public MainWindow MainWindow { get => mainWindow;}

        public override void LoadContent(UserControl control)
        {
            mainWindow.LoadContent(control);
        }

        public void SendContributorInfo(ContributorDisplay contributor)
        {
            SendData(contributor);
            UIBus.mainBus.ContributorManager.AddContributor(contributor.name, contributor.pathsToFiles);
        }
                
    }
}
