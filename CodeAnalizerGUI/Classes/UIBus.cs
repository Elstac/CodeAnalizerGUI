using System;
using System.Collections.Generic;
using System.Windows;
using CodeAnalizer;
using System.IO;
using System.Windows.Controls;
using CodeAnalizerGUI.Classes.Converters;
using CodeAnalizerGUI.Interfaces;
using NUnit.Framework;
namespace CodeAnalizerGUI
{
    public class UIBus: IFileExplorerUser
    {
        public static UIBus mainBus;
        ProjectAnalizer projectAnalizer;
        GitChangesTracker gitAnalizer;
        FileManager fileManager;
        ContributorManager contributorManager;
        List<UserControl> statisitcsViews;
        OptionsHolder options;

        private enum ViewsName
        {
            GlobalStats=0,
            ContributorWindow =1
        }
        string pathToProject =null;
        private MainWindow mainWindow;
        private FileExplorerWindow fileExplorer;
        public string PathToProject { set => pathToProject = value; get => pathToProject; }
        public ContributorManager ContributorManager { get => contributorManager;}

        public UIBus(MainWindow win)
        {
            if (mainBus == null)
            {
                mainWindow = win;
                projectAnalizer = new ProjectAnalizer();
                contributorManager = new ContributorManager();
                statisitcsViews = new List<UserControl>();
                options = new OptionsHolder();
                mainBus = this;
            }
        }

        #region ProjectInit
        public void ExploreFiles()
        {
            fileExplorer = new FileExplorerWindow(this, mainWindow);
            fileExplorer.Show();
            fileExplorer.Focus();
        }

        public void GetFileExplorerResults(string pathToProject)
        {
            PathToProject = pathToProject;
            OpenProject();
        }

        public void OpenProject()
        {
            PrepareLogic();
            LoadContent();
            mainWindow.LoadContent(statisitcsViews[0]);
        }

        private void PrepareLogic()
        {
            if (Directory.Exists(pathToProject + "\\.git"))
                gitAnalizer = new GitChangesTracker(pathToProject);
            string[] tab = new string[1];
            tab[0] = PathToProject;

            fileManager = new FileManager(tab, Language.Csharp);
        }
        #endregion

        #region Options
        public void OpenOptions()
        { 
            GlobalOptionsWindow win = new GlobalOptionsWindow(mainWindow);
            win.Show();
        }

        public void OptionsWindowResults(OptionsHolder newOptions)
        {
            options = newOptions;
        }
        #endregion

        #region LoadContent
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

        private void LoadContent()
        {
            LoadGlobalStatsPanel();
            LoadContributorsPanel();
        }
        private void LoadGlobalStatsPanel()
        {
            GlobalStatsControl panel = new GlobalStatsControl(GetGlobalStatistics());
            statisitcsViews.Add(panel);
        }

        private void LoadContributorsPanel()
        {
            ContributorsControl control = new ContributorsControl();
            control.TreeParent = mainWindow;
            statisitcsViews.Add(control);
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
        #endregion

        #region ContentResults
        public void AddContributor(string name,string[] files)
        {
            contributorManager.AddContributor(name, files);
            ReloadMainWindowContent((int)ViewsName.ContributorWindow);
        }
        #endregion

        private void ShowErrorMessage(string text)
        {
            MessageBox.Show(text);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
