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
using System.ComponentModel;
using CodeAnalizerGUI.Classes.Converters;
using CodeAnalizerGUI.Interfaces;
using System.IO;
namespace CodeAnalizerGUI
{
    /// <summary>
    /// Interaction logic for NewContributorControl.xaml
    /// </summary>
    public partial class NewContributorControl : UserControl, IFileExplorerUser, IFamilyMember
    {
        private string contributorName = "name";
        private string lastName = "last name";
        private string pathToImage;
        private List<string> files = new List<string>() {};
        private IFamilyMember parent;
        public NewContributorControl(IFamilyMember par)
        {
            InitializeComponent();
            ContributorImage.Source = StringToImageConverter.Convert(Directory.GetCurrentDirectory() + "\\plus.png").Source;
            FilesList.DataContext = this;
            FilesList.ItemsSource = files;
            Control tmp;
            parent = par;
           

            foreach (var item in IdPanel.Children)
            {
                if (!(item is Control))
                    continue;
                tmp = item as Control;
                tmp.DataContext = this;
            }
        }

        public string ContributorName { get => contributorName; set => contributorName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public List<string> Files { get => files; set => files = value; }
        public string PathToImage { get => pathToImage; set => pathToImage = value; }

        public void GetFileExplorerResults(string retPath)
        {
            files.Add(retPath);
            ICollectionView view = CollectionViewSource.GetDefaultView(files);
            view.Refresh();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ChoseFileButtonClick(object sender, RoutedEventArgs e)
        {
            Window win=null;
            GetParent<Window>(ref win);
            FileExplorerWindow exp = new FileExplorerWindow(this,win);
            exp.Show();
        }

        private void ConfirmButtonClick(object sender, RoutedEventArgs e)
        {
            ContributorsControl parent = Parent as ContributorsControl;
            //AddContributor(Name,lastName,PathToImage);
        }

        private void CancelButtonClick(object sender, RoutedEventArgs e)
        {
            throw new InvalidOperationException();
        }

        public void GetParent<T>(ref T ret)where T:class
        {
            if (parent is T)
            {
                ret = parent as T;
                return;
            }
            parent.GetParent(ref ret);
        }

        public void GetChildren<T>(ref T ret) where T : class
        {
            throw new InvalidOperationException("Operation not suported");
        }
    }
}
