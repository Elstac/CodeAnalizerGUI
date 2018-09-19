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
using CodeAnalizerGUI.Classes.Converters;
using CodeAnalizerGUI.Classes.MinorClasses;
using CodeAnalizerGUI.Interfaces;
using System.IO;
using CodeAnalizerGUI.UserControls.MainWindowControls;
using CodeAnalizerGUI.UserControls.MainWindowControls.ViewModels;
namespace CodeAnalizerGUI
{
    /// <summary>
    /// Interaction logic for ContributorsControl.xaml
    /// </summary>
    public partial class ContributorsControl : UserControl
    {
        public ContributorsControl()
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
