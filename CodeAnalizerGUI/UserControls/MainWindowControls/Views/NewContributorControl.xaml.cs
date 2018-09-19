﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using CodeAnalizerGUI.UserControls.MainWindowControls.ViewModels;
namespace CodeAnalizerGUI
{
    /// <summary>
    /// Interaction logic for NewContributorControl.xaml
    /// </summary>
    public partial class NewContributorControl : UserControl
    {
       
        public NewContributorControl()
        {
            InitializeComponent();
        }
        
        

        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            if (e.Property.ToString() == "DataContext")
            {
                ViewModel vm = e.NewValue as ViewModel;
                vm.View = this;
            }
        }
    }
}
