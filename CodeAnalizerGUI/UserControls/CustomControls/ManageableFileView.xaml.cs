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
namespace CodeAnalizerGUI
{
    /// <summary>
    /// Interaction logic for ManageableFileView.xaml
    /// </summary>
    public partial class ManageableFileView : UserControl , IFileExplorerUser,IFamilyMember
    {
        private List<string> files;
        
        IFamilyMember treeParent;
        public ManageableFileView()
        {
            files = new List<string>();
            InitializeComponent();
            FilesList.DataContext = this;
            FilesList.ItemsSource = files;
        }

        public void Resize()
        {
            Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
            Arrange(new Rect(0, 0, DesiredSize.Width, DesiredSize.Height));
            Button tmp;
            foreach (var button in MainGrid.Children)
            {
                if (button is Button)
                {
                    tmp = button as Button;
                    tmp.Width = ActualWidth / 2;
                }
            }
        }

        public IFamilyMember TreeParent { get => treeParent; set => treeParent = value; }
        public List<string> Files { get => files;}

        public void GetChildren<T>(ref T ret) where T : class
        {
            throw new NotImplementedException();
        }

        public void GetFileExplorerResults(string retPath)
        {
            files.Add(retPath);
            RefreshFileList();
        }

        private void RefreshFileList()
        {
            ICollectionView view = CollectionViewSource.GetDefaultView(files);
            view.Refresh();
        }

        public void GetParent<T>(ref T ret) where T : class
        {
            if (treeParent is T)
            {
                ret = treeParent as T;
                return;
            }
            treeParent.GetParent(ref ret);
        }

        private void AddButtonClick(object sender, RoutedEventArgs e)
        {
            Window tmp = null;
            GetParent(ref tmp);
            FileExplorerWindow win = new FileExplorerWindow(this,tmp);
            win.Show();
            win.Focus();
        }

        private void DeleteButtonClick(object sender, RoutedEventArgs e)
        {
            if (FilesList.SelectedItem == null)
                throw new NullReferenceException("No file has been selected");

            files.Remove( FilesList.SelectedItem.ToString());
            RefreshFileList();
        }
    }
}
