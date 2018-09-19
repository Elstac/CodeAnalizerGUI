using System;
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
using CodeAnalizerGUI.Interfaces;
using CodeAnalizer.GitTrackerModule.Classes;
using CodeAnalizerGUI.UserControls.MainWindowControls.ViewModels;

namespace CodeAnalizerGUI.UserControls.MainWindowControls.Views
{
    /// <summary>
    /// Interaction logic for GitBinderControl.xaml
    /// </summary>
    public partial class GitBinderControl : UserControl
    {
        public GitBinderControl()
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
