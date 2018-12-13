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
using System.ComponentModel;

using CodeAnalizerGUI.ViewModels;
using CodeAnalizerGUI.Abstractions;
namespace CodeAnalizerGUI
{
    /// <summary>
    /// Interaction logic for ManageableFileView.xaml
    /// </summary>
    public partial class ManageableFileView : UserControl
    {
       
        public ManageableFileView()
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
