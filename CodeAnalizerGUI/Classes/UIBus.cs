using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CodeAnalizer;
using System.IO;
using System.Windows.Controls;
namespace CodeAnalizerGUI
{
    public class UIBus
    {
        ProjectAnalizer projectAnalizer;
        GitChangesTracker gitAnalizer;
        FileManager fileManager;
        ContributorManager contributorManager;
        List<UserControl> statisitcsViews;

        string pathToProject =null;
        private MainWindow mainWindow;
        private FileExplorerWindow fileExplorer;

        public UIBus(MainWindow win)
        {
            mainWindow = win;
            projectAnalizer = new ProjectAnalizer();
            contributorManager = new ContributorManager();
            statisitcsViews = new List<UserControl>();
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
            LoadGlobalStatsPanel();

            mainWindow.LoadContent(statisitcsViews[0]);
        }

        private List<string> GetGlobalStatistics()
        {
            List<string> ret = new List<string>();
            projectAnalizer.Analizers = fileManager.Analizers;
            ret.Add("Lines: " + projectAnalizer.TotalLines());
            ret.Add("Usings: " + projectAnalizer.TotalUsings());
            ret.Add("Charackters: " + projectAnalizer.TotalCharacters());
            ret.Add("Largets file: "+projectAnalizer.GetLargestFile());
            ret.Add("Smallest file: " + projectAnalizer.GetSmallestFile());
            ret.Add("Repository statistics:");
            ret.Add("Commits count: " + gitAnalizer.CommitsCount());
            ret.Add("Lines added: " + gitAnalizer.ChangedLinesCount().Item1);
            ret.Add("Lines deleted: " + gitAnalizer.ChangedLinesCount().Item2);

            return ret;
        }

        private void LoadGlobalStatsPanel()
        {
            GlobalStatsControl panel = new GlobalStatsControl(GetGlobalStatistics());

            statisitcsViews.Add(panel);
        }

        public void ReloadMainWindowContent(int index)
        {
            if (index >= statisitcsViews.Count || index < 0)
                if (pathToProject == null)
                {
                    ShowErrorMessage("No project have been loaded");
                    return;
                }
                else
                {
                    ShowErrorMessage("Invalid index");
                    return;
                }

            mainWindow.LoadContent(statisitcsViews[index]);
        }

        private void ShowErrorMessage(string text)
        {
            MessageBox.Show(text);
        }


    }
}
