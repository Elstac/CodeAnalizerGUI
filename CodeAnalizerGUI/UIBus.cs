using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CodeAnalizer;
using System.IO;
namespace CodeAnalizerGUI
{
    public class UIBus
    {
        ProjectAnalizer projectAnalizer;
        GitChangesTracker gitAnalizer;
        FileManager fileManager;
        ContributorManager contributorManager;

        string pathToProject;
        private MainWindow mainWindow;
        private FileExplorerWindow fileExplorer;

        public UIBus(MainWindow win)
        {
            mainWindow = win;
            projectAnalizer = new ProjectAnalizer();
            contributorManager = new ContributorManager();
        }

        public string PathToProject { set => pathToProject = value; get => pathToProject; }

        public void ExploreFiles()
        {
            fileExplorer = new FileExplorerWindow(this, mainWindow);
            fileExplorer.Show();
            fileExplorer.Focus();
        }
        
        public void OpenProject()
        {
            if(Directory.Exists(pathToProject+"\\.git"))
                gitAnalizer = new GitChangesTracker(pathToProject);
            string[] tab = new string[1];
            tab[0] = PathToProject;

            fileManager = new FileManager(tab, Language.Csharp);
        }

        public void FileExplorerResult(string pathToProject)
        {
            PathToProject = pathToProject;
            fileExplorer.Close();
            OpenProject();
            mainWindow.LoadNumberPanel(GetGlobalStatistics());
        }

        public List<string> GetGlobalStatistics()
        {
            List<string> ret = new List<string>();
            projectAnalizer.Analizers = fileManager.Analizers;
            ret.Add("Lines: " + projectAnalizer.TotalLines());
            ret.Add("Usings: " + projectAnalizer.TotalUsings());
            ret.Add("Charackters: " + projectAnalizer.TotalCharacters());
            ret.Add("Largets file: "+projectAnalizer.GetLargestFile());
            ret.Add("Smallest file: " + projectAnalizer.GetSmallestFile());

            return ret;
        }

        
    }
}
