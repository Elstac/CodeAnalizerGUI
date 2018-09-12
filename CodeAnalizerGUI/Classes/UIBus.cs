using System;
using System.Collections.Generic;
using System.Windows;
using System.IO;
using System.Windows.Controls;
using CodeAnalizerGUI.Classes.Converters;
using CodeAnalizerGUI.Interfaces;
using CodeAnalizer.GitTrackerModule.Classes;
using CodeAnalizer.FileAnalizerModule.Classes;
using CodeAnalizer;
using NUnit.Framework;
namespace CodeAnalizerGUI
{
    public class UIBus: IFileExplorerUser
    {
        private IControlsMediator mediator;
        public static UIBus mainBus;
        ProjectMiner projectMiner;
        RepoTracker gitAnalizer;
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
        internal IControlsMediator Mediator { get => mediator; set => mediator = value; }

        public UIBus(MainWindow win)
        {
            if (mainBus == null)
            {
                mainWindow = win;
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
            mediator.LoadContent(statisitcsViews[0]);
        }

        private void PrepareLogic()
        {
            if (Directory.Exists(pathToProject + "\\.git"))
                gitAnalizer = new RepoTracker(pathToProject);
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
            projectMiner = new ProjectMiner(fileManager.Analizers);
            ret.Add("Lines: " + projectMiner.GetLinesCount());
            ret.Add("Usings: " + projectMiner.GetUsingsCount());
            ret.Add("Characters: " + projectMiner.GetCharactersCount());
            ret.Add("Largets file: "+projectMiner.GetLargestFile());
            ret.Add("Smallest file: " + projectMiner.GetSmallestFile());
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
            control.Mediator = mediator;
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
            mediator.LoadContent(statisitcsViews[index]);
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
