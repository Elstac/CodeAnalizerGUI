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

namespace CodeAnalizerGUI.UserControls.MainWindowControls
{
    /// <summary>
    /// Interaction logic for GitBinderControl.xaml
    /// </summary>
    public partial class GitBinderControl : UserControl, IFamilyMember
    {
        IFamilyMember treeParent;
        public GitBinderControl()
        {
            InitializeComponent();
        }

        public IFamilyMember TreeParent { get => treeParent; set => treeParent = value; }

        public void GetParent<T>(ref T ret) where T : class
        {
            if (treeParent is T)
            {
                ret = treeParent as T;
                return;
            }
            treeParent.GetParent(ref ret);
        }

        public void LoadButtons(string[] authorsList)
        {
            
        }

        private void CreateButton(string text)
        {
            Button btn = new Button();
            
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            NewContributorControl ncc=null;
            GetParent(ref ncc);

            ncc
        }
    }
}
