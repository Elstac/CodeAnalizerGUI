﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CodeAnalizer;
using CodeAnalizerGUI.Interfaces;
using CodeAnalizerGUI.Classes;
using CodeAnalizerGUI.UserControls.MainWindowControls.Views;
using CodeAnalizerGUI.UserControls.CustomControls;
using CodeAnalizerGUI.UserControls.MainWindowControls.ViewModels;
using CodeAnalizerGUI.UserControls.MainWindowControls;
using CodeAnalizerGUI.UserControls.CustomControls.ViewModels;
namespace CodeAnalizerGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //IControlsMediator mediator;
        //UIBus mainBus;
        
        //string[] buttonsNames = new string[] { "Global statistics","Contributors" };

        //internal IControlsMediator Mediator { get => mediator; set => mediator = value; }

        public MainWindow()
        {
            InitializeComponent();

            //InitializeFactory();
            //mediator = new MainWindowControlsMediator(this);
            //mainBus = new UIBus(this);
            //mainBus.Mediator = mediator;
            //LoadButtons();
        }

        //private static void InitializeFactory()
        //{
        //    ControlFactory fac = new ControlFactory();
        //    fac.RegisterViewType(typeof(ContributorsControl), typeof(ContributorsViewModel));
        //    fac.RegisterViewType(typeof(GitBinderControl), typeof(GitBinderViewModel));
        //    fac.RegisterViewType(typeof(NewContributorControl), typeof(NewContributorViewModel));
        //    fac.RegisterViewType(typeof(ManageableFileView), typeof(ManagableFileViewViewModel));
        //    fac.RegisterViewType(typeof(StatisticsControl), typeof(StatisticsViewModel));
        //    fac.RegisterViewType(typeof(ContributorDetailsControl), typeof(ContributorDetailsViewModel));
        //}

        //private void LoadButtons()
        //{
        //    Button tmp;

        //    for (int i = 0; i < buttonsNames.Length; i++)
        //    {
        //        tmp = new Button();
        //        tmp.Content = buttonsNames[i];

        //        tmp.Tag = i;
        //        tmp.Click += new RoutedEventHandler(NavigatePanelButtonClick);
        //        tmp.Margin = new Thickness(0, 5, 0, 5);
        //        NavigationBar.Items.Add(tmp);
        //    }
        //}
        //public void LoadContent(UserControl contentView)
        //{
        //    MainControl.Content = contentView;
        //}
        
        //private void Exit_Button_Click(object sender, RoutedEventArgs e)
        //{
        //    CloseWindow();
        //}

        //private void Open_Button_Click(object sender, RoutedEventArgs e)
        //{
        //    throw new NotImplementedException();
        //}

        //private void NavigatePanelButtonClick(object sender, RoutedEventArgs e)
        //{
        //    Button butt = sender as Button;
        //    mainBus.ReloadMainWindowContent(int.Parse(butt.Tag.ToString()));
        //    mediator.BreakOperation();
        //}

        //private void OptionsButtonClick(object sender, RoutedEventArgs e)
        //{
        //    throw new NotImplementedException();
        //}

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
            
        //}

        //private void CloseWindow()
        //{
        //    Close();
        //}

        //private void OpenSubWindow(Window win)
        //{
        //    win.Owner = this;
        //    win.Show();
        //    Hide();
        //    win.Focus();
        //}

        //private void TESTButtonClick(object sender, RoutedEventArgs e)
        //{
            
        //}

        //public void GetParent<T>(ref T ret) where T : class
        //{
        //    ret = null;
        //}

        //public void GetChildren<T>(ref T ret) where T : class
        //{
        //    throw new InvalidOperationException("Operation not suported");
        //}

        //public object GetContent()
        //{
        //    if (MainControl.Content == null)
        //        throw new NotImplementedException();

        //    return MainControl.Content;
        //}
    }
}
